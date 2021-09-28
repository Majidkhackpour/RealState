using EntityCache.Bussines;
using EntityCache.Core;
using Services;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace EntityCache.SqlServerPersistence
{
    public class AdvTokensPersistenceRepository : IAdvTokensRepository
    {
        private AdvTokenBussines LoadData(SqlDataReader dr)
        {
            var item = new AdvTokenBussines();
            try
            {
                item.Guid = (Guid)dr["Guid"];
                item.Token = dr["Token"].ToString();
                item.Number = (long)dr["Number"];
                item.Type = (AdvertiseType)dr["Type"];
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return item;
        }
        public async Task<AdvTokenBussines> GetTokenAsync(string _connectionString, long number, AdvertiseType type)
        {
            AdvTokenBussines res = null;
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_AdvToken_GetToken", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@number", number);
                    cmd.Parameters.AddWithValue("@type", (short)type);

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
        public async Task<ReturnedSaveFuncInfo> SaveAsync(AdvTokenBussines item, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_AdvToken_Save", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@guid", item.Guid);
                cmd.Parameters.AddWithValue("@number", item.Number);
                cmd.Parameters.AddWithValue("@type", (short)item.Type);
                cmd.Parameters.AddWithValue("@token", item.Token);

                await cmd.ExecuteNonQueryAsync();
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
                var cmd = new SqlCommand("sp_AdvToken_Remove", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
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
    }
}
