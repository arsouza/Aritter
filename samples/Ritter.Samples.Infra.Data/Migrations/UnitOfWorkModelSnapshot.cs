﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Ritter.Samples.Infra.Data;
using System;

namespace Ritter.Samples.Infra.Data.Migrations
{
    [DbContext(typeof(UnitOfWork))]
    partial class UnitOfWorkModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("Ritter.Samples.Domain.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("employee_id");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnName("cpf")
                        .HasMaxLength(11);

                    b.Property<Guid>("Uid")
                        .HasColumnName("uid");

                    b.HasKey("Id");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("Ritter.Samples.Domain.Employee", b =>
                {
                    b.OwnsOne("Ritter.Samples.Domain.ValueObjects.PersonName", "Name", b1 =>
                        {
                            b1.Property<int>("EmployeeId");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnName("first_name")
                                .HasMaxLength(50);

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnName("last_name")
                                .HasMaxLength(50);

                            b1.ToTable("Employee");

                            b1.HasOne("Ritter.Samples.Domain.Employee")
                                .WithOne("Name")
                                .HasForeignKey("Ritter.Samples.Domain.ValueObjects.PersonName", "EmployeeId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
