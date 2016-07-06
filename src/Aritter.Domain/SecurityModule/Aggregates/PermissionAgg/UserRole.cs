using Aritter.Domain.SecurityModule.Aggregates.UserAgg;
using Aritter.Domain.Seedwork;

namespace Aritter.Domain.SecurityModule.Aggregates.PermissionAgg
{
    public class UserRole : Entity
	{
		public int UserId { get; set; }
		public int RoleId { get; set; }
		public User User { get; set; }
		public Role Role { get; set; }
	}
}
