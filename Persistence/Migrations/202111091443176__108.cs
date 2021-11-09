namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _108 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserLogs", "BuildingGuid", c => c.Guid());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserLogs", "BuildingGuid");
        }
    }
}
