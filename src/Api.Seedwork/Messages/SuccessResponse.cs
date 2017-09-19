namespace Ritter.Api.Seedwork.Messages
{
	public sealed class SuccessResponse : ApiResponse
	{
		public SuccessResponse(params string[] messages)
		{
			HasSuccessfully();
			AddMessages(messages);
		}
	}
}
