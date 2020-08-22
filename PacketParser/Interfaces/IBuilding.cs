using System;
using Services;

namespace PacketParser.Interfaces
{
    public interface IBuilding : IHasGuid
    {
        DateTime CreateDate { get; set; }
        string Code { get; set; }
        Guid OwnerGuid { get; set; }
        Guid UserGuid { get; set; }
        decimal SellPrice { get; set; }
        decimal VamPrice { get; set; }
        decimal QestPrice { get; set; }
        int Dang { get; set; }
        Guid? DocumentType { get; set; }
        EnTarakom? Tarakom { get; set; }
        decimal RahnPrice1 { get; set; }
        decimal RahnPrice2 { get; set; }
        decimal EjarePrice1 { get; set; }
        decimal EjarePrice2 { get; set; }
        Guid? RentalAutorityGuid { get; set; }
        bool? IsShortTime { get; set; }
        bool? IsOwnerHere { get; set; }
        decimal PishTotalPrice { get; set; }
        decimal PishPrice { get; set; }
        DateTime? DeliveryDate { get; set; }
        string PishDesc { get; set; }
        string MoavezeDesc { get; set; }
        string MosharekatDesc { get; set; }
        int Masahat { get; set; }
        int ZirBana { get; set; }
        Guid CityGuid { get; set; }
        Guid RegionGuid { get; set; }
        string Address { get; set; }
        Guid BuildingConditionGuid { get; set; }
        EnBuildingSide Side { get; set; }
        Guid BuildingTypeGuid { get; set; }
        string ShortDesc { get; set; }
        Guid BuildingAccountTypeGuid { get; set; }
        float MetrazhTejari { get; set; }
        Guid BuildingViewGuid { get; set; }
        Guid FloorCoverGuid { get; set; }
        Guid KitchenServiceGuid { get; set; }
        EnKhadamati Water { get; set; }
        EnKhadamati Barq { get; set; }
        EnKhadamati Gas { get; set; }
        EnKhadamati Tell { get; set; }
        int TedadTabaqe { get; set; }
        int TabaqeNo { get; set; }
        int VahedPerTabaqe { get; set; }
        float MetrazhKouche { get; set; }
        float ErtefaSaqf { get; set; }
        float Hashie { get; set; }
        string SaleSakht { get; set; }
        string DateParvane { get; set; }
        string ParvaneSerial { get; set; }
        bool BonBast { get; set; }
        bool MamarJoda { get; set; }
        int RoomCount { get; set; }
        EnBuildingStatus BuildingStatus { get; set; }
    }
}
