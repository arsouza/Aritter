using Aritter.Domain.Aggregates.Security;
using Aritter.Infra.Data.Extensions;

namespace Aritter.Infra.Data.Mapping
{
	internal sealed class UserRoleMap : EntityMap<UserRole>
	{
		public UserRoleMap()
		{
			Property(p => p.UserId)
				.HasUniqueIndex("UQ_UserRole", 1);

			Property(p => p.RoleId)
				.HasUniqueIndex("UQ_UserRole", 2);

			HasRequired(p => p.Role)
				.WithMany(p => p.UserRoles)
				.HasForeignKey(p => p.RoleId);

			HasRequired(p => p.User)
				.WithMany(p => p.UserRoles)
				.HasForeignKey(p => p.UserId);
		}
	}
}