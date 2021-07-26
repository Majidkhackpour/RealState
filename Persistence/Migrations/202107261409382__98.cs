namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _98 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BuildingMedias",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        BuildingGuid = c.Guid(nullable: false),
                        MediaName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Guid)
                .ForeignKey("dbo.Buildings", t => t.BuildingGuid)
                .Index(t => t.BuildingGuid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BuildingMedias", "BuildingGuid", "dbo.Buildings");
            DropIndex("dbo.BuildingMedias", new[] { "BuildingGuid" });
            DropTable("dbo.BuildingMedias");
        }
    }
}
