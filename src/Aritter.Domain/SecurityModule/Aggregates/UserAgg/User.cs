using Aritter.Domain.SecurityModule.Aggregates.MainAgg;
using Aritter.Domain.SecurityModule.Aggregates.PermissionAgg;
using Aritter.Domain.Seedwork;
using Aritter.Infra.Crosscutting.Encryption;
using System.Collections.Generic;

namespace Aritter.Domain.SecurityModule.Aggregates.UserAgg
{
    public class User : Entity
    {
        public User(Person person, string username, string email, string password)
            : this()
        {
            Person = person;
            Username = username;
            Email = email;
            Password = password;
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
        public int PersonId { get; private set; }

        public virtual Person Person { get; private set; }
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
