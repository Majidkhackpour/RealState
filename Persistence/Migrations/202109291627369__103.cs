namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _103 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buildings", "WhatsAppCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Buildings", "WhatsAppCount");
        }
    }
}
