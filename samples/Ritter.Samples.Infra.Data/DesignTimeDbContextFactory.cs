using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Ritter.Samples.Infra.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SampleContext>
    {
        public SampleContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SampleContext>();
            builder.UseSqlServer(@"Server=tcp:ritter.database.windows.net,1433;Initial Catalog=ritter-dsv;Persist Security Info=False;User ID=aritter;Password=pxh4P8w3$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            return new SampleContext(builder.Options);
        }
    }
}
