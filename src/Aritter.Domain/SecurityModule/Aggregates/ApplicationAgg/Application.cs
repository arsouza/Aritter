using Aritter.Domain.SecurityModule.Aggregates.PermissionAgg;
using Aritter.Domain.Seedwork;
using System.Collections.Generic;

namespace Aritter.Domain.SecurityModule.Aggregates.ApplicationAgg
{
    public class Application : Entity
    {
        public Application()
            : base()
        {
            Operations = new HashSet<Operation>();
            Resources = new HashSet<Resource>();
            Roles = new HashSet<Role>();
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Operation> Operations { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
