using Aritter.Domain.Seedwork;
using Aritter.Infra.Crosscutting.Encryption;
using Aritter.Infra.Crosscutting.Exceptions;
using System.Collections.Generic;

namespace Aritter.Domain.SecurityModule.Aggregates
{
    public class UserAccount : Entity
    {
        public UserAccount(string username, string email)
            : this()
        {
            Username = username;
            Email = email;
        }

        private UserAccount()
            : base()
        {
        }

        public string Username { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public bool MustChangePassword { get; private set; }

        public int InvalidLoginAttemptsCount { get; private set; }

        public int? ProfileId { get; private set; }

        public virtual UserProfile Profile { get; private set; }

        public virtual ICollection<RoleMember> Roles { get; private set; } = new List<RoleMember>();

        #region Methods

        public void ChangePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ApplicationException("Invalid password");
            }

            Password = Encrypter.Encrypt(password);
        }

        public void SetProfile(UserProfile profile)
        {
            if (profile == null)
            {
                ThrowHelper.ThrowApplicationException("Invalid user profile");
            }

            Profile = profile;
            ProfileId = profile.Id;
        }

        public void HasInvalidLoginAttempt()
        {
            InvalidLoginAttemptsCount++;
        }

        public void HasValidLoginAttempt()
        {
            InvalidLoginAttemptsCount = 0;
        }

        #endregion
    }
}
