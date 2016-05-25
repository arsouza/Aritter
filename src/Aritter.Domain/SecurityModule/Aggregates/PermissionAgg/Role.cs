using Aritter.Domain.SecurityModule.Aggregates.UserAgg;
using Aritter.Domain.Seedwork;
using System.Collections.Generic;
using System.Linq;

namespace Aritter.Domain.SecurityModule.Aggregates.PermissionAgg
{
    public class Role : Entity
    {
        private Role()
        {
        }

        public Role(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public virtual ICollection<User> Users => new HashSet<User>();
        public virtual ICollection<Authorization> Authorizations => new HashSet<Authorization>();

        public void AddMember(User user)
        {
            if (Users.All(p => p.Identity != user.Identity))
            {
                Users.Add(user);
            }
        }

        public void Describe(string description)
        {
            Description = description;
        }
    }
}
