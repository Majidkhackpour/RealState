using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

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
            var list = await BuildingBussines.GetAllAsync(token, false);
            return await GetAllMatchesItemsAsync(list, token);
        }
        public static async Task<List<BuildingRequestViewModel>> GetAllMatchesItemsAsync(List<BuildingBussines> allBuilding, CancellationToken token)
        {
            var list = new List<BuildingRequestViewModel>();
            try
            {
                foreach (var item in allBuilding)
                {
                    decimal price1, price2;
                    EnRequestType type;
                    if (item.SellPrice > 0)
                    {
                        price1 = item.SellPrice;
                        price2 = 0;
                        type = EnRequestType.Forush;
                    }
                    else
                    {
                        price1 = item.RahnPrice1;
                        price2 = item.EjarePrice1;
                        type = EnRequestType.Rahn;
                    }
                    var reqList = await BuildingRequestBussines.GetAllAsync(type, token, price1, price2, item.Masahat,
                        item.RoomCount, item.BuildingAccountTypeGuid, item.RegionGuid);
                    if (reqList == null || reqList.Count <= 0) continue;
                    var a = new BuildingRequestViewModel()
                    {
                        SellPrice = item.SellPrice,
                        BuildingGuid = item.Guid,
                        BuildingTypeName = item.BuildingTypeName,
                        BuildingAccountTypeName = item.BuildingAccountTypeName,
                        OwnerName = item.OwnerName,
                        EjarePrice = item.EjarePrice1,
                        RahnPrice = item.RahnPrice1,
                        BuildingCode = item.Code,
                        RequestCount = reqList.Count,
                        RequestList = reqList
                    };
                    list.Add(a);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public static async Task<List<BuildingRequestViewModel>> GetAllMatchesItemsAsync(BuildingBussines building, CancellationToken token)
        {
            try
            {
                var list = new List<BuildingBussines> { building };
                return await GetAllMatchesItemsAsync(list, token);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
    }
}
