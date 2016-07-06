using Aritter.Domain.SecurityModule.Aggregates.MainAgg;
using Aritter.Domain.SecurityModule.Aggregates.ModuleAgg;
using Aritter.Domain.SecurityModule.Aggregates.PermissionAgg;
using Aritter.Domain.SecurityModule.Aggregates.UserAgg;
using Aritter.Infra.Configuration;
using Aritter.Infra.Data.Seedwork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Aritter.Infra.Data.UnitOfWork
{
    public class AritterContext : DbContext, IQueryableUnitOfWork
    {
        protected bool Disposed { get; set; }

        public virtual DbSet<Authorization> Authorizations { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserCredential> UserCredentials { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
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
            modelBuilder.Entity<Authorization>(entity =>
            {
                entity.HasIndex(e => e.PermissionId)
                    .HasName("IX_Authorizations_PermissionId")
                    .IsUnique();

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_Authorizations_RoleId");

                entity.HasIndex(e => new { e.Id, e.RoleId })
                    .HasName("IX_Authorizations_Id_RoleId")
                    .IsUnique();

                entity.HasOne(d => d.Permission)
                    .WithOne(p => p.Authorization)
                    .HasForeignKey<Authorization>(d => d.PermissionId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Authorizations)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasIndex(e => e.ModuleId)
                    .HasName("IX_Menus_ModuleId");

                entity.HasIndex(e => e.ParentId)
                    .HasName("IX_Menus_ParentId");

                entity.HasIndex(e => new { e.ParentId, e.ModuleId })
                    .HasName("IX_Menus_ParentId_ModuleId")
                    .IsUnique();

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Image).HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ParentId).IsRequired();

                entity.Property(e => e.Url).HasMaxLength(100);

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.Menus)
                    .HasForeignKey(d => d.ModuleId);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.Children)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("IX_Modules_Name")
                    .IsUnique();

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.LastName).HasMaxLength(100);
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasIndex(e => e.ModuleId)
                    .HasName("IX_Permissions_ModuleId");

                entity.HasIndex(e => e.ResourceId)
                    .HasName("IX_Permissions_ResourceId");

                entity.HasIndex(e => new { e.ResourceId, e.Rule })
                    .HasName("IX_Permissions_ResourceId_Rule")
                    .IsUnique();

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.ModuleId);

                entity.HasOne(d => d.Resource)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.ResourceId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasIndex(e => e.ModuleId)
                    .HasName("IX_Resources_ModuleId");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.Resources)
                    .HasForeignKey(d => d.ModuleId);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("IX_Roles_Name")
                    .IsUnique();

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UserCredential>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserCredentials_UserId")
                    .IsUnique();

                entity.Property(e => e.PasswordHash).HasMaxLength(100);

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Credential)
                    .HasForeignKey<UserCredential>(d => d.UserId);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_UserRoles_RoleId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserRoles_UserId");

                entity.HasIndex(e => new { e.UserId, e.RoleId })
                    .HasName("IX_UserRoles_UserId_RoleId")
                    .IsUnique();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<User>(entity =>
            {
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
                    .HasMaxLength(100);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Person)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.PersonId);
            });
        }

        protected void Dispose(bool disposing)
        {
            if (!Disposed && disposing)
            {
                if (Authorizations != null)
                    Authorizations = null;

                if (Modules != null)
                    Modules = null;

                if (UserCredentials != null)
                    UserCredentials = null;

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

                if (Menus != null)
                    Menus = null;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();

            optionsBuilder.UseLoggerFactory(GetLoggerFactory());
            optionsBuilder.UseSqlServer(ApplicationSettings.ConnectionString("aritter"));
        }

        private ILoggerFactory GetLoggerFactory()
        {
            var factory = new EFLoggerFactory();
            factory.AddProvider(new EFLoggerProvider());

            return factory;
        }

        #endregion
    }
    public class EFLoggerFactory : ILoggerFactory
    {
        private ILoggerProvider provider;

        public void AddProvider(ILoggerProvider provider)
        {
            this.provider = provider;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return provider.CreateLogger(categoryName);
        }

        public void Dispose()
        {
        }
    }

    public class EFLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new EFLogger();
        }

        public void Dispose()
        {
            // N/A
        }
    }

    public class EFLogger : ILogger
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public IDisposable BeginScopeImpl(object state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log(LogLevel logLevel, int eventId, object state, Exception exception, Func<object, Exception, string> formatter)
        {
            File.AppendAllText(@"C:\Logs\EF.LOG", formatter(state, exception));
            Debug.WriteLine(formatter(state, exception));
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            using (var file = new FileInfo(@"C:\Logs\EF.LOG").AppendText())
            {
                file.WriteLine(formatter(state, exception));
            }
            Debug.WriteLine(formatter(state, exception));
        }
    }
}