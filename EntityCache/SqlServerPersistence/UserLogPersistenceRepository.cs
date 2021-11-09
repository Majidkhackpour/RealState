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
    public class UserLogPersistenceRepository : IUserLogRepository
    {
        public async Task<List<UserLogBussines>> GetAllAsync(string _connectionString, Guid userGuid, DateTime d1, DateTime d2)
        {
            var list = new List<UserLogBussines>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_UserLog_SelectAll_ByUser_And_Date", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@userGuid", userGuid);
                    cmd.Parameters.AddWithValue("@date1", d1);
                    cmd.Parameters.AddWithValue("@date2", d2);

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
        public async Task<ReturnedSaveFuncInfo> SaveAsync(UserLogBussines item, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_UserLog_Insert", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@guid", item.Guid);
                cmd.Parameters.AddWithValue("@userGuid", item.UserGuid);
                cmd.Parameters.AddWithValue("@date", item.Date);
                cmd.Parameters.AddWithValue("@action", (short)item.Action);
                cmd.Parameters.AddWithValue("@part", (short)item.Part);
                cmd.Parameters.AddWithValue("@desc", item.Description);
                cmd.Parameters.AddWithValue("@buGuid", item.BuildingGuid);

                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public async Task<List<UserLogBussines>> GetBuildingLogAsync(string connectionString, Guid buGuid)
        {
            var list = new List<UserLogBussines>();
            try
            {
                using (var cn = new SqlConnection(connectionString))
                {
                    var cmd = new SqlCommand("sp_UserLog_SelectAll_ByBuilding", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@buGuid", buGuid);

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
        private UserLogBussines LoadData(SqlDataReader dr)
        {
            var item = new UserLogBussines();
            try
            {
                if (dr["Guid"] != DBNull.Value) item.Guid = (Guid)dr["Guid"];
                if (dr["UserGuid"] != DBNull.Value) item.UserGuid = (Guid)dr["UserGuid"];
                if (dr["UserName"] != DBNull.Value) item.UserName = dr["UserName"].ToString();
                if (dr["Date"] != DBNull.Value) item.Date = (DateTime)dr["Date"];
                if (dr["Action"] != DBNull.Value) item.Action = (EnLogAction)dr["Action"];
                if (dr["Part"] != DBNull.Value) item.Part = (EnLogPart)dr["Part"];
                if (dr["Description"] != DBNull.Value) item.Description = dr["Description"].ToString();
                if (dr["BuildingGuid"] != DBNull.Value) item.BuildingGuid = (Guid?)dr["BuildingGuid"];
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return item;
        }
    }
}
