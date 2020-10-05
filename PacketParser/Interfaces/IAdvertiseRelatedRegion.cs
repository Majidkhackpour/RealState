using System;

namespace PacketParser.Interfaces
{
    public interface IAdvertiseRelatedRegion : IHasGuid
    {
        string OnlineRegionName { get; set; }
        Guid LocalRegionGuid { get; set; }
    }
}
