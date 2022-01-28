using System;
using Services;
using Services.Interfaces.Building;

namespace EntityCache.Bussines
{
    public class BuildingWindowBussines : IBuildingWindow
    {
        public Guid Guid { get; set; }
        public bool Status { get; set; } = true;
        public DateTime Modified { get; set; } = DateTime.Now;
        public string Name { get; set; }
        public ServerStatus ServerStatus { get; set; } = ServerStatus.None;
        public DateTime ServerDeliveryDate { get; set; } = DateTime.Now;
    }
}
