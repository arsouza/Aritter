using Aritter.Domain.SecurityModule.Aggregates.UserAgg;
using Aritter.Domain.Seedwork;
using System.Collections.Generic;
using System.Linq;

namespace Aritter.Domain.SecurityModule.Aggregates.PermissionAgg
{
    public class Role : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<UserRole> Users => new HashSet<UserRole>();
        public ICollection<Authorization> Authorizations => new HashSet<Authorization>();

        public void AddMember(User user)
        {
            if (Users.All(p => p.Identity != user.Identity))
            {
                // UserRoles.Add(user);
            }
        }
    }
}
