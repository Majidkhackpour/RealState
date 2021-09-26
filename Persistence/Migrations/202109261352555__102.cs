namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _102 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BuildingRelatedNumbers",
                c => new
                    {
                        BuildingGuid = c.Guid(nullable: false),
                        Number = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.BuildingGuid, t.Number });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BuildingRelatedNumbers");
        }
    }
}
