namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _72 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Sanads", "UserGuid");
            AddForeignKey("dbo.Sanads", "UserGuid", "dbo.Users", "Guid", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sanads", "UserGuid", "dbo.Users");
            DropIndex("dbo.Sanads", new[] { "UserGuid" });
        }
    }
}
