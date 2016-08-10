using Aritter.Domain.SecurityModule.Aggregates.Permissions;
using Aritter.Domain.Seedwork;
using Aritter.Infra.Crosscutting.Encryption;
using System.Collections.Generic;

namespace Aritter.Domain.SecurityModule.Aggregates.Users
{
    public class UserAccount : Entity
    {
        public UserAccount(string username, string email)
            : this()
        {
            Username = username;
            Email = email;
        }

        public UserAccount(string username, string email, UserProfile profile)
            : this(username, email)
        {
            UserProfile = profile;
            UserProfileId = profile.Id;
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
        public int? UserProfileId { get; private set; }

        public virtual UserProfile UserProfile { get; private set; }
        public virtual ICollection<UserAssignment> Assignments { get; private set; } = new List<UserAssignment>();

        #region Methods

        public void ChangePassword(string password)
        {
            Password = Encrypter.Encrypt(password);
        }

        public void HasInvalidAttemptsCount()
        {
            InvalidLoginAttemptsCount++;
        }

        public void HasValidAttemptsCount()
        {
            InvalidLoginAttemptsCount = 0;
        }

        #endregion
    }
}
