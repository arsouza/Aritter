using Aritter.Domain.Aggregates;

namespace Aritter.Infra.Data.Mapping
{
	public class AuditLogMap : EntityMap<AuditLog>
	{
		public AuditLogMap()
		{
			Property(p => p.EntityName)
				.HasMaxLength(250);

			Property(p => p.Type)
				.IsRequired();
		}
	}
}
