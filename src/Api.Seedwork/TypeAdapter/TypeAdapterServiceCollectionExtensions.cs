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

        public static IServiceCollection AddTypeAdapter<TTypeAdapterFactory>(this IServiceCollection services)
            where TTypeAdapterFactory : class, ITypeAdapter, new()
        {
            services.AddSingleton<ITypeAdapter, TTypeAdapterFactory>();
            return services;
        }
    }
}
