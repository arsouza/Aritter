using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Aritter.Security.Infra.Data;

namespace Aritter.Infra.Data.Migrations
{
    [DbContext(typeof(AritterContext))]
    [Migration("20170103155719_V01")]
    partial class V01
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("Aritter.Security.Domain.Users.Aggregates.Credential", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Password")
                        .HasMaxLength(256);

                    b.HasKey("UserId");

                    b.ToTable("Credentials");
                });

            modelBuilder.Entity("Aritter.Security.Domain.Users.Aggregates.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("UID");

                    b.Property<string>("Username")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Aritter.Security.Domain.Users.Aggregates.Credential", b =>
                {
                    b.HasOne("Aritter.Security.Domain.Users.Aggregates.User", "User")
                        .WithOne("Credential")
                        .HasForeignKey("Aritter.Security.Domain.Users.Aggregates.Credential", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
