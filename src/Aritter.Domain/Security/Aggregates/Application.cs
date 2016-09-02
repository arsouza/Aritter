using Aritter.Domain.Seedwork;
using System.Collections.Generic;

namespace Aritter.Domain.Security.Aggregates
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

        public virtual ICollection<Rule> Rules { get; private set; } = new List<Rule>();

        public virtual ICollection<Resource> Resources { get; private set; } = new List<Resource>();

        public virtual ICollection<Role> UserRoles { get; private set; } = new List<Role>();
    }
}
