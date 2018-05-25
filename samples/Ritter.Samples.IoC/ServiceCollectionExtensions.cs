using Microsoft.EntityFrameworkCore;
using Ritter.Application.Services;
using Ritter.Domain;
using Ritter.Infra.Data;
using Ritter.Infra.Data.Query;
using Ritter.Samples.Application.Services.Employees;
using Ritter.Samples.Infra.Data;
using Ritter.Samples.Infra.Data.Query;
using Ritter.Samples.Infra.Data.Query.Repositories.Employee;
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
            services.AddTransient<IEFUnitOfWork>(provider => provider.GetService<UnitOfWork>());

            services.AddEntityFrameworkSqlServer().AddDbContext<QueryUnitOfWork>(optionsBuilder, ServiceLifetime.Transient);
            services.AddTransient<IEFQueryUnitOfWork>(provider => provider.GetService<QueryUnitOfWork>());

            services.FromAssembly<EmployeeQueryRepository>().AddAll<IQueryRepository>((service, implementation)
                => services.AddTransient(service, implementation));

            services.FromAssembly<EmployeeRepository>().AddAll<IRepository>((service, implementation)
                => services.AddTransient(service, implementation));

            services.FromAssembly<EmployeeAppService>().AddAll<IAppService>((service, implementation)
                => services.AddTransient(service, implementation));

            return services;
        }

        public static RegistrationBuilder AddAll<TService>(this IServiceCollection services, Action<Type, Type> registrationAction)
            where TService : class
        {
            RegistrationBuilder builder = new RegistrationBuilder(typeof(TService).Assembly);
            return builder.AddAll<TService>(registrationAction);
        }

        private static RegistrationBuilder FromAssembly<TServiceSource>(this IServiceCollection services)
            where TServiceSource : class
        {
            return new RegistrationBuilder(typeof(TServiceSource).Assembly);
        }
    }
}
