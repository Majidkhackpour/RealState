namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _66 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Peoples", "Account");
            DropColumn("dbo.Peoples", "AccountFirst");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Peoples", "AccountFirst", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Peoples", "Account", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
