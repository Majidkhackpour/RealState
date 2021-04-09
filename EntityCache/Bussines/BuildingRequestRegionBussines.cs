using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using Persistence;
using Services;
using Servicess.Interfaces.Building;

namespace EntityCache.Bussines
{
    public class BuildingRequestRegionBussines : IBuildingRequestRegion
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public Guid RequestGuid { get; set; }
        public Guid RegionGuid { get; set; }
        public string HardSerial => Cache.HardSerial;


        public static async Task<List<BuildingRequestRegionBussines>> GetAllAsync(Guid parentGuid, bool status) =>
            await UnitOfWork.BuildingRequestRegion.GetAllAsync(parentGuid, status);
        public static async Task<ReturnedSaveFuncInfo> ChangeStatusAsync(Guid masterGuid, bool status, string tranName = "")
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = string.IsNullOrEmpty(tranName);
            if (autoTran) tranName = Guid.NewGuid().ToString();
            try
            {
                if (autoTran)
                { //BeginTransaction
                }

                res.AddReturnedValue(await UnitOfWork.BuildingRequestRegion.ChangeStatusAsync(masterGuid, status, tranName));
                if (res.HasError) return res;
                if (autoTran)
                {
                    //CommitTransAction
                }
            }
            catch (Exception ex)
            {
                if (autoTran)
                {
                    //RollBackTransAction
                }
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public static async Task<ReturnedSaveFuncInfo> SaveRangeAsync(List<BuildingRequestRegionBussines> list,
            string tranName = "") => await UnitOfWork.BuildingRequestRegion.SaveRangeAsync(list, tranName);
        public static async Task<ReturnedSaveFuncInfo> RemoveRangeAsync(Guid masterGuid,
            string tranName = "") => await UnitOfWork.BuildingRequestRegion.RemoveRangeAsync(masterGuid, tranName);
    }
}
