namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _13 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buildings",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        OwnerGuid = c.Guid(nullable: false),
                        SellPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VamPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QestPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Dang = c.Int(nullable: false),
                        DocumentType = c.Guid(),
                        Tarakom = c.Short(),
                        RahnPrice1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RahnPrice2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EjarePrice1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EjarePrice2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RentalAutorityGuid = c.Guid(),
                        IsShortTime = c.Boolean(),
                        IsOwnerHere = c.Boolean(),
                        PishTotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PishPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DeliveryDate = c.DateTime(),
                        PishDesc = c.String(),
                        MoavezeDesc = c.String(),
                        MosharekatDesc = c.String(),
                        Masahat = c.Int(nullable: false),
                        ZirBana = c.Int(nullable: false),
                        CityGuid = c.Guid(nullable: false),
                        RegionGuid = c.Guid(nullable: false),
                        Address = c.String(),
                        BuildingConditionGuid = c.Guid(nullable: false),
                        Side = c.Int(nullable: false),
                        BuildingTypeGuid = c.Guid(nullable: false),
                        ShortDesc = c.String(),
                        BuildingAccountTypeGuid = c.Guid(nullable: false),
                        MetrazhTejari = c.Int(nullable: false),
                        BuildingViewGuid = c.Guid(nullable: false),
                        FloorCoverGuid = c.Guid(nullable: false),
                        KitchenServiceGuid = c.Guid(nullable: false),
                        Water = c.Short(nullable: false),
                        Barq = c.Short(nullable: false),
                        Gas = c.Short(nullable: false),
                        Tell = c.Short(nullable: false),
                        TedadTabaqe = c.Int(nullable: false),
                        TabaqeNo = c.Int(nullable: false),
                        VahedPerTabaqe = c.Int(nullable: false),
                        MetrazhKouche = c.Int(nullable: false),
                        ErtefaSaqf = c.Int(nullable: false),
                        Hashie = c.Int(nullable: false),
                        SaleSakht = c.DateTime(),
                        DateParvane = c.DateTime(),
                        ParvaneSerial = c.String(maxLength: 200),
                        BonBast = c.Boolean(nullable: false),
                        MamarJoda = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Buildings");
        }
    }
}
