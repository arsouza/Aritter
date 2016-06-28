using Aritter.Domain.SecurityModule.Aggregates.ModuleAgg;
using Aritter.Infra.Data.Seedwork.Extensions;
using Aritter.Infra.Data.Seedwork.Mapping;

namespace Aritter.Infra.Data.Configuration
{
    internal sealed class ModuleMap : EntityBuilder<Module>
    {
        public Module>()
        {
            Property(p => p.Name)
                .HasMaxLength(50)
                .HasUniqueIndex("UK_Module");

            Property(p => p.Description)
                .HasMaxLength(255)
                .IsOptional();
        }
    }
}
