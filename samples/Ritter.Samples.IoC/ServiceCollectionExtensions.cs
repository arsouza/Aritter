using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ritter.Application.Seedwork.Services;
using Ritter.Domain.Seedwork;
using Ritter.Domain.Seedwork.Services;
using Ritter.Samples.Application;
using Ritter.Samples.Domain;
using Ritter.Samples.Infra.Data;

namespace Ritter.Samples.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services, Action<ConfigurationOptions> configAction)
        {
            ConfigurationOptions options = new ConfigurationOptions();
            configAction?.Invoke(options);

            DbContextOptionsBuilder<UnitOfWork> optionsBuilder = new DbContextOptionsBuilder<UnitOfWork>();
            optionsBuilder.UseSqlServer(options.ConnectionString);

            services.AddTransient<IUnitOfWork>(p => new UnitOfWork(optionsBuilder.Options));
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            //services.AddTransient<IEmployeeDomainService, EmployeeDomainService>();
            services.AddTransient<IEmployeeAppService, EmployeeAppService>();

            return services;
        }
    }
}
