namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _44 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Simcards", "DivarToken", c => c.String());
            AddColumn("dbo.Simcards", "SheypoorToken", c => c.String());
            DropColumn("dbo.Simcards", "Token");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Simcards", "Token", c => c.String());
            DropColumn("dbo.Simcards", "SheypoorToken");
            DropColumn("dbo.Simcards", "DivarToken");
        }
    }
}
