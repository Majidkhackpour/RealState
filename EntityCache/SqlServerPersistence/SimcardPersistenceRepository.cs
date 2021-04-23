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
    public class SimcardPersistenceRepository : ISimcardRepository
    {
        public async Task<SimcardBussines> GetAsync(string _connectionString, long number)
        {
            var obj = new SimcardBussines();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Simcard_GetByNumber", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@number", number);
                    await cn.OpenAsync();
                    var dr = await cmd.ExecuteReaderAsync();
                    if (dr.Read()) obj = LoadData(dr);
                    cn.Close();
                }
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }

            return obj;
        }
        public async Task<SimcardBussines> GetAsync(string _connectionString, Guid guid)
        {
            var obj = new SimcardBussines();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Simcard_Get", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@guid", guid);
                    await cn.OpenAsync();
                    var dr = await cmd.ExecuteReaderAsync();
                    if (dr.Read()) obj = LoadData(dr);
                    cn.Close();
                }
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }

            return obj;
        }
        public async Task<List<SimcardBussines>> GetAllAsync(string _connectionString)
        {
            var list = new List<SimcardBussines>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Simcard_GetAll", cn) { CommandType = CommandType.StoredProcedure };

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
        public async Task<bool> CheckNumberAsync(string _connectionString, long number, Guid guid)
        {
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Simcard_CheckNumber", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@guid", guid);
                    cmd.Parameters.AddWithValue("@number", number);

                    await cn.OpenAsync();
                    var count = (int)await cmd.ExecuteScalarAsync();
                    cn.Close();
                    return count <= 0;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return false;
            }
        }
        public async Task<ReturnedSaveFuncInfo> ChangeStatusAsync(SimcardBussines item, bool status, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_Simcard_ChangeStatus", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@Guid", item.Guid);
                cmd.Parameters.AddWithValue("@st", status);

                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public async Task<ReturnedSaveFuncInfo> SaveAsync(SimcardBussines item, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_Simcard_Save", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@guid", item.Guid);
                cmd.Parameters.AddWithValue("@st", item.Status);
                cmd.Parameters.AddWithValue("@number", item.Number);
                cmd.Parameters.AddWithValue("@owner", item.Owner ?? "");
                cmd.Parameters.AddWithValue("@operator", item.Operator ?? "");
                cmd.Parameters.AddWithValue("@shBlock", item.isSheypoorBlocked);
                cmd.Parameters.AddWithValue("@nextUseSh", item.NextUseSheypoor);
                cmd.Parameters.AddWithValue("@nextUseD", item.NextUseDivar);

                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private SimcardBussines LoadData(SqlDataReader dr)
        {
            var item = new SimcardBussines();
            try
            {
                item.Guid = (Guid)dr["Guid"];
                item.Status = (bool)dr["Status"];
                item.Number = (long)dr["Number"];
                item.Owner = dr["Owner"].ToString();
                item.Operator = dr["Operator"].ToString();
                item.isSheypoorBlocked = (bool)dr["isSheypoorBlocked"];
                item.NextUseSheypoor = (DateTime)dr["NextUseSheypoor"];
                item.NextUseDivar = (DateTime)dr["NextUseDivar"];
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return item;
        }
    }
}
