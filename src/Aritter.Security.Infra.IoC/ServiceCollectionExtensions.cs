using Aritter.Infra.Data.Seedwork;
using Aritter.Security.Application.Services.Users;
using Aritter.Security.Domain.Users.Aggregates;
using Aritter.Security.Infra.Data;
using Aritter.Security.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Aritter.Security.Infra.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AritterContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IQueryableUnitOfWork, AritterContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserAppService, UserAppService>();
        }
    }
}
