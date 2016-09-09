using Aritter.Domain.Seedwork;

namespace Aritter.Domain.Security.Aggregates
{
    public class UserRole : Entity
    {
        public UserRole(Role role, User user)
           : this()
        {
            Role = role;
            RoleId = role.Id;

            User = user;
            UserId = user.Id;
        }

        private UserRole()
            : base()
        {
        }

        public int RoleId { get; private set; }

        public int UserId { get; private set; }

        public virtual Role Role { get; private set; }

        public virtual User User { get; private set; }
    }
}
