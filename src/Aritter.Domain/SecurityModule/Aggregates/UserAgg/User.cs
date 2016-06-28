using Aritter.Domain.SecurityModule.Aggregates.PermissionAgg;
using Aritter.Domain.Seedwork;
using Aritter.Infra.Crosscutting.Encryption;
using Aritter.Infra.Crosscutting.Exceptions;
using System;
using System.Collections.Generic;

namespace Aritter.Domain.SecurityModule.Aggregates.UserAgg
{
    public class User : Entity, IValidatableEntity<User>
	{
		public User()
			: base()
		{
		}

		public User(string userName, string firstName, string lastName, string email)
			: this()
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

		public virtual ICollection<UserPreviousCredential> PreviousCredentials => new HashSet<UserPreviousCredential>();

		public virtual ICollection<UserRole> UserRoles => new HashSet<UserRole>();

		#region Methods

		public string FullName()
		{
			Guard.Against<ArgumentException>(string.IsNullOrEmpty(FirstName), "The first name is invalid");

			return string.IsNullOrEmpty(LastName)
				? FirstName
				: $"{FirstName} {LastName}";
		}

		public void ChangePassword(string passwordHash)
		{
			if (Credential != null)
			{
				PreviousCredentials.Add(new UserPreviousCredential(this, Credential));
			}

			Credential = UserFactory.CreateCredential(this, passwordHash);
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
