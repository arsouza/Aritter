using Aritter.Domain.SecurityModule.Aggregates;
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

        public virtual DbSet<RoleMember> RoleMembers { get; set; }

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
                    .IsUnique();

                entity.HasIndex(e => e.RoleId);

                entity.HasIndex(e => new { e.Id, e.RoleId })
                    .IsUnique();

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.Authorizations)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Authorizations)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Restrict);
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
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Operations)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.Restrict);
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
                    .IsUnique();

                entity.HasOne(d => d.Operation)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.OperationId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Resource)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.ResourceId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Id)
                    .ValueGeneratedOnAdd()
                    .IsRequired();

                entity.Property(e => e.UID)
                    .IsRequired();

                entity.HasIndex(e => e.ClientId);

                entity.Property(e => e.Description)
                    .HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Resources)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.Restrict);
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
                    .IsUnique();

                entity.Property(e => e.Description)
                    .HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<RoleMember>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.HasIndex(e => e.RoleId);

                entity.HasIndex(e => e.MemberId);

                entity.HasIndex(e => new { e.RoleId, e.MemberId })
                    .IsUnique();

                entity.Property(p => p.Id)
                    .ValueGeneratedOnAdd()
                    .IsRequired();

                entity.Property(e => e.UID)
                    .IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.HasIndex(e => new { e.Username })
                    .IsUnique();

                entity.HasIndex(e => new { e.Email })
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

                if (RoleMembers != null)
                    RoleMembers = null;

                if (UserAccounts != null)
                    UserAccounts = null;
            }
        }

        #endregion
    }
}