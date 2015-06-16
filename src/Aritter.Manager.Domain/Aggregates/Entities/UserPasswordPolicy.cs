namespace Aritter.Manager.Domain.Aggregates
{
	public class UserPasswordPolicy : Auditable
	{
		public int RequiredMinimumLength { get; set; }
		public int? RequiredMaximumLength { get; set; }
		public int RequiredUppercase { get; set; }
		public int RequiredLowercase { get; set; }
		public int RequiredNonLetterOrDigit { get; set; }
		public int RequiredDigit { get; set; }

		public virtual UserPolicy UserPolicy { get; set; }
	}
}