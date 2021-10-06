namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _105 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Buildings", new[] { "BuildingConditionGuid" });
            DropIndex("dbo.Buildings", new[] { "BuildingViewGuid" });
            DropIndex("dbo.Buildings", new[] { "FloorCoverGuid" });
            DropIndex("dbo.Buildings", new[] { "KitchenServiceGuid" });
            AlterColumn("dbo.Buildings", "BuildingConditionGuid", c => c.Guid());
            AlterColumn("dbo.Buildings", "Side", c => c.Int());
            AlterColumn("dbo.Buildings", "BuildingViewGuid", c => c.Guid());
            AlterColumn("dbo.Buildings", "FloorCoverGuid", c => c.Guid());
            AlterColumn("dbo.Buildings", "KitchenServiceGuid", c => c.Guid());
            CreateIndex("dbo.Buildings", "BuildingConditionGuid");
            CreateIndex("dbo.Buildings", "BuildingViewGuid");
            CreateIndex("dbo.Buildings", "FloorCoverGuid");
            CreateIndex("dbo.Buildings", "KitchenServiceGuid");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Buildings", new[] { "KitchenServiceGuid" });
            DropIndex("dbo.Buildings", new[] { "FloorCoverGuid" });
            DropIndex("dbo.Buildings", new[] { "BuildingViewGuid" });
            DropIndex("dbo.Buildings", new[] { "BuildingConditionGuid" });
            AlterColumn("dbo.Buildings", "KitchenServiceGuid", c => c.Guid(nullable: false));
            AlterColumn("dbo.Buildings", "FloorCoverGuid", c => c.Guid(nullable: false));
            AlterColumn("dbo.Buildings", "BuildingViewGuid", c => c.Guid(nullable: false));
            AlterColumn("dbo.Buildings", "Side", c => c.Int(nullable: false));
            AlterColumn("dbo.Buildings", "BuildingConditionGuid", c => c.Guid(nullable: false));
            CreateIndex("dbo.Buildings", "KitchenServiceGuid");
            CreateIndex("dbo.Buildings", "FloorCoverGuid");
            CreateIndex("dbo.Buildings", "BuildingViewGuid");
            CreateIndex("dbo.Buildings", "BuildingConditionGuid");
        }
    }
}
