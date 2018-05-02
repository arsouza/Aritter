using Ritter.Domain.Validation.Caching;
using Microsoft.EntityFrameworkCore;
using Ritter.Application.Services;
using Ritter.Domain;
using Ritter.Domain.Validation.Fluent;
using Ritter.Infra.Data;
using Ritter.Samples.Application;
using Ritter.Samples.Infra.Data;
using Ritter.Samples.IoC;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, string connectionString)
        {
            void optionsBuilder(DbContextOptionsBuilder options)
            {
                options.UseSqlServer(connectionString);
                options.EnableSensitiveDataLogging();
            }

            services.AddEntityFrameworkSqlServer().AddDbContext<UnitOfWork>(optionsBuilder, ServiceLifetime.Transient);
            services.AddTransient<IQueryableUnitOfWork>(provider => provider.GetService<UnitOfWork>());
            services.AddTransient<IFluentValidator, FluentValidator>();
            services.AddSingleton<IValidationContractCacheProvider, ValidationContractCacheProvider>();

            services.FromAssembly<EmployeeRepository>().AddAll<IRepository>((service, implementation)
                => services.AddTransient(service, implementation));
            services.FromAssembly<EmployeeAppService>().AddAll<IAppService>((service, implementation)
                => services.AddTransient(service, implementation));

            return services;
        }

        private static RegistrationBuilder FromAssembly<TServiceSource>(this IServiceCollection services)
            where TServiceSource : class
        {
            return new RegistrationBuilder(typeof(TServiceSource).Assembly);
        }

        private static RegistrationBuilder AddAll<TService>(this IServiceCollection services, Action<Type, Type> registrationAction)
        where TService : class
        {
            RegistrationBuilder builder = new RegistrationBuilder(typeof(TService).Assembly);
            return builder.AddAll<TService>(registrationAction);
        }
    }
}
