using Aritter.Domain.SecurityModule.Aggregates.Permissions;
using Aritter.Domain.Seedwork;
using Aritter.Infra.Crosscutting.Encryption;
using System.Collections.Generic;

namespace Aritter.Domain.SecurityModule.Aggregates.Users
{
    public class User : Entity
    {
        public User(Profile person, string username, string email)
            : this()
        {
            Username = username;
            Email = email;

            Profile = person;
            ProfileId = person.Id;
        }

        private User()
            : base()
        {
        }

        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public bool MustChangePassword { get; private set; }
        public int InvalidLoginAttemptsCount { get; private set; }
        public int ProfileId { get; private set; }

        public virtual Profile Profile { get; private set; }
        public virtual ICollection<UserAssignment> UserAssignments { get; private set; } = new List<UserAssignment>();

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
