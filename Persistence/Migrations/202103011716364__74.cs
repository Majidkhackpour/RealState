namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _74 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sanads", "UserGuid", "dbo.Users");
            DropForeignKey("dbo.SanadDetails", "MoeinGuid", "dbo.Moeins");
            DropForeignKey("dbo.SanadDetails", "MasterGuid", "dbo.Sanads");
            DropForeignKey("dbo.SanadDetails", "TafsilGuid", "dbo.Tafsils");
            CreateTable(
                "dbo.ReceptionChecks",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        BankName = c.String(maxLength: 200),
                        DateM = c.DateTime(nullable: false),
                        MasterGuid = c.Guid(nullable: false),
                        Description = c.String(),
                        CheckNumber = c.String(maxLength: 200),
                        PoshtNomre = c.String(maxLength: 200),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CheckStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Guid)
                .ForeignKey("dbo.Receptions", t => t.MasterGuid)
                .Index(t => t.MasterGuid);
            
            CreateTable(
                "dbo.ReceptionHavales",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        DateM = c.DateTime(nullable: false),
                        MasterGuid = c.Guid(nullable: false),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PeygiriNumber = c.String(maxLength: 200),
                        BankTafsilGuid = c.Guid(nullable: false),
                        BankMoeinGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Guid)
                .ForeignKey("dbo.Moeins", t => t.BankMoeinGuid)
                .ForeignKey("dbo.Receptions", t => t.MasterGuid)
                .ForeignKey("dbo.Tafsils", t => t.BankTafsilGuid)
                .Index(t => t.MasterGuid)
                .Index(t => t.BankTafsilGuid)
                .Index(t => t.BankMoeinGuid);
            
            CreateTable(
                "dbo.ReceptionNaqds",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        DateM = c.DateTime(nullable: false),
                        MasterGuid = c.Guid(nullable: false),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SandouqTafsilGuid = c.Guid(nullable: false),
                        SandouqMoeinGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Guid)
                .ForeignKey("dbo.Moeins", t => t.SandouqMoeinGuid)
                .ForeignKey("dbo.Receptions", t => t.MasterGuid)
                .ForeignKey("dbo.Tafsils", t => t.SandouqTafsilGuid)
                .Index(t => t.MasterGuid)
                .Index(t => t.SandouqTafsilGuid)
                .Index(t => t.SandouqMoeinGuid);
            
            AddColumn("dbo.Receptions", "Number", c => c.Long(nullable: false));
            AddColumn("dbo.Receptions", "DateM", c => c.DateTime(nullable: false));
            AddColumn("dbo.Receptions", "TafsilGuid", c => c.Guid(nullable: false));
            AddColumn("dbo.Receptions", "MoeinGuid", c => c.Guid(nullable: false));
            AddColumn("dbo.Receptions", "UserGuid", c => c.Guid(nullable: false));
            AddColumn("dbo.Receptions", "SanadNumber", c => c.Long(nullable: false));
            CreateIndex("dbo.Receptions", "TafsilGuid");
            CreateIndex("dbo.Receptions", "MoeinGuid");
            CreateIndex("dbo.Receptions", "UserGuid");
            AddForeignKey("dbo.Receptions", "MoeinGuid", "dbo.Moeins", "Guid");
            AddForeignKey("dbo.Receptions", "TafsilGuid", "dbo.Tafsils", "Guid");
            AddForeignKey("dbo.Receptions", "UserGuid", "dbo.Users", "Guid");
            AddForeignKey("dbo.Sanads", "UserGuid", "dbo.Users", "Guid");
            AddForeignKey("dbo.SanadDetails", "MoeinGuid", "dbo.Moeins", "Guid");
            AddForeignKey("dbo.SanadDetails", "MasterGuid", "dbo.Sanads", "Guid");
            AddForeignKey("dbo.SanadDetails", "TafsilGuid", "dbo.Tafsils", "Guid");
            DropColumn("dbo.Receptions", "Receptor");
            DropColumn("dbo.Receptions", "CreateDate");
            DropColumn("dbo.Receptions", "NaqdPrice");
            DropColumn("dbo.Receptions", "BankPrice");
            DropColumn("dbo.Receptions", "FishNo");
            DropColumn("dbo.Receptions", "Check");
            DropColumn("dbo.Receptions", "CheckNo");
            DropColumn("dbo.Receptions", "SarResid");
            DropColumn("dbo.Receptions", "BankName");
            DropTable("dbo.GardeshHesabs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GardeshHesabs",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        PeopleGuid = c.Guid(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Type = c.Short(nullable: false),
                        Babat = c.Short(nullable: false),
                        Description = c.String(),
                        ParentGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
            AddColumn("dbo.Receptions", "BankName", c => c.String(maxLength: 50));
            AddColumn("dbo.Receptions", "SarResid", c => c.String(maxLength: 50));
            AddColumn("dbo.Receptions", "CheckNo", c => c.String(maxLength: 50));
            AddColumn("dbo.Receptions", "Check", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Receptions", "FishNo", c => c.String(maxLength: 50));
            AddColumn("dbo.Receptions", "BankPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Receptions", "NaqdPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Receptions", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Receptions", "Receptor", c => c.Guid(nullable: false));
            DropForeignKey("dbo.SanadDetails", "TafsilGuid", "dbo.Tafsils");
            DropForeignKey("dbo.SanadDetails", "MasterGuid", "dbo.Sanads");
            DropForeignKey("dbo.SanadDetails", "MoeinGuid", "dbo.Moeins");
            DropForeignKey("dbo.Sanads", "UserGuid", "dbo.Users");
            DropForeignKey("dbo.Receptions", "UserGuid", "dbo.Users");
            DropForeignKey("dbo.Receptions", "TafsilGuid", "dbo.Tafsils");
            DropForeignKey("dbo.ReceptionHavales", "BankTafsilGuid", "dbo.Tafsils");
            DropForeignKey("dbo.ReceptionNaqds", "SandouqTafsilGuid", "dbo.Tafsils");
            DropForeignKey("dbo.ReceptionNaqds", "MasterGuid", "dbo.Receptions");
            DropForeignKey("dbo.ReceptionNaqds", "SandouqMoeinGuid", "dbo.Moeins");
            DropForeignKey("dbo.ReceptionHavales", "MasterGuid", "dbo.Receptions");
            DropForeignKey("dbo.ReceptionHavales", "BankMoeinGuid", "dbo.Moeins");
            DropForeignKey("dbo.ReceptionChecks", "MasterGuid", "dbo.Receptions");
            DropForeignKey("dbo.Receptions", "MoeinGuid", "dbo.Moeins");
            DropIndex("dbo.ReceptionNaqds", new[] { "SandouqMoeinGuid" });
            DropIndex("dbo.ReceptionNaqds", new[] { "SandouqTafsilGuid" });
            DropIndex("dbo.ReceptionNaqds", new[] { "MasterGuid" });
            DropIndex("dbo.ReceptionHavales", new[] { "BankMoeinGuid" });
            DropIndex("dbo.ReceptionHavales", new[] { "BankTafsilGuid" });
            DropIndex("dbo.ReceptionHavales", new[] { "MasterGuid" });
            DropIndex("dbo.ReceptionChecks", new[] { "MasterGuid" });
            DropIndex("dbo.Receptions", new[] { "UserGuid" });
            DropIndex("dbo.Receptions", new[] { "MoeinGuid" });
            DropIndex("dbo.Receptions", new[] { "TafsilGuid" });
            DropColumn("dbo.Receptions", "SanadNumber");
            DropColumn("dbo.Receptions", "UserGuid");
            DropColumn("dbo.Receptions", "MoeinGuid");
            DropColumn("dbo.Receptions", "TafsilGuid");
            DropColumn("dbo.Receptions", "DateM");
            DropColumn("dbo.Receptions", "Number");
            DropTable("dbo.ReceptionNaqds");
            DropTable("dbo.ReceptionHavales");
            DropTable("dbo.ReceptionChecks");
            AddForeignKey("dbo.SanadDetails", "TafsilGuid", "dbo.Tafsils", "Guid", cascadeDelete: true);
            AddForeignKey("dbo.SanadDetails", "MasterGuid", "dbo.Sanads", "Guid", cascadeDelete: true);
            AddForeignKey("dbo.SanadDetails", "MoeinGuid", "dbo.Moeins", "Guid", cascadeDelete: true);
            AddForeignKey("dbo.Sanads", "UserGuid", "dbo.Users", "Guid", cascadeDelete: true);
        }
    }
}
