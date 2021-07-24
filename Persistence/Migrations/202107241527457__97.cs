namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _97 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhoneBooks", "Title", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhoneBooks", "Title");
        }
    }
}
