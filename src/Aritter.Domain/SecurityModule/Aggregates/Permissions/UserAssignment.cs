using Aritter.Domain.SecurityModule.Aggregates.Users;
using Aritter.Domain.Seedwork;

namespace Aritter.Domain.SecurityModule.Aggregates.Permissions
{
    public class UserAssignment : Entity
    {
        public UserAssignment(UserRole role, UserAccount user)
            : this()
        {
            UserRole = role;
            UserAccount = user;

            UserRoleId = role.Id;
            UserAccountId = user.Id;
        }

        private UserAssignment()
            : base()
        {
        }

        public int UserAccountId { get; private set; }
        public int UserRoleId { get; private set; }
        public virtual UserAccount UserAccount { get; private set; }
        public virtual UserRole UserRole { get; private set; }
    }
}
