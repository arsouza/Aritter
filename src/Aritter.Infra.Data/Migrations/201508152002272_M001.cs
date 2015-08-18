namespace Aritter.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuditLogDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuditLogId = c.Int(nullable: false),
                        FieldName = c.String(nullable: false, maxLength: 8000, unicode: false),
                        OldValue = c.String(maxLength: 8000, unicode: false),
                        NewValue = c.String(maxLength: 8000, unicode: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AuditLogs", t => t.AuditLogId)
                .Index(t => t.AuditLogId);
            
            CreateTable(
                "dbo.AuditLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        EntityName = c.String(nullable: false, maxLength: 250, unicode: false),
                        EntityId = c.Int(),
                        EntityGuid = c.Guid(nullable: false),
                        UserId = c.Int(nullable: false),
                        LogDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Authentications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        UserName = c.String(maxLength: 20, unicode: false),
                        Date = c.DateTime(nullable: false),
                        State = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 100, unicode: false),
                        PasswordHash = c.String(nullable: false, maxLength: 100, unicode: false),
                        FirstName = c.String(nullable: false, maxLength: 100, unicode: false),
                        LastName = c.String(maxLength: 100, unicode: false),
                        Email = c.String(nullable: false, maxLength: 255, unicode: false),
                        EmailConfirmed = c.Boolean(nullable: false),
                        MustChangePassword = c.Boolean(nullable: false),
                        SecurityStamp = c.String(maxLength: 255, unicode: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        Guid = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UQ_UserUsername")
                .Index(t => t.Email, unique: true, name: "UQ_UserMailAddress");
            
            CreateTable(
                "dbo.Authorizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PermissionId = c.Int(nullable: false),
                        UserId = c.Int(),
                        RoleId = c.Int(),
                        Allowed = c.Boolean(nullable: false),
                        Denied = c.Boolean(nullable: false),
                        Guid = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
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
                        Id = c.Int(nullable: false, identity: true),
                        ResourceId = c.Int(nullable: false),
                        OperationId = c.Int(nullable: false),
                        Guid = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Operations", t => t.OperationId)
                .ForeignKey("dbo.Resources", t => t.ResourceId)
                .Index(t => new { t.ResourceId, t.OperationId }, unique: true, name: "UQ_Permission");
            
            CreateTable(
                "dbo.Operations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        Description = c.String(maxLength: 255, unicode: false),
                        Guid = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "UQ_Operation");
            
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 50, unicode: false),
                        Description = c.String(maxLength: 100, unicode: false),
                        Action = c.String(maxLength: 50, unicode: false),
                        Controller = c.String(maxLength: 50, unicode: false),
                        Area = c.String(maxLength: 50, unicode: false),
                        Icon = c.String(maxLength: 20, unicode: false),
                        Order = c.Int(nullable: false),
                        ParentId = c.Int(),
                        ModuleId = c.Int(nullable: false),
                        Guid = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Modules", t => t.ModuleId)
                .ForeignKey("dbo.Resources", t => t.ParentId)
                .Index(t => new { t.ModuleId, t.ParentId, t.Title, t.Area, t.Controller, t.Action, t.Order }, unique: true, name: "UQ_Resource");
            
            CreateTable(
                "dbo.Modules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        Description = c.String(maxLength: 255, unicode: false),
                        Guid = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "UQ_Module");
            
            CreateTable(
                "dbo.ModuleRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModuleId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        Guid = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Modules", t => t.ModuleId)
                .ForeignKey("dbo.Roles", t => t.RoleId)
                .Index(t => new { t.ModuleId, t.RoleId }, unique: true, name: "UQ_ModuleRole");
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        Description = c.String(maxLength: 255, unicode: false),
                        Guid = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "UQ_Role");
            
            CreateTable(
                "dbo.UserPolicies",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        MaximumPasswordAge = c.Int(nullable: false),
                        MinimumPasswordAge = c.Int(nullable: false),
                        MaximumLoginAttempts = c.Int(nullable: false),
                        EnforcePasswordHistory = c.Int(nullable: false),
                        Guid = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.UserPasswordPolicies",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        RequireLength = c.Int(nullable: false),
                        RequireNonLetterOrDigit = c.Boolean(nullable: false),
                        RequireDigit = c.Boolean(nullable: false),
                        RequireLowercase = c.Boolean(nullable: false),
                        RequireUppercase = c.Boolean(nullable: false),
                        Guid = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserPolicies", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        Guid = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => new { t.UserId, t.RoleId }, unique: true, name: "UQ_UserRole");
            
            CreateTable(
                "dbo.UserPasswordHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Password = c.String(nullable: false, maxLength: 50, unicode: false),
                        Date = c.DateTime(nullable: false),
                        Guid = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
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
            DropIndex("dbo.Users", "UQ_UserMailAddress");
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
