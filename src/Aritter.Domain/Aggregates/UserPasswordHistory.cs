using System;

namespace Aritter.Domain.Aggregates
{
	public class UserPasswordHistory : Entity
	{
		public int UserId { get; set; }
		public string Password { get; set; }
		public DateTime Date { get; set; }
		public virtual User User { get; set; }
	}
}
