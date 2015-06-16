using Aritter.Manager.Domain.Aggregates;
using Aritter.Manager.Infrastructure.Data.Mapping;
using System.Collections.Generic;
using System.Data.Entity;

namespace Aritter.Manager.Infrastructure.Data.UnitOfWork
{
	public class ManagerContext : UnitOfWork, ISql
	{
		public ManagerContext()
			: base("manager")
		{
		}

		public DbSet<Authentication> Authentications { get; set; }
		public DbSet<Authorization> Authorizations { get; set; }
		public DbSet<Module> Modules { get; set; }
		public DbSet<ModuleRole> ModuleRoles { get; set; }
		public DbSet<Operation> Operations { get; set; }
		public DbSet<UserPasswordHistory> PasswordHistories { get; set; }
		public DbSet<Permission> Permissions { get; set; }
		public DbSet<Resource> Resources { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<UserPasswordPolicy> UserPasswordPolicies { get; set; }
		public DbSet<UserPolicy> UserPolicies { get; set; }
		public DbSet<UserRole> UserRoles { get; set; }
		public DbSet<Dictionary> Dictionaries { get; set; }
		public DbSet<DictionaryValue> DictionaryValues { get; set; }

		public int ExecuteCommand(string sql, params object[] parameters)
		{
			return this.Database.ExecuteSqlCommand(sql, parameters);
		}

		public IEnumerable<TEntity> ExecuteQuery<TEntity>(string sql, params object[] parameters)
		{
			return this.Database.SqlQuery<TEntity>(sql, parameters);
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

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
			modelBuilder.Configurations.Add(new DictionaryMap());
			modelBuilder.Configurations.Add(new DictionaryValueMap());
		}

		protected override void Dispose(bool disposing)
		{
			if (this.disposed)
				return;

			if (disposing)
			{
				if (this.Authentications != null)
					this.Authentications = null;

				if (this.Authorizations != null)
					this.Authorizations = null;

				if (this.Modules != null)
					this.Modules = null;

				if (this.ModuleRoles != null)
					this.ModuleRoles = null;

				if (this.Operations != null)
					this.Operations = null;

				if (this.PasswordHistories != null)
					this.PasswordHistories = null;

				if (this.Permissions != null)
					this.Permissions = null;

				if (this.Resources != null)
					this.Resources = null;

				if (this.Roles != null)
					this.Roles = null;

				if (this.Users != null)
					this.Users = null;

				if (this.UserPasswordPolicies != null)
					this.UserPasswordPolicies = null;

				if (this.UserPolicies != null)
					this.UserPolicies = null;

				if (this.UserRoles != null)
					this.UserRoles = null;
			}

			base.Dispose(disposing);
		}
	}
}