using Aritter.Domain.Seedwork;
using Aritter.Infra.Crosscutting.Exceptions;

namespace Aritter.Domain.Security.Aggregates
{
    public class Authorization : Entity
    {
        private Authorization()
            : base()
        {
        }

        public Authorization(Permission permission, Role role)
            : this()
        {
            if (permission == null)
            {
                ThrowHelper.ThrowApplicationException("Invalid permission");
            }

            if (role == null)
            {
                ThrowHelper.ThrowApplicationException("Invalid role");
            }

            Permission = permission;
            PermissionId = permission.Id;
            Role = role;
            RoleId = role.Id;
        }

        public int PermissionId { get; private set; }

        public int RoleId { get; private set; }

        public bool Allowed { get; private set; }

        public bool Denied { get; private set; }

        public virtual Permission Permission { get; private set; }

        public virtual Role Role { get; private set; }

        public void Allow()
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