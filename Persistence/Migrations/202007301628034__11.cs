namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SmsPanels", "Name", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SmsPanels", "Name");
        }
    }
}
