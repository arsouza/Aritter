using Microsoft.EntityFrameworkCore;
using Ritter.Infra.Data;
using Ritter.Infra.Data.Auditing;
using Ritter.Samples.Domain.Aggregates.People;

namespace Ritter.Samples.Infra.Data
{
    public class SampleContext : EFAuditUnitOfWork, IEFAuditUnitOfWork, ISql
    {
        public DbSet<Person> People { get; set; }

        public SampleContext(DbContextOptions<SampleContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new DocumentConfiguration());
        }

        public override string GetCurrentPrincipalId()
        {
            return "Anonymous";
        }
    }
}
