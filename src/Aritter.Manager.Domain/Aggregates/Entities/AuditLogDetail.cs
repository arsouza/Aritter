namespace Aritter.Manager.Domain.Aggregates
{
	public class AuditLogDetail : Entity
	{
		public int AuditLogId { get; set; }
		public string FieldName { get; set; }
		public string OldValue { get; set; }
		public string NewValue { get; set; }
		public virtual AuditLog AuditLog { get; set; }
	}
}