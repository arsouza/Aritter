using Aritter.Domain.Seedwork.Specs;
using System;
using System.Linq.Expressions;

namespace Aritter.Domain.SecurityModule.Aggregates.Users.Specs
{
    public sealed class HasEmailSpec : Specification<UserAccount>
    {
        private readonly string email;

        public HasEmailSpec(string email)
        {
            this.email = email;
        }

        public override Expression<Func<UserAccount, bool>> SatisfiedBy()
        {
            return (p => p != null && p.Email == email);
        }
    }
}
