using Microsoft.EntityFrameworkCore;
using Ritter.Infra.Data;
using Ritter.Samples.Domain.Aggregates.People;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ritter.Samples.Infra.Data
{
    public class SampleContext : DbContext, IEFUnitOfWork, ISql
    {
        public DbSet<Person> People { get; set; }

        public SampleContext(DbContextOptions<SampleContext> options) : base(options) { }

        public void BeginTransaction()
        {
            Database.BeginTransaction();
        }

        public void Commit()
        {
            Database.CommitTransaction();
        }

        public void Rollback()
        {
            Database.RollbackTransaction();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new DocumentConfiguration());
        }

        public int ExecuteCommand(string sqlCommand, params object[] parameters)
        {
            return Database.ExecuteSqlRaw(sqlCommand, parameters);
        }

        public async Task<int> ExecuteCommandAsync(string sqlCommand, params object[] parameters)
        {
            return await Database.ExecuteSqlRawAsync(sqlCommand, parameters);
        }

        public async Task<int> ExecuteCommandAsync(string sqlCommand, IEnumerable<object> parameters, CancellationToken cancellationToken = default)
        {
            return await Database.ExecuteSqlRawAsync(sqlCommand, parameters, cancellationToken);
        }
    }
}
