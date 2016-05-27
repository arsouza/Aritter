using Aritter.Domain.SecurityModule.Aggregates.PermissionAgg;
using Aritter.Domain.Seedwork;
using Aritter.Infra.Crosscutting.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aritter.Domain.SecurityModule.Aggregates.UserAgg
{
    public class User : Entity
    {
        public User()
        {
        }

        public User(string userName, string firstName, string lastName, string email)
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            MustChangePassword = true;

            GenerateIdentity();
            Enable();
        }

        public string UserName { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

        public bool MustChangePassword { get; private set; }

        public virtual ICollection<UserCredential> Credentials => new HashSet<UserCredential>();

        public virtual ICollection<Role> Roles => new HashSet<Role>();

        #region Methods

        public string FullName()
        {
            if (string.IsNullOrEmpty(FirstName))
            {
                throw new ArgumentException("The first name is invalid.", nameof(FirstName));
            }

            return string.IsNullOrEmpty(LastName)
                ? FirstName
                : $"{FirstName} {LastName}";
        }

        public void CreateNewPassword(string passwordHash, bool expire)
        {
            int expiresIn = 72;

            foreach (var credential in Credentials)
            {
                credential.Expire();
            }

            var newCredential = new UserCredential(passwordHash);

            if (expire)
            {
                var maxDateDiff = DateTime.MaxValue.Subtract(DateTime.Now);
                expiresIn = maxDateDiff.Days;
            }

            newCredential.SetValidity(expiresIn);
            Credentials.Add(newCredential);
        }

        public bool ValidateCredentials(string password)
        {
            var currentCredential = GetCurrentCredential();

            if (currentCredential == null)
            {
                return false;
            }

            return currentCredential.PasswordHash
                .Equals(Encrypter.Encrypt(password), StringComparison.CurrentCulture);
        }

        private UserCredential GetCurrentCredential()
        {
            return Credentials?
                .OrderByDescending(p => p.Date)
                .LastOrDefault();
        }

        #endregion
    }
}
