namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _142 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BuildingReviews", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BuildingReviews", "Status");
        }
    }
}
