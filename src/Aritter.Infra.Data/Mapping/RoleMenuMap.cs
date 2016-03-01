using Aritter.Domain.Security.Aggregates;
using Aritter.Infra.Data.Seedwork.Mapping;
using Aritter.Infra.Data.SeedWork.Extensions;

namespace Aritter.Infra.Data.Mapping
{
    internal sealed class RoleMenuMap : EntityMap<RoleMenu>
    {
        public RoleMenuMap()
        {
            Property(p => p.MenuId)
                .HasUniqueIndex("UQ_RoleMenu", 1);

            Property(p => p.RoleId)
                .HasUniqueIndex("UQ_RoleMenu", 2);

            HasRequired(p => p.Role)
                .WithMany(p => p.Menus)
                .HasForeignKey(p => p.RoleId);

            HasRequired(p => p.Menu)
                .WithMany(p => p.Roles)
                .HasForeignKey(p => p.MenuId);
        }
    }
}
