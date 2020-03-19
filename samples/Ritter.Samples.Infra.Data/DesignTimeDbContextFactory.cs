using Microsoft.EntityFrameworkCore;
using Ritter.Infra.Data;

namespace Ritter.Samples.Infra.Data
{
    public class DesignTimeDbContextFactory : DesignTimeDbContextFactoryBase<SampleContext>
    {
        protected override SampleContext CreateNewInstance(DbContextOptions<SampleContext> options)
        {
            return new SampleContext(options);
        }
    }
}
