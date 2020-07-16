namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "SecurityQuestion", c => c.Short(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "SecurityQuestion", c => c.String(maxLength: 100));
        }
    }
}
