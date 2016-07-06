using Aritter.Domain.Seedwork.Specifications;
using Aritter.Infra.Crosscutting.Encryption;
using System;
using System.Linq.Expressions;

namespace Aritter.Domain.SecurityModule.Aggregates.UserAgg.Specs
{
    public sealed class UserHasValidCredentialsSpec : Specification<User>
    {
        private readonly string passwordHash;

        public UserHasValidCredentialsSpec(string password)
        {
            this.passwordHash = Encrypter.Encrypt(password);
        }

        public override Expression<Func<User, bool>> SatisfiedBy()
        {
            return (p => p.Credential.PasswordHash.Equals(passwordHash, StringComparison.InvariantCulture));
        }
    }
}
