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
    public class TafsilPersistenceRepository : GenericRepository<TafsilBussines, Tafsil>, ITafsilRepository
    {
        private ModelContext db;
        private string _connectionString;
        public TafsilPersistenceRepository(ModelContext _db, string connectionString) : base(_db, connectionString)
        {
            db = _db;
            _connectionString = connectionString;
        }
        public override async Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<TafsilBussines> items, string tranName)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                foreach (var item in items)
                    res.AddReturnedValue(await SaveAsync(item, tranName));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public override async Task<ReturnedSaveFuncInfo> SaveAsync(TafsilBussines item, string tranName)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Tafsil_Save", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@guid", item.Guid);
                    cmd.Parameters.AddWithValue("@modif", item.Modified);
                    cmd.Parameters.AddWithValue("@st", item.Status);
                    cmd.Parameters.AddWithValue("@name", item.Name ?? "");
                    cmd.Parameters.AddWithValue("@code", item.Code ?? "");
                    cmd.Parameters.AddWithValue("@desc", item.Description ?? "");
                    cmd.Parameters.AddWithValue("@account", item.Account);
                    cmd.Parameters.AddWithValue("@accFirst", item.AccountFirst);
                    cmd.Parameters.AddWithValue("@hType", (int)item.HesabType);
                    cmd.Parameters.AddWithValue("@isSystem", item.isSystem);

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
        public override async Task<List<TafsilBussines>> GetAllAsync()
        {
            var list = new List<TafsilBussines>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Tafsil_SelectAll", cn) { CommandType = CommandType.StoredProcedure };

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
        public override async Task<TafsilBussines> GetAsync(Guid guid)
        {
            TafsilBussines res = null;
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Tafsil_SelectRow", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@guid", guid);

                    await cn.OpenAsync();
                    var dr = await cmd.ExecuteReaderAsync();
                    if (dr.Read()) res = LoadData(dr);
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return res;
        }
        public override async Task<ReturnedSaveFuncInfo> ChangeStatusAsync(TafsilBussines item, bool status, string tranName)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Tafsil_ChangeStatus", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@Guid", item.Guid);
                    cmd.Parameters.AddWithValue("@st", status);

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
        public async Task<string> NextCodeAsync(HesabType type)
        {
            var res = "0";
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Tafsil_NextCode", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@hType", (short)type);

                    await cn.OpenAsync();
                    var obj = await cmd.ExecuteScalarAsync();
                    if (obj != null) res = obj.ToString();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return res;
        }
        public async Task<bool> CheckCodeAsync(Guid guid, string code)
        {
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Tafsil_CheckCode", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@guid", guid);
                    cmd.Parameters.AddWithValue("@code", code);

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
        public async Task<bool> CheckNameAsync(string name)
        {
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Tafsil_CheckName", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@name", name);

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
        public async Task<ReturnedSaveFuncInfo> UpdateAccountAsync(Guid guid, decimal price)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Tafsil_UpdateAccount", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@guid", guid);
                    cmd.Parameters.AddWithValue("@price", price);

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
        private static TafsilBussines LoadData(SqlDataReader dr)
        {
            var item = new TafsilBussines();
            try
            {
                item.Guid = (Guid)dr["Guid"];
                item.Modified = (DateTime)dr["Modified"];
                item.Status = (bool)dr["Status"];
                item.Name = dr["Name"].ToString();
                item.Code = dr["Code"].ToString();
                item.Description = dr["Description"].ToString();
                item.HesabType = (HesabType)dr["HesabType"];
                item.Account = (decimal)dr["Account"];
                item.isSystem = (bool)dr["isSystem"];
                item.DateM = (DateTime)dr["DateM"];
                item.AccountFirst = (decimal)dr["AccountFirst"];
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return item;
        }
    }
}
