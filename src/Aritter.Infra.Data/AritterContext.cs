using Aritter.Domain.Security.Aggregates;
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

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<UserProfile> UserProfiles { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<UserRole> RoleAssignments { get; set; }

        public virtual DbSet<Application> Applications { get; set; }

        public virtual DbSet<Resource> Resources { get; set; }

        public virtual DbSet<Domain.Security.Aggregates.Rule> Rules { get; set; }

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
            modelBuilder.Entity<Application>(entity =>
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

            modelBuilder.Entity<Domain.Security.Aggregates.Rule>((Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Domain.Security.Aggregates.Rule> entity) =>
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

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.Rules)
                    .HasForeignKey(d => d.ApplicationId)
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

                entity.HasIndex(e => new { e.ResourceId, e.RuleId })
                    .IsUnique();

                entity.HasOne(d => d.Rule)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.RuleId)
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

                entity.HasIndex(e => e.ApplicationId);

                entity.Property(e => e.Description)
                    .HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.Resources)
                    .HasForeignKey(d => d.ApplicationId)
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

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.HasIndex(e => e.RoleId);

                entity.HasIndex(e => e.UserId);

                entity.HasIndex(e => new { e.RoleId, e.UserId })
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

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<User>(entity =>
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
                    .WithOne(p => p.User)
                    .HasForeignKey<UserProfile>(p => p.UserId);
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.HasKey(p => p.UserId);

                entity.Property(p => p.UserId)
                    .ValueGeneratedNever()
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

                if (Applications != null)
                    Applications = null;

                if (Resources != null)
                    Resources = null;

                if (Authorizations != null)
                    Authorizations = null;

                if (Rules != null)
                    Rules = null;

                if (Permissions != null)
                    Permissions = null;

                if (Roles != null)
                    Roles = null;

                if (RoleAssignments != null)
                    RoleAssignments = null;

                if (Users != null)
                    Users = null;
            }
        }

        #endregion
    }
}