using System;

namespace PacketParser.Interfaces
{
    public interface IBuildingRequest : IHasGuid
    {
        DateTime CreateDate { get; set; }
        Guid AskerGuid { get; set; }
        Guid UserGuid { get; set; }
        decimal SellPrice1 { get; set; }
        decimal SellPrice2 { get; set; }
        bool? HasVam { get; set; }
        decimal RahnPrice1 { get; set; }
        decimal RahnPrice2 { get; set; }
        decimal EjarePrice1 { get; set; }
        decimal EjarePrice2 { get; set; }
        short? PeopleCount { get; set; }
        bool? HasOwner { get; set; }
        bool? ShortDate { get; set; }
        Guid? RentalAutorityGuid { get; set; }
        Guid CityGuid { get; set; }
        Guid BuildingTypeGuid { get; set; }
        int Masahat1 { get; set; }
        int Masahat2 { get; set; }
        int RoomCount { get; set; }
        Guid BuildingAccountTypeGuid { get; set; }
        Guid BuildingConditionGuid { get; set; }
        string ShortDesc { get; set; }
    }
}
