using Aritter.Infra.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Aritter.Domain.Seedwork.UnitOfWork
{
    public abstract class UnitOfWork : DbContext, IUnitOfWork
    {
        #region Constructors

        public UnitOfWork(string connectionName)
            : base(string.Format("name={0}", connectionName))
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        #endregion

        #region Properties

        protected bool Disposed { get; set; }

        #endregion

        #region Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema(ApplicationSettings.Database.DefaultSchema);
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        protected void EnableAutoDetectedChanges()
        {
            Configuration.AutoDetectChangesEnabled = true;
        }

        protected void DisableAutoDetectedChanges()
        {
            Configuration.AutoDetectChangesEnabled = false;
        }

        #endregion
    }
}
