using System;
using System.Collections.Generic;

namespace Aritter.Domain.Aggregates
{
	public class AuditLog : Entity
	{
		public AuditLogType Type { get; set; }
		public string EntityName { get; set; }
		public int? EntityId { get; set; }
		public Guid EntityGuid { get; set; }
		public int UserId { get; set; }
		public DateTime LogDate { get; set; }
		public virtual ICollection<AuditLogDetail> AuditLogDetails { get; set; }
	}
}
