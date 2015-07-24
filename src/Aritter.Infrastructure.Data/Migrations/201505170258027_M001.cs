using System.Data.Entity.Migrations;

namespace Aritter.Infrastructure.Data.Migrations
{
	public partial class M001 : DbMigration
	{
		public override void Up()
		{
			CreateTable(
				"dbo.AuditLogDetails",
				c => new
				{
					Id = c.Int(false, true),
					AuditLogId = c.Int(false),
					FieldName = c.String(false, 8000, unicode: false),
					OldValue = c.String(maxLength: 8000, unicode: false),
					NewValue = c.String(maxLength: 8000, unicode: false),
					Guid = c.Guid(false),
					IsActive = c.Boolean(false)
				})
				.PrimaryKey(t => t.Id)
				.ForeignKey("dbo.AuditLogs", t => t.AuditLogId)
				.Index(t => t.AuditLogId);

			CreateTable(
				"dbo.AuditLogs",
				c => new
				{
					Id = c.Int(false, true),
					Type = c.Int(false),
					EntityName = c.String(false, 250, unicode: false),
					EntityId = c.Int(),
					EntityGuid = c.Guid(false),
					UserId = c.Int(false),
					LogDate = c.DateTime(false),
					Guid = c.Guid(false),
					IsActive = c.Boolean(false)
				})
				.PrimaryKey(t => t.Id);

			CreateTable(
				"dbo.Authentications",
				c => new
				{
					Id = c.Int(false, true),
					UserId = c.Int(),
					UserName = c.String(maxLength: 20, unicode: false),
					Date = c.DateTime(false),
					State = c.Int(false),
					Guid = c.Guid(false),
					IsActive = c.Boolean(false)
				})
				.PrimaryKey(t => t.Id)
				.ForeignKey("dbo.Users", t => t.UserId)
				.Index(t => t.UserId);

			CreateTable(
				"dbo.Users",
				c => new
				{
					Id = c.Int(false, true),
					Username = c.String(false, 100, unicode: false),
					Password = c.String(false, 100, unicode: false),
					FirstName = c.String(false, 100, unicode: false),
					LastName = c.String(maxLength: 100, unicode: false),
					Mail = c.String(false, 255, unicode: false),
					MustChangePassword = c.Boolean(false),
					Guid = c.Guid(false),
					IsActive = c.Boolean(false)
				})
				.PrimaryKey(t => t.Id)
				.Index(t => t.Username, unique: true, name: "UQ_UserUsername")
				.Index(t => t.Mail, unique: true, name: "UQ_UserMail");

			CreateTable(
				"dbo.Authorizations",
				c => new
				{
					Id = c.Int(false, true),
					PermissionId = c.Int(false),
					UserId = c.Int(),
					RoleId = c.Int(),
					Allowed = c.Boolean(false),
					Denied = c.Boolean(false),
					Guid = c.Guid(false),
					IsActive = c.Boolean(false)
				})
				.PrimaryKey(t => t.Id)
				.ForeignKey("dbo.Permissions", t => t.PermissionId)
				.ForeignKey("dbo.Roles", t => t.RoleId)
				.ForeignKey("dbo.Users", t => t.UserId)
				.Index(t => new { t.PermissionId, t.UserId }, unique: true, name: "UQ_UserAuthorization")
				.Index(t => new { t.PermissionId, t.RoleId }, unique: true, name: "UQ_RoleAuthorization");

			CreateTable(
				"dbo.Permissions",
				c => new
				{
					Id = c.Int(false, true),
					ResourceId = c.Int(false),
					OperationId = c.Int(false),
					Guid = c.Guid(false),
					IsActive = c.Boolean(false)
				})
				.PrimaryKey(t => t.Id)
				.ForeignKey("dbo.Operations", t => t.OperationId)
				.ForeignKey("dbo.Resources", t => t.ResourceId)
				.Index(t => new { t.ResourceId, t.OperationId }, unique: true, name: "UQ_Permission");

			CreateTable(
				"dbo.Operations",
				c => new
				{
					Id = c.Int(false, true),
					Name = c.String(false, 50, unicode: false),
					Description = c.String(maxLength: 255, unicode: false),
					Guid = c.Guid(false),
					IsActive = c.Boolean(false)
				})
				.PrimaryKey(t => t.Id)
				.Index(t => t.Name, unique: true, name: "UQ_Operation");

			CreateTable(
				"dbo.Resources",
				c => new
				{
					Id = c.Int(false, true),
					Type = c.Int(false),
					Title = c.String(false, 50, unicode: false),
					Description = c.String(maxLength: 100, unicode: false),
					Action = c.String(maxLength: 50, unicode: false),
					Controller = c.String(maxLength: 50, unicode: false),
					Area = c.String(maxLength: 50, unicode: false),
					Icon = c.String(maxLength: 20, unicode: false),
					Order = c.Int(false),
					ParentId = c.Int(),
					ModuleId = c.Int(false),
					Guid = c.Guid(false),
					IsActive = c.Boolean(false)
				})
				.PrimaryKey(t => t.Id)
				.ForeignKey("dbo.Modules", t => t.ModuleId)
				.ForeignKey("dbo.Resources", t => t.ParentId)
				.Index(t => new { t.ModuleId, t.ParentId, t.Title, t.Area, t.Controller, t.Action, t.Order }, unique: true, name: "UQ_Resource");

			CreateTable(
				"dbo.Modules",
				c => new
				{
					Id = c.Int(false, true),
					Name = c.String(false, 50, unicode: false),
					Description = c.String(maxLength: 255, unicode: false),
					Guid = c.Guid(false),
					IsActive = c.Boolean(false)
				})
				.PrimaryKey(t => t.Id)
				.Index(t => t.Name, unique: true, name: "UQ_Module");

			CreateTable(
				"dbo.ModuleRoles",
				c => new
				{
					Id = c.Int(false, true),
					ModuleId = c.Int(false),
					RoleId = c.Int(false),
					Guid = c.Guid(false),
					IsActive = c.Boolean(false)
				})
				.PrimaryKey(t => t.Id)
				.ForeignKey("dbo.Modules", t => t.ModuleId)
				.ForeignKey("dbo.Roles", t => t.RoleId)
				.Index(t => new { t.ModuleId, t.RoleId }, unique: true, name: "UQ_ModuleRole");

			CreateTable(
				"dbo.Roles",
				c => new
				{
					Id = c.Int(false, true),
					Name = c.String(false, 50, unicode: false),
					Description = c.String(maxLength: 255, unicode: false),
					PrecedenceOrder = c.Int(false),
					Guid = c.Guid(false),
					IsActive = c.Boolean(false)
				})
				.PrimaryKey(t => t.Id)
				.Index(t => t.Name, unique: true, name: "UQ_Role");

			CreateTable(
				"dbo.UserPolicies",
				c => new
				{
					Id = c.Int(false),
					MaximumPasswordAge = c.Int(false),
					MinimumPasswordAge = c.Int(false),
					MaximumLoginAttempts = c.Int(false),
					EnforcePasswordHistory = c.Int(false),
					Guid = c.Guid(false),
					IsActive = c.Boolean(false)
				})
				.PrimaryKey(t => t.Id)
				.ForeignKey("dbo.Roles", t => t.Id)
				.Index(t => t.Id);

			CreateTable(
				"dbo.UserPasswordPolicies",
				c => new
				{
					Id = c.Int(false),
					RequiredMinimumLength = c.Int(false),
					RequiredMaximumLength = c.Int(),
					RequiredUppercase = c.Int(false),
					RequiredLowercase = c.Int(false),
					RequiredNonLetterOrDigit = c.Int(false),
					RequiredDigit = c.Int(false),
					Guid = c.Guid(false),
					IsActive = c.Boolean(false)
				})
				.PrimaryKey(t => t.Id)
				.ForeignKey("dbo.UserPolicies", t => t.Id)
				.Index(t => t.Id);

			CreateTable(
				"dbo.UserRoles",
				c => new
				{
					Id = c.Int(false, true),
					UserId = c.Int(false),
					RoleId = c.Int(false),
					Guid = c.Guid(false),
					IsActive = c.Boolean(false)
				})
				.PrimaryKey(t => t.Id)
				.ForeignKey("dbo.Roles", t => t.RoleId)
				.ForeignKey("dbo.Users", t => t.UserId)
				.Index(t => new { t.UserId, t.RoleId }, unique: true, name: "UQ_UserRole");

			CreateTable(
				"dbo.UserPasswordHistories",
				c => new
				{
					Id = c.Int(false, true),
					UserId = c.Int(false),
					Password = c.String(false, 50, unicode: false),
					Date = c.DateTime(false),
					Guid = c.Guid(false),
					IsActive = c.Boolean(false)
				})
				.PrimaryKey(t => t.Id)
				.ForeignKey("dbo.Users", t => t.UserId)
				.Index(t => t.UserId);

		}

