namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _18 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BuildingGalleries",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        BuildingGuid = c.Guid(nullable: false),
                        ImageName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.BuildingRelatedOptions",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        BuildinGuid = c.Guid(nullable: false),
                        BuildingOptionGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BuildingRelatedOptions");
            DropTable("dbo.BuildingGalleries");
        }
    }
}
