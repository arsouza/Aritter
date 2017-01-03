using Aritter.Security.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Aritter.Infra.Data.Migrations
{
    public class MigrationsDbContextFactory : IDbContextFactory<AritterContext>
    {
        public AritterContext Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<AritterContext>();
            builder.UseNpgsql("Host=localhost;Port=5432;Database=aritter;User ID=postgres;Password=postgres");
            return new AritterContext(builder.Options);
        }
    }
}
