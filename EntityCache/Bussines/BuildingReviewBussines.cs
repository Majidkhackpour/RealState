using System;
using Services;
using Services.Interfaces.Building;

namespace EntityCache.Bussines
{
    public class BuildingReviewBussines : IBuildingReview
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public Guid BuildingGuid { get; set; }
        public Guid UserGuid { get; set; }
        public Guid CustometGuid { get; set; }
        public DateTime Date { get; set; }
        public string Report { get; set; }
        public ServerStatus ServerStatus { get; set; }
        public DateTime ServerDeliveryDate { get; set; }
    }
}
