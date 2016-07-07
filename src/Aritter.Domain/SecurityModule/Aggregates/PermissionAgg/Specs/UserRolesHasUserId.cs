using Aritter.Domain.Seedwork.Specifications;
using System;
using System.Linq.Expressions;

namespace Aritter.Domain.SecurityModule.Aggregates.PermissionAgg.Specs
{
    public class UserRolesHasUserId : Specification<UserRole>
    {
        private readonly int userId;

        public UserRolesHasUserId(int userId)
        {
            this.userId = userId;
        }

        public override Expression<Func<UserRole, bool>> SatisfiedBy()
        {
            return (p => p.UserId == userId);
        }
    }
}
