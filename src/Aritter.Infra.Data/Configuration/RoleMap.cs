using Aritter.Domain.SecurityModule.Aggregates.PermissionAgg;
using Aritter.Infra.Data.Seedwork.Extensions;
using Aritter.Infra.Data.Seedwork.Mapping;

namespace Aritter.Infra.Data.Configuration
{
    internal sealed class RoleMap : EntityBuilder<Role>
    {
        public Role>()
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
