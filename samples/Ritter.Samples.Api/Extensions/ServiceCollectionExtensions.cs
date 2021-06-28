using Microsoft.Extensions.DependencyInjection;
using Ritter.Samples.Application.Adapters;

namespace Ritter.Samples.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAutoMapperTypeAdapter(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperAdapterFactory).Assembly);
            services.AddTypeAdapterFactory<AutoMapperAdapterFactory>();

            return services;
        }
    }
}
