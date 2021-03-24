namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _86 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contracts", "SanadNumber", c => c.Long(nullable: false));
            AddColumn("dbo.Contracts", "fBabat", c => c.Short(nullable: false));
            AddColumn("dbo.Contracts", "sBabat", c => c.Short(nullable: false));
            AddColumn("dbo.Contracts", "FirstDiscount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Contracts", "SecondDiscount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Contracts", "FirstTax", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Contracts", "FirstAvarez", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Contracts", "SecondTax", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Contracts", "SecondAvarez", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Contracts", "FirstTotalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Contracts", "SecondTotalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            CreateIndex("dbo.Contracts", "FirstSideGuid");
            CreateIndex("dbo.Contracts", "SecondSideGuid");
            CreateIndex("dbo.Contracts", "BuildingGuid");
            CreateIndex("dbo.Contracts", "UserGuid");
            AddForeignKey("dbo.Contracts", "BuildingGuid", "dbo.Buildings", "Guid");
            AddForeignKey("dbo.Contracts", "FirstSideGuid", "dbo.Tafsils", "Guid");
            AddForeignKey("dbo.Contracts", "SecondSideGuid", "dbo.Tafsils", "Guid");
            AddForeignKey("dbo.Contracts", "UserGuid", "dbo.Users", "Guid");
            DropTable("dbo.ContractFinances");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ContractFinances",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        ConGuid = c.Guid(nullable: false),
                        fBabat = c.Short(nullable: false),
                        sBabat = c.Short(nullable: false),
                        FirstDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SecondDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FirstAddedValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SecondAddedValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FirstTotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SecondTotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Guid);
            
            DropForeignKey("dbo.Contracts", "UserGuid", "dbo.Users");
            DropForeignKey("dbo.Contracts", "SecondSideGuid", "dbo.Tafsils");
            DropForeignKey("dbo.Contracts", "FirstSideGuid", "dbo.Tafsils");
            DropForeignKey("dbo.Contracts", "BuildingGuid", "dbo.Buildings");
            DropIndex("dbo.Contracts", new[] { "UserGuid" });
            DropIndex("dbo.Contracts", new[] { "BuildingGuid" });
            DropIndex("dbo.Contracts", new[] { "SecondSideGuid" });
            DropIndex("dbo.Contracts", new[] { "FirstSideGuid" });
            DropColumn("dbo.Contracts", "SecondTotalPrice");
            DropColumn("dbo.Contracts", "FirstTotalPrice");
            DropColumn("dbo.Contracts", "SecondAvarez");
            DropColumn("dbo.Contracts", "SecondTax");
            DropColumn("dbo.Contracts", "FirstAvarez");
            DropColumn("dbo.Contracts", "FirstTax");
            DropColumn("dbo.Contracts", "SecondDiscount");
            DropColumn("dbo.Contracts", "FirstDiscount");
            DropColumn("dbo.Contracts", "sBabat");
            DropColumn("dbo.Contracts", "fBabat");
            DropColumn("dbo.Contracts", "SanadNumber");
        }
    }
}
