using Aritter.Domain.Security.Aggregates;
using Aritter.Infra.CrossCutting.Encryption;
using Aritter.Infra.CrossCutting.Security;
using Aritter.Infra.Data.UnitOfWork;
using System;
using System.Data.Entity.Migrations;

namespace Aritter.Infra.Data.Migrations
{
	internal sealed class Configuration : DbMigrationsConfiguration<AritterContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = true;
			AutomaticMigrationDataLossAllowed = true;
		}

		protected override void Seed(AritterContext context)
		{
			var role = new Role
			{
				Name = "Administrators"
			};

			context.Roles.AddOrUpdate(r => r.Name, role);
			context.SaveChanges();

			var user = new User
			{
				UserName = "anderdsouza",
				Email = "anderdsouza@gmail.com",
				FirstName = "Anderson",
				LastName = "Ritter de Souza",
				IsActive = true
			};

			user.Roles.Add(role);

			context.Users.AddOrUpdate(u => u.UserName, user);
			context.SaveChanges();

			var userPassword = new UserPassword
			{
				UserId = user.Id,
				PasswordHash = Encrypter.Encrypt("#Kk4rtb$"),
				Date = DateTime.Now
			};

			context.PasswordHistories.AddOrUpdate(up => new { up.UserId, up.PasswordHash }, userPassword);
			context.SaveChanges();

			var module = new Module
			{
				Name = "Security"
			};

			context.Modules.AddOrUpdate(m => m.Name, module);
			context.SaveChanges();

			var resource = new Resource
			{
				Name = "MaintainProfile",
				ModuleId = module.Id
			};

			context.Resources.AddOrUpdate(r => r.Name, resource);
			context.SaveChanges();

			var deletePermission = new Permission
			{
				ResourceId = resource.Id,
				Rule = Rule.Delete,
				Authorization = new Authorization
				{
					Allowed = true,
					RoleId = role.Id
				}
			};

			var getPermission = new Permission
			{
				ResourceId = resource.Id,
				Rule = Rule.Get,
				Authorization = new Authorization
				{
					Allowed = true,
					RoleId = role.Id
				}
			};

			var postPermission = new Permission
			{
				ResourceId = resource.Id,
				Rule = Rule.Post,
				Authorization = new Authorization
				{
					Allowed = true,
					RoleId = role.Id
				}
			};

			var putPermission = new Permission
			{
				ResourceId = resource.Id,
				Rule = Rule.Put,
				Authorization = new Authorization
				{
					Allowed = true,
					RoleId = role.Id
				}
			};

			context.Permissions.AddOrUpdate(p => new { p.ResourceId, p.Rule }, deletePermission, getPermission, postPermission, putPermission);
			context.SaveChanges();
		}
	}
}
