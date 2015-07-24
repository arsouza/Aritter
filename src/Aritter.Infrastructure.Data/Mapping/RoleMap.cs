using Aritter.Domain.Aggregates;
using Aritter.Infrastructure.Data.Extensions;

namespace Aritter.Infrastructure.Data.Mapping
{
	public class RoleMap : EntityMap<Role>
	{
		public RoleMap()
		{
			Property(p => p.Name)
				.HasMaxLength(50)
				.HasUniqueIndex("UQ_Role")
				.IsRequired();

			Property(p => p.Description)
				.HasMaxLength(255)
				.IsOptional();

			Property(p => p.PrecedenceOrder)
				.IsRequired();

			HasRequired(p => p.UserPolicy)
				.WithRequiredPrincipal(p => p.Role);
		}
	}
}