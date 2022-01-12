namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _113 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.BuildingRequestRegions", "ServerStatus");
            DropColumn("dbo.BuildingRequestRegions", "ServerDeliveryDate");
            DropColumn("dbo.BuildingGalleries", "ServerStatus");
            DropColumn("dbo.BuildingGalleries", "ServerDeliveryDate");
            DropColumn("dbo.BuildingNotes", "ServerStatus");
            DropColumn("dbo.BuildingNotes", "ServerDeliveryDate");
            DropColumn("dbo.BuildingRelatedOptions", "ServerStatus");
            DropColumn("dbo.BuildingRelatedOptions", "ServerDeliveryDate");
            DropColumn("dbo.PhoneBooks", "ServerStatus");
            DropColumn("dbo.PhoneBooks", "ServerDeliveryDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PhoneBooks", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.PhoneBooks", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.BuildingRelatedOptions", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.BuildingRelatedOptions", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.BuildingNotes", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.BuildingNotes", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.BuildingGalleries", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.BuildingGalleries", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.BuildingRequestRegions", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.BuildingRequestRegions", "ServerStatus", c => c.Short(nullable: false));
        }
    }
}
