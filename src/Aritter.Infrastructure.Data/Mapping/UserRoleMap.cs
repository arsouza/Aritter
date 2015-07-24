using Aritter.Domain.Aggregates;
using Aritter.Infrastructure.Data.Extensions;

namespace Aritter.Infrastructure.Data.Mapping
{
	public class UserRoleMap : EntityMap<UserRole>
	{
		public UserRoleMap()
		{
			Property(p => p.UserId)
				.HasUniqueIndex("UQ_UserRole", 1)
				.IsRequired();

			Property(p => p.RoleId)
				.HasUniqueIndex("UQ_UserRole", 2)
				.IsRequired();

			HasRequired(p => p.Role)
				.WithMany(p => p.UserRoles)
				.HasForeignKey(p => p.RoleId);

			HasRequired(p => p.User)
				.WithMany(p => p.UserRoles)
				.HasForeignKey(p => p.UserId);
		}
	}
}