using Aritter.Domain.Seedwork;
using Aritter.Infra.Crosscutting.Exceptions;

namespace Aritter.Domain.SecurityModule.Aggregates
{
    public class Authorization : Entity
    {
        public Authorization()
            : base()
        {
        }

        public int PermissionId { get; private set; }

        public int RoleId { get; private set; }

        public bool Allowed { get; private set; }

        public bool Denied { get; private set; }

        public virtual Permission Permission { get; private set; }

        public virtual Role Role { get; private set; }

        public void SetPermission(Permission permission)
        {
            if (permission == null)
            {
                ThrowHelper.ThrowApplicationException("Invalid permission");
            }

            Permission = permission;
            PermissionId = permission.Id;
        }

        public void SetUserRole(Role role)
        {
            if (role == null)
            {
                ThrowHelper.ThrowApplicationException("Invalid user role");
            }

            Role = role;
            RoleId = role.Id;
        }

        public void Authorize()
        {
            Allowed = true;
            Denied = false;
        }

        public void Deny()
        {
            Denied = true;
        }

        public static Authorization CreateAuthorization(Role role, Permission permission)
        {
            var authorization = new Authorization();
            authorization.SetPermission(permission);
            authorization.SetUserRole(role);

            return authorization;
        }
    }
}