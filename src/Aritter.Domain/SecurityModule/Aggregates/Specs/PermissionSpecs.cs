using Aritter.Domain.Seedwork.Specs;
using System.Linq;

namespace Aritter.Domain.SecurityModule.Aggregates.Specs
{
    public static class PermissionSpecs
    {
        public static Specification<Permission> FromUserAccount(string username)
        {
            return new DirectSpecification<Permission>(p => p.Authorizations.Any(a => a.UserRole.UserAssignments.Any(ua => ua.UserAccount.Username == username)));
        }

        public static Specification<Permission> FromUserAccount(int userAccountId)
        {
            return new DirectSpecification<Permission>(p => p.Authorizations.Any(a => a.UserRole.UserAssignments.Any(ua => ua.UserAccountId == userAccountId)));
        }
    }
}
