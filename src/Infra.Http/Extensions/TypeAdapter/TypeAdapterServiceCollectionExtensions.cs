using Ritter.Infra.Crosscutting;
using Ritter.Infra.Crosscutting.TypeAdapter;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class TypeAdapterServiceCollectionExtensions
    {
        public static IServiceCollection AddTypeAdapter(this IServiceCollection services, ITypeAdapter typeAdapterFactory)
        {
            Ensure.Argument.NotNull(typeAdapterFactory, nameof(typeAdapterFactory));
            services.AddSingleton(typeof(ITypeAdapter), typeAdapterFactory);
            return services;
        }

        public static IServiceCollection AddTypeAdapter<TTypeAdapter>(this IServiceCollection services)
            where TTypeAdapter : class, ITypeAdapter, new()
        {
            services.AddSingleton<ITypeAdapter, TTypeAdapter>();
            return services;
        }
    }
}
