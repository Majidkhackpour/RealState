namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _47 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PhoneBooks", "Tell", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PhoneBooks", "Tell", c => c.String(maxLength: 20));
        }
    }
}
