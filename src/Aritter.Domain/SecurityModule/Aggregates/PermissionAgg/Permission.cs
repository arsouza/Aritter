using Aritter.Domain.SecurityModule.Aggregates.ModuleAgg;
using Aritter.Domain.Seedwork;
using System.Collections.Generic;

namespace Aritter.Domain.SecurityModule.Aggregates.PermissionAgg
{
    public class Permission : Entity
    {
        public Permission(Resource resource, Operation operation)
            : this()
        {
            Resource = resource;
            Operation = operation;

            ResourceId = resource.Id;
            OperationId = operation.Id;
        }

        private Permission()
            : base()
        {
        }

        public int ResourceId { get; private set; }
        public int OperationId { get; private set; }

        public virtual Operation Operation { get; private set; }
        public virtual Resource Resource { get; private set; }
        public virtual ICollection<Authorization> Authorizations { get; private set; } = new HashSet<Authorization>();

        public void Authorize(Role role)
        {
            var authorization = AuthorizationFactory.CreateAuthorization(this, role);
            Authorizations.Add(authorization);
        }
    }
}
