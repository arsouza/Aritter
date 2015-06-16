using Aritter.Manager.Domain.Aggregates;
using Aritter.Manager.Infrastructure.Data.UnitOfWork;
using Aritter.Manager.Infrastructure.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace Aritter.Manager.Infrastructure.Data.Migrations
{
	internal sealed class Configuration : DbMigrationsConfiguration<ManagerContext>
	{
		public Configuration()
		{
			this.AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(ManagerContext context)
		{
			var user = new User
			{
				FirstName = "Anderson",
				LastName = "Ritter de Souza",
				MailAddress = "anderdsouza@gmail.com",
				Password = Encrypter.Encrypt("jki@b46t"),
				Username = "arsouza"
			};

			context.Users.AddOrUpdate(
				p => p.Username,
				user);

			var role = new Role
			{
				Name = "Administradores",
				PrecedenceOrder = 0
			};

			context.Roles.AddOrUpdate(
				p => p.Name,
				role);

			context.SaveChanges();

			var userRole = new UserRole
			{
				RoleId = role.Id,
				UserId = user.Id
			};

			context.UserRoles.AddOrUpdate(
				p => new { p.UserId, p.RoleId },
				userRole);

			context.SaveChanges();

			var userPolicy = new UserPolicy
			{
				Id = role.Id,
				EnforcePasswordHistory = 5,
				MaximumLoginAttempts = 3,
				MaximumPasswordAge = 90,
				MinimumPasswordAge = 0
			};

			context.UserPolicies.AddOrUpdate(
				p => p.Id,
				userPolicy);

			context.SaveChanges();

			var passwordPolicy = new UserPasswordPolicy
			{
				Id = userPolicy.Id,
				RequiredDigit = 1,
				RequiredLowercase = 1,
				RequiredMinimumLength = 6,
				RequiredNonLetterOrDigit = 1,
				RequiredUppercase = 1
			};

			context.UserPasswordPolicies.AddOrUpdate(
				p => p.Id,
				passwordPolicy);

			context.SaveChanges();

			var passwordHistory = new UserPasswordHistory
			{
				Date = DateTime.Now,
				Password = user.Password,
				UserId = user.Id
			};

			context.PasswordHistories.AddOrUpdate(
				p => p.UserId,
				passwordHistory);

			context.SaveChanges();

			context.Dictionaries.AddOrUpdate(
				p => p.Name,
				new Dictionary
				{
					Name = "AuditLogType",
					DictionaryValues = new List<DictionaryValue>
					{
						new DictionaryValue { Value = 4, Description = "Incluído" },
						new DictionaryValue { Value = 8, Description = "Removido" },
						new DictionaryValue { Value = 16, Description = "Modificado" }
					}
				});

			context.SaveChanges();
		}
	}
}
