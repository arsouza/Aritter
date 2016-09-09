using Aritter.Domain.Seedwork;
using Aritter.Infra.Crosscutting.Exceptions;
using System;
using System.Collections.Generic;

namespace Aritter.Domain.Security.Aggregates
{
    public class User : Entity
    {
        public User(string username, string password, string email)
        {
            if (string.IsNullOrEmpty(username))
            {
                ThrowHelper.ThrowApplicationException("Invalid username");
            }

            if (string.IsNullOrEmpty(email))
            {
                ThrowHelper.ThrowApplicationException("Invalid email");
            }

            Username = username;
            Email = email;

            ChangePassword(password);
            ResetLoginAttempt();
        }

        public User(string username, string password, string email, UserProfile profile)
            : this(username, password, email)
        {
            if (profile == null)
            {
                ThrowHelper.ThrowApplicationException("Invalid user profile");
            }

            Profile = profile;
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

        public virtual UserProfile Profile { get; private set; }

        public virtual ICollection<UserRole> Roles { get; private set; } = new List<UserRole>();

        #region Methods

        public void ChangePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                ThrowHelper.ThrowApplicationException("Invalid password");
            }

            Password = password;
        }

        public bool Authenticate(string passwordHash)
        {
            if (ValidatePassword(passwordHash))
            {
                ResetLoginAttempt();
                return true;
            }

            IncreaseLoginAttempt();
            return false;
        }

        private bool ValidatePassword(string passwordHash)
        {
            return Password.Equals(passwordHash, StringComparison.InvariantCulture);
        }

        public void IncreaseLoginAttempt()
        {
            InvalidLoginAttemptsCount++;
        }

        public void ResetLoginAttempt()
        {
            InvalidLoginAttemptsCount = 0;
        }

        #endregion
    }
}
