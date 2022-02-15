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
    public class BuildingReviewPersistenceRepository : IBuildingReviewRepository
    {
        private BuildingReviewBussines LoadData(SqlDataReader dr)
        {
            var item = new BuildingReviewBussines();
            try
            {
                if (dr["Guid"] != DBNull.Value) item.Guid = (Guid)dr["Guid"];
                if (dr["Modified"] != DBNull.Value) item.Modified = (DateTime)dr["Modified"];
                if (dr["BuildingGuid"] != DBNull.Value) item.BuildingGuid = (Guid)dr["BuildingGuid"];
                if (dr["UserGuid"] != DBNull.Value) item.UserGuid = (Guid)dr["UserGuid"];
                if (dr["CustometGuid"] != DBNull.Value) item.CustometGuid = (Guid)dr["CustometGuid"];
                if (dr["Date"] != DBNull.Value) item.Date = (DateTime)dr["Date"];
                if (dr["Report"] != DBNull.Value) item.Report = dr["Report"].ToString();
                if (dr["ServerStatus"] != DBNull.Value) item.ServerStatus = (ServerStatus)dr["ServerStatus"];
                if (dr["ServerDeliveryDate"] != DBNull.Value) item.ServerDeliveryDate = (DateTime)dr["ServerDeliveryDate"];
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return item;
        }
        public async Task<BuildingReviewBussines> GetAsync(string connectionString, Guid guid)
        {
            var list = new BuildingReviewBussines();
            try
            {
                using (var cn = new SqlConnection(connectionString))
                {
                    var cmd = new SqlCommand("sp_BuildingReview_Get", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@guid", guid);
                    await cn.OpenAsync();
                    var dr = await cmd.ExecuteReaderAsync();
                    if (dr.Read()) list = LoadData(dr);
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
        public async Task<ReturnedSaveFuncInfo> RemoveAsync(Guid guid, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_BuildingReview_Remove", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
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
        public async Task<ReturnedSaveFuncInfo> SaveAsync(BuildingReviewBussines item, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_BuildingReview_Save", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@Guid", item.Guid);
                cmd.Parameters.AddWithValue("@BuildingGuid", item.BuildingGuid);
                cmd.Parameters.AddWithValue("@UserGuid", item.UserGuid);
                cmd.Parameters.AddWithValue("@CustomerGuid", item.CustometGuid);
                cmd.Parameters.AddWithValue("@Date", item.Date);
                cmd.Parameters.AddWithValue("@Report", item.Report??"");
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
        public async Task<List<BuildingReviewBussines>> GetAllNotSentAsync(string connectionString)
        {
            var list = new List<BuildingReviewBussines>();
            try
            {
                using (var cn = new SqlConnection(connectionString))
                {
                    var cmd = new SqlCommand("sp_BuildingReview_GetAllNotSent", cn) { CommandType = CommandType.StoredProcedure };
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
                    var cmd = new SqlCommand("sp_BuildingReView_SetSaveResult", cn)
                    { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@Guid", guid);
                    cmd.Parameters.AddWithValue("@st", (short)status);
                    await cn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    cn.Close();
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
                    var cmd = new SqlCommand("sp_BuildingReview_Reset", cn)
                    { CommandType = CommandType.StoredProcedure };
                    await cn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    cn.Close();
                }
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
