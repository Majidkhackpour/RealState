namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdvertiseLogs",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        SimcardNumber = c.Long(nullable: false),
                        DateM = c.DateTime(nullable: false),
                        Category = c.String(maxLength: 100),
                        SubCategory1 = c.String(maxLength: 100),
                        SubCategory2 = c.String(maxLength: 100),
                        City = c.String(maxLength: 100),
                        Region = c.String(maxLength: 100),
                        Price1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Title = c.String(maxLength: 500),
                        Content = c.String(),
                        URL = c.String(maxLength: 100),
                        UpdateDesc = c.String(),
                        StatusCode = c.Int(nullable: false),
                        IP = c.String(maxLength: 20),
                        LastUpdate = c.DateTime(nullable: false),
                        VisitCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.Simcards",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Number = c.Long(nullable: false),
                        Owner = c.String(maxLength: 200),
                        Token = c.String(),
                        Operator = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Guid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Simcards");
            DropTable("dbo.AdvertiseLogs");
        }
    }
}
