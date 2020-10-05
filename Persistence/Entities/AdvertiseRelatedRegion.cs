using System;
using System.ComponentModel.DataAnnotations;
using PacketParser.Interfaces;

namespace Persistence.Entities
{
    public class AdvertiseRelatedRegion : IAdvertiseRelatedRegion
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        [MaxLength(200)]
        public string OnlineRegionName { get; set; }
        public Guid LocalRegionGuid { get; set; }
    }
}
