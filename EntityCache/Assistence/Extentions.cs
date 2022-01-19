using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Persistence;
using Services;
using Services.Settings;

namespace EntityCache.Assistence
{
    public static class Extentions
    {
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(this GlobalSetting item, SqlTransaction tr = null)
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = tr == null;
            SqlConnection cn = null;
            try
            {
                if (item == null) return res;
                if (autoTran)
                {
                    cn = new SqlConnection(Cache.ConnectionString);
                    await cn.OpenAsync();
                    tr = cn.BeginTransaction();
                }

                var sett = await SettingsBussines.GetAsync(GlobalSetting.Key);
                if (sett != null)
                {
                    res.AddReturnedValue(await SettingsBussines.RemoveAsync(sett.Guid, tr));
                    if (res.HasError) return res;
                }

                var set = new SettingsBussines()
                {
                    Guid = Guid.NewGuid(),
                    Name = GlobalSetting.Key,
                    Value = Json.ToStringJson(item),
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
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(this AdvertiseSetting item, SqlTransaction tr = null)
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = tr == null;
            SqlConnection cn = null;
            try
            {
                if (item == null) return res;
                if (autoTran)
                {
                    cn = new SqlConnection(Cache.ConnectionString);
                    await cn.OpenAsync();
                    tr = cn.BeginTransaction();
                }

                var sett = await SettingsBussines.GetAsync(AdvertiseSetting.Key);
                if (sett != null)
                {
                    res.AddReturnedValue(await SettingsBussines.RemoveAsync(sett.Guid, tr));
                    if (res.HasError) return res;
                }

                var set = new SettingsBussines()
                {
                    Guid = Guid.NewGuid(),
                    Name = AdvertiseSetting.Key,
                    Value = Json.ToStringJson(item),
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
    }
}
