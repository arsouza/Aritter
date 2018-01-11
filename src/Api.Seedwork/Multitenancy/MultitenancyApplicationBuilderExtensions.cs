using Ritter.Api.Seedwork.Multitenancy;
using Ritter.Infra.Crosscutting;

namespace Microsoft.AspNetCore.Builder
{
    public static class MultitenancyApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseMultitenancy<TTenant>(this IApplicationBuilder app)
        {
            Ensure.Argument.NotNull(app, nameof(app));
            return app.UseMiddleware<TenantResolutionMiddleware<TTenant>>();
        }
    }
}