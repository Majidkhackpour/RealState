using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;
using Services;

namespace EntityCache.SqlServerPersistence
{
    public class SanadDetailPersistenceRepository : ISanadDetailRepository
    {
        private SanadDetailBussines LoadData(SqlDataReader dr)
        {
            var item = new SanadDetailBussines();
            try
            {
                item.Guid = (Guid)dr["Guid"];
                item.Modified = (DateTime)dr["Modified"];
                item.MoeinGuid = (Guid)dr["MoeinGuid"];
                item.MoeinCode = dr["MoeinCode"].ToString();
                item.MoeinName = dr["MoeinName"].ToString();
                item.TafsilGuid = (Guid)dr["TafsilGuid"];
                item.TafsilCode = dr["TafsilCode"].ToString();
                item.TafsilName = dr["TafsilName"].ToString();
                item.Description = dr["Description"].ToString();
                item.MasterGuid = (Guid)dr["MasterGuid"];
                item.Debit = (decimal)dr["Debit"];
                item.Credit = (decimal)dr["Credit"];
                item.ServerDeliveryDate = (DateTime)dr["ServerDeliveryDate"];
                item.ServerStatus = (ServerStatus)dr["ServerStatus"];
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return item;
        }
        private GardeshBussines LoadDataGardesh(SqlDataReader dr)
        {
            var item = new GardeshBussines();
            try
            {
                item.Guid = (Guid)dr["Guid"];
                item.Status = (bool)dr["Status"];
                item.MoeinGuid = (Guid)dr["MoeinGuid"];
                item.MoeinCode = dr["MoeinCode"].ToString();
                item.MoeinName = dr["MoeinName"].ToString();
                item.TafsilGuid = (Guid)dr["TafsilGuid"];
                item.TafsilCode = dr["TafsilCode"].ToString();
                item.TafsilName = dr["TafsilName"].ToString();
                item.Description = dr["Description"].ToString();
                item.Debit = (decimal)dr["Debit"];
                item.Credit = (decimal)dr["Credit"];
                item.DateM = (DateTime)dr["DateM"];
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return item;
        }
        public async Task<List<SanadDetailBussines>> GetAllAsync(string _connectionString, Guid masterGuid)
        {
            var list = new List<SanadDetailBussines>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_SanadDetail_GetAllByMaster", cn)
                    { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@masterGuid", masterGuid);

                    await cn.OpenAsync();
                    var dr = await cmd.ExecuteReaderAsync();
                    while (dr.Read()) list.Add(LoadData(dr));
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public async Task<ReturnedSaveFuncInfo> RemoveRangeAsync(Guid masterGuid, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_SanadDetail_RemoveByMasterGuid", tr.Connection, tr)
                { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@masterGuid", masterGuid);

                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public async Task<List<GardeshBussines>> GetAllGardeshAsync(string _connectionString, Guid tafsilGuid)
        {
            var list = new List<GardeshBussines>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Gardesh_GetAll", cn)
                    { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@tafsilGuid", tafsilGuid);

                    await cn.OpenAsync();
                    var dr = await cmd.ExecuteReaderAsync();
                    while (dr.Read()) list.Add(LoadDataGardesh(dr));
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public async Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<SanadDetailBussines> items, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                foreach (var item in items)
                    res.AddReturnedValue(await SaveAsync(item, tr));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public async Task<ReturnedSaveFuncInfo> SaveAsync(SanadDetailBussines item, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_SanadDetail_Save", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@guid", item.Guid);
                cmd.Parameters.AddWithValue("@modif", item.Modified);
                cmd.Parameters.AddWithValue("@moeinGuid", item.MoeinGuid);
                cmd.Parameters.AddWithValue("@desc", item.Description ?? "");
                cmd.Parameters.AddWithValue("@tafsilGuid", item.TafsilGuid);
                cmd.Parameters.AddWithValue("@debit", item.Debit);
                cmd.Parameters.AddWithValue("@credit", item.Credit);
                cmd.Parameters.AddWithValue("@masterGuid", item.MasterGuid);
                cmd.Parameters.AddWithValue("@serverSt", (short)item.ServerStatus);
                cmd.Parameters.AddWithValue("@serverDate", item.ServerDeliveryDate);

                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
    }
}
