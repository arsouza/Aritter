using Aritter.Domain.SecurityModule.Aggregates.Modules;
using Aritter.Domain.Seedwork;
using Aritter.Infra.Crosscutting.Exceptions;
using System.Collections.Generic;

namespace Aritter.Domain.SecurityModule.Aggregates.Permissions
{
    public class Operation : Entity
    {
        public Operation(string name)
            : this()
        {
            Name = name;
        }

        private Operation()
            : base()
        {
        }

        public string Name { get; private set; }
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
