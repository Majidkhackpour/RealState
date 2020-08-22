namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _21 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buildings", "BuildingStatus", c => c.Short(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Buildings", "BuildingStatus");
        }
    }
}
