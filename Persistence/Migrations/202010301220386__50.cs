namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _50 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BackUpLogs", "Size", c => c.Short(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BackUpLogs", "Size");
        }
    }
}
