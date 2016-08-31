﻿using Aritter.Domain.SecurityModule.Aggregates;
using Aritter.Infra.Configuration;
using Aritter.Infra.Crosscutting.Logging;
using Aritter.Infra.Data.Seedwork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace Aritter.Infra.Data
{
    public class AritterContext : DbContext, IQueryableUnitOfWork
    {
        private IDbContextTransaction transaction;
        private bool disposed = false;

        public virtual DbSet<UserAccount> UserAccounts { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserAssignment> UserAssignments { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Operation> Operations { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Authorization> Authorizations { get; set; }

        #region IQueryableUnitOfWork Members

        public void BeginTransaction()
        {
            transaction = Database.BeginTransaction(IsolationLevel.ReadUncommitted);
        }

        public void Commit()
        {
            SaveChanges();

            if (transaction != null)
            {
                Database.CommitTransaction();
            }
        }

        public void Rollback()
        {
            if (transaction != null)
            {
                Database.RollbackTransaction();
            }
        }

        #endregion

        #region Overrides DbContext

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Id)
                    .ValueGeneratedOnAdd()
                    .IsRequired();

                entity.Property(e => e.UID)
                    .IsRequired();

                entity.HasIndex(e => e.Name)
                    .HasName("IX_Client_Name")
                    .IsUnique();

                entity.Property(e => e.Description)
                    .HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Authorization>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Id)
                    .ValueGeneratedOnAdd()
                    .IsRequired();

                entity.Property(e => e.UID)
                    .IsRequired();

                entity.HasIndex(e => e.PermissionId)
                    .HasName("IX_Authorizations_PermissionId")
                    .IsUnique();

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_Authorizations_UserRoleId");

                entity.HasIndex(e => new { e.Id, e.RoleId })
                    .HasName("IX_Authorizations_Id_UserRoleId")
                    .IsUnique();

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.Authorizations)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Authorizations_Permissions");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Authorizations)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Authorizations_UserRoles");
            });

            modelBuilder.Entity<Operation>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Id)
                    .ValueGeneratedOnAdd()
                    .IsRequired();

                entity.Property(e => e.UID)
                    .IsRequired();

                entity.HasIndex(e => e.Name)
                    .HasName("IX_Operation_Name")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Operations)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Operations_Clients");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Id)
                    .ValueGeneratedOnAdd()
                    .IsRequired();

                entity.Property(e => e.UID)
                    .IsRequired();

                entity.HasIndex(e => new { e.ResourceId, e.OperationId })
                    .HasName("IX_Permissions_ResourceId_OperationId")
                    .IsUnique();

                entity.HasOne(d => d.Operation)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.OperationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Permissions_Operations");

                entity.HasOne(d => d.Resource)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.ResourceId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Permissions_Resources");
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Id)
                    .ValueGeneratedOnAdd()
                    .IsRequired();

                entity.Property(e => e.UID)
                    .IsRequired();

                entity.HasIndex(e => e.ClientId)
                    .HasName("IX_Resources_ClientId");

                entity.Property(e => e.Description)
                    .HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Resources)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Resources_Clients");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Id)
                    .ValueGeneratedOnAdd()
                    .IsRequired();

                entity.Property(e => e.UID)
                    .IsRequired();

                entity.HasIndex(e => e.Name)
                    .HasName("IX_UserRoles_Name")
                    .IsUnique();

                entity.Property(e => e.Description)
                    .HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_UserRoles_Clients");
            });

            modelBuilder.Entity<UserAssignment>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Id)
                    .ValueGeneratedOnAdd()
                    .IsRequired();

                entity.Property(e => e.UID)
                    .IsRequired();

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_UserAssignments_UserRoleId");

                entity.HasIndex(e => e.AccountId)
                    .HasName("IX_UserAssignments_UserAccountId");

                entity.HasIndex(e => new { e.AccountId, e.RoleId })
                    .HasName("IX_UserAssignments_UserAccountId_UserRoleId")
                    .IsUnique();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_UserAssignments_UserRoles");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_UserAssignments_UserAccounts");
            });

            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.HasIndex(e => new { e.Username })
                    .HasName("IX_UserAccounts_Username")
                    .IsUnique();

                entity.HasIndex(e => new { e.Email })
                    .HasName("IX_UserAccounts_Email")
                    .IsUnique();

                entity.Property(p => p.Id)
                    .ValueGeneratedOnAdd()
                    .IsRequired();

                entity.Property(e => e.UID)
                    .IsRequired();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(999);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MustChangePassword)
                    .IsRequired();

                entity.Property(e => e.InvalidLoginAttemptsCount)
                    .IsRequired();

                entity.HasOne(p => p.Profile)
                    .WithOne(p => p.Account)
                    .HasForeignKey<UserAccount>(p => p.ProfileId);
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Id)
                    .ValueGeneratedOnAdd()
                    .IsRequired();

                entity.Property(e => e.UID)
                    .IsRequired();

                entity.Property(e => e.FullName)
                    .HasMaxLength(100);
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            LoggerFactory.SetCurrent(new NLogFactory());

            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseLoggerFactory(LoggerFactory.Current());

            optionsBuilder.UseSqlServer(ApplicationSettings.ConnectionString("Aritter_SqlServer"));
            //optionsBuilder.UseNpgsql(ApplicationSettings.ConnectionString("Aritter_Npgsql"));
        }

        public override void Dispose()
        {
            Dispose(true);
        }

        protected void Dispose(bool disposing)
        {
            base.Dispose();

            if (!disposed && disposing)
            {
                if (UserProfiles != null)
                    UserProfiles = null;

                if (Clients != null)
                    Clients = null;

                if (Resources != null)
                    Resources = null;

                if (Authorizations != null)
                    Authorizations = null;

                if (Operations != null)
                    Operations = null;

                if (Permissions != null)
                    Permissions = null;

                if (Roles != null)
                    Roles = null;

                if (UserAssignments != null)
                    UserAssignments = null;

                if (UserAccounts != null)
                    UserAccounts = null;
            }
        }

        #endregion
    }
}