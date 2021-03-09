namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _77 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReceptionChecks", "SandouqTafsilGuid", c => c.Guid(nullable: false));
            AddColumn("dbo.ReceptionChecks", "SandouqMoeinGuid", c => c.Guid(nullable: false));
            CreateIndex("dbo.ReceptionChecks", "SandouqTafsilGuid");
            CreateIndex("dbo.ReceptionChecks", "SandouqMoeinGuid");
            AddForeignKey("dbo.ReceptionChecks", "SandouqMoeinGuid", "dbo.Moeins", "Guid");
            AddForeignKey("dbo.ReceptionChecks", "SandouqTafsilGuid", "dbo.Tafsils", "Guid");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReceptionChecks", "SandouqTafsilGuid", "dbo.Tafsils");
            DropForeignKey("dbo.ReceptionChecks", "SandouqMoeinGuid", "dbo.Moeins");
            DropIndex("dbo.ReceptionChecks", new[] { "SandouqMoeinGuid" });
            DropIndex("dbo.ReceptionChecks", new[] { "SandouqTafsilGuid" });
            DropColumn("dbo.ReceptionChecks", "SandouqMoeinGuid");
            DropColumn("dbo.ReceptionChecks", "SandouqTafsilGuid");
        }
    }
}
