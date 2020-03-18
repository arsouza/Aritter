using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Ritter.Application.Services;
using Ritter.Domain;
using Ritter.Infra.Crosscutting;
using Ritter.Infra.Data;
using Ritter.Infra.Data.Query;
using Ritter.Infra.Http.Seedwork.DependencyInjection;
using Ritter.Samples.Application.People;
using Ritter.Samples.Infra.Data;
using Ritter.Samples.Infra.Data.Query;
using Ritter.Samples.Infra.Data.Query.Repositories.People;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ExtensionMethods
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString(ApplicationConstants.ConnectionStringName);

            services
                .AddDbContext<SampleContext>(options =>
                {
                    options
                        .UseSqlServer(
                            connectionString,
                            opts => opts.MigrationsAssembly(typeof(SampleContext).Assembly.GetName().Name))
                        .EnableSensitiveDataLogging();
                },
                ServiceLifetime.Transient);

            services.AddTransient<IEFUnitOfWork>(provider => provider.GetService<SampleContext>());

            services
                .AddDbContext<SampleQueryContext>(options =>
                {
                    options
                           .UseSqlServer(
                               connectionString,
                               opts => opts.MigrationsAssembly(typeof(SampleContext).Assembly.GetName().Name))
                           .EnableSensitiveDataLogging();
                },
                ServiceLifetime.Transient);

            services.AddTransient<IEFQueryUnitOfWork>(provider => provider.GetService<SampleQueryContext>());

            RegistrationBuilder.RegisterAll<IQueryRepository, PersonQueryRepository>(
                (service, implementation) => services.AddTransient(service, implementation));

            RegistrationBuilder.RegisterAll<IRepository, PersonRepository>(
                (service, implementation) => services.AddTransient(service, implementation));

            RegistrationBuilder.RegisterAll<IAppService, PersonAppService>(
                (service, implementation) => services.AddTransient(service, implementation));

            return services;
        }
    }
}
