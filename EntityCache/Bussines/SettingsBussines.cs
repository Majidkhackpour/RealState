using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using Services;
using Servicess.Interfaces.Building;

namespace EntityCache.Bussines
{
    public class SettingsBussines : ISettings
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public string Name { get; set; }
        public string Value { get; set; }


        public static async Task<SettingsBussines> GetAsync(string memberName) =>
    await UnitOfWork.Settings.GetAsync(memberName);
        public static SettingsBussines Get(string memberName) => AsyncContext.Run(() => GetAsync(memberName));
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

                var sett = Get(key);
                if (sett != null)
                {
                    res.AddReturnedValue(await UnitOfWork.Settings.RemoveAsync(sett.Guid, tranName));
                    res.ThrowExceptionIfError();
                }

                var set = new SettingsBussines()
                {
                    Guid = Guid.NewGuid(),
                    Name = key,
                    Value = value,
                    Modified = DateTime.Now
                };

                res.AddReturnedValue(await UnitOfWork.Settings.SaveAsync(set, tranName));
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
        public async Task<ReturnedSaveFuncInfo> RemoveAsync(string tranName = "")
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = string.IsNullOrEmpty(tranName);
            if (autoTran) tranName = Guid.NewGuid().ToString();
            try
            {
                if (autoTran)
                { //BeginTransaction
                }

                res.AddReturnedValue(await UnitOfWork.Settings.RemoveAsync(Guid, tranName));
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
        public static ReturnedSaveFuncInfo Save(string key, string value, string tranName = "") =>
            AsyncContext.Run(() => SaveAsync(key, value, tranName));
        public static async Task<List<SettingsBussines>> GetAllAsync() => await UnitOfWork.Settings.GetAllAsync();
    }
}
