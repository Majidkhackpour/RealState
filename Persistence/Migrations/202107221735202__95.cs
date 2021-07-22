namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _95 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WorkingRanges",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        RegionGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Guid)
                .ForeignKey("dbo.Regions", t => t.RegionGuid)
                .Index(t => t.RegionGuid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkingRanges", "RegionGuid", "dbo.Regions");
            DropIndex("dbo.WorkingRanges", new[] { "RegionGuid" });
            DropTable("dbo.WorkingRanges");
        }
    }
}
