using Aritter.Domain.Seedwork.Aggregates;
using System.Collections.Generic;
using System.Linq;

namespace Aritter.Domain.Security.Aggregates
{
    public class Role : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ModuleId { get; set; }
        public virtual Module Module { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<RoleMenu> Menus { get; set; }
        public virtual ICollection<Authorization> Authorizations { get; set; }

        public void AddMember(User user)
        {
            if (Id > 0 && UserRoles.All(p => p.UserId != user.Id))
            {
                UserRoles.Add(new UserRole { RoleId = Id, UserId = user.Id });
            }
        }
    }
}
