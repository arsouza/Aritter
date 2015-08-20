using Aritter.Domain.Aggregates;
using Aritter.Domain.UnitOfWork;
using Aritter.Infra.CrossCutting.Configuration;
using Aritter.Infra.CrossCutting.Logging;
using Aritter.Infra.Data.Conventions;
using Aritter.Infra.Data.Mapping;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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

		private void LogDatabase(string message)
		{
			if (!string.IsNullOrEmpty(message.Trim()))
				Logger.Database.Debug(message.Trim());
		}

		#endregion
	}
}