		public override void Down()
		{
			DropForeignKey("dbo.Authentications", "UserId", "dbo.Users");
			DropForeignKey("dbo.UserPasswordHistories", "UserId", "dbo.Users");
			DropForeignKey("dbo.Authorizations", "UserId", "dbo.Users");
			DropForeignKey("dbo.Authorizations", "RoleId", "dbo.Roles");
			DropForeignKey("dbo.Authorizations", "PermissionId", "dbo.Permissions");
			DropForeignKey("dbo.Permissions", "ResourceId", "dbo.Resources");
			DropForeignKey("dbo.Resources", "ParentId", "dbo.Resources");
			DropForeignKey("dbo.Resources", "ModuleId", "dbo.Modules");
			DropForeignKey("dbo.ModuleRoles", "RoleId", "dbo.Roles");
			DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
			DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
			DropForeignKey("dbo.UserPolicies", "Id", "dbo.Roles");
			DropForeignKey("dbo.UserPasswordPolicies", "Id", "dbo.UserPolicies");
			DropForeignKey("dbo.ModuleRoles", "ModuleId", "dbo.Modules");
			DropForeignKey("dbo.Permissions", "OperationId", "dbo.Operations");
			DropForeignKey("dbo.AuditLogDetails", "AuditLogId", "dbo.AuditLogs");
			DropIndex("dbo.UserPasswordHistories", new[] { "UserId" });
			DropIndex("dbo.UserRoles", "UQ_UserRole");
			DropIndex("dbo.UserPasswordPolicies", new[] { "Id" });
			DropIndex("dbo.UserPolicies", new[] { "Id" });
			DropIndex("dbo.Roles", "UQ_Role");
			DropIndex("dbo.ModuleRoles", "UQ_ModuleRole");
			DropIndex("dbo.Modules", "UQ_Module");
			DropIndex("dbo.Resources", "UQ_Resource");
			DropIndex("dbo.Operations", "UQ_Operation");
			DropIndex("dbo.Permissions", "UQ_Permission");
			DropIndex("dbo.Authorizations", "UQ_RoleAuthorization");
			DropIndex("dbo.Authorizations", "UQ_UserAuthorization");
			DropIndex("dbo.Users", "UQ_UserMail");
			DropIndex("dbo.Users", "UQ_UserUsername");
			DropIndex("dbo.Authentications", new[] { "UserId" });
			DropIndex("dbo.AuditLogDetails", new[] { "AuditLogId" });
			DropTable("dbo.UserPasswordHistories");
			DropTable("dbo.UserRoles");
			DropTable("dbo.UserPasswordPolicies");
			DropTable("dbo.UserPolicies");
			DropTable("dbo.Roles");
			DropTable("dbo.ModuleRoles");
			DropTable("dbo.Modules");
			DropTable("dbo.Resources");
			DropTable("dbo.Operations");
			DropTable("dbo.Permissions");
			DropTable("dbo.Authorizations");
			DropTable("dbo.Users");
			DropTable("dbo.Authentications");
			DropTable("dbo.AuditLogs");
			DropTable("dbo.AuditLogDetails");
		}
	}
}
