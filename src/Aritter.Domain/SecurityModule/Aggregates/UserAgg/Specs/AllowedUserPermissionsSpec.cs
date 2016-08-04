using Aritter.Domain.Seedwork.Specifications;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Aritter.Domain.SecurityModule.Aggregates.Users.Specs
{
    public class AllowedUserPermissionsSpec : Specification<User>
    {
        public override Expression<Func<User, bool>> SatisfiedBy()
        {
            return (ua => ua.UserAssignments.Any(r => r.Role.Authorizations.Any(a => a.Allowed && !a.Denied)));
        }
    }
}
