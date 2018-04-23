using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Ritter.Samples.Infra.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<UnitOfWork>
    {
        public UnitOfWork CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<UnitOfWork>();
            builder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=ritter-sample-db;Integrated Security=True");

            return new UnitOfWork(builder.Options);
        }
    }
}
