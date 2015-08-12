using System.Collections.Generic;

namespace Aritter.Domain.Aggregates
{
	public class User : Auditable
	{
		public string UserName { get; set; }
		public string PasswordHash { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public bool EmailConfirmed { get; set; }
		public bool MustChangePassword { get; set; }
		public string SecurityStamp { get; set; }
		public bool TwoFactorEnabled { get; set; }
		public virtual ICollection<Authentication> Authentications { get; set; }
		public virtual ICollection<Authorization> Authorizations { get; set; }
		public virtual ICollection<UserPasswordHistory> PasswordHistory { get; set; }
		public virtual ICollection<UserRole> UserRoles { get; set; }
	}
}
