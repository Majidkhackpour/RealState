namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _22 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BuildingRequests",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        AskerGuid = c.Guid(nullable: false),
                        UserGuid = c.Guid(nullable: false),
                        SellPrice1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellPrice2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HasVam = c.Boolean(),
                        RahnPrice1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RahnPrice2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EjarePrice1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EjarePrice2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PeopleCount = c.Short(),
                        HasOwner = c.Boolean(),
                        ShortDate = c.Boolean(),
                        RentalAutorityGuid = c.Guid(),
                        CityGuid = c.Guid(nullable: false),
                        BuildingTypeGuid = c.Guid(nullable: false),
                        Masahat1 = c.Int(nullable: false),
                        Masahat2 = c.Int(nullable: false),
                        RoomCount = c.Int(nullable: false),
                        BuildingAccountTypeGuid = c.Guid(nullable: false),
                        BuildingConditionGuid = c.Guid(nullable: false),
                        ShortDesc = c.String(),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.BuildingRequestRegions",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        RequestGuid = c.Guid(nullable: false),
                        RegionGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Guid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BuildingRequestRegions");
            DropTable("dbo.BuildingRequests");
        }
    }
}
