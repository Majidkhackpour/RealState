namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _7 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PhoneBooks", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PhoneBooks", "Email", c => c.String(maxLength: 50));
        }
    }
}
