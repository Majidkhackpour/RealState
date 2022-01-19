using Services;
using Services.Interfaces.Building;
using System;

namespace EntityCache.Bussines
{
    public class BuildingMediaBussines : Serializable<BuildingMediaBussines>, IBuildingMedia
    {
        public Guid Guid { get; set; }
        public Guid BuildingGuid { get; set; }
        public string MediaName { get; set; }
    }
}
