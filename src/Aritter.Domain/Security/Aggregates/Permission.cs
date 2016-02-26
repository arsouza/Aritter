using Aritter.Domain.Seedwork.Aggregates;
using System.Collections.Generic;

namespace Aritter.Domain.Security.Aggregates
{
    public class Permission : Entity
    {
        public int ResourceId { get; set; }
        public Rule Rule { get; set; }
        public virtual Resource Resource { get; set; }
        public virtual ICollection<Authorization> Authorizations { get; set; }
    }
}
