using Aritter.Domain.SecurityModule.Aggregates.PermissionAgg;
using Aritter.Domain.Seedwork;
using System.Collections.Generic;

namespace Aritter.Domain.SecurityModule.Aggregates.ModuleAgg
{
    public class Resource : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ModuleId { get; set; }
        public virtual Module Module { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; } = new HashSet<Permission>();
    }
}
