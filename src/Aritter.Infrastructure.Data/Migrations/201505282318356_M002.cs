using System.Data.Entity.Migrations;

namespace Aritter.Infrastructure.Data.Migrations
{
	public partial class M002 : DbMigration
	{
		public override void Up()
		{
			CreateTable(
				"dbo.Dictionaries",
				c => new
				{
					Id = c.Int(false, true),
					Name = c.String(false, 255, unicode: false),
					Guid = c.Guid(false),
					IsActive = c.Boolean(false)
				})
				.PrimaryKey(t => t.Id);

			CreateTable(
				"dbo.DictionaryValues",
				c => new
				{
					Id = c.Int(false, true),
					IdDictionary = c.Int(false),
					Value = c.Int(false),
					Description = c.String(false, 8000, unicode: false),
					Guid = c.Guid(false),
					IsActive = c.Boolean(false)
				})
				.PrimaryKey(t => t.Id)
				.ForeignKey("dbo.Dictionaries", t => t.IdDictionary)
				.Index(t => t.IdDictionary);

		}

		public override void Down()
		{
			DropForeignKey("dbo.DictionaryValues", "IdDictionary", "dbo.Dictionaries");
			DropIndex("dbo.DictionaryValues", new[] { "IdDictionary" });
			DropTable("dbo.DictionaryValues");
			DropTable("dbo.Dictionaries");
		}
	}
}
