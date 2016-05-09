using Aritter.Domain.Security.Aggregates;
using Aritter.Domain.Security.Aggregates.Users;
using Aritter.Infra.Data.Seedwork.Extensions;
using Aritter.Infra.Data.Seedwork.Mapping;

namespace Aritter.Infra.Data.Mapping
{
	internal sealed class RoleMap : EntityMap<Role>
	{
		public RoleMap()
		{
			Property(p => p.Name)
				.HasMaxLength(50)
				.HasUniqueIndex("UK_Role");

			Property(p => p.Description)
				.HasMaxLength(255)
				.IsOptional();

			HasMany(t => t.Users)
				.WithMany(t => t.Roles)
				.Map(m =>
				{
					m.ToTable("RoleMembers");
					m.MapLeftKey("RoleId");
					m.MapRightKey("UserId");
				});
		}
	}
}
