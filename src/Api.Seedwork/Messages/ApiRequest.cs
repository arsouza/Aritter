namespace Ritter.Api.Seedwork.Messages
{
	public class ApiRequest<TData>
		where TData : class
	{
		public TData Data { get; set; }
	}
}
