using System.Collections.Generic;

namespace Ritter.Api.Seedwork.Messages
{
	public abstract class ApiResponse
	{
		public virtual bool Success { get; private set; }

		public virtual ICollection<string> Messages { get; private set; } = new HashSet<string>();

		public void AddMessage(string message)
		{
			AddMessages(message);
		}

		public void AddMessages(params string[] messages)
		{
			if (messages != null)
				Messages = messages;
		}

		protected void HasSuccessfully()
		{
			Success = true;
		}

		protected void HasFailed()
		{
			Success = false;
		}
	}
}