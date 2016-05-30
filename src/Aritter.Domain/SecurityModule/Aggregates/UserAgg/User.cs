using Aritter.Domain.SecurityModule.Aggregates.PermissionAgg;
using Aritter.Domain.Seedwork;
using Aritter.Infra.Crosscutting.Encryption;
using System;
using System.Collections.Generic;

namespace Aritter.Domain.SecurityModule.Aggregates.UserAgg
{
    public class User : Entity, IValidatableEntity<User>
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
        }

        public string UserName { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

        public bool MustChangePassword { get; private set; }

        public virtual UserCredential Credential { get; private set; }

        public virtual ICollection<PreviousUserCredential> PreviousCredentials => new HashSet<PreviousUserCredential>();

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

        public void ChangePassword(UserCredential credential)
        {
            if (Credential != null)
            {
                PreviousCredentials.Add(UserFactory.CreatePreviousCredential(this, Credential));
            }

            Credential = credential;
        }

        public bool ValidateCredential(string password)
        {
            if (Credential == null)
            {
                return false;
            }

            if (!Credential.PasswordHash.Equals(Encrypter.Encrypt(password), StringComparison.CurrentCulture))
            {
                Credential.HasInvalidAttemptsCount();
                return false;
            }

            Credential.HasValidAttemptsCount();
            return true;
        }

        #endregion
    }
}
