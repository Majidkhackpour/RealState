namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _104 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buildings", "Tabdil", c => c.Boolean());
            AddColumn("dbo.Buildings", "ReformArea", c => c.Single(nullable: false));
            AddColumn("dbo.Buildings", "BuildingPermits", c => c.Boolean());
            AddColumn("dbo.Buildings", "WidthOfPassage", c => c.Single(nullable: false));
            AddColumn("dbo.Buildings", "VillaType", c => c.Short());
            AddColumn("dbo.Buildings", "CommericallLicense", c => c.Short());
            AddColumn("dbo.Buildings", "SuitableFor", c => c.String());
            AddColumn("dbo.Buildings", "WallCovering", c => c.String());
            AddColumn("dbo.Buildings", "TreeCount", c => c.Int(nullable: false));
            AddColumn("dbo.Buildings", "ConstructionStage", c => c.Short());
            AddColumn("dbo.Buildings", "Parent", c => c.Short());
            AddColumn("dbo.BuildingOptions", "IsFullOption", c => c.Boolean(nullable: false));
            DropColumn("dbo.Buildings", "RahnPrice2");
            DropColumn("dbo.Buildings", "EjarePrice2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Buildings", "EjarePrice2", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Buildings", "RahnPrice2", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.BuildingOptions", "IsFullOption");
            DropColumn("dbo.Buildings", "Parent");
            DropColumn("dbo.Buildings", "ConstructionStage");
            DropColumn("dbo.Buildings", "TreeCount");
            DropColumn("dbo.Buildings", "WallCovering");
            DropColumn("dbo.Buildings", "SuitableFor");
            DropColumn("dbo.Buildings", "CommericallLicense");
            DropColumn("dbo.Buildings", "VillaType");
            DropColumn("dbo.Buildings", "WidthOfPassage");
            DropColumn("dbo.Buildings", "BuildingPermits");
            DropColumn("dbo.Buildings", "ReformArea");
            DropColumn("dbo.Buildings", "Tabdil");
        }
    }
}
