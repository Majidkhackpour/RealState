namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _80 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PardakhtCheckAvalDores",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        DateSarResid = c.DateTime(nullable: false),
                        Description = c.String(),
                        Number = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateM = c.DateTime(nullable: false),
                        CheckPageGuid = c.Guid(nullable: false),
                        TafsilGuid = c.Guid(nullable: false),
                        UserGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Guid)
                .ForeignKey("dbo.CheckPages", t => t.CheckPageGuid)
                .ForeignKey("dbo.Tafsils", t => t.TafsilGuid)
                .ForeignKey("dbo.Users", t => t.UserGuid)
                .Index(t => t.CheckPageGuid)
                .Index(t => t.TafsilGuid)
                .Index(t => t.UserGuid);
            
            CreateTable(
                "dbo.ReceptionCheckAvalDores",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        BankName = c.String(),
                        DateM = c.DateTime(nullable: false),
                        DateSarResid = c.DateTime(nullable: false),
                        Description = c.String(),
                        CheckNumber = c.String(),
                        PoshtNomre = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CheckStatus = c.Int(nullable: false),
                        SandouqTafsilGuid = c.Guid(nullable: false),
                        SandouqMoeinGuid = c.Guid(nullable: false),
                        TafsilGuid = c.Guid(nullable: false),
                        UserGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Guid)
                .ForeignKey("dbo.Moeins", t => t.SandouqMoeinGuid)
                .ForeignKey("dbo.Tafsils", t => t.TafsilGuid)
                .ForeignKey("dbo.Users", t => t.UserGuid)
                .Index(t => t.SandouqMoeinGuid)
                .Index(t => t.TafsilGuid)
                .Index(t => t.UserGuid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PardakhtCheckAvalDores", "UserGuid", "dbo.Users");
            DropForeignKey("dbo.ReceptionCheckAvalDores", "UserGuid", "dbo.Users");
            DropForeignKey("dbo.ReceptionCheckAvalDores", "TafsilGuid", "dbo.Tafsils");
            DropForeignKey("dbo.ReceptionCheckAvalDores", "SandouqMoeinGuid", "dbo.Moeins");
            DropForeignKey("dbo.PardakhtCheckAvalDores", "TafsilGuid", "dbo.Tafsils");
            DropForeignKey("dbo.PardakhtCheckAvalDores", "CheckPageGuid", "dbo.CheckPages");
            DropIndex("dbo.ReceptionCheckAvalDores", new[] { "UserGuid" });
            DropIndex("dbo.ReceptionCheckAvalDores", new[] { "TafsilGuid" });
            DropIndex("dbo.ReceptionCheckAvalDores", new[] { "SandouqMoeinGuid" });
            DropIndex("dbo.PardakhtCheckAvalDores", new[] { "UserGuid" });
            DropIndex("dbo.PardakhtCheckAvalDores", new[] { "TafsilGuid" });
            DropIndex("dbo.PardakhtCheckAvalDores", new[] { "CheckPageGuid" });
            DropTable("dbo.ReceptionCheckAvalDores");
            DropTable("dbo.PardakhtCheckAvalDores");
        }
    }
}
