using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using PacketParser.Interfaces;
using Services;

namespace EntityCache.Bussines
{
    public class BuildingRelatedOptionsBussines : IBuildingRelatedOptions
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public Guid BuildinGuid { get; set; }
        public Guid BuildingOptionGuid { get; set; }


        public static async Task<List<BuildingRelatedOptionsBussines>> GetAllAsync(Guid parentGuid, bool status) =>
            await UnitOfWork.BuildingRelatedOptions.GetAllAsync(parentGuid, status);

        public static List<BuildingRelatedOptionsBussines> GetAll(Guid parentGuid, bool status) =>
            AsyncContext.Run(() => GetAllAsync(parentGuid, status));

        public static async Task<List<BuildingRelatedOptionsBussines>> GetAllAsync() =>
            await UnitOfWork.BuildingRelatedOptions.GetAllAsync();

        public static List<BuildingRelatedOptionsBussines> GetAll() => AsyncContext.Run(GetAllAsync);

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

                res.AddReturnedValue(await UnitOfWork.BuildingRelatedOptions.ChangeStatusAsync(this, status, tranName));
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
