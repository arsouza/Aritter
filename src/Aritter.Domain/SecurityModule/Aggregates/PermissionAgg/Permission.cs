using Aritter.Domain.SecurityModule.Aggregates.ModuleAgg;
using Aritter.Domain.Seedwork;
using Aritter.Infra.Crosscutting.Security;

namespace Aritter.Domain.SecurityModule.Aggregates.PermissionAgg
{
    public class Permission : Entity
    {
        public int ResourceId { get; set; }
        public Rule Rule { get; set; }
        public virtual Resource Resource { get; set; }
        public virtual Authorization Authorization { get; set; }

        public Permission()
        {
        }

        public Permission(Resource resource, Rule rule)
            : this()
        {
            Resource = resource;
            ResourceId = resource.Id;
            Rule = rule;
        }

        public void Authorize(Role role)
        {
            Authorization = new Authorization(role, true);
        }
    }
}
