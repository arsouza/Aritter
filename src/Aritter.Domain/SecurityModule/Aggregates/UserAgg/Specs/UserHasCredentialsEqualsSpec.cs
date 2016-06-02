using Aritter.Domain.Seedwork.Specifications;
using System;
using System.Linq.Expressions;

namespace Aritter.Domain.SecurityModule.Aggregates.UserAgg.Specs
{
    public sealed class UserHasCredentialsEqualsSpec : Specification<User>
    {
        private readonly string userName;
        private readonly string passwordHash;

        public UserHasCredentialsEqualsSpec(string userName, string passwordHash)
        {
            this.userName = userName;
            this.passwordHash = passwordHash;
        }

        public override Expression<Func<User, bool>> SatisfiedBy()
        {
            return (p => p.UserName == userName && p.Credential.PasswordHash == passwordHash);
        }
    }
}
