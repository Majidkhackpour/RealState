using Services;
using Servicess.Interfaces.Building;
using System;

namespace EntityCache.Bussines
{
    public class BuildingGalleryBussines : Serializable<BuildingGalleryBussines>, IBuildingGallery
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public Guid BuildingGuid { get; set; }
        public string ImageName { get; set; }
    }
}
