namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _101 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buildings", "Hiting", c => c.String(maxLength: 250));
            AddColumn("dbo.Buildings", "Colling", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Buildings", "Colling");
            DropColumn("dbo.Buildings", "Hiting");
        }
    }
}
