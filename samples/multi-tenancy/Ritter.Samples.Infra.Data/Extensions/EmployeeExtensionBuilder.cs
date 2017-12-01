﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ritter.Samples.Domain;

namespace Ritter.Samples.Infra.Data.Extensions
{
    public static class EmployeeExtensionBuilder
    {
        public static void BuildEmployee(this EntityTypeBuilder<Employee> entity)
        {
            entity.ToTable("Employee");
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("employee_id")
                .IsRequired();

            entity.Property(p => p.FirstName)
                .HasColumnName("first_name")
                .HasColumnType("varchar(50)")
                .IsRequired();

            entity.Property(p => p.LastName)
                .HasColumnName("last_name")
                .HasColumnType("varchar(50)")
                .IsRequired();

            entity.Property(p => p.Cpf)
                .HasColumnName("cpf")
                .HasColumnType("varchar(14)")
                .IsRequired();

            entity.Property(p => p.Uid)
                .HasColumnName("uid")
                .HasColumnType("uniqueidentifier")
                .IsRequired();
        }
    }
}