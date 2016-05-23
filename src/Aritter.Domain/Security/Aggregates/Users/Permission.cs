using Aritter.Domain.Seedwork;
using Aritter.Infra.Crosscutting.Security;

namespace Aritter.Domain.Security.Aggregates.Users
{
    public class Permission : Entity
    {
        public int ResourceId { get; set; }
        public Rule Rule { get; set; }
        public virtual Resource Resource { get; set; }
        public virtual Authorization Authorization { get; set; }
    }
}
