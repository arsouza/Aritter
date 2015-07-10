using System;

namespace Aritter.Manager.Domain.Aggregates
{
	public class Authentication : Entity
	{
		public int? UserId { get; set; }
		public string UserName { get; set; }
		public DateTime Date { get; set; }
		public AuthenticationState State { get; set; }
		public virtual User User { get; set; }
	}
}
