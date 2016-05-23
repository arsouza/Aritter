using Aritter.Domain.Seedwork;
using Aritter.Infra.Crosscutting.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aritter.Domain.Security.Aggregates.Users
{
    public class User : Entity
    {
        public User()
        {
            Authentications = new HashSet<Authentication>();
            PasswordHistory = new HashSet<UserPassword>();
            Roles = new HashSet<Role>();

            Activate();
        }

        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool MustChangePassword { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Authentication> Authentications { get; set; }
        public virtual ICollection<UserPassword> PasswordHistory { get; set; }
        public virtual ICollection<Role> Roles { get; set; }

        #region Methods

        public string FullName()
        {
            if (string.IsNullOrEmpty(FirstName))
                throw new ArgumentException("The first name is invalid.", nameof(FirstName));

            if (string.IsNullOrEmpty(LastName))
                return FirstName;

            return string.Format("{0} {1}", FirstName, LastName);
        }

        public void SetPassword(string password)
        {
            if (PasswordHistory == null)
            {
                PasswordHistory = new List<UserPassword>();
            }

            PasswordHistory.Add(new UserPassword
            {
                Date = DateTime.Now.Date,
                PasswordHash = Encrypter.Encrypt(password)
            });
        }

        public bool ValidatePassword(string password)
        {
            if (PasswordHistory == null || !PasswordHistory.Any())
            {
                return false;
            }

            var userPassword = PasswordHistory.Last();

            return userPassword.PasswordHash
                .Equals(Encrypter.Encrypt(password), StringComparison.CurrentCulture);
        }

        public void Activate()
        {
            IsActive = true;
        }

        public void Deactivate()
        {
            IsActive = false;
        }

        #endregion
    }
}
