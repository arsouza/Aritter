namespace Aritter.Manager.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M004 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Users", "UQ_UserMail");
            AddColumn("dbo.Users", "MailAddress", c => c.String(nullable: false, maxLength: 255, unicode: false));
            CreateIndex("dbo.Users", "MailAddress", unique: true, name: "UQ_UserMail");
            DropColumn("dbo.Users", "Mail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Mail", c => c.String(nullable: false, maxLength: 255, unicode: false));
            DropIndex("dbo.Users", "UQ_UserMail");
            DropColumn("dbo.Users", "MailAddress");
            CreateIndex("dbo.Users", "Mail", unique: true, name: "UQ_UserMail");
        }
    }
}
