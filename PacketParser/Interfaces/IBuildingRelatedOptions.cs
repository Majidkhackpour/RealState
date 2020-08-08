using System;

namespace PacketParser.Interfaces
{
    public interface IBuildingRelatedOptions : IHasGuid
    {
        Guid BuildinGuid { get; set; }
        Guid BuildingOptionGuid { get; set; }
    }
}
