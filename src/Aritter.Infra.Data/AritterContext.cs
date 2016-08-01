using Aritter.Domain.SecurityModule.Aggregates.MainAgg;
using Aritter.Domain.SecurityModule.Aggregates.ModuleAgg;
using Aritter.Domain.SecurityModule.Aggregates.PermissionAgg;
using Aritter.Domain.SecurityModule.Aggregates.UserAgg;
using Aritter.Infra.Configuration;
using Aritter.Infra.Data.Seedwork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;

namespace Aritter.Infra.Data
{
    public class AritterContext : DbContext, IQueryableUnitOfWork
    {
        protected bool Disposed { get; set; }

        public virtual DbSet<Authorization> Authorizations { get; set; }
        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserAssignment> UserAssignments { get; set; }
        public virtual DbSet<User> Users { get; set; }

        #region IQueryableUnitOfWork Members

        public void CommitChanges()
        {
            SaveChanges();
        }

        public void RollbackChanges()
        {
            Database.RollbackTransaction();
        }

        #endregion

        #region ISql Members

        public IEnumerable<TEntity> ExecuteQuery<TEntity>(string sqlQuery, params object[] parameters)
        {
            return null;
        }

        public int ExecuteCommand(string sqlCommand, params object[] parameters)
        {
            return Database.ExecuteSqlCommand(sqlCommand, parameters);
        }

        #endregion

        #region Overrides DbContext

        public override void Dispose()
        {
            Dispose(true);
            base.Dispose();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.HasIndex(e => e.Name)
                    .HasName("IX_Application_Name")
                    .IsUnique();

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(256)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Authorization>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.HasIndex(e => e.PermissionId)
                    .HasName("IX_Authorizations_PermissionId")
                    .IsUnique();

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_Authorizations_RoleId");

                entity.HasIndex(e => new { e.Id, e.RoleId })
                    .HasName("IX_Authorizations_Id_RoleId")
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
                    .HasConstraintName("FK_Authorizations_Roles");
            });

            modelBuilder.Entity<Operation>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.HasIndex(e => e.Name)
                    .HasName("IX_Operation_Name")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.Operations)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Operations_Applications");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasKey(p => p.Id);

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

                entity.HasIndex(e => e.ApplicationId)
                    .HasName("IX_Resources_ApplicationId");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(256)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.Resources)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Resources_Applications");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.HasIndex(e => e.Name)
                    .HasName("IX_Roles_Name")
                    .IsUnique();

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(256)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Roles_Applications");
            });

            modelBuilder.Entity<UserAssignment>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_UserAssignments_RoleId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserAssignments_UserId");

                entity.HasIndex(e => new { e.UserId, e.RoleId })
                    .HasName("IX_UserAssignments_UserId_RoleId")
                    .IsUnique();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserAssignments)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_UserAssignments_Roles");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserAssignments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_UserAssignments_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.HasIndex(e => e.Email)
                    .HasName("IX_Users_Email")
                    .IsUnique();

                entity.HasIndex(e => e.PersonId)
                    .HasName("IX_Users_PersonId")
                    .IsUnique();

                entity.HasIndex(e => e.Username)
                    .HasName("IX_Users_Username")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(256)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.MustChangePassword)
                    .IsRequired();

                entity.Property(e => e.InvalidLoginAttemptsCount)
                    .IsRequired();
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(e => e.FirstName)
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.LastName)
                    .HasColumnType("varchar(100)");
            });
        }

        protected void Dispose(bool disposing)
        {
            if (!Disposed && disposing)
            {
                if (Authorizations != null)
                    Authorizations = null;

                if (Applications != null)
                    Applications = null;

                if (Persons != null)
                    Persons = null;

                if (Permissions != null)
                    Permissions = null;

                if (Resources != null)
                    Resources = null;

                if (Roles != null)
                    Roles = null;

                if (Users != null)
                    Users = null;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();

            optionsBuilder.UseLoggerFactory(Crosscutting.Logging.LoggerFactory.CurrentFactory);
            optionsBuilder.UseSqlServer(ApplicationSettings.ConnectionString("aritter"));
        }

        #endregion
    }
}