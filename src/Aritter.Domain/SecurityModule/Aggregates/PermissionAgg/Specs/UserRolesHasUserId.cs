using Aritter.Domain.Seedwork.Specifications;
using System;
using System.Linq.Expressions;

namespace Aritter.Domain.SecurityModule.Aggregates.PermissionAgg.Specs
{
    public class UserRolesHasUserId : Specification<UserAssignment>
    {
        private readonly int userId;

        public UserRolesHasUserId(int userId)
        {
            this.userId = userId;
        }

        public override Expression<Func<UserAssignment, bool>> SatisfiedBy()
        {
            return (p => p.UserId == userId);
        }
    }
}
