using System;
using System.Collections.Generic;
using System.Linq;

namespace Aritter.API.Seedwork.Messages
{
    public abstract class Response<TData>
        where TData : class
    {
        public virtual bool Success { get; protected set; }
        public virtual TData Data { get; set; }
        public virtual IEnumerable<string> Messages { get; protected set; } = new HashSet<string>();
        public Guid Protocol { get; set; }

        public Response()
            : this(Guid.NewGuid())
        {
        }

        public Response(Guid protocol)
        {
            Protocol = protocol;
        }

        public virtual void Resolve(params string[] messages)
        {
            Resolve(null, messages);
        }

        public virtual void Resolve(TData data, params string[] messages)
        {
            AddMessages(messages);
            UseData(data);
            Success = true;
        }

        public virtual void Reject(params string[] messages)
        {
            Reject(null, messages);
        }

        public virtual void Reject(TData data, params string[] messages)
        {
            AddMessages(messages);
            UseData(data);
            Success = false;
        }

        private void AddMessages(string[] messages)
        {
            Messages = Messages.Concat(messages);
        }

        private void UseData(TData data)
        {
            Data = data;
        }
    }
}
