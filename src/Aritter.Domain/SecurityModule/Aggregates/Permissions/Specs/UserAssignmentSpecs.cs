using Aritter.Domain.Seedwork.Specs;
using System.Linq;

namespace Aritter.Domain.SecurityModule.Aggregates.Permissions.Specs
{
    public static class UserAssignmentSpecs
    {
        public static Specification<UserAssignment> HasAllowedPermissions()
        {
            return new DirectSpecification<UserAssignment>(p => p != null && p.UserRole.Authorizations.Any(a => a.Allowed && !a.Denied));
        }

        public static Specification<UserAssignment> HasUserAccountId(int userAccountId)
        {
            return new DirectSpecification<UserAssignment>(p => p != null && p.UserAccountId == userAccountId);
        }
    }
}
