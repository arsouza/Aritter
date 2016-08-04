using Aritter.Domain.Seedwork.Specifications;
using System;
using System.Linq.Expressions;

namespace Aritter.Domain.SecurityModule.Aggregates.Users.Specs
{
    public sealed class EmailEqualsSpec : Specification<UserAccount>
    {
        private readonly string email;

        public EmailEqualsSpec(string email)
        {
            this.email = email;
        }

        public override Expression<Func<UserAccount, bool>> SatisfiedBy()
        {
            return (p => p.Email == email);
        }
    }
}
