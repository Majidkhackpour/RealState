using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;
using Services;

namespace EntityCache.SqlServerPersistence
{
    public class AdvisorPersistenceRepository : IAdvisorRepository
    {
        public async Task<List<AdvisorBussines>> GetAllAsync(string connectionString, CancellationToken token)
        {
            var list = new List<AdvisorBussines>();
            try
            {
                using (var cn = new SqlConnection(connectionString))
                {
                    var cmd = new SqlCommand("sp_Advisor_GetAll", cn) { CommandType = CommandType.StoredProcedure };
                    if (token.IsCancellationRequested) return null;
                    await cn.OpenAsync();
                    var dr = await cmd.ExecuteReaderAsync();
                    while (dr.Read())
                    {
                        if (token.IsCancellationRequested) return null;
                        list.Add(LoadData(dr));
                    }
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
        public async Task<AdvisorBussines> GetAsync(string connectionString, Guid guid)
        {
            AdvisorBussines res = null;
            try
            {
                using (var cn = new SqlConnection(connectionString))
                {
                    var cmd = new SqlCommand("sp_Advisor_Get", cn) { CommandType = CommandType.StoredProcedure };
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
        public async Task<ReturnedSaveFuncInfo> SaveAsync(AdvisorBussines item, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_Advisor_Save", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@guid", item.Guid);
                cmd.Parameters.AddWithValue("@st", item.Status);
                cmd.Parameters.AddWithValue("@name", item.Name ?? "");
                cmd.Parameters.AddWithValue("@address", item.Address ?? "");

                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public async Task<ReturnedSaveFuncInfo> ChangeStatusAsync(AdvisorBussines item, bool status, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_Advisor_ChangeStatus", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
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
        private AdvisorBussines LoadData(SqlDataReader dr)
        {
            var item = new AdvisorBussines();
            try
            {
                item.Guid = (Guid)dr["Guid"];
                item.Modified = (DateTime)dr["Modified"];
                item.Status = (bool)dr["Status"];
                item.Name = dr["Name"].ToString();
                item.Account = (decimal)dr["Account"];
                item.AccountFirst = (decimal)dr["AccountFirst"];
                item.Address = dr["Address"].ToString();
                var tellList = PhoneBookBussines.GetAll(item.Guid, true);
                if (tellList?.Count == 1) item.Mobile1 = tellList[0]?.Tell;
                if (tellList?.Count > 1)
                {
                    item.Mobile1 = tellList[0]?.Tell;
                    item.Mobile2 = tellList[1]?.Tell;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return item;
        }
    }
}
