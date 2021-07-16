using Ritter.Infra.Crosscutting;
using Ritter.Infra.Crosscutting.Adapters;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        //public static IServiceCollection AddValidatorFactory(this IServiceCollection services, IEntityValidatorFactory validatorFactory)
        //{
        //    Ensure.ArgumentNotNull(validatorFactory, nameof(validatorFactory));

        //    services.AddSingleton(typeof(IEntityValidatorFactory), validatorFactory);
        //    services.AddSingleton(factory => factory.GetService<IEntityValidatorFactory>().Create());

        //    return services;
        //}

        //public static IServiceCollection AddValidatorFactory<TEntityValidatorFactory>(this IServiceCollection services)
        //    where TEntityValidatorFactory : class, IEntityValidatorFactory, new()
        //{
        //    return services.AddValidatorFactory(new TEntityValidatorFactory());
        //}

        public static IServiceCollection AddTypeAdapterFactory(this IServiceCollection services, ITypeAdapterFactory typeAdapterFactory)
        {
            Ensure.ArgumentNotNull(typeAdapterFactory, nameof(typeAdapterFactory));

            services.AddSingleton(typeof(ITypeAdapterFactory), typeAdapterFactory);
            services.AddSingleton(factory => factory.GetService<ITypeAdapterFactory>().Create());

            return services;
        }

        public static IServiceCollection AddTypeAdapterFactory<TTypeAdapterFactory>(this IServiceCollection services)
            where TTypeAdapterFactory : class, ITypeAdapterFactory
        {
            services.AddSingleton<ITypeAdapterFactory, TTypeAdapterFactory>();
            services.AddSingleton(factory => factory.GetService<ITypeAdapterFactory>().Create());

            return services;
        }
    }
}
