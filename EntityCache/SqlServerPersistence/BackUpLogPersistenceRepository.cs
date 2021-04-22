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
    public class BackUpLogPersistenceRepository : IBackUpLogRepository
    {
        private BackUpLogBussines LoadData(SqlDataReader dr)
        {
            var item = new BackUpLogBussines();
            try
            {
                item.Guid = (Guid)dr["Guid"];
                item.BackUpStatus = (EnBackUpStatus)dr["BackUpStatus"];
                item.InsertedDate = (DateTime)dr["InsertedDate"];
                item.Path = dr["Path"].ToString();
                item.Type = (EnBackUpType)dr["Type"];
                item.StatusDesc = dr["StatusDesc"].ToString();
                item.Size = (short)dr["Size"];
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return item;
        }
        public async Task<List<BackUpLogBussines>> GetAllAsync(string connectionString)
        {
            var list = new List<BackUpLogBussines>();
            try
            {
                using (var cn = new SqlConnection(connectionString))
                {
                    var cmd = new SqlCommand("sp_BackUpLog_GetAll", cn) { CommandType = CommandType.StoredProcedure };

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
        public async Task<BackUpLogBussines> GetAsync(string connectionString, Guid guid)
        {
            BackUpLogBussines res = null;
            try
            {
                using (var cn = new SqlConnection(connectionString))
                {
                    var cmd = new SqlCommand("sp_BackUpLog_Get", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@guid", guid);

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
        public async Task<ReturnedSaveFuncInfo> SaveAsync(BackUpLogBussines item, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_BackUpLog_Save", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@guid", item.Guid);
                cmd.Parameters.AddWithValue("@insDate", item.InsertedDate);
                cmd.Parameters.AddWithValue("@path", item.Path ?? "");
                cmd.Parameters.AddWithValue("@type", (short)item.Type);
                cmd.Parameters.AddWithValue("@st", (short)item.BackUpStatus);
                cmd.Parameters.AddWithValue("@desc", item.StatusDesc ?? "");
                cmd.Parameters.AddWithValue("@size", item.Size);

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
