using Aritter.Domain.Security.Aggregates;
using Aritter.Infra.Data.Seedwork.Mapping;

namespace Aritter.Infra.Data.Mapping
{
    internal sealed class FeatureMap : EntityMap<Feature>
    {
        public FeatureMap()
        {
            Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.Description)
                .HasMaxLength(100)
                .IsOptional();

            HasRequired(p => p.Module)
                .WithMany(p => p.Features)
                .HasForeignKey(p => p.ModuleId);
        }
    }
}
