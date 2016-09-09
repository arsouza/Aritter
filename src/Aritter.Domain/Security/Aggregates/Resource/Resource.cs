using Aritter.Domain.Seedwork;
using Aritter.Infra.Crosscutting.Exceptions;
using System.Collections.Generic;

namespace Aritter.Domain.Security.Aggregates
{
    public class Resource : Entity
    {
        public Resource(string name, Application application)
            : this()
        {
            if (application == null)
            {
                ThrowHelper.ThrowApplicationException("Invalid application");
            }

            Name = name;

            Application = application;
            ApplicationId = application.Id;
        }

        public Resource(string name, string description, Application application)
            : this(name, application)
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
    }
}
