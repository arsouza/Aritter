using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ritter.Samples.Application.DTO.Employees.Response;

namespace Ritter.Samples.Infra.Data.Query
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<GetEmployeeDto>
    {
        public void Configure(EntityTypeBuilder<GetEmployeeDto> builder)
        {
            builder.ToTable("Employees");
            builder.HasKey(p => p.EmployeeId);

            builder.Property(p => p.EmployeeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("employee_id")
                .IsRequired();

            builder.Property(p => p.FirstName)
                .HasColumnName("first_name")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.LastName)
                .HasColumnName("last_name")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Cpf)
                .HasColumnName("cpf")
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(p => p.Uid)
                .HasColumnName("uid")
                .IsRequired();
        }
    }
}
