namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _100 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buildings", "TelegramCount", c => c.Int(nullable: false));
            AddColumn("dbo.Buildings", "DivarCount", c => c.Int(nullable: false));
            AddColumn("dbo.Buildings", "SheypoorCount", c => c.Int(nullable: false));
            AddColumn("dbo.Buildings", "AdvertiseType", c => c.Short());
            AddColumn("dbo.Buildings", "DivarTitle", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Buildings", "DivarTitle");
            DropColumn("dbo.Buildings", "AdvertiseType");
            DropColumn("dbo.Buildings", "SheypoorCount");
            DropColumn("dbo.Buildings", "DivarCount");
            DropColumn("dbo.Buildings", "TelegramCount");
        }
    }
}
