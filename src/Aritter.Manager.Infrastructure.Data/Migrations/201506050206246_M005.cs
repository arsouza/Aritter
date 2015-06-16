namespace Aritter.Manager.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
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
