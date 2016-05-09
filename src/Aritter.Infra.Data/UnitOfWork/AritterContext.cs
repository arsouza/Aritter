using Aritter.Domain.Security.Aggregates;
using Aritter.Infra.Data.Mapping;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Threading.Tasks;
using Aritter.Domain.Security.Aggregates.Users;
using Aritter.Infra.Data.Seedwork.Conventions;
using Aritter.Infra.Data.Seedwork.UnitOfWork;

namespace Aritter.Infra.Data.UnitOfWork
{
	public class AritterContext : Domain.Seedwork.UnitOfWork.UnitOfWork, ISql
	{
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

		private void LogQuery(string query)
		{
			Debug.WriteLine(query);
		}
	}
}