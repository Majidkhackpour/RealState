using Services;
using Services.Interfaces.Building;
using System;

namespace EntityCache.Bussines
{
    public class BuildingNoteBussines : Serializable<BuildingNoteBussines>, IBuildingNote
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public Guid BuildingGuid { get; set; }
        public string Note { get; set; }
    }
}
