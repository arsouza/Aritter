using Aritter.Domain.Seedwork.Aggregates;
using Aritter.Infra.CrossCutting.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aritter.Domain.Security.Aggregates
{
    public class User : Entity
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool MustChangePassword { get; set; }
        public virtual UserPolicy UserPolicy { get; set; }
        public virtual ICollection<Authentication> Authentications { get; set; }
        public virtual ICollection<Authorization> Authorizations { get; set; }
        public virtual ICollection<UserPassword> PasswordHistory { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }

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
    }
}
