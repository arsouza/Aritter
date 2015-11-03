using Aritter.Domain.SecurityModule.Aggregates;
using Aritter.Domain.UnitOfWork;
using Aritter.Infra.Data.Conventions;
using Aritter.Infra.Data.Mapping;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System;

namespace Aritter.Infra.Data.UnitOfWork
{
    public class AritterContext : BaseUnitOfWork, ISql
    {
        public AritterContext()
            : base("aritter")
        {
        }

        public DbSet<Authentication> Authentications { get; set; }
        public DbSet<Authorization> Authorizations { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<ModuleRole> ModuleRoles { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<UserPassword> PasswordHistories { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserPasswordPolicy> UserPasswordPolicies { get; set; }
        public DbSet<UserPolicy> UserPolicies { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return Database.ExecuteSqlCommand(sql, parameters);
        }

        public IEnumerable<TEntity> ExecuteQuery<TEntity>(string sql, params object[] parameters)
        {
            return Database.SqlQuery<TEntity>(sql, parameters);
        }

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
            modelBuilder.Configurations.Add(new UserRoleMap());
            modelBuilder.Configurations.Add(new ModuleMap());
            modelBuilder.Configurations.Add(new ModuleRoleMap());
            modelBuilder.Configurations.Add(new OperationMap());
            modelBuilder.Configurations.Add(new PermissionMap());
            modelBuilder.Configurations.Add(new AuthorizationMap());
            modelBuilder.Configurations.Add(new AuthenticationMap());
            modelBuilder.Configurations.Add(new UserPasswordHistoryMap());
            modelBuilder.Configurations.Add(new UserPolicyMap());
            modelBuilder.Configurations.Add(new UserPasswordPolicyMap());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                if (Authentications != null)
                    Authentications = null;

                if (Authorizations != null)
                    Authorizations = null;

                if (Modules != null)
                    Modules = null;

                if (ModuleRoles != null)
                    ModuleRoles = null;

                if (Operations != null)
                    Operations = null;

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

                if (UserPasswordPolicies != null)
                    UserPasswordPolicies = null;

                if (UserPolicies != null)
                    UserPolicies = null;

                if (UserRoles != null)
                    UserRoles = null;
            }

            base.Dispose(disposing);
        }

        private void EnableAutoDetectedChanges()
        {
            Configuration.AutoDetectChangesEnabled = true;
        }

        private void DisableAutoDetectedChanges()
        {
            Configuration.AutoDetectChangesEnabled = false;
        }
    }
}