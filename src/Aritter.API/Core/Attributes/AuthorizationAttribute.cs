using Aritter.API.Core.Providers;
using Aritter.Infra.CrossCutting.Security;
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

namespace Aritter.API.Core.Attributes
{
    internal sealed class AuthorizationAttribute : AuthorizeAttribute
    {
        private readonly string permission;
        private readonly Rule[] rules;

        public AuthorizationAttribute()
        {
        }

        public AuthorizationAttribute(string permission, params Rule[] rules)
        {
            this.permission = permission;
            this.rules = rules;
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);

            var isAuthorized = ValidateAuthorization();

            if (isAuthorized)
                return;

            Forbidden(actionContext);
        }

        private bool ValidateAuthorization()
        {
            if (rules == null || !rules.Any())
            {
                return true;
            }

            var identity = GetCurrentIdentity();
            var userClaims = GetUserClaims(identity);

            if (userClaims.Any(a => IsAuthorizedClaim(a)))
            {
                return true;
            }

            return false;
        }

        private bool IsAuthorizedClaim(Claim claim)
        {
            var claimParts = claim.Value.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

            var claimPermission = claimParts[0];
            var claimRule = (Rule)Enum.Parse(typeof(Rule), claimParts[1]);

            return
                claimPermission.Equals(permission, StringComparison.InvariantCulture)
                && rules.Contains(claimRule);
        }

        private IEnumerable<Claim> GetUserClaims(ClaimsIdentity identity)
        {
            return identity.Claims.Where(claim => ClaimConstants.Permission.Equals(claim.Type, StringComparison.InvariantCulture)).ToList();
        }

        private ClaimsIdentity GetCurrentIdentity()
        {
            if (HttpContext.Current != null)
                return HttpContext.Current.User.Identity as ClaimsIdentity;

            return Thread.CurrentPrincipal.Identity as ClaimsIdentity;
        }

        private void Forbidden(HttpActionContext actionContext)
        {
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden);
        }
    }
}
