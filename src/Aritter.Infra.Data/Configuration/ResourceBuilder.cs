using Aritter.Domain.SecurityModule.Aggregates.ModuleAgg;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aritter.Infra.Data.Configuration
{
    internal class ResourceBuilder:EntityBuilder<Resource>
    {
        public override void Build(EntityTypeBuilder<Resource> builder)
        {
            base.Build(builder);

            builder.Property(p => p.Name)
               .HasMaxLength(50)
               .IsRequired();

            builder.Property(p => p.Description)
                .HasMaxLength(100);

            builder.HasOne(p => p.Module)
                .WithMany(p => p.Resources)
                .HasForeignKey(p => p.ModuleId);
        }
    }
}