namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _30 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pardakhts",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Payer = c.Guid(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        NaqdPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BankPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FishNo = c.String(maxLength: 50),
                        Check = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CheckNo = c.String(maxLength: 50),
                        SarResid = c.String(maxLength: 50),
                        BankName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Guid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pardakhts");
        }
    }
}
