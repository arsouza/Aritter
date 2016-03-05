using Aritter.Domain.Seedwork.Aggregates;
using Aritter.Infra.CrossCutting.Security;

namespace Aritter.Domain.Security.Aggregates
{
    public class Permission : Entity
    {
        public int FeatureId { get; set; }
        public Rule Rule { get; set; }
        public virtual Feature Feature { get; set; }
        public virtual Authorization Authorization { get; set; }
    }
}
