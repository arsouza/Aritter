using System;

namespace Ritter.Infra.Data.Auditing
{
    public class Audit
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime AuditDateTimeUtc { get; set; }
        public string AuditType { get; set; }
        public string AuditUser { get; set; }
        public string TableName { get; set; }
        public string KeyValues { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }
        public string ChangedColumns { get; set; }
    }
}
