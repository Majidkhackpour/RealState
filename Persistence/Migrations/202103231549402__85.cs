namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _85 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ReceptionChecks", new[] { "MasterGuid" });
            AddColumn("dbo.ReceptionChecks", "isAvalDore", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ReceptionChecks", "MasterGuid", c => c.Guid());
            CreateIndex("dbo.ReceptionChecks", "MasterGuid");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ReceptionChecks", new[] { "MasterGuid" });
            AlterColumn("dbo.ReceptionChecks", "MasterGuid", c => c.Guid(nullable: false));
            DropColumn("dbo.ReceptionChecks", "isAvalDore");
            CreateIndex("dbo.ReceptionChecks", "MasterGuid");
        }
    }
}
