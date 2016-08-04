using Aritter.Domain.Seedwork.Specifications;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Aritter.Domain.SecurityModule.Aggregates.Users.Specs
{
    public class AllowedUserPermissionsSpec : Specification<UserAccount>
    {
        public override Expression<Func<UserAccount, bool>> SatisfiedBy()
        {
            return (ua => ua.Assignments.Any(r => r.UserRole.Authorizations.Any(a => a.Allowed && !a.Denied)));
        }
    }
}
