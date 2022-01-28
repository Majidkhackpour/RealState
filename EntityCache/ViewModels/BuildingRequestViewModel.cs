﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;
using Services.FilterObjects;

namespace EntityCache.ViewModels
{
    public class BuildingRequestViewModel
    {
        public Guid BuildingGuid { get; set; }
        public string BuildingCode { get; set; }
        public string OwnerName { get; set; }
        public string BuildingTypeName { get; set; }
        public string BuildingAccountTypeName { get; set; }
        public decimal RahnPrice { get; set; }
        public decimal EjarePrice { get; set; }
        public decimal SellPrice { get; set; }
        public int RequestCount { get; set; }
        public List<BuildingRequestBussines> RequestList { get; set; }


        public static async Task<List<BuildingRequestViewModel>> GetAllMatchesItemsAsync(CancellationToken token)
        {
            //var list = await BuildingBussines.GetAllAsync(token, false);
            //return await GetAllMatchesItemsAsync(list, token);
            return new List<BuildingRequestViewModel>();
        }
        public static async Task<List<BuildingRequestViewModel>> GetAllMatchesItemsAsync(List<BuildingBussines> allBuilding, CancellationToken token)
        {
            var list = new List<BuildingRequestViewModel>();
            //try
            //{
            //    foreach (var item in allBuilding)
            //    {
            //        decimal price1, price2;
            //        EnRequestType type;
            //        if (item.SellPrice > 0)
            //        {
            //            price1 = item.SellPrice;
            //            price2 = 0;
            //            type = EnRequestType.Forush;
            //        }
            //        else
            //        {
            //            price1 = item.RahnPrice1;
            //            price2 = item.EjarePrice1;
            //            type = EnRequestType.Rahn;
            //        }

            //        var filter = new RequestMatchFilter()
            //        {
            //            Masahat = item.Masahat,
            //            RegionGuid = item.RegionGuid,
            //            RoomCount = item.RoomCount,
            //            BuildingAccountTypeGuid = item.BuildingAccountTypeGuid,
            //            Type = type,
            //            Price1 = price1,
            //            Price2 = price2
            //        };
            //        var reqList = await BuildingRequestBussines.GetAllAsync(filter, token);
            //        if (reqList == null || reqList.Count <= 0) continue;
            //        var a = new BuildingRequestViewModel()
            //        {
            //            SellPrice = item.SellPrice,
            //            BuildingGuid = item.Guid,
            //            EjarePrice = item.EjarePrice1,
            //            RahnPrice = item.RahnPrice1,
            //            BuildingCode = item.Code,
            //            RequestCount = reqList.Count,
            //            RequestList = reqList
            //        };
            //        list.Add(a);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    WebErrorLog.ErrorInstence.StartErrorLog(ex);
            //}

            return list;
        }
        public static async Task<List<BuildingRequestViewModel>> GetAllMatchesItemsAsync(BuildingBussines building, CancellationToken token)
        {
            try
            {
                //var list = new List<BuildingBussines> { building };
                //return await GetAllMatchesItemsAsync(list, token);
                return new List<BuildingRequestViewModel>();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
    }
}
