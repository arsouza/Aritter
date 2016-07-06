using Aritter.Domain.Seedwork.Specifications;
using System;
using System.Linq.Expressions;

namespace Aritter.Domain.SecurityModule.Aggregates.UserAgg.Specs
{
    public sealed class UserHasValidCredentialsSpec : Specification<User>
    {
        private readonly string username;
        private readonly string passwordHash;

        public UserHasValidCredentialsSpec(string username, string passwordHash)
        {
            this.username = username;
            this.passwordHash = passwordHash;
        }

        public override Expression<Func<User, bool>> SatisfiedBy()
        {
            return (p => p.Username == username && p.Credential.PasswordHash == passwordHash);
        }
    }
}
