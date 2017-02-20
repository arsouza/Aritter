namespace Aritter.API.Seedwork.Messages
{
    public abstract class CollectionRequest<TResponse, TData>
        where TResponse : CollectionResponse<TData>, new()
        where TData : class
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
