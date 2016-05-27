using Aritter.Domain.Seedwork;

namespace Aritter.Domain.SecurityModule.Aggregates.PermissionAgg
{
    public class Authorization : Entity
    {
        public Authorization()
        {
        }

        public Authorization(Role role, bool allowed)
            : this()
        {
            RoleId = role.Id;
            Role = role;

            Allowed = allowed;
            Denied = !allowed;
        }

        public int RoleId { get; private set; }
        public bool Allowed { get; private set; }
        public bool Denied { get; private set; }
        public virtual Permission Permission { get; private set; }
        public virtual Role Role { get; private set; }
    }
}