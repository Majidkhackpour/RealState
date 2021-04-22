using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using Persistence;
using Services;
using Servicess.Interfaces.Building;

namespace EntityCache.Bussines
{
    public class SettingsBussines : ISettings
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }


        public static async Task<SettingsBussines> GetAsync(string memberName) => await UnitOfWork.Settings.GetAsync(Cache.ConnectionString, memberName);
        public static SettingsBussines Get(string memberName) => AsyncContext.Run(() => GetAsync(memberName));
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(string key, string value, SqlTransaction tr = null)
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = tr == null;
            SqlConnection cn = null;
            try
            {
                if (autoTran)
                {
                    cn = new SqlConnection(Cache.ConnectionString);
                    await cn.OpenAsync();
                    tr = cn.BeginTransaction();
                }

                var sett = Get(key);
                if (sett != null)
                {
                    res.AddReturnedValue(await RemoveAsync(sett.Guid, tr));
                    if (res.HasError) return res;
                }

                var set = new SettingsBussines()
                {
                    Guid = Guid.NewGuid(),
                    Name = key,
                    Value = value,
                };

                res.AddReturnedValue(await UnitOfWork.Settings.SaveAsync(set, tr));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (autoTran)
                {
                    res.AddReturnedValue(tr.TransactionDestiny(res.HasError));
                    res.AddReturnedValue(cn.CloseConnection());
                }
            }
            return res;
        }
        public static async Task<ReturnedSaveFuncInfo> RemoveAsync(Guid guid, SqlTransaction tr = null)
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = tr == null;
            SqlConnection cn = null;
            try
            {
                if (autoTran)
                {
                    cn = new SqlConnection(Cache.ConnectionString);
                    await cn.OpenAsync();
                    tr = cn.BeginTransaction();
                }

                res.AddReturnedValue(await UnitOfWork.Settings.RemoveAsync(guid, tr));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (autoTran)
                {
                    res.AddReturnedValue(tr.TransactionDestiny(res.HasError));
                    res.AddReturnedValue(cn.CloseConnection());
                }
            }
            return res;
        }
        public static ReturnedSaveFuncInfo Save(string key, string value, SqlTransaction tr = null) => AsyncContext.Run(() => SaveAsync(key, value, tr));
        public static async Task<List<SettingsBussines>> GetAllAsync() => await UnitOfWork.Settings.GetAllAsync(Cache.ConnectionString);
    }
}
