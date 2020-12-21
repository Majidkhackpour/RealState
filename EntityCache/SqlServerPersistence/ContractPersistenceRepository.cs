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
    public class ContractPersistenceRepository : GenericRepository<ContractBussines, Contract>, IContractRepository
    {
        private ModelContext db;
        private string _connectionString;
        public ContractPersistenceRepository(ModelContext _db, string connectionString) : base(_db, connectionString)
        {
            db = _db;
            _connectionString = connectionString;
        }

        public async Task<List<ContractBussines>> GetAllAsyncBySp()
        {
            try
            {
                var res = db.Database.SqlQuery<ContractBussines>("sp_Contract_SelectAll");
                var a = await res.ToListAsync();
                return a;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
        public async Task<string> NextCodeAsync()
        {
            try
            {
                var all = await GetAllAsync();
                if (all.Count <= 0) return "001001";
                var code = all.ToList()?.Max(q => q.Code) ?? 0;
                code += 1;
                var new_code = code.ToString();
                if (code < 10)
                {
                    new_code = "00000" + code;
                    return new_code;
                }
                if (code >= 10 && code < 100)
                {
                    new_code = "0000" + code;
                    return new_code;
                }
                if (code >= 100 && code < 1000)
                {
                    new_code = "000" + code;
                    return new_code;
                }

                if (code >= 1000 && code < 10000)
                {
                    new_code = "00" + code;
                    return new_code;
                }
                if (code >= 10000 && code < 100000)
                {
                    new_code = "0" + code;
                    return new_code;
                }
                if (code >= 100000 && code < 1000000)
                {
                    new_code = code.ToString();
                    return new_code;
                }

                return new_code;
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return "001001";
            }
        }
        public async Task<bool> CheckCodeAsync(string code, Guid guid)
        {
            try
            {
                var co = code.ParseToLong();
                var acc = db.Contract.AsNoTracking()
                    .Where(q => q.Code == co && q.Guid != guid)
                    .ToList();
                return acc.Count == 0;
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return false;
            }
        }
        public override async Task<ReturnedSaveFuncInfo> ChangeStatusAsync(ContractBussines item, bool status, string tranName)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {

                    var cmd = new SqlCommand("sp_Contract_ChangeStatus", cn)
                    { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@conGuid", item.Guid);
                    cmd.Parameters.AddWithValue("@st", !item.Status);
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
        public override async Task<ReturnedSaveFuncInfo> SaveAsync(ContractBussines item, string tranName)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Contract_Save", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@Guid", item.Guid);
                    cmd.Parameters.AddWithValue("@st", item.Status);
                    cmd.Parameters.AddWithValue("@modif", item.Modified);
                    cmd.Parameters.AddWithValue("@code", item.Code);
                    cmd.Parameters.AddWithValue("@isTemp", item.IsTemp);
                    cmd.Parameters.AddWithValue("@fGuid", item.FirstSideGuid);
                    cmd.Parameters.AddWithValue("@sGuid", item.SecondSideGuid);
                    cmd.Parameters.AddWithValue("@term", item.Term);
                    cmd.Parameters.AddWithValue("@fromDate", item.FromDate);
                    cmd.Parameters.AddWithValue("@totalPrice", item.TotalPrice);
                    cmd.Parameters.AddWithValue("@minorPrice", item.MinorPrice);
                    cmd.Parameters.AddWithValue("@checkNo", item.CheckNo);
                    cmd.Parameters.AddWithValue("@bankName", item.BankName);
                    cmd.Parameters.AddWithValue("@shobe", item.Shobe);
                    cmd.Parameters.AddWithValue("@sareresid", item.SarResid);
                    cmd.Parameters.AddWithValue("@discharcgDate", item.DischargeDate);
                    cmd.Parameters.AddWithValue("@setDocDate", item.SetDocDate);
                    cmd.Parameters.AddWithValue("@setDocPlace", item.SetDocPlace);
                    cmd.Parameters.AddWithValue("@sarqofli", item.SarQofli);
                    cmd.Parameters.AddWithValue("@delay", item.Delay);
                    cmd.Parameters.AddWithValue("@desc", item.Description);
                    cmd.Parameters.AddWithValue("@userGuid", item.UserGuid);
                    cmd.Parameters.AddWithValue("@buGuid", item.BuildingGuid);
                    cmd.Parameters.AddWithValue("@type", (short)item.Type);
                    cmd.Parameters.AddWithValue("@dateM", item.DateM);
                    cmd.Parameters.AddWithValue("@dateSh", item.DateSh);
                    cmd.Parameters.AddWithValue("@fPrice", item.FPrice);
                    cmd.Parameters.AddWithValue("@sPrice", item.SPrice);
                    cmd.Parameters.AddWithValue("@fSidePrice", (item.Finance.FirstTotalPrice + item.Finance.FirstAddedValue) - item.Finance.FirstDiscount);
                    cmd.Parameters.AddWithValue("@sSidePrice", (item.Finance.SecondTotalPrice + item.Finance.SecondAddedValue) - item.Finance.SecondDiscount);
                    cmd.Parameters.AddWithValue("@bazaryabGuid", item.BazaryabGuid);
                    cmd.Parameters.AddWithValue("@bazaryabPrice", item.BazaryabPrice);
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
