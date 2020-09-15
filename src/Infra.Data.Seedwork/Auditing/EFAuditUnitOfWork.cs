using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ritter.Infra.Data.Auditing
{
    public abstract class EFAuditUnitOfWork : EFUnitOfWork, IEFAuditUnitOfWork
    {
        public virtual DbSet<Audit> Audits { get; set; }

        public EFAuditUnitOfWork(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Audit>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("Audits");

                entity.Property(p => p.Id)
                    .IsRequired()
                    .HasDefaultValueSql("newid()");

                entity.Property(p => p.AuditType)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(p => p.AuditDateTimeUtc)
                    .IsRequired();

                entity.Property(p => p.TableName)
                    .IsRequired()
                    .HasMaxLength(128);
            });
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            IEnumerable<Audit> audits = this.AuditEntries("");
            int result = await base.SaveChangesAsync(cancellationToken);

            Audits.AddRange(audits);
            await base.SaveChangesAsync();

            return result;
        }

        public abstract string GetCurrentPrincipalId();
    }
}
