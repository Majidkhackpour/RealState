namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _55 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AdvertiseLogs", "Asansor", c => c.Boolean());
            AlterColumn("dbo.AdvertiseLogs", "Parking", c => c.Boolean());
            AlterColumn("dbo.AdvertiseLogs", "Anbari", c => c.Boolean());
            AlterColumn("dbo.AdvertiseLogs", "Balkon", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AdvertiseLogs", "Balkon", c => c.Boolean(nullable: false));
            AlterColumn("dbo.AdvertiseLogs", "Anbari", c => c.Boolean(nullable: false));
            AlterColumn("dbo.AdvertiseLogs", "Parking", c => c.Boolean(nullable: false));
            AlterColumn("dbo.AdvertiseLogs", "Asansor", c => c.Boolean(nullable: false));
        }
    }
}
