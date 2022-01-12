using System;
using System.Collections.Generic;
using EntityCache.Bussines;
using Services;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public  class BuildingRelatedOptionMapper
    {
        public static BuildingRelatedOptionMapper Instance { get; private set; } = new BuildingRelatedOptionMapper();
        public WebBuildingRelatedOptions Map(BuildingRelatedOptionsBussines cls)
        {
            return new WebBuildingRelatedOptions()
            {
                Guid = cls.Guid,
                BuildingOptionGuid = cls.BuildingOptionGuid,
                BuildinGuid = cls.BuildinGuid,
                Modified = cls.Modified,
            };
        }
        public List<WebBuildingRelatedOptions> MapList(List<BuildingRelatedOptionsBussines> cls)
        {
            var list = new List<WebBuildingRelatedOptions>();
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
