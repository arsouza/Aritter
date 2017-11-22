using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Ritter.Application.Seedwork.Services;
using Ritter.Domain.Seedwork;
using Ritter.Infra.Data.Seedwork;
using Ritter.Samples.Application;
using Ritter.Samples.Infra.Data;

namespace Ritter.Samples.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, Action<RegistrationOptions> setupAction)
        {
            RegistrationOptions options = new RegistrationOptions();
            setupAction?.Invoke(options);

            Action<DbContextOptionsBuilder> dbContextOptionsBuilder = (builder) =>
            {
                builder.UseSqlServer(options.ConnectionString);
                builder.EnableSensitiveDataLogging();
            };

            services.AddDbContext<UnitOfWork>(dbContextOptionsBuilder, ServiceLifetime.Transient);
            services.AddTransient<IQueryableUnitOfWork>(provider => provider.GetService<UnitOfWork>());
            services.RegisterAllServices<IRepository, EmployeeRepository>((service, implementation) => services.AddTransient(service, implementation));
            services.RegisterAllServices<IAppService, EmployeeAppService>((service, implementation) => services.AddTransient(service, implementation));

            return services;
        }

        private static IServiceCollection RegisterAllServices<TServiceBase>(this IServiceCollection services, Action<Type, Type> registrationAction)
            where TServiceBase : class
        {
            return services.RegisterAllServices<TServiceBase, TServiceBase>(registrationAction);
        }

        private static IServiceCollection RegisterAllServices<TServiceBase, TAssemblySource>(this IServiceCollection services, Action<Type, Type> registrationAction)
            where TServiceBase : class
        {
            Type serviceType;
            Type serviceBaseType = typeof(TServiceBase);

            Assembly assembly = typeof(TAssemblySource).Assembly;

            var types = assembly.GetTypes()
                .Where(type => serviceBaseType.IsAssignableFrom(type)
                       && type.GetTypeInfo().IsClass
                       && !type.GetTypeInfo().IsAbstract);

            foreach (var implementationType in types)
            {
                serviceType = implementationType.GetInterfaces().Last();
                registrationAction?.Invoke(serviceType, implementationType);
            }

            return services;
        }
    }
}
