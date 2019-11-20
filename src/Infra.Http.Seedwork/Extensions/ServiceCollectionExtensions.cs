using Ritter.Infra.Crosscutting;
using Ritter.Infra.Crosscutting.Validations;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddValidatorFactory(this IServiceCollection services, IEntityValidatorFactory validatorFactory)
        {
            Ensure.Argument.NotNull(validatorFactory, nameof(validatorFactory));

            services.AddSingleton(typeof(IEntityValidatorFactory), validatorFactory);
            services.AddSingleton(factory => factory.GetService<IEntityValidatorFactory>().Create());

            return services;
        }

        public static IServiceCollection AddValidatorFactory<TEntityValidatorFactory>(this IServiceCollection services)
            where TEntityValidatorFactory : class, IEntityValidatorFactory, new()
        {
            return services.AddValidatorFactory(new TEntityValidatorFactory());
        }
    }
}
