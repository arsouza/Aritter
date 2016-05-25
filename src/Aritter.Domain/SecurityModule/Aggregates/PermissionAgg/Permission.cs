using Aritter.Domain.SecurityModule.Aggregates.ModuleAgg;
using Aritter.Domain.Seedwork;
using System.Data;

namespace Aritter.Domain.SecurityModule.Aggregates.PermissionAgg
{
    public class Permission : Entity
    {
        public int ResourceId { get; set; }
        public Rule Rule { get; set; }
        public virtual Resource Resource { get; set; }
        public virtual Authorization Authorization { get; set; }

        public Permission(Rule rule)
        {
            Rule = rule;
        }

        public void SetResource(Resource resource)
        {
            ResourceId = resource.Id;
        }
    }
}
