using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Ritter.Infra.Crosscutting;

namespace Ritter.Infra.Data.Auditing
{
    internal static class ExtensionMethods
    {
        public static IEnumerable<Audit> AuditEntries(this IEFAuditUnitOfWork unitOfWork, string userName)
        {
            Ensure.Argument.NotNull(unitOfWork);

            var auditEntries = new List<AuditEntry>();
            unitOfWork.ChangeTracker.DetectChanges();

            foreach (EntityEntry entry in unitOfWork.ChangeTracker.Entries())
            {
                if (entry.Entity is Audit || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                {
                    continue;
                }

                var auditEntry = new AuditEntry(entry, userName);
                auditEntries.Add(auditEntry);
            }

            if (auditEntries.Any())
            {
                return auditEntries.Select(x => x.ToAudit());
            }

            return Enumerable.Empty<Audit>();
        }
    }
}
