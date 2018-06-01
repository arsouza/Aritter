using Ritter.Infra.Crosscutting.TypeAdapter;
using System;

namespace Microsoft.AspNetCore.Builder
{
    public static class TypeAdapterApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseTypeAdapterFactory(this IApplicationBuilder app)
        {
            TypeAdapterFactory.SetCurrent(app.ApplicationServices.GetService<ITypeAdapterFactory>());
            return app;
        }
    }
}
