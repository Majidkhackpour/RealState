using System;
using System.Collections.Generic;
using EntityCache.Bussines;
using Services;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class BuildingReviewMapper
    {
        public static BuildingReviewMapper Instance { get; private set; } = new BuildingReviewMapper();
        public WebBuildingReview Map(BuildingReviewBussines cls)
        {
            return new WebBuildingReview()
            {
                Guid = cls.Guid,
                Modified = cls.Modified,
                ServerStatus = cls.ServerStatus,
                ServerDeliveryDate = cls.ServerDeliveryDate,
                BuildingGuid = cls.BuildingGuid,
                UserGuid = cls.UserGuid,
                Date = cls.Date,
                Report = cls.Report,
                CustometGuid = cls.CustometGuid,
                Status = cls.Status
            };
        }
        public List<WebBuildingReview> MapList(List<BuildingReviewBussines> cls)
        {
            var list = new List<WebBuildingReview>();
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
