using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using PacketParser.Interfaces;
using Services;

namespace EntityCache.Bussines
{
    public class AdvertiseRelatedRegionBussines : IAdvertiseRelatedRegion
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public string OnlineRegionName { get; set; }
        public Guid LocalRegionGuid { get; set; }


        public static async Task<ReturnedSaveFuncInfo> SaveRangeAsync(List<AdvertiseRelatedRegionBussines> list,
            string tranName = "")
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = string.IsNullOrEmpty(tranName);
            if (autoTran) tranName = Guid.NewGuid().ToString();
            try
            {
                if (autoTran)
                { //BeginTransaction
                }

                var _list = await GetAllAsync(list.FirstOrDefault()?.OnlineRegionName, true);
                if (_list != null && _list.Count > 0)
                    await RemoveRangeAsync(_list);

                res.AddReturnedValue(await UnitOfWork.AdvertiseRelatedRegion.SaveRangeAsync(list, tranName));
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

        public static async Task<List<AdvertiseRelatedRegionBussines>> GetAllAsync(string onlineRegion, bool status) =>
            await UnitOfWork.AdvertiseRelatedRegion.GetAllAsync(onlineRegion, status);

        public static async Task<ReturnedSaveFuncInfo> RemoveRangeAsync(List<AdvertiseRelatedRegionBussines> list,
            string tranName = "")
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = string.IsNullOrEmpty(tranName);
            if (autoTran) tranName = Guid.NewGuid().ToString();
            try
            {
                if (autoTran)
                { //BeginTransaction
                }

                res.AddReturnedValue(
                    await UnitOfWork.AdvertiseRelatedRegion.RemoveRangeAsync(list.Select(q => q.Guid), tranName));
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

        public static async Task<List<AdvertiseRelatedRegionBussines>> GetAllAsync() =>
            await UnitOfWork.AdvertiseRelatedRegion.GetAllAsync();

        public static async Task<AdvertiseRelatedRegionBussines> GetByRegionGuidAsync(Guid regionGuid) =>
            await UnitOfWork.AdvertiseRelatedRegion.GetByRegionGuidAsync(regionGuid);

    }
}
