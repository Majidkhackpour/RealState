using System;
using Services;
using Services.Interfaces.Building;

namespace EntityCache.Bussines
{
    public class BuildingZoncanBussines : IBuildingZoncan
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ServerStatus ServerStatus { get; set; }
        public DateTime ServerDeliveryDate { get; set; }
    }
}
