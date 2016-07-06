using Aritter.Domain.SecurityModule.Aggregates.UserAgg;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aritter.Infra.Data.Configuration
{
    internal sealed class UserBuilder : EntityBuilder<User>
    {
        public override void Build(EntityTypeBuilder<User> builder)
        {
            base.Build(builder);

            builder.Property(p => p.Username)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(p => p.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(p => p.Credential)
                .WithOne(i => i.User)
                .HasForeignKey<UserCredential>(b => b.UserId);

            builder
                .HasIndex(p => p.Username)
                .IsUnique();

            builder
                .HasIndex(p => p.Email)
                .IsUnique();
        }
    }
}
