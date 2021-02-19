namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _64 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CheckPages",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        CheckGuid = c.Guid(nullable: false),
                        DatePardakht = c.DateTime(),
                        Number = c.Long(nullable: false),
                        ReceptorGuid = c.Guid(),
                        DateSarresid = c.DateTime(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CheckStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
            AddColumn("dbo.DasteChecks", "FromNumber", c => c.Long(nullable: false));
            AddColumn("dbo.DasteChecks", "ToNumber", c => c.Long(nullable: false));
            AddColumn("dbo.DasteChecks", "Description", c => c.String());
            AlterColumn("dbo.DasteChecks", "SerialNumber", c => c.String(maxLength: 100));
            DropColumn("dbo.DasteChecks", "IsSarresidShode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DasteChecks", "IsSarresidShode", c => c.Boolean(nullable: false));
            AlterColumn("dbo.DasteChecks", "SerialNumber", c => c.Long(nullable: false));
            DropColumn("dbo.DasteChecks", "Description");
            DropColumn("dbo.DasteChecks", "ToNumber");
            DropColumn("dbo.DasteChecks", "FromNumber");
            DropTable("dbo.CheckPages");
        }
    }
}
