using Aritter.Domain.SecurityModule.Aggregates.ModuleAgg;
using Aritter.Domain.SecurityModule.Aggregates.PermissionAgg;
using Aritter.Domain.SecurityModule.Aggregates.UserAgg;
using Aritter.Infra.Crosscutting.Encryption;
using Aritter.Infra.Crosscutting.Security;
using Aritter.Infra.Data.UnitOfWork;
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
            var user = UserFactory.CreateUser("anderdsouza", Encrypter.Encrypt("#Kk4rtb$"), "Anderson", "Ritter de Souza", "anderdsouza@gmail.com");

            context.Users.AddOrUpdate(u => u.UserName, user);
            context.SaveChanges();

            var role = new Role("Administrators");
            role.AddMember(user);

            context.Roles.AddOrUpdate(r => r.Name, role);
            context.SaveChanges();

            var module = new Module("Security");
            var resource = new Resource("MaintainProfile");

            module.AddResource(resource);

            context.Modules.AddOrUpdate(m => m.Name, module);
            context.SaveChanges();

            var deletePermission = new Permission(resource, Rule.Delete);
            deletePermission.Authorize(role);

            var getPermission = new Permission(resource, Rule.Get);
            deletePermission.Authorize(role);

            var postPermission = new Permission(resource, Rule.Post);
            deletePermission.Authorize(role);

            var putPermission = new Permission(resource, Rule.Put);
            deletePermission.Authorize(role);

            context.Permissions.AddOrUpdate(p => new
            {
                p.ResourceId,
                p.Rule
            }, deletePermission, getPermission, postPermission, putPermission);
            context.SaveChanges();
        }
    }
}
