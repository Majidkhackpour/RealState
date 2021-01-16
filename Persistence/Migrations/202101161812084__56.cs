namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _56 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AdvertiseLogs", "Tabdil");
            DropColumn("dbo.AdvertiseLogs", "RentalAuthority");
            DropColumn("dbo.AdvertiseLogs", "Asansor");
            DropColumn("dbo.AdvertiseLogs", "Parking");
            DropColumn("dbo.AdvertiseLogs", "Anbari");
            DropColumn("dbo.AdvertiseLogs", "Balkon");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AdvertiseLogs", "Balkon", c => c.Boolean());
            AddColumn("dbo.AdvertiseLogs", "Anbari", c => c.Boolean());
            AddColumn("dbo.AdvertiseLogs", "Parking", c => c.Boolean());
            AddColumn("dbo.AdvertiseLogs", "Asansor", c => c.Boolean());
            AddColumn("dbo.AdvertiseLogs", "RentalAuthority", c => c.String(maxLength: 20));
            AddColumn("dbo.AdvertiseLogs", "Tabdil", c => c.String(maxLength: 20));
        }
    }
}
