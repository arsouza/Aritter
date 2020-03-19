using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ritter.Samples.Domain.Aggregates.People;

namespace Ritter.Samples.Infra.Data
{
    internal sealed class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.ToTable("Documents");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("person_id")
                .IsRequired();

            builder.Property(p => p.Type)
                .HasColumnName("type")
                .IsRequired();

            builder.Property(p => p.Number)
                .HasColumnName("number")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(p => p.Uid)
                .HasColumnName("uid")
                .IsRequired();

            builder.HasIndex(p => p.Uid)
                .IsUnique();
        }
    }
}
