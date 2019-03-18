using Ritter.Infra.Crosscutting;
using Ritter.Infra.Crosscutting.TypeAdapter;
using Ritter.Infra.Crosscutting.Validations;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
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

        public static IServiceCollection AddValidatorFactory(this IServiceCollection services, IEntityValidatorFactory validatorFactory)
        {
            Ensure.Argument.NotNull(validatorFactory, nameof(validatorFactory));
            services.AddSingleton(typeof(IEntityValidatorFactory), validatorFactory);
            return services;
        }

        public static IServiceCollection AddValidatorFactory<TEntityValidatorFactory>(this IServiceCollection services)
            where TEntityValidatorFactory : class, IEntityValidatorFactory, new()
        {
            services.AddSingleton<IEntityValidatorFactory, TEntityValidatorFactory>();
            return services;
        }
    }
}
