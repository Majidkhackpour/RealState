using EntityCache.Bussines;
using EntityCache.Core;
using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace EntityCache.SqlServerPersistence
{
    public class AdvertiseRelatedRegionPersistenceRepository : IAdvertiseRelatedRegionRepository
    {
        public AdvertiseRelatedRegionPersistenceRepository() { }
        private AdvertiseRelatedRegionBussines LoadData(SqlDataReader dr)
        {
            var item = new AdvertiseRelatedRegionBussines();
            try
            {
                item.Guid = (Guid)dr["Guid"];
                item.OnlineRegionName = dr["OnlineRegionName"].ToString();
                item.LocalRegionGuid = (Guid)dr["LocalRegionGuid"];
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return item;
        }
        public async Task<List<AdvertiseRelatedRegionBussines>> GetAllAsync(string onlineRegion, SqlTransaction tr)
        {
            var list = new List<AdvertiseRelatedRegionBussines>();
            try
            {
                var cmd = new SqlCommand("sp_AdvertiseRelatedRegion_GetAllByOnlineRegionName", tr.Connection, tr)
                { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@onlineRegionName", onlineRegion ?? "");

                var dr = await cmd.ExecuteReaderAsync();
                while (dr.Read()) list.Add(LoadData(dr));
                dr.Close();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public async Task<ReturnedSaveFuncInfo> SaveAsync(AdvertiseRelatedRegionBussines item, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_AdvertiseRelatedRegion_Save", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@guid", item.Guid);
                cmd.Parameters.AddWithValue("@onlineRegionName", item.OnlineRegionName ?? "");
                cmd.Parameters.AddWithValue("@localRegionGuid", item.LocalRegionGuid);

                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public async Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<AdvertiseRelatedRegionBussines> items, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                foreach (var item in items)
                {
                    res.AddReturnedValue(await SaveAsync(item, tr));
                    if (res.HasError) return res;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            return res;
        }
        public async Task<ReturnedSaveFuncInfo> RemoveAsync(Guid guid, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_AdvertiseRelatedRegion_Remove", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@guid", guid);

                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            return res;
        }
        public async Task<ReturnedSaveFuncInfo> RemoveRangeAsync(IEnumerable<Guid> items, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                foreach (var item in items)
                {
                    res.AddReturnedValue(await RemoveAsync(item, tr));
                    if (res.HasError) return res;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            return res;
        }
        public async Task<AdvertiseRelatedRegionBussines> GetByRegionGuidAsync(string connectionString, Guid regionGuid)
        {
            AdvertiseRelatedRegionBussines res = null;
            try
            {
                using (var cn = new SqlConnection(connectionString))
                {
                    var cmd = new SqlCommand("sp_AdvertiseRelatedRegion_GetByLocalRegionGuid", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@localRegionGuid", regionGuid);

                    await cn.OpenAsync();
                    var dr = await cmd.ExecuteReaderAsync();
                    if (dr.Read()) res = LoadData(dr);
                    dr.Close();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return res;
        }
        public async Task<List<AdvertiseRelatedRegionBussines>> GetAllAsync(string connectionString)
        {
            var list = new List<AdvertiseRelatedRegionBussines>();
            try
            {
                using (var cn = new SqlConnection(connectionString))
                {
                    var cmd = new SqlCommand("sp_AdvertiseRelatedRegion_GetAll", cn) { CommandType = CommandType.StoredProcedure };

                    await cn.OpenAsync();
                    var dr = await cmd.ExecuteReaderAsync();
                    while (dr.Read()) list.Add(LoadData(dr));
                    dr.Close();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
    }
}
