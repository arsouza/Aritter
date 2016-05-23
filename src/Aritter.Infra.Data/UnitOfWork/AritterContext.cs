using Aritter.Domain.Security.Aggregates;
using Aritter.Domain.Security.Aggregates.Users;
using Aritter.Infra.Data.Mapping;
using Aritter.Infra.Data.Seedwork;
using Aritter.Infra.Data.Seedwork.Conventions;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Aritter.Infra.Data.UnitOfWork
{
    public class AritterContext : DbContext, IQueryableUnitOfWork
    {
        protected bool Disposed { get; set; }

        public AritterContext()
            : base("aritter")
        {
            Database.Log = LogQuery;
        }

        public DbSet<Authentication> Authentications { get; set; }
        public DbSet<Authorization> Authorizations { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<UserPassword> PasswordHistories { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Menu> Menus { get; set; }

        #region IQueryableUnitOfWork Members

        public void Attach<TEntity>(TEntity item)
            where TEntity : class
        {
            Entry(item).State = EntityState.Unchanged;
        }

        public void SetModified<TEntity>(TEntity item)
            where TEntity : class
        {
            Entry(item).State = EntityState.Modified;
        }

        public void ApplyCurrentValues<TEntity>(TEntity original, TEntity current)
            where TEntity : class
        {
            Entry(original).CurrentValues.SetValues(current);
        }

        public void Commit()
        {
            SaveChanges();
        }

        public void CommitAndRefreshChanges()
        {
            var saveFailed = false;

            do
            {
                try
                {
                    SaveChanges();

                    saveFailed = false;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;

                    ex.Entries.ToList()
                      .ForEach(entry => { entry.OriginalValues.SetValues(entry.GetDatabaseValues()); });
                }
            }
            while (saveFailed);
        }

        public void RollbackChanges()
        {
            ChangeTracker.Entries()
                         .ToList()
                         .ForEach(entry => entry.State = EntityState.Unchanged);
        }

        #endregion

        #region ISql Members

        public IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters)
        {
            return Database.SqlQuery<TEntity>(sqlQuery, parameters);
        }

        public int ExecuteCommand(string sqlCommand, params object[] parameters)
        {
            return Database.ExecuteSqlCommand(sqlCommand, parameters);
        }

        #endregion

        #region Overrides DbContext

        public override int SaveChanges()
        {
            EnableAutoDetectedChanges();
            int affectedRows = base.SaveChanges();
            DisableAutoDetectedChanges();

            return affectedRows;
        }

        public override async Task<int> SaveChangesAsync()
        {
            EnableAutoDetectedChanges();
            int affectedRows = await base.SaveChangesAsync();
            DisableAutoDetectedChanges();

            return affectedRows;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Add(new AritterEntityMappingConvention());

            modelBuilder.Configurations.Add(new ResourceMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new ModuleMap());
            modelBuilder.Configurations.Add(new PermissionMap());
            modelBuilder.Configurations.Add(new AuthorizationMap());
            modelBuilder.Configurations.Add(new AuthenticationMap());
            modelBuilder.Configurations.Add(new UserPasswordHistoryMap());
            modelBuilder.Configurations.Add(new MenuMap());
        }

        protected override void Dispose(bool disposing)
        {
            if (!Disposed && disposing)
            {
                if (Authentications != null)
                    Authentications = null;

                if (Authorizations != null)
                    Authorizations = null;

                if (Modules != null)
                    Modules = null;

                if (PasswordHistories != null)
                    PasswordHistories = null;

                if (Permissions != null)
                    Permissions = null;

                if (Resources != null)
                    Resources = null;

                if (Roles != null)
                    Roles = null;

                if (Users != null)
                    Users = null;

                if (Menus != null)
                    Menus = null;
            }

            base.Dispose(disposing);
        }

        #endregion

        #region Private Members

        private void DisableAutoDetectedChanges()
        {
            Configuration.AutoDetectChangesEnabled = false;
        }

        private void EnableAutoDetectedChanges()
        {
            Configuration.AutoDetectChangesEnabled = true;
        }

        private void LogQuery(string query)
        {
            Debug.WriteLine(query);
        }

        #endregion
    }
}