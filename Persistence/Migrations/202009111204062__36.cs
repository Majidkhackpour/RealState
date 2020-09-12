namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _36 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.SmsPanels", "UserName");
            DropColumn("dbo.SmsPanels", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SmsPanels", "Password", c => c.String(maxLength: 200));
            AddColumn("dbo.SmsPanels", "UserName", c => c.String(maxLength: 200));
        }
    }
}
