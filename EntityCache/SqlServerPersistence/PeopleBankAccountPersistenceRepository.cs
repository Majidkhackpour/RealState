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
    public class PeopleBankAccountPersistenceRepository : IPeoplesBankAccountRepository
    {
        public async Task<List<PeoplesBankAccountBussines>> GetAllAsync(string _connectionString, Guid parentGuid)
        {
            var list = new List<PeoplesBankAccountBussines>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_People_BankAccount_GetAllByParent", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@pGuid", parentGuid);
                    await cn.OpenAsync();
                    var dr = await cmd.ExecuteReaderAsync();
                    while (dr.Read()) list.Add(LoadData(dr));
                    cn.Close();
                }
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }

            return list;
        }
        public async Task<ReturnedSaveFuncInfo> RemoveAsync(Guid parentGuid, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_People_BankAccount_RemoveByParent", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@parentGuid", parentGuid);
                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }

            return res;
        }
        public async Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<PeoplesBankAccountBussines> items, SqlTransaction tr)
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
        public async Task<ReturnedSaveFuncInfo> SaveAsync(PeoplesBankAccountBussines item, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_People_BankAccount_Save", tr.Connection, tr)
                { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@guid", item.Guid);
                cmd.Parameters.AddWithValue("@parentGuid", item.ParentGuid);
                cmd.Parameters.AddWithValue("@bankname", item.BankName ?? "");
                cmd.Parameters.AddWithValue("@accountNumber", item.AccountNumber ?? "");
                cmd.Parameters.AddWithValue("@shobe", item.Shobe ?? "");

                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private PeoplesBankAccountBussines LoadData(SqlDataReader dr)
        {
            var res = new PeoplesBankAccountBussines();
            try
            {
                res.Guid = (Guid)dr["Guid"];
                res.BankName = dr["BankName"].ToString();
                res.AccountNumber = dr["AccountNumber"].ToString();
                res.Shobe = dr["Shobe"].ToString();
                res.ParentGuid = (Guid)dr["ParentGuid"];
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return res;
        }
    }
}
