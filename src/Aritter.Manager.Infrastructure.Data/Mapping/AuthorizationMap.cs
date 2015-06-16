using Aritter.Manager.Domain.Aggregates;
using Aritter.Manager.Infrastructure.Data.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aritter.Manager.Infrastructure.Data.Mapping
{
	public class AuthorizationMap : EntityMap<Authorization>
	{
		public AuthorizationMap()
		{
			this.Property(p => p.PermissionId)
				.HasUniqueIndex(new IndexAttribute("UQ_UserAuthorization", 1), new IndexAttribute("UQ_RoleAuthorization", 1))
				.IsRequired();

			this.Property(p => p.UserId)
				.HasUniqueIndex("UQ_UserAuthorization", 2)
				.IsOptional();

			this.Property(p => p.RoleId)
				.HasUniqueIndex("UQ_RoleAuthorization", 2)
				.IsOptional();

			this.Property(p => p.Allowed)
				.IsRequired();

			this.Property(p => p.Denied)
				.IsRequired();

			this.HasRequired(p => p.Permission)
				.WithMany(p => p.Authorizations)
				.HasForeignKey(p => p.PermissionId);

			this.HasOptional(p => p.User)
				.WithMany(p => p.Authorizations)
				.HasForeignKey(p => p.UserId);

			this.HasOptional(p => p.Role)
				.WithMany(p => p.Authorizations)
				.HasForeignKey(p => p.RoleId);
		}
	}
}
