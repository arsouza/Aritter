using Aritter.Manager.Domain.Aggregates;
using Aritter.Manager.Infrastructure.Data.Extensions;

namespace Aritter.Manager.Infrastructure.Data.Mapping
{
	public class ModuleRoleMap : EntityMap<ModuleRole>
	{
		public ModuleRoleMap()
		{
			this.Property(p => p.ModuleId)
				.HasUniqueIndex("UQ_ModuleRole", 1)
				.IsRequired();

			this.Property(p => p.RoleId)
				.HasUniqueIndex("UQ_ModuleRole", 2)
				.IsRequired();

			this.HasRequired(p => p.Module)
				.WithMany(p => p.ModuleRoles)
				.HasForeignKey(p => p.ModuleId);

			this.HasRequired(p => p.Role)
				.WithMany(p => p.ModuleRoles)
				.HasForeignKey(p => p.RoleId);
		}
	}
}
