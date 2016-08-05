using Aritter.Domain.Seedwork.Specs;
using Aritter.Infra.Crosscutting.Encryption;
using System;
using System.Linq.Expressions;

namespace Aritter.Domain.SecurityModule.Aggregates.Users.Specs
{
    public sealed class HasValidCredentialsSpec : Specification<UserAccount>
    {
        private readonly string passwordHash;

        public HasValidCredentialsSpec(string password)
        {
            this.passwordHash = Encrypter.Encrypt(password);
        }

        public override Expression<Func<UserAccount, bool>> SatisfiedBy()
        {
            return (p => p != null && p.Password.Equals(passwordHash, StringComparison.InvariantCulture));
        }
    }
}
