using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Ritter.Application.Seedwork.Services;
using Ritter.Domain.Seedwork;
using Ritter.Infra.Crosscutting.Extensions;
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

        private static IServiceCollection RegisterAllServices<TService>(this IServiceCollection services, Action<Type, Type> registrationAction)
            where TService : class
        {
            return services.RegisterAllServices<TService, TService>(registrationAction);
        }

        private static IServiceCollection RegisterAllServices<TService, TServiceSource>(this IServiceCollection services, Action<Type, Type> registrationAction)
            where TService : class
        {
            Type sourceType = typeof(TService);
            Assembly assembly = typeof(TServiceSource).Assembly;

            assembly.GetTypes()
                .Where(type => type.IsClass && !type.IsAbstract && sourceType.IsAssignableFrom(type))
                .Select(type => new
                {
                    Service = type.GetInterfaces().Last(),
                    Implementation = type
                })
                .ForEach(registration =>
                {
                    registrationAction?.Invoke(registration.Service, registration.Implementation);
                });

            return services;
        }
    }
}
