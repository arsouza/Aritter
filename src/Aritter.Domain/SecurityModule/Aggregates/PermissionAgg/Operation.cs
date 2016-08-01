using Aritter.Domain.SecurityModule.Aggregates.ModuleAgg;
using Aritter.Domain.Seedwork;
using System.Collections.Generic;

namespace Aritter.Domain.SecurityModule.Aggregates.PermissionAgg
{
    public class Operation : Entity
    {
        public Operation(string name, Application application)
            : this()
        {
            Name = name;
            Application = application;

            ApplicationId = application.Id;
        }

        private Operation()
            : base()
        {
        }

        public string Name { get; private set; }
        public int ApplicationId { get; private set; }

        public virtual Application Application { get; private set; }
        public virtual ICollection<Permission> Permissions { get; private set; } = new HashSet<Permission>();
    }
}
