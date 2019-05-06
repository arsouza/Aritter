using Microsoft.Extensions.Configuration;
using Ritter.Infra.Http.Settings;

namespace Ritter.Infra.Http.Extensions
{
    public static class ConfigurationExtensions
    {
        public static string[] GetCorsOrigins(this IConfiguration configuration)
        {
            CorsSettings setting = configuration.GetSection(typeof(CorsSettings).Name).Get<CorsSettings>();
            return setting?.AllowedOrigins ?? new string[] { };
        }
    }
}
