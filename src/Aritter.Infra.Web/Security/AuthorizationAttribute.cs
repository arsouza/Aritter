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
        private readonly Dictionary<string, Rule[]> permissions;

        public AuthorizationAttribute()
        {
            permissions = new Dictionary<string, Rule[]>();
        }

        public AuthorizationAttribute(string permission, params Rule[] rules)
            : this()
        {
            permissions.Add(permission, rules);
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

            var claims = GetUserClaims(identity, Claims.Permission);

            return claims.Any(HasAuthorizedClaim);
        }

        private bool HasAuthorizedClaim(Claim claim)
        {
            var claimParts = claim.Value.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

            var permission = claimParts[0];
            var rule = (Rule)Enum.Parse(typeof(Rule), claimParts[1]);

            return
                permissions.ContainsKey(permission)
                && permissions[permission].Contains(rule);
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