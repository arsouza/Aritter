using Aritter.Infra.Crosscutting.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Aritter.Infra.Web.Security
{
    public sealed class AuthorizationAttribute : AuthorizeAttribute
    {
        private readonly Dictionary<string, Dictionary<string, Rule[]>> permissions;

        public AuthorizationAttribute()
        {
            permissions = new Dictionary<string, Dictionary<string, Rule[]>>();
        }

        public AuthorizationAttribute(string application, string resource, params Rule[] rules)
            : this()
        {
            var permission = new Dictionary<string, Rule[]>()
            {
                { resource, rules }
            };

            permissions.Add(application, permission);
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);

            if (!IsAuthorized(actionContext))
            {
                Forbidden(actionContext);
            }
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            if (!base.IsAuthorized(actionContext))
            {
                return false;
            }

            if (!permissions.Any())
            {
                return true;
            }

            ClaimsIdentity identity = GetCurrentIdentity();

            var claims = GetUserClaims(identity, ClaimTypes.Permission);

            return claims.Any(HasAuthorizedClaim);
        }

        private bool HasAuthorizedClaim(Claim claim)
        {
            var values = claim.Value.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

            var application = values[0];
            var resource = values[1];
            var rule = (Rule)Enum.Parse(typeof(Rule), values[2]);

            return
                permissions.ContainsKey(application)
                && permissions[application].ContainsKey(resource)
                && permissions[application][resource].Contains(rule);
        }

        private IEnumerable<Claim> GetUserClaims(ClaimsIdentity identity, string claimType)
        {
            return identity.Claims.Where(claim => claimType.Equals(claim.Type, StringComparison.InvariantCulture)).ToList();
        }

        private ClaimsIdentity GetCurrentIdentity()
        {
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.User.Identity as ClaimsIdentity;
            }

            return Thread.CurrentPrincipal.Identity as ClaimsIdentity;
        }

        private static void Forbidden(HttpActionContext actionContext)
        {
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden);
        }
    }
}