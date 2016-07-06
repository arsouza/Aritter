using Aritter.Domain.SecurityModule.Aggregates.ModuleAgg;
using Aritter.Domain.Seedwork;
using Aritter.Infra.Crosscutting.Security;

namespace Aritter.Domain.SecurityModule.Aggregates.PermissionAgg
{
    public class Permission : Entity
    {
        public int ResourceId { get; set; }
        public Rule Rule { get; set; }
        public Resource Resource { get; set; }
        public Authorization Authorization { get; set; }

        public void Authorize(Role role)
        {
            Authorization = new Authorization
            {
                RoleId = role.Id
            };
        }
    }
}
