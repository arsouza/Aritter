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

        public string Name { get; private set; }
        public string Description { get; private set; }
        public int ModuleId { get; private set; }
        public virtual Module Module { get; private set; }
        public virtual ICollection<Permission> Permissions => new HashSet<Permission>();
    }
}
