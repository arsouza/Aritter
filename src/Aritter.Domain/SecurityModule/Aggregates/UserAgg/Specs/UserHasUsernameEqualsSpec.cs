using Aritter.Domain.Seedwork.Specifications;
using System;
using System.Linq.Expressions;

namespace Aritter.Domain.SecurityModule.Aggregates.UserAgg.Specs
{
    public class UserHasUsernameEqualsSpec : Specification<User>
    {
        private readonly string username;

        public UserHasUsernameEqualsSpec(string username)
        {
            this.username = username;
        }

        public override Expression<Func<User, bool>> SatisfiedBy()
        {
            return (p => p.Username == username);
        }
    }
}
