namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _46 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AdvertiseLogs", "State", c => c.String(maxLength: 20));
            AddColumn("dbo.AdvertiseLogs", "Tabdil", c => c.String(maxLength: 20));
            AddColumn("dbo.AdvertiseLogs", "RentalAuthority", c => c.String(maxLength: 20));
            AddColumn("dbo.AdvertiseLogs", "Asansor", c => c.Boolean(nullable: false));
            AddColumn("dbo.AdvertiseLogs", "Parking", c => c.Boolean(nullable: false));
            AddColumn("dbo.AdvertiseLogs", "Anbari", c => c.Boolean(nullable: false));
            AddColumn("dbo.AdvertiseLogs", "Balkon", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AdvertiseLogs", "Balkon");
            DropColumn("dbo.AdvertiseLogs", "Anbari");
            DropColumn("dbo.AdvertiseLogs", "Parking");
            DropColumn("dbo.AdvertiseLogs", "Asansor");
            DropColumn("dbo.AdvertiseLogs", "RentalAuthority");
            DropColumn("dbo.AdvertiseLogs", "Tabdil");
            DropColumn("dbo.AdvertiseLogs", "State");
        }
    }
}
