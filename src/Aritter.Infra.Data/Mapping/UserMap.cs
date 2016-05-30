using Aritter.Domain.SecurityModule.Aggregates.UserAgg;
using Aritter.Infra.Data.Seedwork.Extensions;
using Aritter.Infra.Data.Seedwork.Mapping;

namespace Aritter.Infra.Data.Mapping
{
    internal sealed class UserMap : EntityMap<User>
    {
        public UserMap()
        {
            Property(p => p.UserName)
                .HasMaxLength(100)
                .HasUniqueIndex("UK_UserUsername")
                .IsRequired();

            Property(p => p.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            Property(p => p.LastName)
                .HasMaxLength(100)
                .IsOptional();

            Property(p => p.Email)
                .HasMaxLength(255)
                .HasUniqueIndex("UK_UserMailAddress");

            Property(p => p.MustChangePassword)
                .IsRequired();

            HasMany(p => p.PreviousCredentials)
                .WithRequired(p => p.User)
                .HasForeignKey(p => p.UserId);
        }
    }
}
