namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _107 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BuildingNotes",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        ServerStatus = c.Short(nullable: false),
                        ServerDeliveryDate = c.DateTime(nullable: false),
                        BuildingGuid = c.Guid(nullable: false),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.Guid)
                .ForeignKey("dbo.Buildings", t => t.BuildingGuid)
                .Index(t => t.BuildingGuid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BuildingNotes", "BuildingGuid", "dbo.Buildings");
            DropIndex("dbo.BuildingNotes", new[] { "BuildingGuid" });
            DropTable("dbo.BuildingNotes");
        }
    }
}
