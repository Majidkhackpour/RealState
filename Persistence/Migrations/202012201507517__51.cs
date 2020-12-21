namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _51 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contracts", "BazaryabGuid", c => c.Guid(nullable: false));
            AddColumn("dbo.Contracts", "BazaryabPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contracts", "BazaryabPrice");
            DropColumn("dbo.Contracts", "BazaryabGuid");
        }
    }
}
