using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EntityCache.Bussines;
using EntityCache.Bussines.ReportBussines;
using Services;
using Services.FilterObjects;

namespace EntityCache.ViewModels
{
    public class BuildingRequestViewModel
    {
        public Guid BuildingGuid { get; set; }
        public string BuildingCode { get; set; }
        public Guid OwnerGuid { get; set; }
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
            var list = await BuildingBussines.GetGuidListAsync();
            return await GetAllMatchesItemsAsync(list, token);
        }
        private static async Task<List<BuildingRequestViewModel>> GetAllMatchesItemsAsync(List<Guid> buGuidList, CancellationToken token)
        {
            var list = new List<BuildingRequestViewModel>();
            try
            {
                var allrequests = await BuildingRequestBussines.GetAllAsync(new RequestMatchFilter(), default);
                if (!(allrequests?.Any() ?? false)) return list;
                foreach (var item in buGuidList)
                {
                    var building = await BuildingReportBussines.GetAsync(item);
                    decimal price1, price2;
                    EnRequestType type;
                    if (building.SellPrice > 0)
                    {
                        price1 = building.SellPrice;
                        price2 = 0;
                        type = EnRequestType.Forush;
                    }
                    else
                    {
                        price1 = building.RahnPrice1;
                        price2 = building.EjarePrice1;
                        type = EnRequestType.Rahn;
                    }

                    var filter = new RequestMatchFilter()
                    {
                        Masahat = building.Masahat,
                        RegionGuid = building.RegionGuid,
                        RoomCount = building.RoomCount,
                        BuildingAccountTypeGuid = building.BuildingAccountTypeGuid,
                        Type = type,
                        Price1 = price1,
                        Price2 = price2
                    };
                    var reqList = await BuildingRequestBussines.GetAllAsync(filter, token);
                    if (reqList == null || reqList.Count <= 0) continue;
                    var a = new BuildingRequestViewModel()
                    {
                        SellPrice = building.SellPrice,
                        BuildingGuid = building.Guid,
                        EjarePrice = building.EjarePrice1,
                        RahnPrice = building.RahnPrice1,
                        BuildingCode = building.Code,
                        RequestCount = reqList.Count,
                        RequestList = reqList,
                        OwnerName = building.OwnerName,
                        BuildingTypeName = building.BuildingTypeName,
                        BuildingAccountTypeName = building.BuildingAccountTypeName,
                        OwnerGuid = building.OwnerGuid
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
        public static async Task<List<BuildingRequestViewModel>> GetAllMatchesItemsAsync(Guid buGuid, CancellationToken token)
        {
            try
            {
                var list = new List<Guid> { buGuid };
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
