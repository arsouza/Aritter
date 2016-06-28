using Aritter.Domain.SecurityModule.Aggregates.UserAgg;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aritter.Infra.Data.Configuration
{
    internal sealed class UserBuilder : EntityBuilder<User>
	{
		public override void Build(EntityTypeBuilder<User> builder)
		{
			base.Build(builder);

			builder.Property(p => p.UserName)
				.HasMaxLength(100)
				.IsRequired();

			builder.Property(p => p.FirstName)
				.HasMaxLength(100)
				.IsRequired();

			builder.Property(p => p.LastName)
				.HasMaxLength(200)
				.IsRequired();

			builder.Property(p => p.Email)
				.HasMaxLength(255)
				.IsRequired();

			builder.Property(p => p.MustChangePassword)
				.IsRequired();

            builder.HasOne(p => p.Credential)
                .WithOne(p => p.User)
                .HasForeignKey<UserCredential>(p => p.Id);

            builder
				.HasMany(p => p.PreviousCredentials)
				.WithOne(p => p.User)
				.HasForeignKey(p => p.UserId);

			builder
				.HasIndex(p => p.UserName)
				.IsUnique();

			builder
				.HasIndex(p => p.Email)
				.IsUnique();
		}
	}
}
