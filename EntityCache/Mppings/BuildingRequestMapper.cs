using System;
using System.Collections.Generic;
using EntityCache.Bussines;
using Services;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class BuildingRequestMapper
    {
        public static BuildingRequestMapper Instance { get; private set; } = new BuildingRequestMapper();
        public WebBuildingRequest Map(BuildingRequestBussines cls)
        {
            return new WebBuildingRequest()
            {
                Guid = cls.Guid,
                Modified = cls.Modified,
                Status = cls.Status,
                EjarePrice1 = cls.EjarePrice1,
                RahnPrice1 = cls.RahnPrice1,
                RoomCount = cls.RoomCount,
                BuildingAccountTypeGuid = cls.BuildingAccountTypeGuid,
                UserGuid = cls.UserGuid,
                BuildingTypeGuid = cls.BuildingTypeGuid,
                EjarePrice2 = cls.EjarePrice2,
                RentalAutorityGuid = cls.RentalAutorityGuid,
                ShortDesc = cls.ShortDesc,
                CityGuid = cls.CityGuid,
                CreateDate = cls.CreateDate,
                RahnPrice2 = cls.RahnPrice2,
                SellPrice2 = cls.SellPrice2,
                BuildingConditionGuid = cls.BuildingConditionGuid,
                AskerGuid = cls.AskerGuid,
                SellPrice1 = cls.SellPrice1,
                Masahat1 = cls.Masahat1,
                Masahat2 = cls.Masahat2,
                PeopleCount = cls.PeopleCount,
                ShortDate = cls.ShortDate,
                HasVam = cls.HasVam,
                HasOwner = cls.HasOwner,
                RegionList = BuildingRequestRegionMapper.Instance.MapList(cls.RegionList),
                ServerStatus = cls.ServerStatus,
                ServerDeliveryDate = cls.ServerDeliveryDate
            };
        }
        public List<WebBuildingRequest> MapList(List<BuildingRequestBussines> cls)
        {
            var list = new List<WebBuildingRequest>();
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
