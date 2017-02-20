namespace Aritter.API.Seedwork.Messages
{
    public sealed class ErrorResponse : Response<object>
    {
        public ErrorResponse(params string[] messages)
        {
            Reject(messages);
        }
    }
}
