using Aritter.Domain.Seedwork;
using Aritter.Infra.Crosscutting.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace Aritter.Domain.Security.Aggregates
{
    public class Role : Entity
    {
        public Role(string name, Application application)
            : this()
        {
            if (application == null)
            {
                ThrowHelper.ThrowApplicationException("Invalid application");
            }

            Name = name;
            Application = application;
            ApplicationId = application.Id;
        }

        public Role(string name, string description, Application application)
            : this(name, application)
        {
            Description = description;
        }

        private Role()
            : base()
        {
        }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public int ApplicationId { get; private set; }

        public virtual Application Application { get; private set; }

        public virtual ICollection<Authorization> Authorizations { get; private set; } = new HashSet<Authorization>();

        public virtual ICollection<UserRole> Members { get; private set; } = new HashSet<UserRole>();

        public void AddMember(User user)
        {
            if (user == null)
            {
                ThrowHelper.ThrowApplicationException("Invalid user user");
            }

            if (Members.All(p => p.User != user))
            {
                Members.Add(new UserRole(this, user));
            }
        }
    }
}
