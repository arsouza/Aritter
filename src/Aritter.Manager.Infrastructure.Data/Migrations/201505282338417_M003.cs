using System.Data.Entity.Migrations;

namespace Aritter.Manager.Infrastructure.Data.Migrations
{
	public partial class M003 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AuditLogDetails", "Guid");
            DropColumn("dbo.AuditLogs", "Guid");
            DropColumn("dbo.Authentications", "Guid");
            DropColumn("dbo.Dictionaries", "Guid");
            DropColumn("dbo.DictionaryValues", "Guid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DictionaryValues", "Guid", c => c.Guid(false));
            AddColumn("dbo.Dictionaries", "Guid", c => c.Guid(false));
            AddColumn("dbo.Authentications", "Guid", c => c.Guid(false));
            AddColumn("dbo.AuditLogs", "Guid", c => c.Guid(false));
            AddColumn("dbo.AuditLogDetails", "Guid", c => c.Guid(false));
        }
    }
}
