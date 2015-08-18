using Aritter.Domain;
using Aritter.Domain.Aggregates;
using Aritter.Domain.UnitOfWork;
using Aritter.Infra.CrossCutting.Configuration;
using Aritter.Infra.Data.Conventions;
using Aritter.Infra.Data.Mapping;
using Aritter.Infra.CrossCutting.Extensions;
using Aritter.Infra.CrossCutting.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Security.Principal;

namespace Aritter.Infra.Data.UnitOfWork
{
	public abstract class UnitOfWork : DbContext, IUnitOfWork
	{
		#region Attributes

		protected bool disposed;
		protected IIdentity currentUser;

		#endregion

		#region Constructors

		public UnitOfWork(string connectionName)
			: base(string.Format("name={0}", connectionName))
		{
			Configuration.LazyLoadingEnabled = false;
			Configuration.ProxyCreationEnabled = false;

			currentUser = ApplicationSettings.CurrentUser;

			Database.Log = LogDatabase;
		}

		#endregion

		#region Properties

		public DbSet<AuditLog> AuditLogs { get; set; }
		public DbSet<AuditLogDetail> AuditLogDetails { get; set; }

		#endregion

		#region Methods

		public override int SaveChanges()
		{
			if (!ApplicationSettings.Auditing.Enabled)
				return base.SaveChanges();

			var logs = GetAuditLogs();
			var affectedRows = base.SaveChanges();

			if (!logs.Any())
				return affectedRows;

			SaveAuditLogs(logs);

			return affectedRows;
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.HasDefaultSchema(ApplicationSettings.Database.DefaultSchema);
			modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
			modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
			modelBuilder.Conventions.Add<AritterEntityMappingConvention>();

			modelBuilder.Configurations.Add(new AuditLogMap());
			modelBuilder.Configurations.Add(new AuditLogDetailMap());
		}

		protected override void Dispose(bool disposing)
		{
			if (disposed)
				return;

			if (disposing)
			{
				base.Dispose(disposing);

				if (AuditLogs != null)
					AuditLogs = null;

				if (AuditLogDetails != null)
					AuditLogDetails = null;
			}

			disposed = true;
		}

		protected virtual IEnumerable<AuditLog> GetAuditLogs()
		{
			var now = DateTime.Now;

			return ChangeTracker.Entries<IAuditable>()
				.Where(p => p.State != EntityState.Unchanged)
				.Select(entry =>
				{
					var entityType = entry.Entity.GetType();
					var log = GetAuditLog(entry, entityType, now);
					var logFields = GetLogFields(entityType);

					switch (entry.State)
					{
						case EntityState.Added:
							log.AuditLogDetails = GetAddedEntryLogDetails(entry, logFields);
							break;
						case EntityState.Modified:
							log.EntityId = entry.Entity.Id;
							log.AuditLogDetails = GetModifiedEntryLogDetails(entry, logFields);
							break;
						case EntityState.Deleted:
							log.EntityId = entry.Entity.Id;
							log.AuditLogDetails = GetDeletedEntryLogDetails(entry, logFields);
							break;
					}

					return log;
				});
		}

		protected virtual IEnumerable<string> GetLogFields(Type entityType)
		{
			return entityType.GetProperties().Where(p => !p.GetGetMethod().IsVirtual).Select(p => p.Name);
		}

		private void SaveAuditLogs(IEnumerable<AuditLog> logs)
		{
			UpdateAddedAuditLogs(logs);
			AuditLogs.AddRange(logs);
			base.SaveChanges();
		}

		private void UpdateAddedAuditLogs(IEnumerable<AuditLog> logs)
		{
			var addedLogs = logs
				.Where(p => p.Type == AuditLogType.Added);

			if (!addedLogs.Any())
				return;

			var entries = ChangeTracker.Entries<IAuditable>()
				.Where(p => addedLogs.Any(x => x.EntityGuid == p.Entity.Guid))
				.ToList();

			foreach (var entry in entries)
			{
				addedLogs.First(p => p.EntityGuid == entry.Entity.Guid).EntityId = entry.Entity.Id;
			}
		}

		private AuditLog GetAuditLog(DbEntityEntry<IAuditable> entry, Type entityType, DateTime logDate)
		{
			var userId = currentUser.GetId();
			if (userId == 0) userId = 1;

			return new AuditLog
			{
				LogDate = logDate,
				EntityName = entityType.Name.Pluralize(),
				EntityGuid = entry.Entity.Guid,
				UserId = userId,
				Type = (AuditLogType)entry.State
			};
		}

		private ICollection<AuditLogDetail> GetAddedEntryLogDetails(DbEntityEntry<IAuditable> entry, IEnumerable<string> logFields)
		{
			return logFields.Select(field => new AuditLogDetail
			{
				FieldName = field,
				NewValue = entry.CurrentValues[field] == null ? null : entry.CurrentValues[field].ToString()
			})
			.ToList();
		}

		private ICollection<AuditLogDetail> GetModifiedEntryLogDetails(DbEntityEntry<IAuditable> entry, IEnumerable<string> logFields)
		{
			return logFields.Select(field => new AuditLogDetail
			{
				FieldName = field,
				NewValue = entry.CurrentValues[field] == null ? null : entry.CurrentValues[field].ToString(),
				OldValue = entry.OriginalValues[field] == null ? null : entry.OriginalValues[field].ToString()
			})
			.Where(p => p.OldValue != p.NewValue)
			.ToList();
		}

		private ICollection<AuditLogDetail> GetDeletedEntryLogDetails(DbEntityEntry<IAuditable> entry, IEnumerable<string> logFields)
		{
			return logFields.Select(field => new AuditLogDetail
			{
				FieldName = field,
				NewValue = null,
				OldValue = entry.OriginalValues[field] == null ? null : entry.OriginalValues[field].ToString()
			})
			.ToList();
		}

		private void LogDatabase(string message)
		{
			if (!string.IsNullOrEmpty(message.Trim()))
				Logger.Database.Debug(message.Trim());
		}

		#endregion
	}
}
