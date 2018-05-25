using Microsoft.EntityFrameworkCore;
using Ritter.Infra.Data.Query;
using Ritter.Samples.Application.DTO.Employees.Response;

namespace Ritter.Samples.Infra.Data.Query
{
    public class QueryUnitOfWork : DbContext, IEFQueryUnitOfWork
    {
        public DbSet<GetEmployeeDto> Employees { get; set; }

        public QueryUnitOfWork(DbContextOptions<QueryUnitOfWork> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }
    }
}
