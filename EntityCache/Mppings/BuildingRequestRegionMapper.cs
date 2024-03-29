﻿using System;
using System.Collections.Generic;
using EntityCache.Bussines;
using Services;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class BuildingRequestRegionMapper
    {
        public static BuildingRequestRegionMapper Instance { get; private set; } = new BuildingRequestRegionMapper();
        public WebBuildingRequestRegion Map(BuildingRequestRegionBussines cls)
        {
            return new WebBuildingRequestRegion()
            {
                Guid = cls.Guid,
                Modified = cls.Modified,
                RegionGuid = cls.RegionGuid,
                RequestGuid = cls.RequestGuid,
            };
        }
        public List<WebBuildingRequestRegion> MapList(List<BuildingRequestRegionBussines> cls)
        {
            var list = new List<WebBuildingRequestRegion>();
            try
            {
                if (cls == null) return list;
                foreach (var item in cls)
                    list.Add(Map(item));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
    }
}
