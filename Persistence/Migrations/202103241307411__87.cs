namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _87 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contracts", "BazaryabGuid", c => c.Guid());
            CreateIndex("dbo.Contracts", "BazaryabGuid");
            AddForeignKey("dbo.Contracts", "BazaryabGuid", "dbo.Tafsils", "Guid");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contracts", "BazaryabGuid", "dbo.Tafsils");
            DropIndex("dbo.Contracts", new[] { "BazaryabGuid" });
            AlterColumn("dbo.Contracts", "BazaryabGuid", c => c.Guid(nullable: false));
        }
    }
}
