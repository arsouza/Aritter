using Microsoft.EntityFrameworkCore;
using Ritter.Infra.Data.Seedwork;
using Ritter.Samples.Domain;
using Ritter.Samples.Infra.Data.Extensions;
using System.Linq;
using System.Threading.Tasks;

namespace Ritter.Samples.Infra.Data
{
    public class UnitOfWork : DbContext, IQueryableUnitOfWork
    {
        public DbSet<Employee> Employees { get; set; }

        public UnitOfWork(DbContextOptions<UnitOfWork> options)
            : base(options)
        {
        }

        public UnitOfWork()
            : base()
        {
        }

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

        public bool IsLocal<TEntity>(TEntity entity) where TEntity : class
        {
            return ChangeTracker.Entries<TEntity>().Any(e => e.Entity.Equals(entity));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(e => e.BuildEmployee());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=RitterSample;Integrated Security=True");
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
