using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Persistence;
using Services;
using Servicess.Interfaces.Building;

namespace EntityCache.Bussines
{
    public class AdvertiseRelatedRegionBussines : IAdvertiseRelatedRegion
    {
        public Guid Guid { get; set; }
        public string OnlineRegionName { get; set; }
        public Guid LocalRegionGuid { get; set; }


        public static async Task<ReturnedSaveFuncInfo> SaveRangeAsync(List<AdvertiseRelatedRegionBussines> list,
            SqlTransaction tr = null)
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

                var _list = await GetAllAsync(list.FirstOrDefault()?.OnlineRegionName, tr);
                if (_list != null && _list.Count > 0)
                    await RemoveRangeAsync(_list, tr);

                res.AddReturnedValue(await UnitOfWork.AdvertiseRelatedRegion.SaveRangeAsync(list, tr));
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
        public static async Task<List<AdvertiseRelatedRegionBussines>> GetAllAsync(string onlineRegion, SqlTransaction tr)
        {
            var res = new List<AdvertiseRelatedRegionBussines>();
            var ret = new ReturnedSaveFuncInfo();
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

                await UnitOfWork.AdvertiseRelatedRegion.GetAllAsync(onlineRegion, tr);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                ret.AddReturnedValue(ex);
            }
            finally
            {
                if (autoTran)
                {
                    tr.TransactionDestiny(ret.HasError);
                    cn.CloseConnection();
                }
            }
            return res;
        }
        public static async Task<ReturnedSaveFuncInfo> RemoveRangeAsync(List<AdvertiseRelatedRegionBussines> list,
            SqlTransaction tr = null)
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

                res.AddReturnedValue(
                    await UnitOfWork.AdvertiseRelatedRegion.RemoveRangeAsync(list.Select(q => q.Guid), tr));
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
        public static async Task<List<AdvertiseRelatedRegionBussines>> GetAllAsync() =>
            await UnitOfWork.AdvertiseRelatedRegion.GetAllAsync(Cache.ConnectionString);
        public static async Task<AdvertiseRelatedRegionBussines> GetByRegionGuidAsync(Guid regionGuid) =>
            await UnitOfWork.AdvertiseRelatedRegion.GetByRegionGuidAsync(Cache.ConnectionString, regionGuid);
    }
}
