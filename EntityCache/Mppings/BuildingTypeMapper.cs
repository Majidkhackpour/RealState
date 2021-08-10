﻿using System;
using System.Collections.Generic;
using EntityCache.Bussines;
using Services;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class BuildingTypeMapper
    {
        public static BuildingTypeMapper Instance { get; private set; } = new BuildingTypeMapper();
        public WebBuildingType Map(BuildingTypeBussines cls)
        {
            return new WebBuildingType()
            {
                Guid = cls.Guid,
                Name = cls.Name,
                Modified = cls.Modified,
                Status = cls.Status,
                HardSerial = cls.HardSerial,
                ServerStatus = cls.ServerStatus,
                ServerDeliveryDate = cls.ServerDeliveryDate
            };
        }
        public List<WebBuildingType> MapList(List<BuildingTypeBussines> cls)
        {
            var list = new List<WebBuildingType>();
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
