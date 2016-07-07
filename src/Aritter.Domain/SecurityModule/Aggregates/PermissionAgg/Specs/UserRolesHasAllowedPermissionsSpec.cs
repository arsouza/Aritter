using Aritter.Domain.Seedwork.Specifications;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Aritter.Domain.SecurityModule.Aggregates.PermissionAgg.Specs
{
    public class UserRolesHasAllowedPermissionsSpec : Specification<UserRole>
    {
        public override Expression<Func<UserRole, bool>> SatisfiedBy()
        {
            return (p => p.Role.Authorizations.Any(a => a.Allowed && !a.Denied));
        }
    }
}
