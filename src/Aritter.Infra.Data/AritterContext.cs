using Aritter.Domain.SecurityModule.Aggregates.Modules;
using Aritter.Domain.SecurityModule.Aggregates.Permissions;
using Aritter.Domain.SecurityModule.Aggregates.Users;
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
		public virtual DbSet<UserRole> UserRoles { get; set; }
		public virtual DbSet<UserAssignment> UserAssignments { get; set; }
		public virtual DbSet<Application> Applications { get; set; }
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
			modelBuilder.Entity<Application>(entity =>
			{
				entity.HasKey(p => p.Id);

				entity.Property(p => p.Id)
					.IsRequired();

				entity.Property(e => e.UID)
					.IsRequired();

				entity.HasIndex(e => e.Name)
					.HasName("IX_Application_Name")
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
					.IsRequired();

				entity.Property(e => e.UID)
					.IsRequired();

				entity.HasIndex(e => e.PermissionId)
					.HasName("IX_Authorizations_PermissionId")
					.IsUnique();

				entity.HasIndex(e => e.UserRoleId)
					.HasName("IX_Authorizations_UserRoleId");

				entity.HasIndex(e => new { e.Id, e.UserRoleId })
					.HasName("IX_Authorizations_Id_UserRoleId")
					.IsUnique();

				entity.HasOne(d => d.Permission)
					.WithMany(p => p.Authorizations)
					.HasForeignKey(d => d.PermissionId)
					.OnDelete(DeleteBehavior.Restrict)
					.HasConstraintName("FK_Authorizations_Permissions");

				entity.HasOne(d => d.Role)
					.WithMany(p => p.Authorizations)
					.HasForeignKey(d => d.UserRoleId)
					.OnDelete(DeleteBehavior.Restrict)
					.HasConstraintName("FK_Authorizations_UserRoles");
			});

			modelBuilder.Entity<Operation>(entity =>
			{
				entity.HasKey(p => p.Id);

				entity.Property(p => p.Id)
					.IsRequired();

				entity.Property(e => e.UID)
					.IsRequired();

				entity.HasIndex(e => e.Name)
					.HasName("IX_Operation_Name")
					.IsUnique();

				entity.Property(e => e.Name)
					.IsRequired()
					.HasMaxLength(50);

				entity.HasOne(d => d.Application)
					.WithMany(p => p.Operations)
					.HasForeignKey(d => d.ApplicationId)
					.OnDelete(DeleteBehavior.Restrict)
					.HasConstraintName("FK_Operations_Applications");
			});

			modelBuilder.Entity<Permission>(entity =>
			{
				entity.HasKey(p => p.Id);

				entity.Property(p => p.Id)
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
					.IsRequired();

				entity.Property(e => e.UID)
					.IsRequired();

				entity.HasIndex(e => e.ApplicationId)
					.HasName("IX_Resources_ApplicationId");

				entity.Property(e => e.Description)
					.HasMaxLength(256);

				entity.Property(e => e.Name)
					.IsRequired()
					.HasMaxLength(50);

				entity.HasOne(d => d.Application)
					.WithMany(p => p.Resources)
					.HasForeignKey(d => d.ApplicationId)
					.OnDelete(DeleteBehavior.Restrict)
					.HasConstraintName("FK_Resources_Applications");
			});

			modelBuilder.Entity<UserRole>(entity =>
			{
				entity.HasKey(p => p.Id);

				entity.Property(p => p.Id)
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

				entity.HasOne(d => d.Application)
					.WithMany(p => p.UserRoles)
					.HasForeignKey(d => d.ApplicationId)
					.OnDelete(DeleteBehavior.Restrict)
					.HasConstraintName("FK_UserRoles_Applications");
			});

			modelBuilder.Entity<UserAssignment>(entity =>
			{
				entity.HasKey(p => p.Id);

				entity.Property(p => p.Id)
					.IsRequired();

				entity.Property(e => e.UID)
					.IsRequired();

				entity.HasIndex(e => e.UserRoleId)
					.HasName("IX_UserAssignments_UserRoleId");

				entity.HasIndex(e => e.UserAccountId)
					.HasName("IX_UserAssignments_UserId");

				entity.HasIndex(e => new { e.UserAccountId, e.UserRoleId })
					.HasName("IX_UserAssignments_UserId_UserRoleId")
					.IsUnique();

				entity.HasOne(d => d.UserRole)
					.WithMany(p => p.UserAssignments)
					.HasForeignKey(d => d.UserRoleId)
					.OnDelete(DeleteBehavior.Restrict)
					.HasConstraintName("FK_UserAssignments_UserRoles");

				entity.HasOne(d => d.UserAccount)
					.WithMany(p => p.Assignments)
					.HasForeignKey(d => d.UserAccountId)
					.OnDelete(DeleteBehavior.Restrict)
					.HasConstraintName("FK_UserAssignments_UserAccounts");
			});

			modelBuilder.Entity<UserAccount>(entity =>
			{
				entity.HasKey(p => p.Id);

				entity.HasIndex(e => e.Username)
					.HasName("IX_UserAccounts_Username")
					.IsUnique();

				entity.HasIndex(e => e.Email)
					.HasName("IX_UserAccounts_Email")
					.IsUnique();

				entity.Property(p => p.Id)
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

				entity.HasOne(p => p.UserProfile)
					.WithOne(p => p.UserAccount)
					.HasForeignKey<UserAccount>(p => p.UserProfileId);
			});

			modelBuilder.Entity<UserProfile>(entity =>
			{
				entity.HasKey(p => p.Id);

				entity.Property(p => p.Id)
					.IsRequired();

				entity.Property(e => e.UID)
					.IsRequired();

				entity.Property(e => e.Name)
					.HasMaxLength(100);
			});
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			LoggerFactory.SetCurrent(new NLogFactory());

			optionsBuilder.EnableSensitiveDataLogging();
			optionsBuilder.UseLoggerFactory(LoggerFactory.Current());

			//optionsBuilder.UseSqlServer(ApplicationSettings.ConnectionString("aritter"));
			optionsBuilder.UseNpgsql(ApplicationSettings.ConnectionString("aritter"));
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

				if (Operations != null)
					Operations = null;

				if (Permissions != null)
					Permissions = null;

				if (UserRoles != null)
					UserRoles = null;

				if (UserAssignments != null)
					UserAssignments = null;

				if (UserAccounts != null)
					UserAccounts = null;
			}
		}

		#endregion
	}
}