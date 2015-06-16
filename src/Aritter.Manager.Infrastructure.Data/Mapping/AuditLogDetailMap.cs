using Aritter.Manager.Domain.Aggregates;

namespace Aritter.Manager.Infrastructure.Data.Mapping
{
	public class AuditLogDetailMap : EntityMap<AuditLogDetail>
	{
		public AuditLogDetailMap()
		{
			this.Property(p => p.AuditLogId)
				.IsRequired();

			this.Property(p => p.FieldName)
				.IsMaxLength()
				.IsRequired();

			this.Property(p => p.OldValue)
				.IsMaxLength()
				.IsOptional();

			this.Property(p => p.NewValue)
				.IsMaxLength()
				.IsOptional();

			this.HasRequired(p => p.AuditLog)
				.WithMany(p => p.AuditLogDetails)
				.HasForeignKey(p => p.AuditLogId);
		}
	}
}
