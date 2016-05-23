using Aritter.Domain.Seedwork;
using System.Collections.Generic;
using System.Linq;

namespace Aritter.Domain.Security.Aggregates.Users
{
    public class Role : Entity
    {
        public Role()
        {
            Users = new HashSet<User>();
            Authorizations = new HashSet<Authorization>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Authorization> Authorizations { get; set; }

        public void AddMember(User user)
        {
            if (Users.All(p => p.UserName != user.UserName))
            {
                Users.Add(user);
            }
        }
    }
}
