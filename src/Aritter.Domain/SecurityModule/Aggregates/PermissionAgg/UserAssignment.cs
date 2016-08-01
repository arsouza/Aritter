using Aritter.Domain.SecurityModule.Aggregates.UserAgg;
using Aritter.Domain.Seedwork;

namespace Aritter.Domain.SecurityModule.Aggregates.PermissionAgg
{
    public class UserAssignment : Entity
    {
        public UserAssignment(Role role, User user)
            : this()
        {
            Role = role;
            User = user;

            RoleId = role.Id;
            UserId = user.Id;
        }

        private UserAssignment()
            : base()
        {
        }

        public int UserId { get; private set; }
        public int RoleId { get; private set; }
        public virtual User User { get; private set; }
        public virtual Role Role { get; private set; }
    }
}
