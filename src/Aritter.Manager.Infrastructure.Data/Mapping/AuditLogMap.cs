using Aritter.Manager.Domain.Aggregates;

namespace Aritter.Manager.Infrastructure.Data.Mapping
{
	public class AuditLogMap : EntityMap<AuditLog>
	{
		public AuditLogMap()
		{
			Property(p => p.Type)
				.IsRequired();

			Property(p => p.EntityName)
				.HasMaxLength(250)
				.IsRequired();

			Property(p => p.EntityId)
				.IsOptional();

			Property(p => p.EntityGuid)
				.IsRequired();

			Property(p => p.UserId)
				.IsRequired();

			Property(p => p.LogDate)
				.IsRequired();
		}
	}
}
