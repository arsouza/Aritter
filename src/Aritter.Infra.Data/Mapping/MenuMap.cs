using Aritter.Domain.Security.Aggregates;
using Aritter.Infra.Data.Seedwork.Mapping;
using Aritter.Infra.Data.SeedWork.Extensions;

namespace Aritter.Infra.Data.Mapping
{
    internal sealed class MenuMap : EntityMap<Menu>
    {
        public MenuMap()
        {
            Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.Description)
                .HasMaxLength(100)
                .IsOptional();

            Property(p => p.ParentId)
                .HasUniqueIndex("UQ_Feature", 2);

            Property(p => p.ModuleId)
                .HasUniqueIndex("UQ_Feature", 1);

            Property(p => p.Image)
                .HasMaxLength(200)
                .IsOptional();

            Property(p => p.Url)
                .HasMaxLength(100)
                .IsOptional();

            HasRequired(p => p.Module)
                .WithMany(p => p.Menus)
                .HasForeignKey(p => p.ModuleId);

            HasOptional(p => p.Parent)
                .WithMany(p => p.Children)
                .HasForeignKey(p => p.ParentId);
        }
    }
}
