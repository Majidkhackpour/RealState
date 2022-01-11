using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EntityCache.Assistence;
using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;
using Services;

namespace EntityCache.SqlServerPersistence
{
    public class UsersPersistenceRepository : IUsersRepository
    {
        public async Task<bool> CheckUserNameAsync(string _connectionString, Guid guid, string userName)
        {
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_User_CheckUserName", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@guid", guid);
                    cmd.Parameters.AddWithValue("@userName", userName);

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
        public async Task<UserBussines> GetAsync(string _connectionString, string userName)
        {
            var obj = new UserBussines();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_User_GetByUserName", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@userName", userName);
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
        public async Task<UserBussines> GetByEmailAsync(string _connectionString, string email)
        {
            var obj = new UserBussines();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_User_GetByEmail", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@email", email);
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
        public async Task<UserBussines> GetByMobilAsync(string _connectionString, string mobile)
        {
            var obj = new UserBussines();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_User_GetByMobile", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@mobile", mobile);
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
        public async Task<List<UserBussines>> GetAllAsync(string _connectionString, EnSecurityQuestion question, string answer)
        {
            var list = new List<UserBussines>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_User_GetAllByQuestion", cn)
                    { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@question", (short)question);
                    cmd.Parameters.AddWithValue("@answer", answer);

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
        public async Task<UserBussines> GetAsync(string _connectionString, Guid guid)
        {
            var obj = new UserBussines();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_User_GetByGuid", cn) { CommandType = CommandType.StoredProcedure };
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
        public async Task<List<UserBussines>> GetAllAsync(string _connectionString, CancellationToken token)
        {
            var list = new List<UserBussines>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_User_GetAll", cn) { CommandType = CommandType.StoredProcedure };
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
        public async Task<ReturnedSaveFuncInfo> SaveAsync(UserBussines item, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_User_Save", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@guid", item.Guid);
                cmd.Parameters.AddWithValue("@modif", item.Modified);
                cmd.Parameters.AddWithValue("@st", item.Status);
                cmd.Parameters.AddWithValue("@name", item.Name ?? "");
                cmd.Parameters.AddWithValue("@userName", item.UserName ?? "");
                cmd.Parameters.AddWithValue("@pass", item.Password ?? "");
                cmd.Parameters.AddWithValue("@access", item.Access ?? "");
                cmd.Parameters.AddWithValue("@answer", item.AnswerQuestion ?? "");
                cmd.Parameters.AddWithValue("@questiion", (short)item.SecurityQuestion);
                cmd.Parameters.AddWithValue("@email", item.Email);
                cmd.Parameters.AddWithValue("@mobile", item.Mobile);
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
        public async Task<ReturnedSaveFuncInfo> ChangeStatusAsync(UserBussines item, bool status, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_User_ChangeStatus", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
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
        public async Task<List<UserBussines>> GetAllNotSentAsync(string connectionString)
        {
            var list = new List<UserBussines>();
            try
            {
                using (var cn = new SqlConnection(connectionString))
                {
                    var cmd = new SqlCommand("sp_User_GetAllNotSent", cn) { CommandType = CommandType.StoredProcedure };
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
                    var cmd = new SqlCommand("sp_User_SetSaveResult", cn)
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
                    var cmd = new SqlCommand("sp_User_Reset", cn)
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
        private UserBussines LoadData(SqlDataReader dr)
        {
            var item = new UserBussines();
            try
            {
                item.Guid = (Guid)dr["Guid"];
                item.Modified = (DateTime)dr["Modified"];
                item.Status = (bool)dr["Status"];
                item.Name = dr["Name"].ToString();
                item.UserName = dr["UserName"].ToString();
                item.Password = dr["Password"].ToString();
                item.Access = dr["Access"].ToString();
                item.SecurityQuestion = (EnSecurityQuestion)dr["SecurityQuestion"];
                item.AnswerQuestion = dr["AnswerQuestion"].ToString();
                item.Email = dr["Email"].ToString();
                item.Mobile = dr["Mobile"].ToString();
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
