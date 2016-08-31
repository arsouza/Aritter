using Aritter.Infra.Crosscutting.Exceptions;
using Newtonsoft.Json;
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
        public Permission Permission { get; private set; }

        public AuthorizationAttribute()
        {
            Permission = new Permission();
        }

        public AuthorizationAttribute(string client, string resource, params Rule[] rules)
            : this()
        {
            if (string.IsNullOrEmpty(client))
            {
                ThrowHelper.ThrowArgumentNullException(nameof(client));
            }

            if (string.IsNullOrEmpty(resource))
            {
                ThrowHelper.ThrowArgumentNullException(nameof(resource));
            }

            Permission.Client = client;
            Permission.Resource = resource;
            Permission.Authorizations = rules.ToList();
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

            if (!Permission.Authorizations.Any())
            {
                return true;
            }

            ClaimsIdentity identity = GetCurrentIdentity();

            var claims = GetUserClaims(identity, ClaimTypes.Permission);

            return claims.Any(HasAuthorizedClaim);
        }

        private bool HasAuthorizedClaim(Claim claim)
        {
            var permission = JsonConvert.DeserializeObject<Permission>(claim.Value);

            return permission != null
                && Permission.Client == permission.Client
                && Permission.Resource == permission.Resource
                && Permission.Authorizations.Intersect(permission.Authorizations).Any();
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