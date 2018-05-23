using Ritter.Infra.Crosscutting;
using Ritter.Infra.Crosscutting.TypeAdapter;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class TypeAdapterServiceCollectionExtensions
    {
        public static IServiceCollection AddTypeAdapterFactory(this IServiceCollection services, ITypeAdapterFactory typeAdapterFactory)
        {
            Ensure.Argument.NotNull(typeAdapterFactory, nameof(typeAdapterFactory));
            services.AddSingleton(typeof(ITypeAdapterFactory), typeAdapterFactory);
            return services;
        }

        public static IServiceCollection AddTypeAdapterFactory<TTypeAdapterFactory>(this IServiceCollection services)
            where TTypeAdapterFactory : class, ITypeAdapterFactory, new()
        {
            services.AddSingleton<ITypeAdapterFactory, TTypeAdapterFactory>();
            return services;
        }
    }
}
