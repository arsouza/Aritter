using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Ritter.Application.Services;
using Ritter.Domain;
using Ritter.Infra.Data;
using Ritter.Infra.Data.Query;
using Ritter.Samples.Application.People;
using Ritter.Samples.Infra.Data;
using Ritter.Samples.Infra.Data.Query;
using Ritter.Samples.Infra.Data.Query.Repositories.People;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ExtensionMethods
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            services
                .AddDbContext<SampleContext>(options =>
                {
                    options
                        .UseSqlite(
                            connectionString,
                            opts => opts.MigrationsAssembly(typeof(SampleContext).Assembly.GetName().Name))
                        .EnableSensitiveDataLogging();
                });

            services.AddScoped<IEFUnitOfWork>(provider => provider.GetService<SampleContext>());

            services
                .AddDbContext<SampleQueryContext>(options =>
                {
                    options
                           .UseSqlite(
                               connectionString,
                               opts => opts.MigrationsAssembly(typeof(SampleContext).Assembly.GetName().Name))
                           .EnableSensitiveDataLogging();
                });

            services.AddScoped<IEFQueryUnitOfWork>(provider => provider.GetService<SampleQueryContext>());

            services.RegisterAllTypesOf<IQueryRepository>(typeof(PersonQueryRepository).Assembly);
            services.RegisterAllTypesOf<IRepository>(typeof(PersonRepository).Assembly);
            services.RegisterAllTypesOf<IAppService>(typeof(PersonAppService).Assembly);

            return services;
        }
    }
}
