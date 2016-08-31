using Aritter.Domain.Seedwork;

namespace Aritter.Domain.SecurityModule.Aggregates
{
    public class UserAssignment : Entity
    {
        public UserAssignment(Role role, UserAccount user)
            : this()
        {
            Role = role;
            RoleId = role.Id;

            Account = user;
            AccountId = user.Id;
        }

        private UserAssignment()
            : base()
        {
        }

        public int AccountId { get; private set; }

        public int RoleId { get; private set; }

        public virtual UserAccount Account { get; private set; }

        public virtual Role Role { get; private set; }
    }
}
