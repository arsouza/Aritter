using Aritter.Domain.SecurityModule.Aggregates.ModuleAgg;
using Aritter.Domain.SecurityModule.Aggregates.PermissionAgg;
using Aritter.Domain.SecurityModule.Aggregates.UserAgg;
using Aritter.Infra.Data.Configuration;
using Aritter.Infra.Data.Configuration.Extensions;
using Aritter.Infra.Data.Seedwork;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Aritter.Infra.Data.UnitOfWork
{
    public class AritterContext : DbContext, IQueryableUnitOfWork
	{
		protected bool Disposed { get; set; }

		public DbSet<Authorization> Authorizations { get; set; }
		public DbSet<Module> Modules { get; set; }
		public DbSet<UserCredential> UserCredentials { get; set; }
        public DbSet<UserPreviousCredential> UserPreviousCredentials { get; set; }
        public DbSet<Permission> Permissions { get; set; }
		public DbSet<Resource> Resources { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Menu> Menus { get; set; }
		public DbSet<UserRole> UserRoles { get; set; }

		#region IQueryableUnitOfWork Members

		public void CommitChanges()
		{
			SaveChanges();
			Database.CommitTransaction();
		}

		public void RollbackChanges()
		{
			Database.RollbackTransaction();
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

			modelBuilder.AddConfiguration(new UserBuilder());
            modelBuilder.AddConfiguration(new UserCredentialBuilder());
            modelBuilder.AddConfiguration(new UserPreviousCredentialBuilder());
			modelBuilder.AddConfiguration(new RoleBuilder());
			modelBuilder.AddConfiguration(new UserRoleBuilder());
			modelBuilder.AddConfiguration(new ResourceBuilder());
			modelBuilder.AddConfiguration(new ModuleBuilder());
			modelBuilder.AddConfiguration(new MenuBuilder());
			modelBuilder.AddConfiguration(new PermissionBuilder());
			modelBuilder.AddConfiguration(new AuthorizationBuilder());
        }

		public override void Dispose()
		{
			Dispose(true);
			base.Dispose();
		}

		protected void Dispose(bool disposing)
		{
			if (!Disposed && disposing)
			{
				if (Authorizations != null)
					Authorizations = null;

				if (Modules != null)
					Modules = null;

				if (UserCredentials != null)
					UserCredentials = null;

                if (UserPreviousCredentials != null)
                    UserPreviousCredentials = null;

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
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Aritter;Trusted_Connection=True;");
		}

		#endregion
	}
}