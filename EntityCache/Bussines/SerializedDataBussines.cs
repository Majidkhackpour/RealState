using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Assistence;
using EntityCache.ViewModels;
using Persistence;
using Services;
using Servicess.Interfaces.Building;

namespace EntityCache.Bussines
{
    public class SerializedDataBussines : ISerializedData
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }


        public static async Task<List<DivarCities>> GetDivarCityAsync()
        {
            var list = await UnitOfWork.SerializedData.GetAsync(Cache.ConnectionString, "DivarCities");
            return list?.Data.FromJson<List<DivarCities>>();
        }
        public static async Task<List<DivarRegion>> GetDivarRegionAsync()
        {
            var list = await UnitOfWork.SerializedData.GetAsync(Cache.ConnectionString, "DivarRegions");
            return list?.Data.FromJson<List<DivarRegion>>();
        }
        public static async Task<SerializedDataBussines> GetAsync(string memberName) =>
            await UnitOfWork.SerializedData.GetAsync(Cache.ConnectionString, memberName);
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

                var sett = await GetAsync(key);
                if (sett != null)
                {
                    res.AddReturnedValue(await RemoveAsync(sett.Guid, tr));
                    if (res.HasError) return res;
                }

                var set = new SerializedDataBussines()
                {
                    Guid = Guid.NewGuid(),
                    Name = key,
                    Data = value,
                };

                res.AddReturnedValue(await UnitOfWork.SerializedData.SaveAsync(set, tr));
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

                res.AddReturnedValue(await UnitOfWork.SerializedData.RemoveAsync(guid, tr));
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
