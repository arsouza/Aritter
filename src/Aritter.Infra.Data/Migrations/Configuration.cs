using Aritter.Domain.SecurityModule.Aggregates;
using Aritter.Infra.CrossCutting.Encryption;
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
            var user = new User
            {
                FirstName = "Anderson",
                LastName = "Ritter de Souza",
                Email = "anderdsouza@gmail.com",
                PasswordHash = Encrypter.Encrypt("jki@b46t"),
                UserName = "arsouza"
            };

            context.Users.AddOrUpdate(
                p => p.UserName,
                user);

            var role = new Role
            {
                Name = "Administrators"
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
                RequireDigit = true,
                RequireLowercase = true,
                RequireLength = 6,
                RequireNonLetterOrDigit = true,
                RequireUppercase = true
            };

            context.UserPasswordPolicies.AddOrUpdate(
                p => p.Id,
                passwordPolicy);

            context.SaveChanges();

            var passwordHistory = new UserPasswordHistory
            {
                Date = DateTime.Now,
                Password = user.PasswordHash,
                UserId = user.Id
            };

            context.PasswordHistories.AddOrUpdate(
                p => p.UserId,
                passwordHistory);

            context.SaveChanges();
        }
    }
}
