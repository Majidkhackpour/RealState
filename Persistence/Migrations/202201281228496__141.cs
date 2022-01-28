namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _141 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BuildingReviews",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        BuildingGuid = c.Guid(nullable: false),
                        UserGuid = c.Guid(nullable: false),
                        CustometGuid = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Report = c.String(),
                        ServerStatus = c.Short(nullable: false),
                        ServerDeliveryDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Guid)
                .ForeignKey("dbo.Buildings", t => t.BuildingGuid)
                .ForeignKey("dbo.Tafsils", t => t.CustometGuid)
                .ForeignKey("dbo.Users", t => t.UserGuid)
                .Index(t => t.BuildingGuid)
                .Index(t => t.UserGuid)
                .Index(t => t.CustometGuid);
            
            CreateTable(
                "dbo.BuildingWindows",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Name = c.String(maxLength: 250),
                        ServerStatus = c.Short(nullable: false),
                        ServerDeliveryDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.BuildingZoncans",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(maxLength: 200),
                        Description = c.String(),
                        ServerStatus = c.Short(nullable: false),
                        ServerDeliveryDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
            AddColumn("dbo.Buildings", "ZoncanGuid", c => c.Guid());
            AddColumn("dbo.Buildings", "WindowGuid", c => c.Guid());
            AddColumn("dbo.Buildings", "VahedNo", c => c.Int(nullable: false));
            CreateIndex("dbo.Buildings", "ZoncanGuid");
            CreateIndex("dbo.Buildings", "WindowGuid");
            AddForeignKey("dbo.Buildings", "WindowGuid", "dbo.BuildingWindows", "Guid");
            AddForeignKey("dbo.Buildings", "ZoncanGuid", "dbo.BuildingZoncans", "Guid");
            DropColumn("dbo.Buildings", "TelegramCount");
            DropColumn("dbo.Buildings", "WhatsAppCount");
            DropColumn("dbo.Buildings", "DivarCount");
            DropColumn("dbo.Buildings", "SheypoorCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Buildings", "SheypoorCount", c => c.Int(nullable: false));
            AddColumn("dbo.Buildings", "DivarCount", c => c.Int(nullable: false));
            AddColumn("dbo.Buildings", "WhatsAppCount", c => c.Int(nullable: false));
            AddColumn("dbo.Buildings", "TelegramCount", c => c.Int(nullable: false));
            DropForeignKey("dbo.Buildings", "ZoncanGuid", "dbo.BuildingZoncans");
            DropForeignKey("dbo.Buildings", "WindowGuid", "dbo.BuildingWindows");
            DropForeignKey("dbo.BuildingReviews", "UserGuid", "dbo.Users");
            DropForeignKey("dbo.BuildingReviews", "CustometGuid", "dbo.Tafsils");
            DropForeignKey("dbo.BuildingReviews", "BuildingGuid", "dbo.Buildings");
            DropIndex("dbo.BuildingReviews", new[] { "CustometGuid" });
            DropIndex("dbo.BuildingReviews", new[] { "UserGuid" });
            DropIndex("dbo.BuildingReviews", new[] { "BuildingGuid" });
            DropIndex("dbo.Buildings", new[] { "WindowGuid" });
            DropIndex("dbo.Buildings", new[] { "ZoncanGuid" });
            DropColumn("dbo.Buildings", "VahedNo");
            DropColumn("dbo.Buildings", "WindowGuid");
            DropColumn("dbo.Buildings", "ZoncanGuid");
            DropTable("dbo.BuildingZoncans");
            DropTable("dbo.BuildingWindows");
            DropTable("dbo.BuildingReviews");
        }
    }
}
