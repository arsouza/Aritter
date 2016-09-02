using Aritter.Domain.Seedwork;
using Aritter.Infra.Crosscutting.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace Aritter.Domain.Security.Aggregates
{
    public class Role : Entity
    {
        public Role(string name)
            : this()
        {
            Name = name;
        }

        public Role(string name, string description)
            : this(name)
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

        public virtual ICollection<RoleMember> Members { get; private set; } = new HashSet<RoleMember>();

        public void AddMember(UserAccount account)
        {
            if (account == null)
            {
                ThrowHelper.ThrowApplicationException("Invalid user account");
            }

            if (Members.All(p => p.Member != account))
            {
                Members.Add(new RoleMember(this, account));
            }
        }

        public void SetApplication(Application application)
        {
            if (application == null)
            {
                ThrowHelper.ThrowApplicationException("Invalid application");
            }

            Application = application;
            ApplicationId = application.Id;
        }

        public void Authorize(Permission permission)
        {
            if (permission == null)
            {
                ThrowHelper.ThrowApplicationException("Invalid permission");
            }

            var authorization = GetAuthorization(this, permission);
            authorization.Authorize();
        }

        public void Deny(Permission permission)
        {
            if (permission == null)
            {
                ThrowHelper.ThrowApplicationException("Invalid permission");
            }

            var authorization = GetAuthorization(this, permission);
            authorization.Deny();
        }

        private Authorization GetAuthorization(Role role, Permission permission)
        {
            var authorization = permission.Authorizations.FirstOrDefault(p => p.Role == this && p.Permission == permission);

            if (authorization == null)
            {
                role.Authorizations.Add(Authorization.CreateAuthorization(this, permission));
            }

            return authorization;
        }

        public static Role CreateRole(string name, Application application)
        {
            return CreateRole(name, null, application);
        }

        public static Role CreateRole(string name, string description, Application application)
        {
            var userRole = new Role(name, description);
            userRole.SetApplication(application);

            return userRole;
        }
    }
}
