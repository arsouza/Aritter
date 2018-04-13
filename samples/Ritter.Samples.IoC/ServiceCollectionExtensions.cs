using Domain.Seedwork.Validation.Caching;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Ritter.Application.Seedwork.Services;
using Ritter.Domain.Seedwork;
using Ritter.Domain.Seedwork.Validation.Fluent;
using Ritter.Infra.Data.Seedwork;
using Ritter.Samples.Application;
using Ritter.Samples.Infra.Data;
using Ritter.Samples.IoC;
using System;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services, string connectionString)
        {
            void optionsBuilder(DbContextOptionsBuilder options)
            {
                options.UseNpgsql(connectionString);
                options.EnableSensitiveDataLogging();
            }

            services.AddEntityFrameworkNpgsql().AddDbContext<UnitOfWork>(optionsBuilder, ServiceLifetime.Transient);
            services.AddTransient<IQueryableUnitOfWork>(provider => provider.GetService<UnitOfWork>());

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.FromAssembly<EmployeeRepository>().AddAll<IRepository>((service, implementation) => services.AddTransient(service, implementation));
            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.FromAssembly<EmployeeAppService>().AddAll<IAppService>((service, implementation) => services.AddTransient(service, implementation));
            services.AddTransient<IFluentValidator, FluentValidator>();

            return services;
        }

        public static IServiceCollection AddCachingProviders(this IServiceCollection services)
        {
            services.AddSingleton<IValidationContractCacheProvider, ValidationContractCacheProvider>();
            return services;
        }

        private static RegistrationBuilder FromAssembly<TServiceSource>(this IServiceCollection services)
            where TServiceSource : class
        {
            Assembly assembly = typeof(TServiceSource).Assembly;
            return new RegistrationBuilder(assembly);
        }

        private static RegistrationBuilder AddAll<TService>(this IServiceCollection services, Action<Type, Type> registrationAction)
        where TService : class
        {
            Assembly assembly = typeof(TService).Assembly;
            RegistrationBuilder builder = new RegistrationBuilder(assembly);
            builder.AddAll<TService>(registrationAction);

            return builder;
        }
    }
}
