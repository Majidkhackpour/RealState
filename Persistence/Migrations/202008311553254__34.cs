namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _34 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contracts", "BuildingGuid", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contracts", "BuildingGuid");
        }
    }
}
