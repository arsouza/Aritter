using Aritter.Domain.Seedwork.Specs;
using System.Linq;

namespace Aritter.Domain.SecurityModule.Aggregates.Permissions.Specs
{
    public static class PermissionSpecs
    {
        public static Specification<Permission> OfUserAccount(string username)
        {
            return new DirectSpecification<Permission>(p => p.Authorizations.Any(au => au.UserRole.UserAssignments.Any(ua => ua.UserAccount.Username == username)));
        }

        public static Specification<Permission> AllowedPermissions()
        {
            return new DirectSpecification<Permission>(p => p.Authorizations.Any(a => a.Allowed && !a.Denied));
        }
    }
}
