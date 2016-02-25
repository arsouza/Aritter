using Aritter.Domain.Aggregates.Security;
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

            HasRequired(p => p.UserPolicy)
                .WithRequiredPrincipal(p => p.Role);
        }
    }
}
