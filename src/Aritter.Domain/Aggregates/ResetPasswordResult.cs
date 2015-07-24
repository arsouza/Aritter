namespace Aritter.Domain.Aggregates
{
	public class ResetPasswordResult
	{
		public string UserMailAddress { get; set; }
		public string DisplayName { get; set; }
		public string Token { get; set; }
	}
}
