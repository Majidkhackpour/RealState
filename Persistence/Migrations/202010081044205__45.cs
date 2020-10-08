namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _45 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Simcards", "DivarToken");
            DropColumn("dbo.Simcards", "SheypoorToken");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Simcards", "SheypoorToken", c => c.String());
            AddColumn("dbo.Simcards", "DivarToken", c => c.String());
        }
    }
}
