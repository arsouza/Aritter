using Aritter.Domain.Seedwork.Specifications;
using Aritter.Infra.Crosscutting.Encryption;
using System;
using System.Linq.Expressions;

namespace Aritter.Domain.SecurityModule.Aggregates.Users.Specs
{
    public sealed class ValidUserCredentialSpec : Specification<User>
    {
        private readonly string passwordHash;

        public ValidUserCredentialSpec(string password)
        {
            this.passwordHash = Encrypter.Encrypt(password);
        }

        public override Expression<Func<User, bool>> SatisfiedBy()
        {
            return (p => p.Password.Equals(passwordHash, StringComparison.InvariantCulture));
        }
    }
}
