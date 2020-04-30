using Microsoft.EntityFrameworkCore;
using Ritter.Infra.Data;

namespace Ritter.Samples.Infra.Data
{
    public class DesignTimeDbContextFactory : DesignTimeDbContextFactoryBase<SampleContext>
    {
        protected override SampleContext CreateNewInstance(DbContextOptionsBuilder<SampleContext> optionsBuilder, string connectionString)
        {
            optionsBuilder.UseSqlite(connectionString);
            return new SampleContext(optionsBuilder.Options);
        }
    }
}
