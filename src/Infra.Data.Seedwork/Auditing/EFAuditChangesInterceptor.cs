using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Ritter.Infra.Data.Auditing
{
    public abstract class EFAuditChangesInterceptor : SaveChangesInterceptor
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ILogger<EFAuditChangesInterceptor> logger;

        public EFAuditChangesInterceptor(
            IHttpContextAccessor httpContextAccessor,
            ILogger<EFAuditChangesInterceptor> logger)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.logger = logger;
        }

        public virtual string GetCurrentPrincipal() => httpContextAccessor?.HttpContext?.User?.Identity?.Name;

        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                string user = GetCurrentPrincipal();
                var auditEntries = new List<AuditEntry>();

                eventData.Context.ChangeTracker.DetectChanges();

                foreach (EntityEntry entry in eventData.Context.ChangeTracker.Entries())
                {
                    if (entry.Entity is Audit || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged || !entry.Properties.Any())
                    {
                        continue;
                    }

                    auditEntries.Add(new AuditEntry(entry, user));
                }

                IEnumerable<Audit> audits = auditEntries.Any()
                    ? auditEntries.Select(x => x.ToAudit())
                    : Enumerable.Empty<Audit>();

                await SaveAuditEntriesAsync(audits);
            }
            catch (Exception ex)
            {
                logger?.LogWarning($"Fail do index audit logs. Details: {ex}");
            }

            return result;
        }

        protected abstract Task SaveAuditEntriesAsync(IEnumerable<Audit> audits);
    }
}
