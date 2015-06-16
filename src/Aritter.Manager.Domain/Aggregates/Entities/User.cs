using System;
using System.Collections.Generic;

namespace Aritter.Manager.Domain.Aggregates
{
	public class User : Auditable
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MailAddress { get; set; }
		public bool MustChangePassword { get; set; }
		public Guid? SecurityToken { get; set; }
		public virtual ICollection<Authentication> Authentications { get; set; }
		public virtual ICollection<Authorization> Authorizations { get; set; }
		public virtual ICollection<UserPasswordHistory> PasswordHistory { get; set; }
		public virtual ICollection<UserRole> UserRoles { get; set; }
	}
}
