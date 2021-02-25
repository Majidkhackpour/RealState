namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _69 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sanads",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        DateM = c.DateTime(nullable: false),
                        Description = c.String(),
                        Number = c.Long(nullable: false),
                        SanadStatus = c.Short(nullable: false),
                        UserGuid = c.Guid(nullable: false),
                        SumDebit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SumCredit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SanadType = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.SanadDetails",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        MasterGuid = c.Guid(nullable: false),
                        MoeinGuid = c.Guid(nullable: false),
                        MoeinCode = c.String(maxLength: 20),
                        MoeinName = c.String(maxLength: 200),
                        TafsilGuid = c.Guid(nullable: false),
                        TafsilCode = c.String(maxLength: 20),
                        TafsilName = c.String(maxLength: 200),
                        Debit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Credit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        Sanad_Guid = c.Guid(),
                    })
                .PrimaryKey(t => t.Guid)
                .ForeignKey("dbo.Sanads", t => t.Sanad_Guid)
                .Index(t => t.Sanad_Guid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SanadDetails", "Sanad_Guid", "dbo.Sanads");
            DropIndex("dbo.SanadDetails", new[] { "Sanad_Guid" });
            DropTable("dbo.SanadDetails");
            DropTable("dbo.Sanads");
        }
    }
}
