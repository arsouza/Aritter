using System.Data.Entity.Migrations;

namespace Aritter.Manager.Infrastructure.Data.Migrations
{
	public partial class M005 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "SecurityToken", c => c.Guid());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "SecurityToken");
        }
    }
}
