namespace Ritter.Api.Seedwork.Messages
{
    public sealed class ErrorResponse : ApiResponse
    {
        public ErrorResponse(params string[] messages)
        {
			AddMessages(messages);
        }
    }
}
