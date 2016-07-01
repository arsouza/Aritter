using Aritter.Domain.SecurityModule.Aggregates.PermissionAgg;
using Aritter.Domain.Seedwork;
using System.Collections.Generic;

namespace Aritter.Domain.SecurityModule.Aggregates.ModuleAgg
{
    public class Resource : Entity
    {
        public Resource()
        {
        }

        public Resource(string name)
            : this(name, null)
        {
        }

        public Resource(string name, string description)
            : this()
        {
            Name = name;
            Description = description;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int ModuleId { get; set; }
        public virtual Module Module { get; set; }
        public virtual ICollection<Permission> Permissions => new HashSet<Permission>();
    }
}
