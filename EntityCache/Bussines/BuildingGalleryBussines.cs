using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Services;
using Servicess.Interfaces.Building;

namespace EntityCache.Bussines
{
    public class BuildingGalleryBussines : IBuildingGallery
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public Guid BuildingGuid { get; set; }
        public string ImageName { get; set; }



        public static async Task<List<BuildingGalleryBussines>> GetAllAsync(Guid parentGuid, bool status) =>
            await UnitOfWork.BuildingGallery.GetAllAsync(parentGuid, status);
        public static async Task<List<BuildingGalleryBussines>> GetAllAsync() =>
            await UnitOfWork.BuildingGallery.GetAllAsync();
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

                res.AddReturnedValue(await UnitOfWork.BuildingGallery.ChangeStatusAsync(this, status, tranName));
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
