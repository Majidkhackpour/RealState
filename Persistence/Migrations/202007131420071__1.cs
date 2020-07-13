namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BuildingAccountTypes",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.BuildingConditions",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.BuildingOptions",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.BuildingViews",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(maxLength: 200),
                        StateGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.DocumentTypes",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.FloorCovers",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.KitchenServices",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.Naqzs",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Message = c.String(),
                        UseCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(maxLength: 200),
                        CityGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.RentalAuthorities",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(maxLength: 400),
                        UserName = c.String(maxLength: 200),
                        Password = c.String(maxLength: 200),
                        Access = c.String(),
                        SecurityQuestion = c.String(maxLength: 100),
                        AnswerQuestion = c.String(maxLength: 400),
                        Email = c.String(maxLength: 50),
                        Mobile = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Guid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.States");
            DropTable("dbo.RentalAuthorities");
            DropTable("dbo.Regions");
            DropTable("dbo.Naqzs");
            DropTable("dbo.KitchenServices");
            DropTable("dbo.FloorCovers");
            DropTable("dbo.DocumentTypes");
            DropTable("dbo.Cities");
            DropTable("dbo.BuildingViews");
            DropTable("dbo.BuildingOptions");
            DropTable("dbo.BuildingConditions");
            DropTable("dbo.BuildingAccountTypes");
        }
    }
}
