using Aritter.Domain.Seedwork.Specs;
using Aritter.Infra.Crosscutting.Encryption;
using System;
using System.Linq;

namespace Aritter.Domain.Security.Aggregates.Specs
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

        public static Specification<UserAccount> HasApplicationId(int applicationId)
        {
            return new DirectSpecification<UserAccount>(p => p.Roles.Any(ua => ua.Role.Authorizations.Any(a => a.Permission.Resource.ApplicationId == applicationId && a.Permission.Rule.ApplicationId == applicationId)));
        }
    }
}
