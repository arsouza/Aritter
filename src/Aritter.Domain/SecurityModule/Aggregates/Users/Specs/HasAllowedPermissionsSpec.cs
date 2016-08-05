using Aritter.Domain.Seedwork.Specs;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Aritter.Domain.SecurityModule.Aggregates.Users.Specs
{
    public class HasAllowedPermissionsSpec : Specification<UserAccount>
    {
        public override Expression<Func<UserAccount, bool>> SatisfiedBy()
        {
            return (p => p != null && p.Assignments.Any(r => r.UserRole.Authorizations.Any(a => a.Allowed && !a.Denied)));
        }
    }
}
