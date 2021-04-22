using System;
using System.ComponentModel.DataAnnotations;
using Servicess.Interfaces.Building;

namespace Persistence.Entities
{
    public class AdvertiseRelatedRegion : IAdvertiseRelatedRegion
    {
        [Key]
        public Guid Guid { get; set; }
        [MaxLength(200)]
        public string OnlineRegionName { get; set; }
        public Guid LocalRegionGuid { get; set; }
    }
}
