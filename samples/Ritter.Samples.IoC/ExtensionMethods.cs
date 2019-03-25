using Microsoft.EntityFrameworkCore;
using Ritter.Application.Services;
using Ritter.Domain;
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
        public static IServiceCollection RegisterServices(this IServiceCollection services, string connectionString)
        {
            void optionsBuilder(DbContextOptionsBuilder options)
            {
                options
                    .UseSqlServer(connectionString)
                    .EnableSensitiveDataLogging();
            }

            services
                .AddEntityFrameworkSqlServer()
                .AddDbContext<SampleContext>(optionsBuilder, ServiceLifetime.Transient);

            services.AddTransient<IEFUnitOfWork>(provider => provider.GetService<SampleContext>());

            services
                .AddEntityFrameworkSqlServer()
                .AddDbContext<SampleQueryContext>(optionsBuilder, ServiceLifetime.Transient);

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
