using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Ritter.Infra.Data.Auditing
{
    public interface IEFAuditUnitOfWork : IEFUnitOfWork
    {
        DbSet<Audit> Audits { get; set; }
        ChangeTracker ChangeTracker { get; }

        string GetCurrentPrincipalId();
    }
}
