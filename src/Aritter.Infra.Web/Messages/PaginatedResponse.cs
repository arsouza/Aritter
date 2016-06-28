namespace Aritter.Infra.Web.Messages
{
    public abstract class PaginatedResponse<TData> : Response<TData>
		where TData : class
	{
		public int TotalCount { get; set; }
	}
}
