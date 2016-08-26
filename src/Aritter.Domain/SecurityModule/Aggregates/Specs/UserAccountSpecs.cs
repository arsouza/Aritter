using Aritter.Domain.Seedwork.Specs;
using Aritter.Infra.Crosscutting.Encryption;
using System;
using System.Linq;

namespace Aritter.Domain.SecurityModule.Aggregates.Specs
{
    public static class UserAccountSpecs
    {
        public static Specification<UserAccount> HasEmail(string email)
        {
            return new DirectSpecification<UserAccount>(p => p.Email == email);
        }

        public static Specification<UserAccount> HasValidCredentials(string password)
        {
            var passwordHash = Encrypter.Encrypt(password);
            return new DirectSpecification<UserAccount>(p => p.Password.Equals(passwordHash, StringComparison.InvariantCulture));
        }

        public static Specification<UserAccount> HasUsername(string username)
        {
            return new DirectSpecification<UserAccount>(p => p.Username == username);
        }

        public static Specification<UserAccount> HasAllowedPermissions()
        {
            return new DirectSpecification<UserAccount>(u => u.Assignments.Any(p => p.UserRole.Authorizations.Any(a => a.Allowed && !a.Denied)));
        }

        public static Specification<UserAccount> HasClientId(int clientId)
        {
            return new DirectSpecification<UserAccount>(p => p.Assignments.Any(ua => ua.UserRole.Authorizations.Any(a => a.Permission.Resource.ClientId == clientId && a.Permission.Operation.ClientId == clientId)));
        }
    }
}
