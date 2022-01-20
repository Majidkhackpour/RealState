using EntityCache.Assistence;
using Persistence;
using Services;
using Services.Settings;
using Servicess.Interfaces.Building;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace EntityCache.Bussines
{
    public class SettingsBussines : ISettings
    {
        private static AdvertiseSetting _advSetting = null;
        private static GlobalSetting _settings = null;

        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public static async Task<SettingsBussines> GetAsync(string memberName) => await UnitOfWork.Settings.GetAsync(Cache.ConnectionString, memberName);
        private static SettingsBussines Get(string memberName) => UnitOfWork.Settings.Get(Cache.ConnectionString, memberName);
        public async Task<ReturnedSaveFuncInfo> SaveAsync(SqlTransaction tr = null)
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

                var sett = await GetAsync(Name);
                if (sett != null)
                {
                    res.AddReturnedValue(await RemoveAsync(sett.Guid, tr));
                    if (res.HasError) return res;
                }

                res.AddReturnedValue(await UnitOfWork.Settings.SaveAsync(this, tr));
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
        public static AdvertiseSetting AdvertiseSetting
        {
            get
            {
                try
                {
                    if (_advSetting == null)
                    {
                        var sett = Get(AdvertiseSetting.Key);
                        if (sett == null || string.IsNullOrEmpty(sett.Value))
                            return null;
                        _advSetting = sett.Value.FromJson<AdvertiseSetting>();
                    }
                }
                catch (Exception ex)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                }

                return _advSetting;
            }
            set => _advSetting = value;
        }
        public static GlobalSetting Setting
        {
            get
            {
                try
                {
                    if (_settings == null)
                    {
                        var sett = Get(GlobalSetting.Key);
                        if (sett == null || string.IsNullOrEmpty(sett.Value))
                            return null;
                        _settings = sett.Value.FromJson<GlobalSetting>();
                    }
                }
                catch (Exception ex)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                }

                return _settings;
            }
            set => _settings = value;
        }
    }
}
