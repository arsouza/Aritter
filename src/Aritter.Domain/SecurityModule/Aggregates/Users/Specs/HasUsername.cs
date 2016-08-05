using Aritter.Domain.Seedwork.Specs;
using System;
using System.Linq.Expressions;

namespace Aritter.Domain.SecurityModule.Aggregates.Users.Specs
{
    public sealed class HasUsername : Specification<UserAccount>
    {
        private readonly string username;

        public HasUsername(string username)
        {
            this.username = username;
        }

        public override Expression<Func<UserAccount, bool>> SatisfiedBy()
        {
            return (p => p != null && p.Username == username);
        }
    }
}
