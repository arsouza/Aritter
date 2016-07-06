using Aritter.Domain.SecurityModule.Aggregates.MainAgg;
using Aritter.Domain.SecurityModule.Aggregates.PermissionAgg;
using Aritter.Domain.Seedwork;
using Aritter.Infra.Crosscutting.Encryption;
using System;
using System.Collections.Generic;

namespace Aritter.Domain.SecurityModule.Aggregates.UserAgg
{
    public class User : Entity
    {
        public int PersonId { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public bool MustChangePassword { get; set; }

        public virtual Person Person { get; set; }

        public virtual UserCredential Credential { get; set; }

        public virtual ICollection<UserRole> Roles { get; set; } = new HashSet<UserRole>();

        #region Methods

        public void ChangePassword(string password)
        {
            Credential = UserFactory.CreateCredential(this, password);
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
