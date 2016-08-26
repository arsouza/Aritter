using Aritter.Domain.Seedwork;
using Aritter.Infra.Crosscutting.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace Aritter.Domain.SecurityModule.Aggregates
{
    public class UserRole : Entity
    {
        public UserRole(string name)
            : this()
        {
            Name = name;
        }

        public UserRole(string name, string description)
            : this(name)
        {
            Description = description;
        }

        private UserRole()
            : base()
        {
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public int ClientId { get; private set; }

        public virtual ICollection<Authorization> Authorizations { get; private set; } = new HashSet<Authorization>();
        public virtual ICollection<UserAssignment> UserAssignments { get; private set; } = new HashSet<UserAssignment>();
        public virtual Client Client { get; private set; }

        public void AddMember(UserAccount userAccount)
        {
            if (userAccount == null)
            {
                ThrowHelper.ThrowApplicationException("Invalid user account");
            }

            if (UserAssignments.All(p => p != userAccount))
            {
                var userAssignment = new UserAssignment(this, userAccount);
                UserAssignments.Add(userAssignment);
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

        private Authorization GetAuthorization(UserRole userRole, Permission permission)
        {
            var authorization = permission.Authorizations.FirstOrDefault(p => p.UserRole == this && p.Permission == permission);

            if (authorization == null)
            {
                authorization = AuthorizationFactory.CreateAuthorization(this, permission);
                userRole.Authorizations.Add(authorization);
            }

            return authorization;
        }
    }
}
