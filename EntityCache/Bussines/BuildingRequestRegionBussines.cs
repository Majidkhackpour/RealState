using EntityCache.Assistence;
using Persistence;
using Services;
using Servicess.Interfaces.Building;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace EntityCache.Bussines
{
    public class BuildingRequestRegionBussines : IBuildingRequestRegion
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public Guid RequestGuid { get; set; }
        public Guid RegionGuid { get; set; }
    }
}
