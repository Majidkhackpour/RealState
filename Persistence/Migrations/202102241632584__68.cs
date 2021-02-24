namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _68 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Hazines");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Hazines",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(maxLength: 200),
                        Account = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AccountFirst = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Guid);
            
        }
    }
}
