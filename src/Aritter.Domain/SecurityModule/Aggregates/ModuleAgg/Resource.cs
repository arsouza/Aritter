using Aritter.Domain.SecurityModule.Aggregates.Permissions;
using Aritter.Domain.Seedwork;
using System.Collections.Generic;

namespace Aritter.Domain.SecurityModule.Aggregates.Modules
{
    public class Resource : Entity
    {
        public Resource(string name, Application application)
            : this(name, null, application)
        {
        }

        public Resource(string name, string description, Application application)
            : this()
        {
            Name = name;
            Description = description;
            Application = application;

            ApplicationId = application.Id;
        }

        private Resource()
            : base()
        {
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public int ApplicationId { get; private set; }

        public virtual Application Application { get; private set; }
        public virtual ICollection<Permission> Permissions { get; private set; } = new HashSet<Permission>();
    }
}
