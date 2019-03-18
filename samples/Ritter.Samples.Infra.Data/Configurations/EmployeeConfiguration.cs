using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ritter.Samples.Domain.Aggregates.Employees;
using Ritter.Samples.Domain.Aggregates.People;

namespace Ritter.Samples.Infra.Data
{
    internal sealed class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("employee_id")
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
                .WithOne(p => p.Employee)
                .HasForeignKey<Document>(e => e.EmployeeId);
        }
    }
}
