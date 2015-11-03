using Aritter.Domain.Contracts;

namespace Aritter.Domain.SecurityModule.Aggregates
{
	public class UserPasswordPolicy : Entity
	{
		public int RequireLength { get; set; }
		public bool RequireNonLetterOrDigit { get; set; }
		public bool RequireDigit { get; set; }
		public bool RequireLowercase { get; set; }
		public bool RequireUppercase { get; set; }

		public virtual UserPolicy UserPolicy { get; set; }
	}
}