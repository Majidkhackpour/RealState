using System;

namespace PacketParser.Interfaces
{
    public interface IBuildingGallery : IHasGuid
    {
        Guid BuildingGuid { get; set; }
        string ImageName { get; set; }
    }
}
