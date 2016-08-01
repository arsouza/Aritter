using Aritter.Domain.Seedwork.Specifications;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Aritter.Domain.SecurityModule.Aggregates.PermissionAgg.Specs
{
    public class UserRolesHasAllowedPermissionsSpec : Specification<UserAssignment>
    {
        public override Expression<Func<UserAssignment, bool>> SatisfiedBy()
        {
            return (p => p.Role.Authorizations.Any(a => a.Allowed && !a.Denied));
        }
    }
}
