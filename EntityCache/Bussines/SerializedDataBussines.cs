using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Assistence;
using EntityCache.ViewModels;
using Nito.AsyncEx;
using Services;
using Servicess.Interfaces.Building;

namespace EntityCache.Bussines
{
    public class SerializedDataBussines : ISerializedData
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public string Name { get; set; }
        public string Data { get; set; }


        public static async Task<List<DivarCities>> GetDivarCityAsync()
        {
            var list = await UnitOfWork.SerializedData.GetAsync("DivarCities");
            return list?.Data.FromJson<List<DivarCities>>();
        }
        public static async Task<List<DivarRegion>> GetDivarRegionAsync()
        {
            var list = await UnitOfWork.SerializedData.GetAsync("DivarRegions");
            return list?.Data.FromJson<List<DivarRegion>>();
        }
        public static async Task<SerializedDataBussines> GetAsync(string memberName) =>
            await UnitOfWork.SerializedData.GetAsync(memberName);
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(string key, string value, string tranName = "")
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = string.IsNullOrEmpty(tranName);
            if (autoTran) tranName = Guid.NewGuid().ToString();
            try
            {
                if (autoTran)
                { //BeginTransaction
                }

                var sett = await GetAsync(key);
                if (sett != null)
                {
                    res.AddReturnedValue(await RemoveAsync(sett.Guid, tranName));
                    if (res.HasError) return res;
                }

                var set = new SerializedDataBussines()
                {
                    Guid = Guid.NewGuid(),
                    Name = key,
                    Data = value,
                    Modified = DateTime.Now
                };

                res.AddReturnedValue(await UnitOfWork.SerializedData.SaveAsync(set, tranName));
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
        public static async Task<ReturnedSaveFuncInfo> RemoveAsync(Guid guid, string tranName = "")
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = string.IsNullOrEmpty(tranName);
            if (autoTran) tranName = Guid.NewGuid().ToString();
            try
            {
                if (autoTran)
                { //BeginTransaction
                }

                res.AddReturnedValue(await UnitOfWork.SerializedData.RemoveAsync(guid, tranName));
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
    }
}
