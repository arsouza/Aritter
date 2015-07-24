using System.Data.Entity.Migrations;

namespace Aritter.Infrastructure.Data.Migrations
{
	public partial class M006 : DbMigration
	{
		public override void Up()
		{
			RenameIndex("dbo.Users", "UQ_UserMail", "UQ_UserMailAddress");
		}

		public override void Down()
		{
			RenameIndex("dbo.Users", "UQ_UserMailAddress", "UQ_UserMail");
		}
	}
}
