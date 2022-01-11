using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using EntityCache.Core;
using Services;

namespace EntityCache.SqlServerPersistence
{
    public class BuildingNotePersistenceRepository : IBuildingNoteRepository
    {
        public async Task<List<BuildingNoteBussines>> GetAllAsync(string connectionString, Guid parentGuid)
        {
            var list = new List<BuildingNoteBussines>();
            try
            {
                using (var cn = new SqlConnection(connectionString))
                {
                    var cmd = new SqlCommand("sp_BuildingNote_GetAll", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@buGuid", parentGuid);
                    await cn.OpenAsync();
                    var dr = await cmd.ExecuteReaderAsync();
                    while (dr.Read()) list.Add(LoadData(dr));
                    dr.Close();
                    cn.Close();
                }
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }

            return list;
        }
        public async Task<ReturnedSaveFuncInfo> RemoveRangeAsync(Guid masterGuid, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_BuildingNote_Remove", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@guid", masterGuid);

                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            return res;
        }
        public async Task<ReturnedSaveFuncInfo> SaveAsync(BuildingNoteBussines item, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_BuildingNote_Save", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@guid", item.Guid);
                cmd.Parameters.AddWithValue("@note", item.Note ?? "");
                cmd.Parameters.AddWithValue("@modif", item.Modified);
                cmd.Parameters.AddWithValue("@buGuid", item.BuildingGuid);
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
        public async Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<BuildingNoteBussines> items, SqlTransaction tr)
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
        public async Task<List<BuildingNoteBussines>> GetAllNotSentAsync(string connectionString)
        {
            var list = new List<BuildingNoteBussines>();
            try
            {
                using (var cn = new SqlConnection(connectionString))
                {
                    var cmd = new SqlCommand("sp_BuildingNote_GetAllNotSent", cn) { CommandType = CommandType.StoredProcedure };
                    await cn.OpenAsync();
                    var dr = await cmd.ExecuteReaderAsync();
                    while (dr.Read()) list.Add(LoadData(dr));
                    dr.Close();
                    cn.Close();
                }
            }
            catch (TaskCanceledException) { }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public async Task<ReturnedSaveFuncInfo> SetSaveResultAsync(string connectionString, Guid guid, ServerStatus status)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                using (var cn = new SqlConnection(connectionString))
                {
                    var cmd = new SqlCommand("sp_BuildingNote_SetSaveResult", cn)
                    { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@Guid", guid);
                    cmd.Parameters.AddWithValue("@st", (short)status);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public async Task<ReturnedSaveFuncInfo> ResetAsync(string connectionString)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                using (var cn = new SqlConnection(connectionString))
                {
                    var cmd = new SqlCommand("sp_BuildingNote_Reset", cn)
                    { CommandType = CommandType.StoredProcedure };
                    await cmd.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private BuildingNoteBussines LoadData(SqlDataReader dr)
        {
            var res = new BuildingNoteBussines();
            try
            {
                if (dr["Guid"] != DBNull.Value) res.Guid = (Guid)dr["Guid"];
                if (dr["Modified"] != DBNull.Value) res.Modified = (DateTime)dr["Modified"];
                if (dr["BuildingGuid"] != DBNull.Value) res.BuildingGuid = (Guid)dr["BuildingGuid"];
                if (dr["Note"] != DBNull.Value) res.Note = dr["Note"].ToString();
                if (dr["ServerDeliveryDate"] != DBNull.Value) res.ServerDeliveryDate = (DateTime)dr["ServerDeliveryDate"];
                if (dr["ServerStatus"] != DBNull.Value) res.ServerStatus = (ServerStatus)dr["ServerStatus"];
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return res;
        }
    }
}
