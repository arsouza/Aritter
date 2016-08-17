using Aritter.Domain.SecurityModule.Aggregates.Permissions;
using Aritter.Domain.Seedwork;
using Aritter.Infra.Crosscutting.Exceptions;
using System.Collections.Generic;

namespace Aritter.Domain.SecurityModule.Aggregates.Modules
{
    public class Resource : Entity
    {
        public Resource(string name)
            : this()
        {
            Name = name;
        }

        public Resource(string name, string description)
            : this(name)
        {

            Description = description;
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

        public void SetApplication(Application application)
        {
            if (application == null)
            {
                ThrowHelper.ThrowApplicationException("Invalid application");
            }

            Application = application;
            ApplicationId = application.Id;
        }
    }
}
