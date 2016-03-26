using Aritter.Domain.Security.Aggregates;
using Aritter.Infra.Data.Seedwork.Mapping;
using Aritter.Infra.Data.SeedWork.Extensions;

namespace Aritter.Infra.Data.Mapping
{
    internal sealed class AuthorizationMap : EntityMap<Authorization>
    {
        public AuthorizationMap()
        {
            Property(p => p.Id)
                .HasUniqueIndex("UK_RoleAuthorization", 1);

            Property(p => p.RoleId)
                .HasUniqueIndex("UK_RoleAuthorization", 2);

            HasRequired(p => p.Permission)
                .WithRequiredDependent(p => p.Authorization);

            HasRequired(p => p.Role)
                .WithMany(p => p.Authorizations)
                .HasForeignKey(p => p.RoleId);
        }
    }
}
