using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;

namespace Aritter.API.Seedwork.Security.Providers
{
    public sealed class IdentityProviderContext : FilterContext
    {
        public IdentityProviderContext(ActionContext actionContext, IList<IFilterMetadata> filters)
            : base(actionContext, filters)
        {
            Username = HttpContext.Request.Form["username"];
            Password = HttpContext.Request.Form["password"];
        }

        public string Username { get; private set; }
        public string Password { get; private set; }
    }
}
