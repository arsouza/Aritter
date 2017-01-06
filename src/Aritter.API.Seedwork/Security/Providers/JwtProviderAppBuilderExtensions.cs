using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;

namespace Aritter.API.Seedwork.Security.Providers
{
    /// <summary>
    /// Adds a token generation endpoint to an application pipeline.
    /// </summary>
    public static class JwtProviderAppBuilderExtensions
    {
        /// <summary>
        /// Adds the <see cref="JwtProviderMiddleware"/> middleware to the specified <see cref="IApplicationBuilder"/>, which enables token generation capabilities.
        /// <param name="app">The <see cref="IApplicationBuilder"/> to add the middleware to.</param>
        /// <param name="options">A  <see cref="JwtProviderOptions"/> that specifies options for the middleware.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IApplicationBuilder UseJwtProvider(this IApplicationBuilder app, JwtProviderOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            return app.UseMiddleware<JwtProviderMiddleware>(Options.Create(options));
        }
    }
}
