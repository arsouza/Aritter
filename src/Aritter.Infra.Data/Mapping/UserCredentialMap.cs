using Aritter.Domain.SecurityModule.Aggregates.UserAgg;
using Aritter.Infra.Data.Seedwork.Mapping;

namespace Aritter.Infra.Data.Mapping
{
    internal sealed class UserCredentialMap : EntityMap<UserCredential>
    {
        public UserCredentialMap()
        {
            Property(p => p.PasswordHash)
                .HasMaxLength(50);

            HasRequired(p => p.User)
                .WithMany(p => p.Credentials)
                .HasForeignKey(p => p.UserId);
        }
    }
}
