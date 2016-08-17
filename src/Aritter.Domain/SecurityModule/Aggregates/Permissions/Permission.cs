using Aritter.Domain.SecurityModule.Aggregates.Modules;
using Aritter.Domain.Seedwork;
using Aritter.Infra.Crosscutting.Exceptions;
using System.Collections.Generic;

namespace Aritter.Domain.SecurityModule.Aggregates.Permissions
{
    public class Permission : Entity
    {
        public Permission()
            : base()
        {
        }

        public int ResourceId { get; private set; }
        public int OperationId { get; private set; }

        public virtual Operation Operation { get; private set; }
        public virtual Resource Resource { get; private set; }
        public virtual ICollection<Authorization> Authorizations { get; private set; } = new HashSet<Authorization>();

        public void Authorize(UserRole role)
        {
            var authorization = AuthorizationFactory.CreateAuthorization(role, this);
            Authorizations.Add(authorization);
        }

        public void SetResource(Resource resource)
        {
            if (resource == null)
            {
                ThrowHelper.ThrowApplicationException("Invalid resource");
            }

            Resource = resource;
            ResourceId = resource.Id;
        }

        public void SetOperation(Operation operation)
        {
            if (operation == null)
            {
                ThrowHelper.ThrowApplicationException("Invalid operation");
            }

            Operation = operation;
            OperationId = operation.Id;
        }
    }
}
