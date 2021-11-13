namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _109 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contracts", "RealStateCode", c => c.String(maxLength: 100));
            AddColumn("dbo.Contracts", "HologramCode", c => c.String(maxLength: 100));
            AddColumn("dbo.Contracts", "CheckNoTo", c => c.String(maxLength: 200));
            AddColumn("dbo.Contracts", "BankNameEjare", c => c.String(maxLength: 200));
            AddColumn("dbo.Contracts", "ShobeEjare", c => c.String(maxLength: 100));
            AddColumn("dbo.Contracts", "SarResidTo", c => c.DateTime());
            AddColumn("dbo.Contracts", "SetDocNo", c => c.Int(nullable: false));
            AddColumn("dbo.Contracts", "FirstSideDelay", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Contracts", "SecondSideDelay", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Contracts", "BuildingPlack", c => c.String(maxLength: 50));
            AddColumn("dbo.Contracts", "BuildingZip", c => c.String(maxLength: 50));
            AddColumn("dbo.Contracts", "SanadSerial", c => c.String(maxLength: 100));
            AddColumn("dbo.Contracts", "PartNo", c => c.Int(nullable: false));
            AddColumn("dbo.Contracts", "Page", c => c.Int(nullable: false));
            AddColumn("dbo.Contracts", "Office", c => c.String(maxLength: 100));
            AddColumn("dbo.Contracts", "BuildingNumber", c => c.String(maxLength: 100));
            AddColumn("dbo.Contracts", "ParkingNo", c => c.Int(nullable: false));
            AddColumn("dbo.Contracts", "ParkingMasahat", c => c.Single(nullable: false));
            AddColumn("dbo.Contracts", "StoreNo", c => c.Int(nullable: false));
            AddColumn("dbo.Contracts", "StoreMasahat", c => c.Single(nullable: false));
            AddColumn("dbo.Contracts", "PhoneLineCount", c => c.Int(nullable: false));
            AddColumn("dbo.Contracts", "BuildingPhoneNumber", c => c.String(maxLength: 50));
            AddColumn("dbo.Contracts", "PeopleCount", c => c.Int(nullable: false));
            AddColumn("dbo.Contracts", "PayankarNo", c => c.String(maxLength: 50));
            AddColumn("dbo.Contracts", "PayankarDate", c => c.DateTime());
            AddColumn("dbo.Contracts", "PishPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Contracts", "Witness1", c => c.String(maxLength: 100));
            AddColumn("dbo.Contracts", "Witness2", c => c.String(maxLength: 100));
            AddColumn("dbo.Contracts", "BuildingRegistrationNo", c => c.String(maxLength: 100));
            AddColumn("dbo.Contracts", "BuildingRegistrationNoSub", c => c.String(maxLength: 100));
            AddColumn("dbo.Contracts", "BuildingRegistrationNoOrigin", c => c.String(maxLength: 100));
            AddColumn("dbo.Contracts", "BuildingCosumable", c => c.String(maxLength: 100));
            AddColumn("dbo.Contracts", "ManufacturingLicensePlace", c => c.String(maxLength: 100));
            AddColumn("dbo.Contracts", "ManufacturingLicenseDate", c => c.DateTime());
            AddColumn("dbo.Contracts", "SettlementDate", c => c.DateTime());
            AddColumn("dbo.Contracts", "AmountOfRent", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Contracts", "GulidType", c => c.String(maxLength: 100));
            AddColumn("dbo.Contracts", "DocumentAdjust", c => c.String(maxLength: 100));
            AlterColumn("dbo.Contracts", "SarResid", c => c.DateTime());
            AlterColumn("dbo.Contracts", "DischargeDate", c => c.DateTime());
            DropColumn("dbo.Contracts", "Delay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contracts", "Delay", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Contracts", "DischargeDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Contracts", "SarResid", c => c.String(maxLength: 20));
            DropColumn("dbo.Contracts", "DocumentAdjust");
            DropColumn("dbo.Contracts", "GulidType");
            DropColumn("dbo.Contracts", "AmountOfRent");
            DropColumn("dbo.Contracts", "SettlementDate");
            DropColumn("dbo.Contracts", "ManufacturingLicenseDate");
            DropColumn("dbo.Contracts", "ManufacturingLicensePlace");
            DropColumn("dbo.Contracts", "BuildingCosumable");
            DropColumn("dbo.Contracts", "BuildingRegistrationNoOrigin");
            DropColumn("dbo.Contracts", "BuildingRegistrationNoSub");
            DropColumn("dbo.Contracts", "BuildingRegistrationNo");
            DropColumn("dbo.Contracts", "Witness2");
            DropColumn("dbo.Contracts", "Witness1");
            DropColumn("dbo.Contracts", "PishPrice");
            DropColumn("dbo.Contracts", "PayankarDate");
            DropColumn("dbo.Contracts", "PayankarNo");
            DropColumn("dbo.Contracts", "PeopleCount");
            DropColumn("dbo.Contracts", "BuildingPhoneNumber");
            DropColumn("dbo.Contracts", "PhoneLineCount");
            DropColumn("dbo.Contracts", "StoreMasahat");
            DropColumn("dbo.Contracts", "StoreNo");
            DropColumn("dbo.Contracts", "ParkingMasahat");
            DropColumn("dbo.Contracts", "ParkingNo");
            DropColumn("dbo.Contracts", "BuildingNumber");
            DropColumn("dbo.Contracts", "Office");
            DropColumn("dbo.Contracts", "Page");
            DropColumn("dbo.Contracts", "PartNo");
            DropColumn("dbo.Contracts", "SanadSerial");
            DropColumn("dbo.Contracts", "BuildingZip");
            DropColumn("dbo.Contracts", "BuildingPlack");
            DropColumn("dbo.Contracts", "SecondSideDelay");
            DropColumn("dbo.Contracts", "FirstSideDelay");
            DropColumn("dbo.Contracts", "SetDocNo");
            DropColumn("dbo.Contracts", "SarResidTo");
            DropColumn("dbo.Contracts", "ShobeEjare");
            DropColumn("dbo.Contracts", "BankNameEjare");
            DropColumn("dbo.Contracts", "CheckNoTo");
            DropColumn("dbo.Contracts", "HologramCode");
            DropColumn("dbo.Contracts", "RealStateCode");
        }
    }
}
