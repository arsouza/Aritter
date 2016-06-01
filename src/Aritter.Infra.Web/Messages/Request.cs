using System;

namespace Aritter.Infra.Web.Messages
{
	public abstract class Request<TResponse, TData>
		where TResponse : Response<TData>, new()
		where TData : class
	{
		public Guid Protocol => Guid.NewGuid();

		public virtual TResponse CreateResponse()
		{
			var response = new TResponse()
			{
				Protocol = Protocol
			};

			response.Resolve();

			return response;
		}
	}
}
