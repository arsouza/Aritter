using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Aritter.Infra.Data.UnitOfWork;

namespace Aritter.Infra.Data.Migrations
{
    [DbContext(typeof(AritterContext))]
    partial class AritterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.MainAgg.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<Guid>("Identity");

                    b.Property<bool>("IsEnabled");

                    b.Property<string>("LastName")
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.ModuleAgg.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<Guid>("Identity");

                    b.Property<string>("Image")
                        .HasAnnotation("MaxLength", 200);

                    b.Property<bool>("IsEnabled");

                    b.Property<int>("ModuleId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<int?>("ParentId");

                    b.Property<string>("Url")
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.HasIndex("ParentId");

                    b.HasIndex("ParentId", "ModuleId")
                        .IsUnique();

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.ModuleAgg.Module", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 255);

                    b.Property<Guid>("Identity");

                    b.Property<bool>("IsEnabled");

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.ModuleAgg.Resource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<Guid>("Identity");

                    b.Property<bool>("IsEnabled");

                    b.Property<int>("ModuleId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.PermissionAgg.Authorization", b =>
                {
                    b.Property<int>("Id");

                    b.Property<bool>("Allowed");

                    b.Property<bool>("Denied");

                    b.Property<Guid>("Identity");

                    b.Property<bool>("IsEnabled");

                    b.Property<int>("PermissionId");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.HasIndex("Id", "RoleId")
                        .IsUnique();

                    b.ToTable("Authorizations");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.PermissionAgg.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("Identity");

                    b.Property<bool>("IsEnabled");

                    b.Property<int?>("ModuleId");

                    b.Property<int>("ResourceId");

                    b.Property<int>("Rule");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.HasIndex("ResourceId");

                    b.HasIndex("ResourceId", "Rule")
                        .IsUnique();

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.PermissionAgg.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 255);

                    b.Property<Guid>("Identity");

                    b.Property<bool>("IsEnabled");

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.PermissionAgg.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("Identity");

                    b.Property<bool>("IsEnabled");

                    b.Property<int>("RoleId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.HasIndex("UserId", "RoleId")
                        .IsUnique();

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.UserAgg.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<Guid>("Identity");

                    b.Property<bool>("IsEnabled");

                    b.Property<bool>("MustChangePassword");

                    b.Property<int>("PersonId");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.UserAgg.UserCredential", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<Guid>("Identity");

                    b.Property<int>("InvalidAttemptsCount");

                    b.Property<bool>("IsEnabled");

                    b.Property<string>("PasswordHash")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<int>("UserId");

                    b.Property<DateTime>("Validity");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserCredentials");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.ModuleAgg.Menu", b =>
                {
                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.ModuleAgg.Module", "Module")
                        .WithMany("Menus")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.ModuleAgg.Menu", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.ModuleAgg.Resource", b =>
                {
                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.ModuleAgg.Module", "Module")
                        .WithMany("Resources")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.PermissionAgg.Authorization", b =>
                {
                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.PermissionAgg.Permission", "Permission")
                        .WithOne("Authorization")
                        .HasForeignKey("Aritter.Domain.SecurityModule.Aggregates.PermissionAgg.Authorization", "PermissionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.PermissionAgg.Role", "Role")
                        .WithMany("Authorizations")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.PermissionAgg.Permission", b =>
                {
                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.ModuleAgg.Module")
                        .WithMany("Permissions")
                        .HasForeignKey("ModuleId");

                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.ModuleAgg.Resource", "Resource")
                        .WithMany("Permissions")
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.PermissionAgg.UserRole", b =>
                {
                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.PermissionAgg.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.UserAgg.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.UserAgg.User", b =>
                {
                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.MainAgg.Person", "Person")
                        .WithOne("User")
                        .HasForeignKey("Aritter.Domain.SecurityModule.Aggregates.UserAgg.User", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.UserAgg.UserCredential", b =>
                {
                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.UserAgg.User", "User")
                        .WithOne("Credential")
                        .HasForeignKey("Aritter.Domain.SecurityModule.Aggregates.UserAgg.UserCredential", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
