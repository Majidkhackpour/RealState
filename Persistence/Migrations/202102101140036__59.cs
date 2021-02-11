namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _59 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HesabGroups",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(maxLength: 200),
                        Code = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.Kols",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(maxLength: 200),
                        GroupGuid = c.Guid(nullable: false),
                        Code = c.String(maxLength: 10),
                        Account = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.Moeins",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(maxLength: 200),
                        Code = c.String(maxLength: 10),
                        KolGuid = c.Guid(nullable: false),
                        DateM = c.DateTime(nullable: false),
                        Account = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.Tafsils",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(maxLength: 200),
                        Code = c.String(maxLength: 10),
                        Description = c.String(),
                        HesabType = c.Int(nullable: false),
                        DateM = c.DateTime(nullable: false),
                        Account = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Guid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tafsils");
            DropTable("dbo.Moeins");
            DropTable("dbo.Kols");
            DropTable("dbo.HesabGroups");
        }
    }
}
