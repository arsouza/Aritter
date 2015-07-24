namespace Aritter.Domain.Aggregates
{
	public class UserPolicy : Auditable
	{
		public int MaximumPasswordAge { get; set; }
		public int MinimumPasswordAge { get; set; }
		public int MaximumLoginAttempts { get; set; }
		public int EnforcePasswordHistory { get; set; }
		public virtual Role Role { get; set; }
		public virtual UserPasswordPolicy UserPasswordPolicy { get; set; }
	}
}
