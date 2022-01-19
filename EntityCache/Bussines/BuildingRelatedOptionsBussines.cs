using Services;
using Servicess.Interfaces.Building;
using System;

namespace EntityCache.Bussines
{
    public class BuildingRelatedOptionsBussines : Serializable<BuildingRelatedOptionsBussines>, IBuildingRelatedOptions
    {
        public Guid Guid { get; set; }
        public Guid BuildinGuid { get; set; }
        public DateTime Modified { get; set; }
        public Guid BuildingOptionGuid { get; set; }
    }
}
