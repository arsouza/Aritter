using Aritter.Domain.SecurityModule.Aggregates.MainAgg;
using Aritter.Infra.Crosscutting.Encryption;
using System;

namespace Aritter.Domain.SecurityModule.Aggregates.UserAgg
{
    public static class UserFactory
    {
        public static User CreateUser(string userName, string password, string firstName, string lastName, string email)
        {
            var user = new User
            {
                Username = userName,
                Email = email,
                Person = new Person
                {
                    FirstName = firstName,
                    LastName = lastName
                }
            };

            user.ChangePassword(password);

            return user;
        }

        internal static UserCredential CreateCredential(User user, string password)
        {
            var credential = new UserCredential
            {
                Id = user.Id,
                User = user,
                PasswordHash = Encrypter.Encrypt(password),
                Date = DateTime.Now
            };

            return credential;
        }
    }
}
