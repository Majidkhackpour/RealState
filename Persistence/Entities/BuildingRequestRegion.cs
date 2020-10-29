using System;
using System.ComponentModel.DataAnnotations;
using Servicess.Interfaces.Building;

namespace Persistence.Entities
{
    public class BuildingRequestRegion : IBuildingRequestRegion
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public Guid RequestGuid { get; set; }
        public Guid RegionGuid { get; set; }
    }
}
