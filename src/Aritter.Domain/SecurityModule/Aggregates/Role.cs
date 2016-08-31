using Aritter.Domain.Seedwork;
using Aritter.Infra.Crosscutting.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace Aritter.Domain.SecurityModule.Aggregates
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

        public int ClientId { get; private set; }

        public virtual Client Client { get; private set; }

        public virtual ICollection<Authorization> Authorizations { get; private set; } = new HashSet<Authorization>();

        public virtual ICollection<UserAssignment> Members { get; private set; } = new HashSet<UserAssignment>();

        public void AddMember(UserAccount account)
        {
            if (account == null)
            {
                ThrowHelper.ThrowApplicationException("Invalid user account");
            }

            if (Members.All(p => p != account))
            {
                Members.Add(new UserAssignment(this, account));
            }
        }

        public void SetClient(Client client)
        {
            if (client == null)
            {
                ThrowHelper.ThrowApplicationException("Invalid client");
            }

            Client = client;
            ClientId = client.Id;
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
                role.Authorizations.Add(AuthorizationFactory.CreateAuthorization(this, permission));
            }

            return authorization;
        }
    }
}
