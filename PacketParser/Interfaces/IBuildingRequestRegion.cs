using System;

namespace PacketParser.Interfaces
{
    public interface IBuildingRequestRegion : IHasGuid
    {
        Guid RequestGuid { get; set; }
        Guid RegionGuid { get; set; }
    }
}
