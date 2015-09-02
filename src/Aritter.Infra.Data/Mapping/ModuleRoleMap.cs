using Aritter.Domain.Aggregates;
using Aritter.Infra.Data.Extensions;

namespace Aritter.Infra.Data.Mapping
{
	internal sealed class ModuleRoleMap : EntityMap<ModuleRole>
	{
		public ModuleRoleMap()
		{
			Property(p => p.ModuleId)
				.HasUniqueIndex("UQ_ModuleRole", 1);

			Property(p => p.RoleId)
				.HasUniqueIndex("UQ_ModuleRole", 2);

			HasRequired(p => p.Module)
				.WithMany(p => p.ModuleRoles)
				.HasForeignKey(p => p.ModuleId);

			HasRequired(p => p.Role)
				.WithMany(p => p.ModuleRoles)
				.HasForeignKey(p => p.RoleId);
		}
	}
}
