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
    public class NotePersistenceRepository : INoteRepository
    {
        public async Task<List<NoteBussines>> GetAllAsync(string _connectionString)
        {
            var list = new List<NoteBussines>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Note_SelectAll", cn) { CommandType = CommandType.StoredProcedure };

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
        public async Task<NoteBussines> GetAsync(string _connectionString, Guid guid)
        {
            var obj = new NoteBussines();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Note_Get", cn) { CommandType = CommandType.StoredProcedure };
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
        public async Task<ReturnedSaveFuncInfo> SaveAsync(NoteBussines item, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_Note_Save", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@guid", item.Guid);
                cmd.Parameters.AddWithValue("@title", item.Title ?? "");
                cmd.Parameters.AddWithValue("@desc", item.Description ?? "");
                cmd.Parameters.AddWithValue("@dateSabt", item.DateSabt);
                cmd.Parameters.AddWithValue("@dateSarresid", item.DateSarresid);
                cmd.Parameters.AddWithValue("@userGuid", item.UserGuid);
                cmd.Parameters.AddWithValue("@priority", (short)item.Priority);
                cmd.Parameters.AddWithValue("@status", (short)item.NoteStatus);

                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private NoteBussines LoadData(SqlDataReader dr)
        {
            var item = new NoteBussines();
            try
            {
                item.Guid = (Guid)dr["Guid"];
                item.Title = dr["Title"].ToString();
                item.Description = dr["Description"].ToString();
                item.DateSabt = (DateTime)dr["DateSabt"];
                if (dr["DateSarresid"] != DBNull.Value) item.DateSarresid = (DateTime)dr["DateSarresid"];
                item.UserGuid = (Guid)dr["UserGuid"];
                item.UserName = dr["UserName"].ToString();
                item.Priority = (EnNotePriority)dr["Priority"];
                item.NoteStatus = (EnNoteStatus)dr["NoteStatus"];
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return item;
        }
    }
}
