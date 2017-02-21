using System;

namespace Aritter.API.Seedwork.Messages
{
    public abstract class Request<TResponse, TData>
        where TResponse : Response<TData>, new()
        where TData : class
    {
        public Guid Protocol => Guid.NewGuid();

        public virtual TResponse CreateResponse()
        {
            var response = (TResponse)Activator.CreateInstance(typeof(TResponse), Protocol);
            response.Resolve();

            return response;
        }
    }
}
