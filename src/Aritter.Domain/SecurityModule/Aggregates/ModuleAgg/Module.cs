using Aritter.Domain.SecurityModule.Aggregates.PermissionAgg;
using Aritter.Domain.Seedwork;
using System.Collections.Generic;
using System.Linq;

namespace Aritter.Domain.SecurityModule.Aggregates.ModuleAgg
{
    public class Module : Entity
    {
        public Module()
        {
        }

        public Module(string name)
            : this(name, null)
        {
        }

        public Module(string name, string description)
            : this()
        {
            Name = name;
            Description = description;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Resource> Resources => new HashSet<Resource>();
        public virtual ICollection<Menu> Menus => new HashSet<Menu>();
        public virtual ICollection<Permission> Permissions => new HashSet<Permission>();

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
