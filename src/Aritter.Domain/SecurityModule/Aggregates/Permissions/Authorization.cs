using Aritter.Domain.Seedwork;
using Aritter.Infra.Crosscutting.Exceptions;

namespace Aritter.Domain.SecurityModule.Aggregates.Permissions
{
    public class Authorization : Entity
    {
        public Authorization()
            : base()
        {
        }

        public int PermissionId { get; private set; }
        public int UserRoleId { get; private set; }
        public bool Allowed { get; private set; }
        public bool Denied { get; private set; }

        public virtual Permission Permission { get; private set; }
        public virtual UserRole UserRole { get; private set; }

        public void SetPermission(Permission permission)
        {
            if (permission == null)
            {
                ThrowHelper.ThrowApplicationException("Invalid permission");
            }

            Permission = permission;
            PermissionId = permission.Id;
        }

        public void SetUserRole(UserRole userRole)
        {
            if (userRole == null)
            {
                ThrowHelper.ThrowApplicationException("Invalid user role");
            }

            UserRole = userRole;
            UserRoleId = userRole.Id;
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
    }
}