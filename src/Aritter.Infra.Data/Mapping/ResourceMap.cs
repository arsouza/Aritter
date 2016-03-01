using Aritter.Domain.Security.Aggregates;
using Aritter.Infra.Data.Seedwork.Mapping;
using Aritter.Infra.Data.SeedWork.Extensions;

namespace Aritter.Infra.Data.Mapping
{
    internal sealed class ResourceMap : EntityMap<Resource>
    {
        public ResourceMap()
        {
            Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.Description)
                .HasMaxLength(100)
                .IsOptional();

            Property(p => p.ParentId)
                .HasUniqueIndex("UQ_Resource", 2);

            Property(p => p.ModuleId)
                .HasUniqueIndex("UQ_Resource", 1);

            Property(p => p.Type)
                .IsRequired();

            HasRequired(p => p.Module)
                .WithMany(p => p.Resources)
                .HasForeignKey(p => p.ModuleId);

            HasOptional(p => p.Parent)
                .WithMany(p => p.Children)
                .HasForeignKey(p => p.ParentId);
        }
    }
}
