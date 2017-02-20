namespace Aritter.API.Seedwork.Messages
{
    public sealed class SuccessResponse<TData> : Response<TData>
        where TData : class
    {
        public SuccessResponse(params string[] messages)
        {
            Resolve(messages);
        }

        public SuccessResponse(TData data, params string[] messages)
        {
            Resolve(data, messages);
        }
    }
}
