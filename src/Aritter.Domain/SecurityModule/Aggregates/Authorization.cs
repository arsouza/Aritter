using Aritter.Domain.Contracts;

namespace Aritter.Domain.SecurityModule.Aggregates
{
	public class Authorization : Entity
	{
		public int PermissionId { get; set; }
		public int? UserId { get; set; }
		public int? RoleId { get; set; }
		public bool Allowed { get; set; }
		public bool Denied { get; set; }
		public virtual Permission Permission { get; set; }
		public virtual User User { get; set; }
		public virtual Role Role { get; set; }
	}
}