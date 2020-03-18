using Microsoft.EntityFrameworkCore;
using Ritter.Infra.Data.Query;
using Ritter.Samples.Domain.Aggregates.People;

namespace Ritter.Samples.Infra.Data.Query
{
    public class SampleQueryContext : DbContext, IEFQueryUnitOfWork
    {
        public SampleQueryContext()
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Document> Documents { get; set; }

        public SampleQueryContext(DbContextOptions<SampleQueryContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new DocumentConfiguration());
        }
    }
}
