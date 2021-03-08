namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _76 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReceptionChecks", "DateSarResid", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReceptionChecks", "DateSarResid");
        }
    }
}
