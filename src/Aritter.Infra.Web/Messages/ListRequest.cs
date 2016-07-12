namespace Aritter.Infra.Web.Messages
{
    public abstract class ListRequest<TResponse, TData>
        where TResponse : ListResponse<TData>, new()
        where TData : class
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
