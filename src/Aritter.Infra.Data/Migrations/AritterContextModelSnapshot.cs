using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Aritter.Infra.Data;

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

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ResourceId");

                    b.Property<int>("RuleId");

                    b.Property<Guid>("UID");

                    b.HasKey("Id");

                    b.HasIndex("ResourceId");

                    b.HasIndex("RuleId");

                    b.HasIndex("ResourceId", "RuleId")
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

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.RoleMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MemberId");

                    b.Property<int>("RoleId");

                    b.Property<Guid>("UID");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("RoleId");

                    b.HasIndex("RoleId", "MemberId")
                        .IsUnique();

                    b.ToTable("RoleMembers");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.Rule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClientId");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<Guid>("UID");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Rules");
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

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.Permission", b =>
                {
                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.Resource", "Resource")
                        .WithMany("Permissions")
                        .HasForeignKey("ResourceId");

                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.Rule", "Rule")
                        .WithMany("Permissions")
                        .HasForeignKey("RuleId");
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

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.RoleMember", b =>
                {
                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.UserAccount", "Member")
                        .WithMany("Roles")
                        .HasForeignKey("MemberId");

                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.Role", "Role")
                        .WithMany("Members")
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Aritter.Domain.SecurityModule.Aggregates.Rule", b =>
                {
                    b.HasOne("Aritter.Domain.SecurityModule.Aggregates.Client", "Client")
                        .WithMany("Rules")
                        .HasForeignKey("ClientId");
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
