using Ritter.Infra.Crosscutting.Extensions;
using System;
using System.Linq;
using System.Reflection;

namespace Ritter.Samples.IoC
{
    public class RegistrationBuilder
    {
        public RegistrationBuilder(Assembly assembly)
        {
            Assembly = assembly ?? throw new ArgumentNullException(nameof(assembly));
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
