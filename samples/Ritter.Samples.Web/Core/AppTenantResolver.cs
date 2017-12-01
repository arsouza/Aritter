using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Ritter.Api.Seedwork.Multitenancy;

namespace Ritter.Samples.Web.Core
{
    public class AppTenantResolver : ITenantResolver<AppTenant>
    {
        IEnumerable<AppTenant> tenants = new List<AppTenant>(new []
        {
            new AppTenant
            {
                Name = "Tenant 1",
                Hostnames = new [] { "localhost:5000" }
            },
            new AppTenant
            {
                Name = "Tenant 2",
                Hostnames = new [] { "localhost:5001" }
            }
        });

        public async Task<TenantContext<AppTenant>> ResolveAsync(HttpContext context)
        {
            return await Task.Run(() =>
            {
                TenantContext<AppTenant> tenantContext = null;

                var tenant = tenants.FirstOrDefault(t => t.Hostnames.Any(h => h.Equals(context.Request.Host.Value.ToLower())));

                if (tenant != null)
                    tenantContext = new TenantContext<AppTenant>(tenant);

                return tenantContext;
            });
        }
    }
}