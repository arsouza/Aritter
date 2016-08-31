using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Aritter.Infra.Data;

namespace Aritter.Infra.Data.Migrations
{
    [DbContext(typeof(AritterContext))]
    [Migration("20160831190012_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.Authorization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Allowed");

                    b.Property<bool>("Denied");

                    b.Property<int>("PermissionId");

                    b.Property<int>("RoleId");

                    b.Property<Guid>("UID");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.HasIndex("RoleId");

                    b.HasIndex("Id", "RoleId")
                        .IsUnique();

                    b.ToTable("Authorizations");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<Guid>("UID");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.Operation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClientId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<Guid>("UID");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Operations");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("OperationId");

                    b.Property<int>("ResourceId");

                    b.Property<Guid>("UID");

                    b.HasKey("Id");

                    b.HasIndex("OperationId");

                    b.HasIndex("ResourceId");

                    b.HasIndex("ResourceId", "OperationId")
                        .IsUnique();

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.Resource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClientId");

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<Guid>("UID");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClientId");

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<Guid>("UID");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.RoleAssignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AccountMemberId");

                    b.Property<int>("RoleId");

                    b.Property<int?>("RoleMemberId");

                    b.Property<Guid>("UID");

                    b.HasKey("Id");

                    b.HasIndex("AccountMemberId");

                    b.HasIndex("RoleId");

                    b.HasIndex("RoleMemberId");

                    b.HasIndex("RoleId", "RoleMemberId", "AccountMemberId")
                        .IsUnique();

                    b.ToTable("RoleAssignments");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.UserAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<int>("InvalidLoginAttemptsCount");

                    b.Property<bool>("MustChangePassword");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 999);

                    b.Property<int?>("ProfileId");

                    b.Property<Guid>("UID");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("ProfileId")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("UserAccounts");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.UserProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FullName")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<Guid>("UID");

                    b.HasKey("Id");

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.Authorization", b =>
                {
                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.Permission", "Permission")
                        .WithMany("Authorizations")
                        .HasForeignKey("PermissionId");

                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.Role", "Role")
                        .WithMany("Authorizations")
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.Operation", b =>
                {
                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.Client", "Client")
                        .WithMany("Operations")
                        .HasForeignKey("ClientId");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.Permission", b =>
                {
                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.Operation", "Operation")
                        .WithMany("Permissions")
                        .HasForeignKey("OperationId");

                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.Resource", "Resource")
                        .WithMany("Permissions")
                        .HasForeignKey("ResourceId");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.Resource", b =>
                {
                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.Client", "Client")
                        .WithMany("Resources")
                        .HasForeignKey("ClientId");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.Role", b =>
                {
                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.Client", "Client")
                        .WithMany("UserRoles")
                        .HasForeignKey("ClientId");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.RoleAssignment", b =>
                {
                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.UserAccount", "AccountMember")
                        .WithMany("Roles")
                        .HasForeignKey("AccountMemberId");

                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.Role", "Role")
                        .WithMany("Members")
                        .HasForeignKey("RoleId");

                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.Role", "RoleMember")
                        .WithMany("Roles")
                        .HasForeignKey("RoleMemberId");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.UserAccount", b =>
                {
                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.UserProfile", "Profile")
                        .WithOne("Account")
                        .HasForeignKey("Aritter.Domain.SecurityModule.Aggregates.UserAccount", "ProfileId");
                });
        }
    }
}
