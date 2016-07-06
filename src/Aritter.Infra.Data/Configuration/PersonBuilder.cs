using Aritter.Domain.SecurityModule.Aggregates.MainAgg;
using Aritter.Domain.SecurityModule.Aggregates.UserAgg;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aritter.Infra.Data.Configuration
{
    internal sealed class PersonBuilder : EntityBuilder<Person>
    {
        public override void Build(EntityTypeBuilder<Person> builder)
        {
            base.Build(builder);

            builder.Property(p => p.FirstName)
                .HasMaxLength(100);

            builder.Property(p => p.LastName)
                .HasMaxLength(100);

            builder.HasOne(p => p.User)
                .WithOne(p => p.Person)
                .HasForeignKey<User>(p => p.PersonId);
        }
    }
}
