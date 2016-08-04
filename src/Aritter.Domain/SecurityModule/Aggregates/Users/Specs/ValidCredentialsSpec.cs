using Aritter.Domain.Seedwork.Specifications;
using Aritter.Infra.Crosscutting.Encryption;
using System;
using System.Linq.Expressions;

namespace Aritter.Domain.SecurityModule.Aggregates.Users.Specs
{
    public sealed class ValidCredentialsSpec : Specification<UserAccount>
    {
        private readonly string passwordHash;

        public ValidCredentialsSpec(string password)
        {
            this.passwordHash = Encrypter.Encrypt(password);
        }

        public override Expression<Func<UserAccount, bool>> SatisfiedBy()
        {
            return (p => p.Password.Equals(passwordHash, StringComparison.InvariantCulture));
        }
    }
}
