namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _67 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "Account");
            DropColumn("dbo.Users", "AccountFirst");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "AccountFirst", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Users", "Account", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
