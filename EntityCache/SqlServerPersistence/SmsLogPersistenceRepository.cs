using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;
using Services;

namespace EntityCache.SqlServerPersistence
{
    public class SmsLogPersistenceRepository : ISmsLogRepository
    {
        public async Task<SmsLogBussines> GetAsync(string _connectionString, long messageId)
        {
            var obj = new SmsLogBussines();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_SmsLog_GetByMessageId", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@messageId", messageId);
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
        public async Task<SmsLogBussines> GetAsync(string _connectionString, Guid guid)
        {
            var obj = new SmsLogBussines();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_SmsLog_Get", cn) { CommandType = CommandType.StoredProcedure };
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
        public async Task<List<SmsLogBussines>> GetAllAsync(string _connectionString)
        {
            var list = new List<SmsLogBussines>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_SmsLog_SelectAll", cn) { CommandType = CommandType.StoredProcedure };

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
        public async Task<ReturnedSaveFuncInfo> SaveAsync(SmsLogBussines item, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_SmsLog_Save", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@guid", item.Guid);
                cmd.Parameters.AddWithValue("@date", item.Date);
                cmd.Parameters.AddWithValue("@userGuid", item.UserGuid);
                cmd.Parameters.AddWithValue("@sender", item.Sender ?? "");
                cmd.Parameters.AddWithValue("@reciver", item.Reciver ?? "");
                cmd.Parameters.AddWithValue("@message", item.Message ?? "");
                cmd.Parameters.AddWithValue("@cost", item.Cost);
                cmd.Parameters.AddWithValue("@messageId", item.MessageId);
                cmd.Parameters.AddWithValue("@statusText", item.StatusText ?? "");

                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private SmsLogBussines LoadData(SqlDataReader dr)
        {
            var item = new SmsLogBussines();
            try
            {
                item.Guid = (Guid)dr["Guid"];
                item.Date = (DateTime)dr["Date"];
                item.UserGuid = (Guid)dr["UserGuid"];
                item.UserName = dr["UserName"].ToString();
                item.Sender = dr["Sender"].ToString();
                item.Reciver = dr["Reciver"].ToString();
                item.Message = dr["Message"].ToString();
                item.Cost = (decimal)dr["Cost"];
                item.MessageId = (long)dr["MessageId"];
                item.StatusText = dr["StatusText"].ToString();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return item;
        }
    }
}
