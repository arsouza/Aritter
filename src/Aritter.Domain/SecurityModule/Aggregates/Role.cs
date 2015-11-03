using Aritter.Domain.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Aritter.Domain.SecurityModule.Aggregates
{
    public class Role : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual UserPolicy UserPolicy { get; set; }
        public virtual ICollection<ModuleRole> ModuleRoles { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<Authorization> Authorizations { get; set; }

        public void AddUser(User user)
        {
            if (Id > 0 && UserRoles.All(p => p.UserId != user.Id))
            {
                UserRoles.Add(new UserRole { RoleId = Id, UserId = user.Id });
            }
        }
    }
}
