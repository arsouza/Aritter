using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Ritter.Infra.Http.Seedwork.DependencyInjection
{
    public class RegistrationBuilder
    {
        public static void RegisterAll<TService>(Action<Type, Type> registrationAction)
            where TService : class
        {
            RegisterAll<TService, TService>(registrationAction);
        }

        public static void RegisterAll<TService, TAssemblySourceType>(Action<Type, Type> registrationAction)
            where TService : class
        {
            Type serviceType = typeof(TService);
            Type assemblySourceType = typeof(TAssemblySourceType);

            RegisterServices(serviceType.Assembly, serviceType, registrationAction);
        }

        private static void RegisterServices(Assembly assembly, Type serviceType, Action<Type, Type> registrationAction)
        {
            assembly.GetTypes()
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
                .ForEach(registration => registrationAction?.Invoke(registration.Service, registration.Implementation));
        }
    }
}
