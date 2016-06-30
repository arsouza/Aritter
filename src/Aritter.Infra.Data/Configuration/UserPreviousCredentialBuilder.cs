using Aritter.Domain.SecurityModule.Aggregates.UserAgg;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aritter.Infra.Data.Configuration
{
    internal sealed class UserPreviousCredentialBuilder : EntityBuilder<UserPreviousCredential>
    {
        public override void Build(EntityTypeBuilder<UserPreviousCredential> builder)
        {
            base.Build(builder);

            builder.Property(p => p.Id)
                .ValueGeneratedNever();

            builder.Property(p => p.PasswordHash)
                .HasMaxLength(100);

            builder.HasOne(p => p.User)
                .WithMany(p => p.PreviousCredentials)
                .HasForeignKey(p => p.UserId);
        }
    }
}
