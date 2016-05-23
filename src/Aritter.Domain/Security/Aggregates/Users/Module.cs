using Aritter.Domain.Seedwork;
using System.Collections.Generic;

namespace Aritter.Domain.Security.Aggregates.Users
{
    public class Module : Entity
    {
        public Module()
        {
            Resources = new HashSet<Resource>();
            Menus = new HashSet<Menu>();
            Permissions = new HashSet<Permission>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
