using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services;
using Servicess.Interfaces.Building;

namespace Persistence.Entities
{
    public class BuildingRequestRegion : IBuildingRequestRegion
    {
        [Key]
        public Guid Guid { get; set; }
        public ServerStatus ServerStatus { get; set; }
        public DateTime ServerDeliveryDate { get; set; }
        [ForeignKey("Request")]
        public Guid RequestGuid { get; set; }
        [ForeignKey("Region")]
        public Guid RegionGuid { get; set; }
        public virtual BuildingRequest Request { get; set; }
        public virtual Regions Region { get; set; }
    }
}
