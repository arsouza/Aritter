using Aritter.Domain.Seedwork;
using Aritter.Infra.Crosscutting.Exceptions;
using System.Collections.Generic;

namespace Aritter.Domain.Security.Aggregates
{
    public class Permission : Entity
    {
        public Permission()
            : base()
        {
        }

        public int ResourceId { get; private set; }

        public int RuleId { get; private set; }

        public virtual Rule Rule { get; private set; }

        public virtual Resource Resource { get; private set; }

        public virtual ICollection<Authorization> Authorizations { get; private set; } = new HashSet<Authorization>();

        public void Authorize(Role role)
        {
            Authorizations.Add(Authorization.CreateAuthorization(role, this));
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

        public void SetRule(Rule rule)
        {
            if (rule == null)
            {
                ThrowHelper.ThrowApplicationException("Invalid rule");
            }

            Rule = rule;
            RuleId = rule.Id;
        }

        public static Permission CreatePermission(Resource resource, Rule rule)
        {
            var permission = new Permission();
            permission.SetResource(resource);
            permission.SetRule(rule);

            return permission;
        }
    }
}
