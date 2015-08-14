using Aritter.Domain.Aggregates;
using Aritter.Infrastructure.Data.Extensions;

namespace Aritter.Infrastructure.Data.Mapping
{
	public class ModuleRoleMap : AuditableMap<ModuleRole>
	{
		public ModuleRoleMap()
		{
			Property(p => p.ModuleId)
				.HasUniqueIndex("UQ_ModuleRole", 1)
				.IsRequired();

			Property(p => p.RoleId)
				.HasUniqueIndex("UQ_ModuleRole", 2)
				.IsRequired();

			HasRequired(p => p.Module)
				.WithMany(p => p.ModuleRoles)
				.HasForeignKey(p => p.ModuleId);

			HasRequired(p => p.Role)
				.WithMany(p => p.ModuleRoles)
				.HasForeignKey(p => p.RoleId);
		}
	}
}
