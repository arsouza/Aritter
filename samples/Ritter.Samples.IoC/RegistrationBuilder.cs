using Ritter.Infra.Crosscutting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Ritter.Samples.IoC
{
    public class RegistrationBuilder
    {
        public RegistrationBuilder(Assembly assembly)
        {
            Ensure.Argument.NotNull(assembly, nameof(assembly));
            Assembly = assembly;
        }

        public Assembly Assembly { get; }

        public RegistrationBuilder AddAll<TService>(Action<Type, Type> registrationAction)
            where TService : class
        {
            Type serviceType = typeof(TService);
            ConfigureTypes(serviceType, Assembly, registrationAction);

            return this;
        }

        private static void ConfigureTypes(Type serviceType, Assembly assembly, Action<Type, Type> registrationAction)
        {
            assembly.GetTypes()
                .Where(type => type.IsClass && !type.IsAbstract && serviceType.IsAssignableFrom(type))
                .Select(type => new { Service = type.GetInterfaces().Last(), Implementation = type })
                .ForEach(registration => registrationAction?.Invoke(registration.Service, registration.Implementation));
        }
    }
}
