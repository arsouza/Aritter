using Aritter.Domain.Seedwork;
using Aritter.Infra.Crosscutting.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace Aritter.Domain.Security.Aggregates
{
    public class Permission : Entity
    {
        public Permission()
            : base()
        {
        }

        public Permission(Resource resource, Rule rule)
            : this()
        {
            if (resource == null)
            {
                ThrowHelper.ThrowApplicationException("Invalid resource");
            }

            if (rule == null)
            {
                ThrowHelper.ThrowApplicationException("Invalid rule");
            }

            RuleId = rule.Id;
            ResourceId = resource.Id;

            Rule = rule;
            Resource = resource;
        }

        public int ResourceId { get; private set; }

        public int RuleId { get; private set; }

        public virtual Rule Rule { get; private set; }

        public virtual Resource Resource { get; private set; }

        public virtual ICollection<Authorization> Authorizations { get; private set; } = new HashSet<Authorization>();

        public void Authorize(Role role)
        {
            var authorization = Authorizations.FirstOrDefault();

            if (authorization == null)
            {
                authorization = new Authorization(this, role);
                authorization.Allow();
                Authorizations.Add(authorization);
            }
            else
            {
                authorization.Allow();
            }
        }

        public void Deny(Role role)
        {
            var authorization = Authorizations.FirstOrDefault();

            if (authorization == null)
            {
                authorization = new Authorization(this, role);
                authorization.Deny();
                Authorizations.Add(authorization);
            }
            else
            {
                authorization.Deny();
            }
        }
    }
}
