using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

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

                    b.ToTable("Persons");
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

                    b.Property<int?>("ParentId")
                        .IsRequired();

                    b.Property<string>("Url")
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("Id");

                    b.HasIndex("ModuleId")
                        .HasName("IX_Menus_ModuleId");

                    b.HasIndex("ParentId")
                        .HasName("IX_Menus_ParentId");

                    b.HasIndex("ParentId", "ModuleId")
                        .IsUnique()
                        .HasName("IX_Menus_ParentId_ModuleId");

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
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("IX_Modules_Name");

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

                    b.HasIndex("ModuleId")
                        .HasName("IX_Resources_ModuleId");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.PermissionAgg.Authorization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Allowed");

                    b.Property<bool>("Denied");

                    b.Property<Guid>("Identity");

                    b.Property<bool>("IsEnabled");

                    b.Property<int>("PermissionId");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId")
                        .IsUnique()
                        .HasName("IX_Authorizations_PermissionId");

                    b.HasIndex("RoleId")
                        .HasName("IX_Authorizations_RoleId");

                    b.HasIndex("Id", "RoleId")
                        .IsUnique()
                        .HasName("IX_Authorizations_Id_RoleId");

                    b.ToTable("Authorizations");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.PermissionAgg.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("Identity");

                    b.Property<bool>("IsEnabled");

                    b.Property<int>("ModuleId");

                    b.Property<int>("ResourceId");

                    b.Property<int>("Rule");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId")
                        .HasName("IX_Permissions_ModuleId");

                    b.HasIndex("ResourceId")
                        .HasName("IX_Permissions_ResourceId");

                    b.HasIndex("ResourceId", "Rule")
                        .IsUnique()
                        .HasName("IX_Permissions_ResourceId_Rule");

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
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("IX_Roles_Name");

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

                    b.HasIndex("RoleId")
                        .HasName("IX_UserRoles_RoleId");

                    b.HasIndex("UserId")
                        .HasName("IX_UserRoles_UserId");

                    b.HasIndex("UserId", "RoleId")
                        .IsUnique()
                        .HasName("IX_UserRoles_UserId_RoleId");

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
                        .IsUnique()
                        .HasName("IX_UserCredentials_UserId");

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
                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.ModuleAgg.Module", "Module")
                        .WithMany("Permissions")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.ModuleAgg.Resource", "Resource")
                        .WithMany("Permissions")
                        .HasForeignKey("ResourceId");
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
