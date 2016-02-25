using Aritter.Domain.Aggregates.Security;
using Aritter.Infra.Data.Seedwork.Mapping;
using Aritter.Infra.Data.SeedWork.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aritter.Infra.Data.Mapping
{
    internal sealed class AuthorizationMap : EntityMap<Authorization>
    {
        public AuthorizationMap()
        {
            Property(p => p.PermissionId)
                .HasUniqueIndex(new IndexAttribute("UQ_UserAuthorization", 1), new IndexAttribute("UQ_RoleAuthorization", 1));

            Property(p => p.UserId)
                .HasUniqueIndex("UQ_UserAuthorization", 2);

            Property(p => p.RoleId)
                .HasUniqueIndex("UQ_RoleAuthorization", 2);

            HasRequired(p => p.Permission)
                .WithMany(p => p.Authorizations)
                .HasForeignKey(p => p.PermissionId);

            HasOptional(p => p.User)
                .WithMany(p => p.Authorizations)
                .HasForeignKey(p => p.UserId);

            HasOptional(p => p.Role)
                .WithMany(p => p.Authorizations)
                .HasForeignKey(p => p.RoleId);
        }
    }
}
