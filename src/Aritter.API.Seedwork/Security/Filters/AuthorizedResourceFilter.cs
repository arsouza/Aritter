using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;

namespace Aritter.API.Seedwork.Security.Filters
{
    public sealed class AuthorizedResourceFilter : AuthorizeFilter
    {
        public AuthorizedResourceFilter(AuthorizationPolicy policy)
            : base(policy)
        {
        }

        public AuthorizedResourceFilter(IEnumerable<IAuthorizeData> authorizeData)
            : base(authorizeData)
        {
        }

        public AuthorizedResourceFilter(string policy)
            : base(policy)
        {
        }

        public AuthorizedResourceFilter(IAuthorizationPolicyProvider policyProvider, IEnumerable<IAuthorizeData> authorizeData)
            : base(policyProvider, authorizeData)
        {
        }

        public override Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            return base.OnAuthorizationAsync(context);
        }
    }
}
