using System.Data.Entity.Migrations;

namespace Aritter.Manager.Infrastructure.Data.Migrations
{
	public partial class M004 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Users", "UQ_UserMail");
            AddColumn("dbo.Users", "MailAddress", c => c.String(false, 255, unicode: false));
            CreateIndex("dbo.Users", "MailAddress", true, "UQ_UserMail");
            DropColumn("dbo.Users", "Mail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Mail", c => c.String(false, 255, unicode: false));
            DropIndex("dbo.Users", "UQ_UserMail");
            DropColumn("dbo.Users", "MailAddress");
            CreateIndex("dbo.Users", "Mail", true, "UQ_UserMail");
        }
    }
}
