using Aritter.Domain.Aggregates;
using Aritter.Infrastructure.Data.Extensions;

namespace Aritter.Infrastructure.Data.Mapping
{
	public class PermissionMap : EntityMap<Permission>
	{
		public PermissionMap()
		{
			Property(p => p.ResourceId)
				.HasUniqueIndex("UQ_Permission", 1);

			Property(p => p.OperationId)
				.HasUniqueIndex("UQ_Permission", 2);

			HasRequired(p => p.Operation)
				.WithMany(p => p.Permissions)
				.HasForeignKey(p => p.OperationId);

			HasRequired(p => p.Resource)
				.WithMany(p => p.Permissions)
				.HasForeignKey(p => p.ResourceId);
		}
	}
}
