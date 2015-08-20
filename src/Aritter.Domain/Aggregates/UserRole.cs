namespace Aritter.Domain.Aggregates
{
	public class UserRole : Entity
	{
		public int UserId { get; set; }
		public int RoleId { get; set; }
		public virtual Role Role { get; set; }
		public virtual User User { get; set; }
	}
}
