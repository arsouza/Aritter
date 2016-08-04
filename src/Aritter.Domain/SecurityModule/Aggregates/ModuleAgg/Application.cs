using Aritter.Domain.SecurityModule.Aggregates.Permissions;
using Aritter.Domain.Seedwork;
using System.Collections.Generic;

namespace Aritter.Domain.SecurityModule.Aggregates.Modules
{
    public class Application : Entity
    {
        public Application(string name)
            : this()
        {
            Name = name;
        }

        public Application(string name, string description)
            : this(name)
        {
            Description = description;
        }

        private Application()
            : base()
        {
        }

        public string Name { get; private set; }
        public string Description { get; private set; }

        public virtual ICollection<Operation> Operations { get; private set; } = new HashSet<Operation>();
        public virtual ICollection<Resource> Resources { get; private set; } = new HashSet<Resource>();
        public virtual ICollection<Role> Roles { get; private set; } = new HashSet<Role>();
    }
}
