using Aritter.Domain.SecurityModule.Aggregates.PermissionAgg;
using Aritter.Domain.Seedwork;
using System.Collections.Generic;
using System.Linq;

namespace Aritter.Domain.SecurityModule.Aggregates.ModuleAgg
{
    public class Module : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Resource> Resources { get; set; } = new HashSet<Resource>();
        public virtual ICollection<Menu> Menus { get; set; } = new HashSet<Menu>();
        public virtual ICollection<Permission> Permissions { get; set; } = new HashSet<Permission>();

        public void AddResource(Resource resource)
        {
            if (Resources.All(p => p.Name != resource.Name))
            {
                Resources.Add(resource);
            }
        }

        public void AddMenu(Menu menu)
        {
            if (Menus.All(p => p.Name != menu.Name))
            {
                Menus.Add(menu);
            }
        }
    }
}
