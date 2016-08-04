using Aritter.Domain.Seedwork;

namespace Aritter.Domain.SecurityModule.Aggregates.Permissions
{
    public class Authorization : Entity
    {
        public Authorization(Role role, Permission permission)
            : this()
        {
            Permission = permission;
            Role = role;

            PermissionId = permission.Id;
            RoleId = role.Id;
        }

        private Authorization()
            : base()
        {
        }

        public int PermissionId { get; private set; }
        public int RoleId { get; private set; }
        public bool Allowed { get; private set; }
        public bool Denied { get; private set; }

        public virtual Permission Permission { get; private set; }
        public virtual Role Role { get; private set; }

        public void Authorize()
        {
            Allowed = true;
            Denied = false;
        }

        public void Deny()
        {
            Denied = true;
        }
    }
}