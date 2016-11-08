using Aritter.Infra.Crosscutting.Exceptions;
using Aritter.Infra.Crosscutting.Logging;
using Aritter.Infra.Data.Seedwork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Aritter.Infra.Data
{
    public class AritterContext : DbContext, IQueryableUnitOfWork
    {
        private IDbContextTransaction transaction;
        private bool disposed = false;

        //public virtual DbSet<User> Users { get; set; }

        public void BeginTransaction()
        {
            transaction = Database.BeginTransaction();
        }

        public void Commit()
        {
            if (transaction == null)
            {
                ThrowHelper.ThrowApplicationException("Transaction is not open");
            }

            Database.CommitTransaction();
        }

        public void Rollback()
        {
            if (transaction == null)
            {
                ThrowHelper.ThrowApplicationException("Transaction is not open");
            }

            Database.RollbackTransaction();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Application>(entity =>
            // {
            //     entity.HasKey(p => p.Id);

            //     entity.Property(p => p.Id)
            //         .ValueGeneratedOnAdd()
            //         .IsRequired();

            //     entity.Property(e => e.UID)
            //         .IsRequired();

            //     entity.HasIndex(e => e.Name)
            //         .IsUnique();

            //     entity.Property(e => e.Description)
            //         .HasMaxLength(256);

            //     entity.Property(e => e.Name)
            //         .IsRequired()
            //         .HasMaxLength(50);
            // });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //LoggerFactory.SetCurrent(new NLogFactory());

            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseLoggerFactory(LoggerFactory.Current());

            //optionsBuilder.UseSqlServer(ApplicationSettings.ConnectionString("Aritter_SqlServer"));
            //optionsBuilder.UseNpgsql(ApplicationSettings.ConnectionString("Aritter_Npgsql"));
        }

        public override void Dispose()
        {
            Dispose(true);
        }

        protected void Dispose(bool disposing)
        {
            base.Dispose();

            if (!disposed && disposing)
            {
                // if (UserProfiles != null)
                //     UserProfiles = null;
            }
        }
    }
}
