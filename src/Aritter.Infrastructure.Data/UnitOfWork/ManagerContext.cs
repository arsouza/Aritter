using Aritter.Domain.Aggregates;
using Aritter.Infrastructure.Data.Mapping;
using System.Collections.Generic;
using System.Data.Entity;

namespace Aritter.Infrastructure.Data.UnitOfWork
{
	public class ManagerContext : UnitOfWork, ISql
	{
		public ManagerContext()
			: base("aritter")
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

		public int ExecuteSqlCommand(string sql, params object[] parameters)
		{
			return Database.ExecuteSqlCommand(sql, parameters);
		}

		public IEnumerable<TEntity> ExecuteQuery<TEntity>(string sql, params object[] parameters)
		{
			return Database.SqlQuery<TEntity>(sql, parameters);
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
	}
}