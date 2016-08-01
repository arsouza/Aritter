using Aritter.Domain.SecurityModule.Aggregates.ModuleAgg;
using Aritter.Domain.SecurityModule.Aggregates.UserAgg;
using Aritter.Domain.Seedwork;
using System.Collections.Generic;
using System.Linq;

namespace Aritter.Domain.SecurityModule.Aggregates.PermissionAgg
{
    public class Role : Entity
    {
        public Role(string name)
            : this(name, null)
        {
        }

        public Role(string name, string description)
            : this()
        {
            Name = name;
            Description = description;
        }

        private Role()
            : base()
        {
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public int ApplicationId { get; private set; }

        public virtual ICollection<Authorization> Authorizations { get; private set; } = new HashSet<Authorization>();
        public virtual ICollection<UserAssignment> UserAssignments { get; private set; } = new HashSet<UserAssignment>();
        public virtual Application Application { get; private set; }

        public void AddMember(User user)
        {
            if (UserAssignments.All(p => p != user))
            {
                var userAssignment = new UserAssignment(this, user);
                UserAssignments.Add(userAssignment);
            }
        }
    }
}
