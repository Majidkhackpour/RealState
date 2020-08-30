namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _31 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Code = c.Long(nullable: false),
                        IsTemp = c.Boolean(nullable: false),
                        FirstSideGuid = c.Guid(nullable: false),
                        SecondSideGuid = c.Guid(nullable: false),
                        Term = c.Int(),
                        FromDate = c.DateTime(),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MinorPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CheckNo = c.String(maxLength: 200),
                        BankName = c.String(maxLength: 200),
                        Shobe = c.String(maxLength: 200),
                        SarResid = c.String(maxLength: 20),
                        DischargeDate = c.DateTime(nullable: false),
                        SetDocDate = c.DateTime(),
                        SetDocPlace = c.String(maxLength: 500),
                        SarQofli = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Delay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.ContractFinances",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        ConGuid = c.Guid(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Babat = c.Short(nullable: false),
                        FirstDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SecondDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FirstAddedValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SecondAddedValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FirstTotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SecondTotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Guid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ContractFinances");
            DropTable("dbo.Contracts");
        }
    }
}
