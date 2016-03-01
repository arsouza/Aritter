using Aritter.Domain.Seedwork.Aggregates;
using System.Collections.Generic;

namespace Aritter.Domain.Security.Aggregates
{
    public class Module : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<Feature> Features { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }

        public void AddRole(Role role)
        {
            if (!Roles.Contains(role))
            {
                Roles.Add(role);
            }
        }

        public void AddFeature(Feature feature)
        {
            if (!Features.Contains(feature))
            {
                Features.Add(feature);
            }
        }

        public void AddMenu(Menu menu)
        {
            if (!Menus.Contains(menu))
            {
                Menus.Add(menu);
            }
        }
    }
}
