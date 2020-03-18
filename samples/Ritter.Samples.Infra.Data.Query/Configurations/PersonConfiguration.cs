using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ritter.Samples.Domain.Aggregates.People;

namespace Ritter.Samples.Infra.Data.Query
{
    internal sealed class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("People");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("person_id")
                .IsRequired();

            builder.OwnsOne(p => p.Name, name =>
            {
                name.Property(p => p.FirstName)
                    .HasColumnName("first_name")
                    .HasMaxLength(50)
                    .IsRequired();

                name.Property(p => p.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(50)
                    .IsRequired();
            });

            builder.Property(p => p.Uid)
                .HasColumnName("uid")
                .IsRequired();

            builder.HasOne(p => p.Cpf)
                .WithOne(p => p.Person)
                .HasForeignKey<Document>(e => e.Id);
        }
    }
}
