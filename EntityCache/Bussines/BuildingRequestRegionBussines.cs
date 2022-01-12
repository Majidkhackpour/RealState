using EntityCache.Assistence;
using EntityCache.Mppings;
using Persistence;
using Services;
using Servicess.Interfaces.Building;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WebHesabBussines;

namespace EntityCache.Bussines
{
    public class BuildingRequestRegionBussines : IBuildingRequestRegion
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public Guid RequestGuid { get; set; }
        public Guid RegionGuid { get; set; }


        public static async Task<List<BuildingRequestRegionBussines>> GetAllAsync(Guid parentGuid) =>
            await UnitOfWork.BuildingRequestRegion.GetAllAsync(Cache.ConnectionString, parentGuid);
        public static async Task<BuildingRequestRegionBussines> GetAsync(Guid guid) =>
            await UnitOfWork.BuildingRequestRegion.GetAsync(Cache.ConnectionString, guid);
        public static async Task<ReturnedSaveFuncInfo> SaveRangeAsync(List<BuildingRequestRegionBussines> list, SqlTransaction tr = null)
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

                res.AddReturnedValue(await UnitOfWork.BuildingRequestRegion.SaveRangeAsync(list, tr));
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
        public static async Task<ReturnedSaveFuncInfo> RemoveRangeAsync(Guid masterGuid, SqlTransaction tr = null)
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

                res.AddReturnedValue(await UnitOfWork.BuildingRequestRegion.RemoveRangeAsync(masterGuid, tr));
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
