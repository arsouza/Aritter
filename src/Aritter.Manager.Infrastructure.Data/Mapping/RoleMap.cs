using Aritter.Manager.Domain.Aggregates;
using Aritter.Manager.Infrastructure.Data.Extensions;

namespace Aritter.Manager.Infrastructure.Data.Mapping
{
	public class RoleMap : EntityMap<Role>
	{
		public RoleMap()
		{
			this.Property(p => p.Name)
				.HasMaxLength(50)
				.HasUniqueIndex("UQ_Role")
				.IsRequired();

			this.Property(p => p.Description)
				.HasMaxLength(255)
				.IsOptional();

			this.Property(p => p.PrecedenceOrder)
				.IsRequired();

			this.HasRequired(p => p.UserPolicy)
				.WithRequiredPrincipal(p => p.Role);
		}
	}
}
