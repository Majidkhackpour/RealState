namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _111 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contracts", "Bazaryab2Guid", c => c.Guid());
            AddColumn("dbo.Contracts", "Bazaryab2Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            CreateIndex("dbo.Contracts", "Bazaryab2Guid");
            AddForeignKey("dbo.Contracts", "Bazaryab2Guid", "dbo.Tafsils", "Guid");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contracts", "Bazaryab2Guid", "dbo.Tafsils");
            DropIndex("dbo.Contracts", new[] { "Bazaryab2Guid" });
            DropColumn("dbo.Contracts", "Bazaryab2Price");
            DropColumn("dbo.Contracts", "Bazaryab2Guid");
        }
    }
}
