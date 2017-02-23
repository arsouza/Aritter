namespace Aritter.Web.Seedwork.Messages
{
    public sealed class ErrorResponse : ApiResponse
    {
        public ErrorResponse(params string[] messages)
        {
			AddMessages(messages);
        }
    }
}
