namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _58 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buildings", "Priority", c => c.Short(nullable: false));
            AddColumn("dbo.Buildings", "IsArchive", c => c.Boolean(nullable: false));
            DropColumn("dbo.Buildings", "BuildingStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Buildings", "BuildingStatus", c => c.Short(nullable: false));
            DropColumn("dbo.Buildings", "IsArchive");
            DropColumn("dbo.Buildings", "Priority");
        }
    }
}
