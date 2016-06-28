using Aritter.Domain.SecurityModule.Aggregates.ModuleAgg;
using Aritter.Domain.SecurityModule.Aggregates.PermissionAgg;
using Aritter.Domain.SecurityModule.Aggregates.UserAgg;
using Aritter.Infra.Data.Configuration;
using Aritter.Infra.Data.Configuration.Extensions;
using Aritter.Infra.Data.Seedwork;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;

namespace Aritter.Infra.Data.UnitOfWork
{
    public class AritterContext : DbContext, IQueryableUnitOfWork
    {
        protected bool Disposed { get; set; }

        public AritterContext()
        {
        }

        public DbSet<Authorization> Authorizations { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<UserCredential> PasswordHistory { get; set; }
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
            EnableAutoDetectedChanges();
            SaveChanges();
            DisableAutoDetectedChanges();
        }

        #endregion

        #region ISql Members

        public IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters)
        {
            return null;
        }

        public int ExecuteCommand(string sqlCommand, params object[] parameters)
        {
            return Database.ExecuteSqlCommand(sqlCommand, parameters);
        }

        #endregion

        #region Overrides DbContext

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Conventions.Add(new AritterEntityMappingConvention());

            modelBuilder.AddConfiguration(new ResourceBuilder());
            modelBuilder.AddConfiguration(new UserBuilder());
            modelBuilder.AddConfiguration(new RoleBuilder());
            modelBuilder.AddConfiguration(new ModuleBuilder());
            modelBuilder.AddConfiguration(new PermissionBuilder());
            modelBuilder.AddConfiguration(new AuthorizationBuilder());
            modelBuilder.AddConfiguration(new UserCredentialBuilder());
            modelBuilder.AddConfiguration(new MenuBuilder());
        }

        protected override void Dispose(bool disposing)
        {
            if (!Disposed && disposing)
            {
                if (Authorizations != null)
                    Authorizations = null;

                if (Modules != null)
                    Modules = null;

                if (PasswordHistory != null)
                    PasswordHistory = null;

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