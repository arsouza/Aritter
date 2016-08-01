using Aritter.Domain.SecurityModule.Aggregates.PermissionAgg;
using Aritter.Domain.Seedwork;
using System.Collections.Generic;

namespace Aritter.Domain.SecurityModule.Aggregates.ApplicationAgg
{
    public class Resource : Entity
    {
        public Resource()
            : base()
        {
            Permissions = new HashSet<Permission>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int ApplicationId { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }
        public virtual Application Application { get; set; }
    }
}
