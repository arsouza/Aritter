using Aritter.Domain.SecurityModule.Aggregates.PermissionAgg;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aritter.Infra.Data.Configuration
{
    internal sealed class UserRoleBuilder : EntityBuilder<UserRole>
    {
        public override void Build(EntityTypeBuilder<UserRole> builder)
        {
            base.Build(builder);

            builder
                .HasOne(p => p.User)
                .WithMany(p => p.Roles)
                .HasForeignKey(p => p.UserId);

            builder
                .HasOne(p => p.Role)
                .WithMany(p => p.Users)
                .HasForeignKey(p => p.RoleId);
        }
    }
}
