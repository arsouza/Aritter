using Ritter.Infra.Crosscutting.TypeAdapter;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseTypeAdapterFactory(this IApplicationBuilder app)
        {
            var typeAdapterFactory = app.ApplicationServices.GetService(typeof(ITypeAdapterFactory)) as ITypeAdapterFactory;
            TypeAdapterFactory.UseFactory(typeAdapterFactory);

            return app;
        }
    }
}
