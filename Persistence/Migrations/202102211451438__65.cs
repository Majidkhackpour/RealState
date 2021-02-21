namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _65 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tafsils", "AccountFirst", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tafsils", "AccountFirst");
        }
    }
}
