using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Ritter.Samples.Infra.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SampleContext>
    {
        public SampleContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SampleContext>();
            builder.UseSqlServer(@"Data Source=10.99.31.61,11433;Initial Catalog=ritter-sample-db;User Id=sa;Password=pxh4P8w3");

            return new SampleContext(builder.Options);
        }
    }
}
