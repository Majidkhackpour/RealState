using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;
using Services;

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

                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private UserLogBussines LoadData(SqlDataReader dr)
        {
            var item = new UserLogBussines();
            try
            {
                item.Guid = (Guid)dr["Guid"];
                item.UserGuid = (Guid)dr["UserGuid"];
                item.UserName = dr["UserName"].ToString();
                item.Date = (DateTime)dr["Date"];
                item.Action = (EnLogAction)dr["Action"];
                item.Part = (EnLogPart)dr["Part"];
                item.Description = dr["Description"].ToString();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return item;
        }
    }
}
