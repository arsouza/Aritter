using Ritter.Infra.Crosscutting.Validations;

namespace Microsoft.AspNetCore.Builder
{
    public static class ValidationsApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseValidatorFactory(this IApplicationBuilder app)
        {
            IEntityValidatorFactory validatorFactory = app.ApplicationServices.GetService(typeof(IEntityValidatorFactory)) as IEntityValidatorFactory;
            EntityValidatorFactory.UseFactory(validatorFactory);

            return app;
        }
    }
}
