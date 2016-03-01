using Aritter.Domain.Security.Aggregates;
using Aritter.Infra.Data.Seedwork.Mapping;
using Aritter.Infra.Data.SeedWork.Extensions;

namespace Aritter.Infra.Data.Mapping
{
    internal sealed class RoleMap : EntityMap<Role>
    {
        public RoleMap()
        {
            Property(p => p.Name)
                .HasMaxLength(50)
                .HasUniqueIndex("UQ_Role");

            Property(p => p.Description)
                .HasMaxLength(255)
                .IsOptional();

            Property(p => p.ModuleId)
                .IsRequired();
        }
    }
}
