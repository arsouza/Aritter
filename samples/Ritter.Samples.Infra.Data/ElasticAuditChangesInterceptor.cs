using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Ritter.Infra.Data.Auditing;

namespace Ritter.Samples.Infra.Data
{
    public class ElasticAuditChangesInterceptor : EFAuditChangesInterceptor
    {
        public ElasticAuditChangesInterceptor(
            IHttpContextAccessor httpContextAccessor,
            ILogger<EFAuditChangesInterceptor> logger)
            : base(httpContextAccessor, logger)
        {
        }

        protected override Task SaveAuditEntriesAsync(IEnumerable<Audit> audits) => throw new System.NotImplementedException();
    }
}
