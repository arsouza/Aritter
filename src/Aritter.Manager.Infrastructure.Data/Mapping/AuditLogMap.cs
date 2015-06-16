using Aritter.Manager.Domain.Aggregates;

namespace Aritter.Manager.Infrastructure.Data.Mapping
{
	public class AuditLogMap : EntityMap<AuditLog>
	{
		public AuditLogMap()
		{
			this.Property(p => p.Type)
				.IsRequired();

			this.Property(p => p.EntityName)
				.HasMaxLength(250)
				.IsRequired();

			this.Property(p => p.EntityId)
				.IsOptional();

			this.Property(p => p.EntityGuid)
				.IsRequired();

			this.Property(p => p.UserId)
				.IsRequired();

			this.Property(p => p.LogDate)
				.IsRequired();
		}
	}
}
