namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _63 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DasteChecks",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        SerialNumber = c.Long(nullable: false),
                        BankGuid = c.Guid(nullable: false),
                        IsSarresidShode = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DasteChecks");
        }
    }
}
