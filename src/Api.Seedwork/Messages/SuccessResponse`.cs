namespace Ritter.Api.Seedwork.Messages
{
	public sealed class SuccessResponse<TData> : ApiResponse<TData>
		where TData : class
	{
		public SuccessResponse(params string[] messages)
		{
			HasSuccessfully();
			AddMessages(messages);
		}

		public SuccessResponse(TData data, params string[] messages)
			: this(messages)
		{
			SetData(data);
		}
	}
}
