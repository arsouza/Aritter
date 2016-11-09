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
            builder.UseSqlServer("Server=.;Database=AritterDB;User ID=Aritter;Password=Aritter");
            return new AritterContext(builder.Options);
        }
    }
}
