namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _83 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PardakhtCheckAvalDores", "DasteCheckName", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PardakhtCheckAvalDores", "DasteCheckName");
        }
    }
}
