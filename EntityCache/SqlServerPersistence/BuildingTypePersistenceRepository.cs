using EntityCache.Bussines;
using EntityCache.Core;
using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace EntityCache.SqlServerPersistence
{
    public class BuildingTypePersistenceRepository : IBuildingTypeRepository
    {
        public async Task<bool> CheckNameAsync(string _connectionString, string name, Guid guid)
        {
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_BuildingType_CheckName", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@guid", guid);
                    cmd.Parameters.AddWithValue("@name", name ?? "");

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
        public async Task<BuildingTypeBussines> GetAsync(string _connectionString, string name)
        {
            var obj = new BuildingTypeBussines();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_BuildingType_GetByName", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@name", name);
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
        public async Task<BuildingTypeBussines> GetAsync(string _connectionString, Guid guid)
        {
            var obj = new BuildingTypeBussines();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_BuildingType_Get", cn) { CommandType = CommandType.StoredProcedure };
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
        public async Task<List<BuildingTypeBussines>> GetAllAsync(string _connectionString, CancellationToken token)
        {
            var list = new List<BuildingTypeBussines>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_BuildingType_GetAll", cn) { CommandType = CommandType.StoredProcedure };
                    if (token.IsCancellationRequested) return null;
                    await cn.OpenAsync();
                    var dr = await cmd.ExecuteReaderAsync();
                    while (dr.Read())
                    {
                        if (token.IsCancellationRequested) return null;
                        list.Add(LoadData(dr));
                    }
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
        public async Task<ReturnedSaveFuncInfo> SaveAsync(BuildingTypeBussines item, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_BuildingType_Save", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@guid", item.Guid);
                cmd.Parameters.AddWithValue("@st", item.Status);
                cmd.Parameters.AddWithValue("@name", item.Name ?? "");
                cmd.Parameters.AddWithValue("@modif", item.Modified);
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
        public async Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<BuildingTypeBussines> items, SqlTransaction tr)
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
        public async Task<ReturnedSaveFuncInfo> ChangeStatusAsync(BuildingTypeBussines item, bool status, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_BuildingType_ChangeStatus", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
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
        public async Task<List<BuildingTypeBussines>> GetAllNotSentAsync(string connectionString)
        {
            var list = new List<BuildingTypeBussines>();
            try
            {
                using (var cn = new SqlConnection(connectionString))
                {
                    var cmd = new SqlCommand("sp_BuildingType_GetAllNotSent", cn) { CommandType = CommandType.StoredProcedure };
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
                    var cmd = new SqlCommand("sp_BuildingType_SetSaveResult", cn)
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
                    var cmd = new SqlCommand("sp_BuildingType_Reset", cn)
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
        private BuildingTypeBussines LoadData(SqlDataReader dr)
        {
            var item = new BuildingTypeBussines();
            try
            {
                item.Guid = (Guid)dr["Guid"];
                item.Modified = (DateTime)dr["Modified"];
                item.Status = (bool)dr["Status"];
                item.Name = dr["Name"].ToString();
                item.ServerDeliveryDate = (DateTime)dr["ServerDeliveryDate"];
                item.ServerStatus = (ServerStatus)dr["ServerStatus"];
                item.IsModified = true;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return item;
        }
    }
}
