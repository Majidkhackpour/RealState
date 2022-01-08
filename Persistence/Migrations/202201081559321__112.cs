namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _112 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Advisors", "ServerStatus");
            DropColumn("dbo.Advisors", "ServerDeliveryDate");
            DropColumn("dbo.Banks", "ServerStatus");
            DropColumn("dbo.Banks", "ServerDeliveryDate");
            DropColumn("dbo.DasteChecks", "ServerStatus");
            DropColumn("dbo.DasteChecks", "ServerDeliveryDate");
            DropColumn("dbo.CheckPages", "ServerStatus");
            DropColumn("dbo.CheckPages", "ServerDeliveryDate");
            DropColumn("dbo.Tafsils", "ServerStatus");
            DropColumn("dbo.Tafsils", "ServerDeliveryDate");
            DropColumn("dbo.Contracts", "ServerStatus");
            DropColumn("dbo.Contracts", "ServerDeliveryDate");
            DropColumn("dbo.Pardakhts", "ServerStatus");
            DropColumn("dbo.Pardakhts", "ServerDeliveryDate");
            DropColumn("dbo.Moeins", "ServerStatus");
            DropColumn("dbo.Moeins", "ServerDeliveryDate");
            DropColumn("dbo.Kols", "ServerStatus");
            DropColumn("dbo.Kols", "ServerDeliveryDate");
            DropColumn("dbo.PardakhtHavales", "ServerStatus");
            DropColumn("dbo.PardakhtHavales", "ServerDeliveryDate");
            DropColumn("dbo.PardakhtNaqds", "ServerStatus");
            DropColumn("dbo.PardakhtNaqds", "ServerDeliveryDate");
            DropColumn("dbo.Receptions", "ServerStatus");
            DropColumn("dbo.Receptions", "ServerDeliveryDate");
            DropColumn("dbo.ReceptionChecks", "ServerStatus");
            DropColumn("dbo.ReceptionChecks", "ServerDeliveryDate");
            DropColumn("dbo.ReceptionHavales", "ServerStatus");
            DropColumn("dbo.ReceptionHavales", "ServerDeliveryDate");
            DropColumn("dbo.ReceptionNaqds", "ServerStatus");
            DropColumn("dbo.ReceptionNaqds", "ServerDeliveryDate");
            DropColumn("dbo.ReceptionCheckAvalDores", "ServerStatus");
            DropColumn("dbo.ReceptionCheckAvalDores", "ServerDeliveryDate");
            DropColumn("dbo.SanadDetails", "ServerStatus");
            DropColumn("dbo.SanadDetails", "ServerDeliveryDate");
            DropColumn("dbo.Sanads", "ServerStatus");
            DropColumn("dbo.Sanads", "ServerDeliveryDate");
            DropColumn("dbo.PardakhtCheckMoshtaris", "ServerStatus");
            DropColumn("dbo.PardakhtCheckMoshtaris", "ServerDeliveryDate");
            DropColumn("dbo.PardakhtCheckShakhsis", "ServerStatus");
            DropColumn("dbo.PardakhtCheckShakhsis", "ServerDeliveryDate");
            DropColumn("dbo.PardakhtCheckAvalDores", "ServerStatus");
            DropColumn("dbo.PardakhtCheckAvalDores", "ServerDeliveryDate");
            DropTable("dbo.Calendars");
            DropTable("dbo.Temps");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Temps",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Type = c.Short(nullable: false),
                        ObjectGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.Calendars",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        DateM = c.DateTime(nullable: false),
                        Monasebat = c.String(maxLength: 500),
                        Description = c.String(),
                        isTatil = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
            AddColumn("dbo.PardakhtCheckAvalDores", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.PardakhtCheckAvalDores", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.PardakhtCheckShakhsis", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.PardakhtCheckShakhsis", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.PardakhtCheckMoshtaris", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.PardakhtCheckMoshtaris", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.Sanads", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Sanads", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.SanadDetails", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.SanadDetails", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.ReceptionCheckAvalDores", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ReceptionCheckAvalDores", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.ReceptionNaqds", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ReceptionNaqds", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.ReceptionHavales", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ReceptionHavales", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.ReceptionChecks", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ReceptionChecks", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.Receptions", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Receptions", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.PardakhtNaqds", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.PardakhtNaqds", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.PardakhtHavales", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.PardakhtHavales", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.Kols", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Kols", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.Moeins", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Moeins", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.Pardakhts", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Pardakhts", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.Contracts", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Contracts", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.Tafsils", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tafsils", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.CheckPages", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.CheckPages", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.DasteChecks", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.DasteChecks", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.Banks", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Banks", "ServerStatus", c => c.Short(nullable: false));
            AddColumn("dbo.Advisors", "ServerDeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Advisors", "ServerStatus", c => c.Short(nullable: false));
        }
    }
}
