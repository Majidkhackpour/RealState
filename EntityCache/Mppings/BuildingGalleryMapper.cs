using EntityCache.Bussines;
using Services;
using System;
using System.Collections.Generic;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class BuildingGalleryMapper
    {
        public static BuildingGalleryMapper Instance { get; private set; } = new BuildingGalleryMapper();
        public WebBuildingGallery Map(BuildingGalleryBussines cls)
        {
            return new WebBuildingGallery()
            {
                Guid = cls.Guid,
                Modified = cls.Modified,
                BuildingGuid = cls.BuildingGuid,
                ImageName = cls.ImageName
            };
        }
        public List<WebBuildingGallery> MapList(List<BuildingGalleryBussines> cls)
        {
            var list = new List<WebBuildingGallery>();
            try
            {
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
