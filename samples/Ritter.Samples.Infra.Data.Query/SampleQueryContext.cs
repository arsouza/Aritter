using Microsoft.EntityFrameworkCore;
using Ritter.Infra.Data.Query;
using Ritter.Samples.Application.DTO.Employees.Response;

namespace Ritter.Samples.Infra.Data.Query
{
    public class SampleQueryContext : DbContext, IEFQueryUnitOfWork
    {
        public DbSet<EmployeeDto> Employees { get; set; }

        public SampleQueryContext(DbContextOptions<SampleQueryContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }
    }
}
