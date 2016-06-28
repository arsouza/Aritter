using Aritter.Domain.SecurityModule.Aggregates.ModuleAgg;
using Aritter.Infra.Data.Seedwork.Extensions;
using Aritter.Infra.Data.Seedwork.Mapping;

namespace Aritter.Infra.Data.Configuration
{
    internal sealed class MenuMap : EntityBuilder<Menu>
    {
        public Menu> builder)
        {
            Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.Description)
                .HasMaxLength(100)
                .IsOptional();

            Property(p => p.ParentId)
                .HasUniqueIndex("UK_Feature", 2);

            Property(p => p.ModuleId)
                .HasUniqueIndex("UK_Feature", 1);

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
