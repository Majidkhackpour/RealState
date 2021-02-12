namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _61 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tafsils", "isSystem", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tafsils", "isSystem");
        }
    }
}
