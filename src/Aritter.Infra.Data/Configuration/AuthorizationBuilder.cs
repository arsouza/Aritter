using Aritter.Domain.SecurityModule.Aggregates.PermissionAgg;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aritter.Infra.Data.Configuration
{
    internal sealed class AuthorizationBuilder : EntityBuilder<Authorization>
    {
        public override void Build(EntityTypeBuilder<Authorization> builder)
        {
            base.Build(builder);

            builder.Property(p => p.Id)
                .ValueGeneratedNever();

            builder
                .HasIndex(p => new { p.Id, p.RoleId })
                .IsUnique(true);

            builder
                .HasOne(p => p.Role)
                .WithMany(p => p.Authorizations)
                .HasForeignKey(p => p.RoleId);
        }
    }
}
