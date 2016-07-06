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
        public Module Module { get; set; }
        public ICollection<Permission> Permissions => new HashSet<Permission>();
    }
}
