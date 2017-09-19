namespace Ritter.Api.Seedwork.Messages
{
	public abstract class ApiResponse<TData> : ApiResponse
		where TData : class
	{
		public TData Data { get; set; }

		protected void SetData(TData data)
		{
			if (data != null)
				Data = data;
		}
	}
}