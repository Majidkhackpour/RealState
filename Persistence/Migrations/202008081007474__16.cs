namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _16 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buildings", "UserGuid", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Buildings", "UserGuid");
        }
    }
}
