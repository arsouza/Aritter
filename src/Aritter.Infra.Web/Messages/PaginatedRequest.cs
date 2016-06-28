namespace Aritter.Infra.Web.Messages
{
    public abstract class PaginatedRequest<TResponse, TData>
		where TResponse : PaginatedResponse<TData>, new()
		where TData : class
	{
		public int PageNumber { get; set; }
		public int PageSize { get; set; }
	}
}
