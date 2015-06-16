namespace Aritter.Manager.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M006 : DbMigration
    {
        public override void Up()
        {
            RenameIndex(table: "dbo.Users", name: "UQ_UserMail", newName: "UQ_UserMailAddress");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Users", name: "UQ_UserMailAddress", newName: "UQ_UserMail");
        }
    }
}
