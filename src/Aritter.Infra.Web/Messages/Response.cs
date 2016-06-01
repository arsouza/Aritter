using Aritter.Infra.Crosscutting.Extensions;
using System;
using System.Collections.Generic;

namespace Aritter.Infra.Web.Messages
{
	public abstract class Response<TData>
		where TData : class
	{
		public virtual bool Success { get; protected set; }
		public virtual TData Data { get; set; }
		public virtual IEnumerable<string> Messages { get; protected set; }
		public Guid Protocol { get; set; }

		public virtual void Resolve(params string[] messages)
		{
			Resolve(null, messages);
		}

		public virtual void Resolve(TData data, params string[] messages)
		{
			InsertMessages(messages);
			UseData(data);
			Success = true;
		}

		public virtual void Reject(params string[] messages)
		{
			Reject(null, messages);
		}

		public virtual void Reject(TData data, params string[] messages)
		{
			InsertMessages(messages);
			UseData(data);
			Success = false;
		}

		private void InsertMessages(string[] messages)
		{
			Messages.AddRange(messages);
		}

		private void UseData(TData data)
		{
			Data = data;
		}
	}
}
