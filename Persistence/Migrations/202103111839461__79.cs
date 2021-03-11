namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _79 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pardakhts",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        TafsilGuid = c.Guid(nullable: false),
                        MoeinGuid = c.Guid(nullable: false),
                        DateM = c.DateTime(nullable: false),
                        Description = c.String(),
                        UserGuid = c.Guid(nullable: false),
                        Number = c.Long(nullable: false),
                        SanadNumber = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Guid)
                .ForeignKey("dbo.Moeins", t => t.MoeinGuid)
                .ForeignKey("dbo.Tafsils", t => t.TafsilGuid)
                .ForeignKey("dbo.Users", t => t.UserGuid)
                .Index(t => t.TafsilGuid)
                .Index(t => t.MoeinGuid)
                .Index(t => t.UserGuid);
            
            CreateTable(
                "dbo.PardakhtCheckMoshtaris",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Description = c.String(),
                        CheckGuid = c.Guid(nullable: false),
                        MasterGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Guid)
                .ForeignKey("dbo.Pardakhts", t => t.MasterGuid)
                .ForeignKey("dbo.ReceptionChecks", t => t.CheckGuid)
                .Index(t => t.CheckGuid)
                .Index(t => t.MasterGuid);
            
            CreateTable(
                "dbo.PardakhtHavales",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Description = c.String(),
                        Number = c.String(maxLength: 200),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BankTafsilGuid = c.Guid(nullable: false),
                        BankMoeinGuid = c.Guid(nullable: false),
                        MasterGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Guid)
                .ForeignKey("dbo.Moeins", t => t.BankMoeinGuid)
                .ForeignKey("dbo.Pardakhts", t => t.MasterGuid)
                .ForeignKey("dbo.Tafsils", t => t.BankTafsilGuid)
                .Index(t => t.BankTafsilGuid)
                .Index(t => t.BankMoeinGuid)
                .Index(t => t.MasterGuid);
            
            CreateTable(
                "dbo.PardakhtNaqds",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SandouqTafsilGuid = c.Guid(nullable: false),
                        SandouqMoeinGuid = c.Guid(nullable: false),
                        MasterGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Guid)
                .ForeignKey("dbo.Moeins", t => t.SandouqMoeinGuid)
                .ForeignKey("dbo.Pardakhts", t => t.MasterGuid)
                .ForeignKey("dbo.Tafsils", t => t.SandouqTafsilGuid)
                .Index(t => t.SandouqTafsilGuid)
                .Index(t => t.SandouqMoeinGuid)
                .Index(t => t.MasterGuid);
            
            CreateTable(
                "dbo.PardakhtCheckShakhsis",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        DateSarResid = c.DateTime(nullable: false),
                        Description = c.String(),
                        Number = c.String(maxLength: 200),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateM = c.DateTime(nullable: false),
                        CheckPageGuid = c.Guid(nullable: false),
                        MasterGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Guid)
                .ForeignKey("dbo.CheckPages", t => t.CheckPageGuid)
                .ForeignKey("dbo.Pardakhts", t => t.MasterGuid)
                .Index(t => t.CheckPageGuid)
                .Index(t => t.MasterGuid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pardakhts", "UserGuid", "dbo.Users");
            DropForeignKey("dbo.Pardakhts", "TafsilGuid", "dbo.Tafsils");
            DropForeignKey("dbo.PardakhtCheckShakhsis", "MasterGuid", "dbo.Pardakhts");
            DropForeignKey("dbo.PardakhtCheckShakhsis", "CheckPageGuid", "dbo.CheckPages");
            DropForeignKey("dbo.PardakhtCheckMoshtaris", "CheckGuid", "dbo.ReceptionChecks");
            DropForeignKey("dbo.PardakhtNaqds", "SandouqTafsilGuid", "dbo.Tafsils");
            DropForeignKey("dbo.PardakhtNaqds", "MasterGuid", "dbo.Pardakhts");
            DropForeignKey("dbo.PardakhtNaqds", "SandouqMoeinGuid", "dbo.Moeins");
            DropForeignKey("dbo.PardakhtHavales", "BankTafsilGuid", "dbo.Tafsils");
            DropForeignKey("dbo.PardakhtHavales", "MasterGuid", "dbo.Pardakhts");
            DropForeignKey("dbo.PardakhtHavales", "BankMoeinGuid", "dbo.Moeins");
            DropForeignKey("dbo.PardakhtCheckMoshtaris", "MasterGuid", "dbo.Pardakhts");
            DropForeignKey("dbo.Pardakhts", "MoeinGuid", "dbo.Moeins");
            DropIndex("dbo.PardakhtCheckShakhsis", new[] { "MasterGuid" });
            DropIndex("dbo.PardakhtCheckShakhsis", new[] { "CheckPageGuid" });
            DropIndex("dbo.PardakhtNaqds", new[] { "MasterGuid" });
            DropIndex("dbo.PardakhtNaqds", new[] { "SandouqMoeinGuid" });
            DropIndex("dbo.PardakhtNaqds", new[] { "SandouqTafsilGuid" });
            DropIndex("dbo.PardakhtHavales", new[] { "MasterGuid" });
            DropIndex("dbo.PardakhtHavales", new[] { "BankMoeinGuid" });
            DropIndex("dbo.PardakhtHavales", new[] { "BankTafsilGuid" });
            DropIndex("dbo.PardakhtCheckMoshtaris", new[] { "MasterGuid" });
            DropIndex("dbo.PardakhtCheckMoshtaris", new[] { "CheckGuid" });
            DropIndex("dbo.Pardakhts", new[] { "UserGuid" });
            DropIndex("dbo.Pardakhts", new[] { "MoeinGuid" });
            DropIndex("dbo.Pardakhts", new[] { "TafsilGuid" });
            DropTable("dbo.PardakhtCheckShakhsis");
            DropTable("dbo.PardakhtNaqds");
            DropTable("dbo.PardakhtHavales");
            DropTable("dbo.PardakhtCheckMoshtaris");
            DropTable("dbo.Pardakhts");
        }
    }
}
