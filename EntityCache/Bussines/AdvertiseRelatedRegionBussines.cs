using System;
using PacketParser.Interfaces;

namespace EntityCache.Bussines
{
    public class AdvertiseRelatedRegionBussines : IAdvertiseRelatedRegion
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public string OnlineRegionName { get; set; }
        public Guid LocalRegionGuid { get; set; }
    }
}
