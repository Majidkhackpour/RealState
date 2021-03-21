namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _82 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PardakhtCheckAvalDores", "DateSarResid");
            DropColumn("dbo.PardakhtCheckAvalDores", "Description");
            DropColumn("dbo.PardakhtCheckAvalDores", "Number");
            DropColumn("dbo.PardakhtCheckAvalDores", "Price");
            DropColumn("dbo.PardakhtCheckAvalDores", "DateM");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PardakhtCheckAvalDores", "DateM", c => c.DateTime(nullable: false));
            AddColumn("dbo.PardakhtCheckAvalDores", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.PardakhtCheckAvalDores", "Number", c => c.String(maxLength: 200));
            AddColumn("dbo.PardakhtCheckAvalDores", "Description", c => c.String());
            AddColumn("dbo.PardakhtCheckAvalDores", "DateSarResid", c => c.DateTime(nullable: false));
        }
    }
}
