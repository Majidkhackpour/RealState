using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
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


        public static async Task<List<BuildingRequestRegionBussines>> GetAllAsync(Guid parentGuid, bool status) =>
            await UnitOfWork.BuildingRequestRegion.GetAllAsync(parentGuid, status);
        public static async Task<List<BuildingRequestRegionBussines>> GetAllAsync() =>
            await UnitOfWork.BuildingRequestRegion.GetAllAsync();
        public async Task<ReturnedSaveFuncInfo> ChangeStatusAsync(bool status, string tranName = "")
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = string.IsNullOrEmpty(tranName);
            if (autoTran) tranName = Guid.NewGuid().ToString();
            try
            {
                if (autoTran)
                { //BeginTransaction
                }

                res.AddReturnedValue(await UnitOfWork.BuildingRequestRegion.ChangeStatusAsync(this, status, tranName));
                res.ThrowExceptionIfError();
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
    }
}
