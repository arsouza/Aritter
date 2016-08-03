﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Aritter.Infra.Data;

namespace Aritter.Infra.Data.Migrations
{
    [DbContext(typeof(AritterContext))]
    [Migration("20160803025100_20160802V1")]
    partial class _20160802V1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.MainAgg.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Enabled");

                    b.Property<string>("FirstName")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("LastName")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<Guid>("UID");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.ModuleAgg.Application", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("Enabled");

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

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.ModuleAgg.Resource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ApplicationId");

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("Enabled");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<Guid>("UID");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId")
                        .HasName("IX_Resources_ApplicationId");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.PermissionAgg.Authorization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Allowed");

                    b.Property<bool>("Denied");

                    b.Property<bool>("Enabled");

                    b.Property<int>("PermissionId");

                    b.Property<int>("RoleId");

                    b.Property<Guid>("UID");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId")
                        .HasName("IX_Authorizations_PermissionId");

                    b.HasIndex("RoleId")
                        .HasName("IX_Authorizations_RoleId");

                    b.HasIndex("Id", "RoleId")
                        .IsUnique()
                        .HasName("IX_Authorizations_Id_RoleId");

                    b.ToTable("Authorizations");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.PermissionAgg.Operation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ApplicationId");

                    b.Property<bool>("Enabled");

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

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.PermissionAgg.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Enabled");

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

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.PermissionAgg.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ApplicationId");

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("Enabled");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<Guid>("UID");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("IX_Roles_Name");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.PermissionAgg.UserAssignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Enabled");

                    b.Property<int>("RoleId");

                    b.Property<Guid>("UID");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId")
                        .HasName("IX_UserAssignments_RoleId");

                    b.HasIndex("UserId")
                        .HasName("IX_UserAssignments_UserId");

                    b.HasIndex("UserId", "RoleId")
                        .IsUnique()
                        .HasName("IX_UserAssignments_UserId_RoleId");

                    b.ToTable("UserAssignments");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.UserAgg.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("Enabled");

                    b.Property<int>("InvalidLoginAttemptsCount");

                    b.Property<bool>("MustChangePassword");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 999);

                    b.Property<int>("PersonId");

                    b.Property<Guid>("UID");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasName("IX_Users_Email");

                    b.HasIndex("PersonId")
                        .IsUnique()
                        .HasName("IX_Users_PersonId");

                    b.HasIndex("Username")
                        .IsUnique()
                        .HasName("IX_Users_Username");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.ModuleAgg.Resource", b =>
                {
                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.ModuleAgg.Application", "Application")
                        .WithMany("Resources")
                        .HasForeignKey("ApplicationId")
                        .HasConstraintName("FK_Resources_Applications");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.PermissionAgg.Authorization", b =>
                {
                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.PermissionAgg.Permission", "Permission")
                        .WithMany("Authorizations")
                        .HasForeignKey("PermissionId");

                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.PermissionAgg.Role", "Role")
                        .WithMany("Authorizations")
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.PermissionAgg.Operation", b =>
                {
                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.ModuleAgg.Application", "Application")
                        .WithMany("Operations")
                        .HasForeignKey("ApplicationId")
                        .HasConstraintName("FK_Operations_Applications");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.PermissionAgg.Permission", b =>
                {
                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.PermissionAgg.Operation", "Operation")
                        .WithMany("Permissions")
                        .HasForeignKey("OperationId")
                        .HasConstraintName("FK_Permissions_Operations");

                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.ModuleAgg.Resource", "Resource")
                        .WithMany("Permissions")
                        .HasForeignKey("ResourceId");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.PermissionAgg.Role", b =>
                {
                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.ModuleAgg.Application", "Application")
                        .WithMany("Roles")
                        .HasForeignKey("ApplicationId")
                        .HasConstraintName("FK_Roles_Applications");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.PermissionAgg.UserAssignment", b =>
                {
                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.PermissionAgg.Role", "Role")
                        .WithMany("UserAssignments")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_UserAssignments_Roles");

                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.UserAgg.User", "User")
                        .WithMany("UserAssignments")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.UserAgg.User", b =>
                {
                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.MainAgg.Person", "Person")
                        .WithOne("User")
                        .HasForeignKey("Aritter.Domain.SecurityModule.Aggregates.UserAgg.User", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
