namespace Aritter.Manager.Domain.Aggregates
{
	public class PasswordComplexityValidation
	{
		public bool IsInvalid { get; set; }
		public int RequiredMinimumLength { get; set; }
		public int? RequiredMaximumLength { get; set; }
		public int RequiredUppercase { get; set; }
		public int RequiredLowercase { get; set; }
		public int RequiredNonLetterOrDigit { get; set; }
		public int RequiredDigit { get; set; }
	}
}
