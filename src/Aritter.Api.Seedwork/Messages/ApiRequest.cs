namespace Aritter.Web.Seedwork.Messages
{
	public class ApiRequest<TData>
		where TData : class
	{
		public TData Data { get; set; }
	}
}
