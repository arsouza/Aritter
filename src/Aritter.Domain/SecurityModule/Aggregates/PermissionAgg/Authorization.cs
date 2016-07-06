using Aritter.Domain.Seedwork;

namespace Aritter.Domain.SecurityModule.Aggregates.PermissionAgg
{
    public class Authorization : Entity
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
        public bool Allowed { get; set; }
        public bool Denied { get; set; }
        public virtual Permission Permission { get; set; }
        public virtual Role Role { get; set; }
    }
}