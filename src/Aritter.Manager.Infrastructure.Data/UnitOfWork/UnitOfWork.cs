using Aritter.Manager.Domain;
using Aritter.Manager.Domain.Aggregates;
using Aritter.Manager.Domain.UnitOfWork;
using Aritter.Manager.Infrastructure.Configuration;
using Aritter.Manager.Infrastructure.Data.Conventions;
using Aritter.Manager.Infrastructure.Data.Mapping;
using Aritter.Manager.Infrastructure.Extensions;
using Aritter.Manager.Infrastructure.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace Aritter.Manager.Infrastructure.Data.UnitOfWork
{
	public abstract class UnitOfWork : DbContext, IUnitOfWork
	{
		#region Attributes

		protected bool disposed = false;

		#endregion

		#region Constructors

		public UnitOfWork(string connectionName)
			: base(string.Format("name={0}", connectionName))
		{
			this.Configuration.LazyLoadingEnabled = false;
			this.Configuration.ProxyCreationEnabled = false;

			this.Database.Log = this.LogDatabase;
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

			var logs = this.GetAuditLogs();
			var affectedRows = base.SaveChanges();

			if (!logs.Any())
				return affectedRows;

			this.SaveAuditLogs(logs);

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
			if (this.disposed)
				return;

			if (disposing)
			{
				base.Dispose(disposing);

				if (this.AuditLogs != null)
					this.AuditLogs = null;

				if (this.AuditLogDetails != null)
					this.AuditLogDetails = null;
			}

			this.disposed = true;
		}

		protected virtual IEnumerable<AuditLog> GetAuditLogs()
		{
			var now = DateTime.Now;
			var logs = new List<AuditLog>();

			foreach (var entry in this.ChangeTracker.Entries<IAuditable>().Where(p => p.State != EntityState.Unchanged))
			{
				var entityType = entry.Entity.GetType();
				var log = this.GetAuditLog(entry, entityType, now);
				var fieldsToLog = this.FieldsToLog(entityType);

				switch (entry.State)
				{
					case EntityState.Added:
						log.AuditLogDetails = this.GetAddedEntryLogDetails(entry, fieldsToLog);
						break;
					case EntityState.Modified:
						log.EntityId = entry.Entity.Id;
						log.AuditLogDetails = this.GetModifiedEntryLogDetails(entry, fieldsToLog);
						break;
					case EntityState.Deleted:
						log.EntityId = entry.Entity.Id;
						log.AuditLogDetails = this.GetDeletedEntryLogDetails(entry, fieldsToLog);
						break;
				}

				logs.Add(log);
			}

			return logs;
		}

		protected virtual IEnumerable<string> FieldsToLog(Type entityType)
		{
			return entityType.GetProperties().Where(p => !p.GetGetMethod().IsVirtual).Select(p => p.Name);
		}

		private void SaveAuditLogs(IEnumerable<AuditLog> logs)
		{
			this.UpdateAddedAuditLogs(logs);
			this.AuditLogs.AddRange(logs);
			base.SaveChanges();
		}

		private void UpdateAddedAuditLogs(IEnumerable<AuditLog> logs)
		{
			var addedLogs = logs
				.Where(p => p.Type == AuditLogType.Added);

			if (!addedLogs.Any())
				return;

			var entries = this.ChangeTracker.Entries<IAuditable>()
				.Where(p => addedLogs.Any(x => x.EntityGuid == p.Entity.Guid))
				.ToList();

			foreach (var entry in entries)
			{
				addedLogs.First(p => p.EntityGuid == entry.Entity.Guid).EntityId = entry.Entity.Id;
			}
		}

		private AuditLog GetAuditLog(DbEntityEntry<IAuditable> entry, Type entityType, DateTime logDate)
		{
			var userId = ApplicationSettings.CurrentUser.GetId();
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

		private ICollection<AuditLogDetail> GetAddedEntryLogDetails(DbEntityEntry<IAuditable> entry, IEnumerable<string> fieldsToLog)
		{
			return fieldsToLog.Select(p => new AuditLogDetail
			{
				FieldName = p,
				NewValue = entry.CurrentValues[p] == null ? null : entry.CurrentValues[p].ToString()
			})
			.ToList();
		}

		private ICollection<AuditLogDetail> GetModifiedEntryLogDetails(DbEntityEntry<IAuditable> entry, IEnumerable<string> fieldsToLog)
		{
			return fieldsToLog.Select(p => new AuditLogDetail
			{
				FieldName = p,
				NewValue = entry.CurrentValues[p] == null ? null : entry.CurrentValues[p].ToString(),
				OldValue = entry.OriginalValues[p] == null ? null : entry.OriginalValues[p].ToString()
			})
			.Where(p => p.OldValue != p.NewValue)
			.ToList();
		}

		private ICollection<AuditLogDetail> GetDeletedEntryLogDetails(DbEntityEntry<IAuditable> entry, IEnumerable<string> fieldsToLog)
		{
			return fieldsToLog.Select(p => new AuditLogDetail
			{
				FieldName = p,
				NewValue = null,
				OldValue = entry.OriginalValues[p] == null ? null : entry.OriginalValues[p].ToString()
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
