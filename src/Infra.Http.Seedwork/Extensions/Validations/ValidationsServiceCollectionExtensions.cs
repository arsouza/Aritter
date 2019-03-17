using Ritter.Infra.Crosscutting;
using Ritter.Infra.Crosscutting.Validations;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ValidationsServiceCollectionExtensions
    {
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
