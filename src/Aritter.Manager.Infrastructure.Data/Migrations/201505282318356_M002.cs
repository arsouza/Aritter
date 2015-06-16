namespace Aritter.Manager.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M002 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dictionaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255, unicode: false),
                        Guid = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DictionaryValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdDictionary = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Guid = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
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
