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
    public class UsersPersistenceRepository : GenericRepository<UserBussines, Users>, IUsersRepository
    {
        private ModelContext db;
        private string _connectionString;
        public UsersPersistenceRepository(ModelContext _db, string connectionString) : base(_db, connectionString)
        {
            db = _db;
            _connectionString = connectionString;
        }

        public async Task<bool> CheckUserNameAsync(Guid guid, string userName)
        {
            try
            {
                var acc = db.Users.AsNoTracking().Where(q => q.UserName == userName && q.Guid != guid)
                    .ToList();
                return acc.Count == 0;
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return false;
            }
        }
        public async Task<UserBussines> GetAsync(string userName)
        {
            var obj = new UserBussines();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_User_GetByUserName", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@uName", userName);
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
        public async Task<UserBussines> GetByEmailAsync(string email)
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
        public async Task<UserBussines> GetByMobilAsync(string mobile)
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
        public async Task<List<UserBussines>> GetAllAsync(EnSecurityQuestion question, string answer)
        {
            try
            {
                var acc = db.Users.AsNoTracking().Where(q =>
                    !string.IsNullOrEmpty(q.AnswerQuestion) && q.SecurityQuestion == question &&
                    q.AnswerQuestion == answer && q.Status);
                return Mappings.Default.Map<List<UserBussines>>(acc);
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }
        public override async Task<UserBussines> GetAsync(Guid guid)
        {
            var obj = new UserBussines();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_User_Get", cn) { CommandType = CommandType.StoredProcedure };
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
                item.Account = (decimal) dr["Account"];
                item.AccountFirst = (decimal) dr["AccountFirst"];
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return item;
        }
    }
}
