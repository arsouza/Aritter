using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Ritter.Application.Seedwork.Services;
using Ritter.Domain.Seedwork;
using Ritter.Domain.Seedwork.Validation;
using Ritter.Infra.Data.Seedwork;
using Ritter.Samples.Application;
using Ritter.Samples.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Ritter.Samples.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services, string connectionString)
        {
            Action<DbContextOptionsBuilder> optionsBuilder = (options) =>
            {
                options.UseNpgsql(connectionString);
                options.EnableSensitiveDataLogging();
            };

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
            services.AddTransient<IEntityValidator, FluentEntityValidator>();

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