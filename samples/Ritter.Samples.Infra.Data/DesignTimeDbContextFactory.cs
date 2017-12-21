using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Ritter.Samples.Infra.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<UnitOfWork>
    {
        public UnitOfWork CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<UnitOfWork>();
            builder.UseNpgsql("Server=localhost;Database=tms-api;Username=postgres;Password=postgres");

            return new UnitOfWork(builder.Options);
        }
    }
}