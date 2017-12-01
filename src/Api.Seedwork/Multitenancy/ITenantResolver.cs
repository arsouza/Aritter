using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Ritter.Api.Seedwork.Multitenancy
{
    public interface ITenantResolver<TTenant>
    {
        Task<TenantContext<TTenant>> ResolveAsync(HttpContext context);
    }
}