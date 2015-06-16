using Aritter.Manager.Domain.Aggregates;
using Aritter.Manager.Infrastructure.Data.Extensions;

namespace Aritter.Manager.Infrastructure.Data.Mapping
{
	public class UserRoleMap : EntityMap<UserRole>
	{
		public UserRoleMap()
		{
			this.Property(p => p.UserId)
				.HasUniqueIndex("UQ_UserRole", 1)
				.IsRequired();

			this.Property(p => p.RoleId)
				.HasUniqueIndex("UQ_UserRole", 2)
				.IsRequired();

			this.HasRequired(p => p.Role)
				.WithMany(p => p.UserRoles)
				.HasForeignKey(p => p.RoleId);

			this.HasRequired(p => p.User)
				.WithMany(p => p.UserRoles)
				.HasForeignKey(p => p.UserId);
		}
	}
}