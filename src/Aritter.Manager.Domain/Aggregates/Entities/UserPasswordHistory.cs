using System;

namespace Aritter.Manager.Domain.Aggregates
{
	public class UserPasswordHistory : Auditable
	{
		public int UserId { get; set; }
		public string Password { get; set; }
		public DateTime Date { get; set; }
		public virtual User User { get; set; }
	}
}
