namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _84 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PardakhtCheckMoshtaris", "CheckGuid", "dbo.ReceptionChecks");
            DropIndex("dbo.PardakhtCheckMoshtaris", new[] { "CheckGuid" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.PardakhtCheckMoshtaris", "CheckGuid");
            AddForeignKey("dbo.PardakhtCheckMoshtaris", "CheckGuid", "dbo.ReceptionChecks", "Guid");
        }
    }
}
