using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;

namespace Aritter.API.Seedwork.Security.Providers
{
    public sealed class IdentityProviderContext : FilterContext
    {
        public IdentityProviderContext(HttpContext httpContext)
            : base(new ActionContext(httpContext, new RouteData(), new ActionDescriptor()), new List<IFilterMetadata>())
        {
            Username = HttpContext.Request.Form["username"];
            Password = HttpContext.Request.Form["password"];
        }

        public string Username { get; private set; }
        public string Password { get; private set; }
    }
}
