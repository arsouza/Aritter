using Aritter.Domain.Seedwork.Aggregates;

namespace Aritter.Domain.Aggregates.Security
{
	public class UserPolicy : Entity
	{
		public int MaximumPasswordAge { get; set; }
		public int MinimumPasswordAge { get; set; }
		public int MaximumLoginAttempts { get; set; }
		public int EnforcePasswordHistory { get; set; }
		public virtual Role Role { get; set; }
		public virtual UserPasswordPolicy UserPasswordPolicy { get; set; }
	}
}
