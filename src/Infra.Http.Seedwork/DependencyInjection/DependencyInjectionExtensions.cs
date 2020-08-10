using System;
using System.Linq;
using System.Reflection;
using Ritter.Infra.Crosscutting;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static void RegisterAllTypesOf<TService>(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Scoped)
            where TService : class
        {
            Type serviceType = typeof(TService);
            services.RegisterAllTypes(serviceType, serviceType.Assembly, lifetime);
        }

        public static void RegisterAllTypesOf<TService>(this IServiceCollection services, Assembly assembly, ServiceLifetime lifetime = ServiceLifetime.Scoped)
            where TService : class
        {
            Ensure.Argument.NotNull(assembly, nameof(assembly));
            services.RegisterAllTypes(typeof(TService), assembly, lifetime);
        }

        public static void RegisterAllTypes(this IServiceCollection services, Type serviceType, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            Ensure.Argument.NotNull(serviceType, nameof(serviceType));
            services.RegisterAllTypes(serviceType, serviceType.Assembly, lifetime);
        }

        public static void RegisterAllTypes(this IServiceCollection services, Type serviceType, Assembly assembly, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            Ensure.Argument.NotNull(serviceType, nameof(serviceType));
            Ensure.Argument.NotNull(assembly, nameof(assembly));

            var types = assembly.GetTypes()
               .Where(
                   type => type.IsClass
                   && !type.IsAbstract
                   && serviceType.IsAssignableFrom(type))
               .Select(
                   type => new
                   {
                       Service = type.GetInterfaces().Last(),
                       Implementation = type
                   })
               .ToList();

            types.ForEach(registration =>
            {
                services.Add(new ServiceDescriptor(
                    registration.Service,
                    registration.Implementation,
                    lifetime));
            });
        }
    }
}
