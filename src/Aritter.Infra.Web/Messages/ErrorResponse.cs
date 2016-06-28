namespace Aritter.Infra.Web.Messages
{
    public sealed class ErrorResponse : Response<object>
	{
		public ErrorResponse(params string[] messages)
		{
			Reject(messages);
		}
	}
}
