using Aritter.Domain.Seedwork.Aggregates;
using System.Collections.Generic;

namespace Aritter.Domain.Security.Aggregates
{
    public class Module : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ModuleRole> ModuleRoles { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }

        public void AddModuleRole(ModuleRole moduleRole)
        {
            if (!ModuleRoles.Contains(moduleRole))
            {
                ModuleRoles.Add(moduleRole);
            }
        }

        public void AddResource(Resource resource)
        {
            if (!Resources.Contains(resource))
            {
                Resources.Add(resource);
            }
        }
    }
}
