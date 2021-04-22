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
using Services.DefaultCoding;

namespace EntityCache.SqlServerPersistence
{
    public class TafsilPersistenceRepository : ITafsilRepository
    {
        public TafsilPersistenceRepository() { }
        public async Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<TafsilBussines> items, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                foreach (var item in items)
                    res.AddReturnedValue(await SaveAsync(item, tr));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public async Task<ReturnedSaveFuncInfo> SaveAsync(TafsilBussines item, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_Tafsil_Save", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
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
                cmd.Parameters.AddWithValue("@BankCreditMoeinGuid", ParentDefaults.MoeinCoding.CLSMoein10101);
                cmd.Parameters.AddWithValue("@SandouqCreditMoeinGuid", ParentDefaults.MoeinCoding.CLSMoein10102);
                cmd.Parameters.AddWithValue("@HazineCreditMoeinGuid", ParentDefaults.MoeinCoding.CLSMoein80211);
                cmd.Parameters.AddWithValue("@TafsilCreditMoeinGuid", ParentDefaults.MoeinCoding.CLSMoein10304);
                cmd.Parameters.AddWithValue("@userGuid", ParentDefaults.TafsilCoding.CLSTafsil1030401);
                cmd.Parameters.AddWithValue("@sarmayeMoeinGuid", ParentDefaults.MoeinCoding.CLSMoein50110);
                cmd.Parameters.AddWithValue("@sarmayeTafsilGuid", ParentDefaults.TafsilCoding.CLSTafsil5011001);
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
        public async Task<List<TafsilBussines>> GetAllAsync(string _connectionString)
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
        public async Task<TafsilBussines> GetAsync(Guid guid, SqlTransaction tr)
        {
            TafsilBussines res = null;
            try
            {
                var cmd = new SqlCommand("sp_Tafsil_SelectRow", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@guid", guid);

                var dr = await cmd.ExecuteReaderAsync();
                if (dr.Read()) res = LoadData(dr);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return res;
        }
        public async Task<ReturnedSaveFuncInfo> ChangeStatusAsync(TafsilBussines item, bool status, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_Tafsil_ChangeStatus", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
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
        public async Task<string> NextCodeAsync(string _connectionString, HesabType type)
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
        public async Task<bool> CheckCodeAsync(string _connectionString, Guid guid, string code)
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
        public async Task<bool> CheckNameAsync(string _connectionString, string name)
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
        public async Task<ReturnedSaveFuncInfo> UpdateAccountAsync(Guid guid, decimal price, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_Tafsil_UpdateAccount", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@guid", guid);
                cmd.Parameters.AddWithValue("@price", price);

                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public async Task<TafsilBussines> GetAsync(string _connectionString, string code)
        {
            TafsilBussines res = null;
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Tafsil_GetByCode", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@code", code);

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
                item.ServerDeliveryDate = (DateTime)dr["ServerDeliveryDate"];
                item.ServerStatus = (ServerStatus)dr["ServerStatus"];
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return item;
        }
    }
}
