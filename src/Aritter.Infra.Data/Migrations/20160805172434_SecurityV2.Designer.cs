using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Aritter.Infra.Data;

namespace Aritter.Infra.Data.Migrations
{
    [DbContext(typeof(AritterContext))]
    [Migration("20160805172434_SecurityV2")]
    partial class SecurityV2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.Modules.Application", b =>
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
                        .IsUnique()
                        .HasName("IX_Application_Name");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.Modules.Resource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ApplicationId");

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<Guid>("UID");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId")
                        .HasName("IX_Resources_ApplicationId");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.Permissions.Authorization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Allowed");

                    b.Property<bool>("Denied");

                    b.Property<int>("PermissionId");

                    b.Property<Guid>("UID");

                    b.Property<int>("UserRoleId");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId")
                        .HasName("IX_Authorizations_PermissionId");

                    b.HasIndex("UserRoleId")
                        .HasName("IX_Authorizations_UserRoleId");

                    b.HasIndex("Id", "UserRoleId")
                        .IsUnique()
                        .HasName("IX_Authorizations_Id_UserRoleId");

                    b.ToTable("Authorizations");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.Permissions.Operation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ApplicationId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<Guid>("UID");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("IX_Operation_Name");

                    b.ToTable("Operations");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.Permissions.Permission", b =>
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
                        .IsUnique()
                        .HasName("IX_Permissions_ResourceId_OperationId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.Permissions.UserAssignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("UID");

                    b.Property<int>("UserAccountId");

                    b.Property<int>("UserRoleId");

                    b.HasKey("Id");

                    b.HasIndex("UserAccountId")
                        .HasName("IX_UserAssignments_UserId");

                    b.HasIndex("UserRoleId")
                        .HasName("IX_UserAssignments_UserRoleId");

                    b.HasIndex("UserAccountId", "UserRoleId")
                        .IsUnique()
                        .HasName("IX_UserAssignments_UserId_UserRoleId");

                    b.ToTable("UserAssignments");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.Permissions.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ApplicationId");

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<Guid>("UID");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("IX_UserRoles_Name");

                    b.ToTable("UserUserRoles");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.Users.UserAccount", b =>
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

                    b.Property<Guid>("UID");

                    b.Property<int?>("UserProfileId");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasName("IX_UserAccounts_Email");

                    b.HasIndex("UserProfileId")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique()
                        .HasName("IX_UserAccounts_Username");

                    b.ToTable("UserAccounts");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.Users.UserProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<Guid>("UID");

                    b.HasKey("Id");

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.Modules.Resource", b =>
                {
                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.Modules.Application", "Application")
                        .WithMany("Resources")
                        .HasForeignKey("ApplicationId")
                        .HasConstraintName("FK_Resources_Applications");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.Permissions.Authorization", b =>
                {
                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.Permissions.Permission", "Permission")
                        .WithMany("Authorizations")
                        .HasForeignKey("PermissionId");

                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.Permissions.UserRole", "Role")
                        .WithMany("Authorizations")
                        .HasForeignKey("UserRoleId");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.Permissions.Operation", b =>
                {
                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.Modules.Application", "Application")
                        .WithMany("Operations")
                        .HasForeignKey("ApplicationId")
                        .HasConstraintName("FK_Operations_Applications");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.Permissions.Permission", b =>
                {
                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.Permissions.Operation", "Operation")
                        .WithMany("Permissions")
                        .HasForeignKey("OperationId")
                        .HasConstraintName("FK_Permissions_Operations");

                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.Modules.Resource", "Resource")
                        .WithMany("Permissions")
                        .HasForeignKey("ResourceId");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.Permissions.UserAssignment", b =>
                {
                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.Users.UserAccount", "UserAccount")
                        .WithMany("Assignments")
                        .HasForeignKey("UserAccountId");

                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.Permissions.UserRole", "UserRole")
                        .WithMany("UserAssignments")
                        .HasForeignKey("UserRoleId")
                        .HasConstraintName("FK_UserAssignments_UserRoles");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.Permissions.UserRole", b =>
                {
                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.Modules.Application", "Application")
                        .WithMany("UserRoles")
                        .HasForeignKey("ApplicationId")
                        .HasConstraintName("FK_UserRoles_Applications");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.Users.UserAccount", b =>
                {
                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.Users.UserProfile", "UserProfile")
                        .WithOne("UserAccount")
                        .HasForeignKey("Aritter.Domain.SecurityModule.Aggregates.Users.UserAccount", "UserProfileId");
                });
        }
    }
}
