using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EntityCache.Bussines;
using EntityCache.Core;
using EntityCache.ViewModels;
using Persistence.Entities;
using Persistence.Model;
using Services;

namespace EntityCache.SqlServerPersistence
{
    public class ContractPersistenceRepository : IContractRepository
    {
        public async Task<List<ContractBussines>> GetAllAsync(string _connectionString, CancellationToken token)
        {
            var list = new List<ContractBussines>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Contract_GetAll", cn) { CommandType = CommandType.StoredProcedure };
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
        public async Task<string> NextCodeAsync(string _connectionString)
        {
            var res = "0";
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Contract_NextCode", cn) { CommandType = CommandType.StoredProcedure };

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
        public async Task<bool> CheckCodeAsync(string _connectionString, string code, Guid guid)
        {
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Contract_CheckCode", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@guid", guid);
                    cmd.Parameters.AddWithValue("@code", code.ParseToLong());

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
        public async Task<ReturnedSaveFuncInfo> SaveAsync(ContractBussines item, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_Contract_Save", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@Guid", item.Guid);
                cmd.Parameters.AddWithValue("@modif", item.Modified);
                cmd.Parameters.AddWithValue("@code", item.Code);
                cmd.Parameters.AddWithValue("@isTemp", item.IsTemp);
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
                cmd.Parameters.AddWithValue("@bazaryabGuid", item.BazaryabGuid);
                cmd.Parameters.AddWithValue("@bazaryabPrice", item.BazaryabPrice);
                cmd.Parameters.AddWithValue("@fSideGuid", item.FirstSideGuid);
                cmd.Parameters.AddWithValue("@sSideGuid", item.SecondSideGuid);
                cmd.Parameters.AddWithValue("@sanadNumber", item.SanadNumber);
                cmd.Parameters.AddWithValue("@fBabat", item.fBabat);
                cmd.Parameters.AddWithValue("@sBabat", item.sBabat);
                cmd.Parameters.AddWithValue("@fDiscount", item.FirstDiscount);
                cmd.Parameters.AddWithValue("@sDiscount", item.SecondDiscount);
                cmd.Parameters.AddWithValue("@fTax", item.FirstTax);
                cmd.Parameters.AddWithValue("@sTax", item.SecondTax);
                cmd.Parameters.AddWithValue("@fAvarez", item.FirstAvarez);
                cmd.Parameters.AddWithValue("@sAvarez", item.SecondAvarez);
                cmd.Parameters.AddWithValue("@fTotalPrice", item.FirstTotalPrice);
                cmd.Parameters.AddWithValue("@sTotalPrice", item.SecondTotalPrice);
                cmd.Parameters.AddWithValue("@serverSt", (short)item.ServerStatus);
                cmd.Parameters.AddWithValue("@serverDate", item.ServerDeliveryDate);
                cmd.Parameters.AddWithValue("@codeInArchive", item.CodeInArchive);

                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public async Task<int> DbCount(string _connectionString, Guid userGuid)
        {
            var count = 0;
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Contract_Count", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@userGuid", userGuid);
                    await cn.OpenAsync();
                    count = (int)await cmd.ExecuteScalarAsync();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return count;
        }
        public async Task<ContractBussines> GetAsync(string _connectionString, Guid guid)
        {
            var list = new ContractBussines();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Contract_Get", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@guid", guid);
                    await cn.OpenAsync();
                    var dr = await cmd.ExecuteReaderAsync();
                    if (dr.Read()) list = LoadData(dr);
                    cn.Close();
                }
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }

            return list;
        }
        public async Task<int> DischargeDbCount(string _connectionString, DateTime d1, DateTime d2)
        {
            var count = 0;
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Building_Discharge_Count", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@date1", d1);
                    cmd.Parameters.AddWithValue("@date2", d2);
                    await cn.OpenAsync();
                    count = (int)await cmd.ExecuteScalarAsync();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return count;
        }
        public async Task<List<BuildingDischargeViewModel>> DischargeListAsync(string _connectionString, DateTime d1, DateTime d2)
        {
            var list = new List<BuildingDischargeViewModel>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Building_Discharge_List", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@d1", d1);
                    cmd.Parameters.AddWithValue("@d2", d2);

                    await cn.OpenAsync();
                    var dr = await cmd.ExecuteReaderAsync();
                    while (dr.Read()) list.Add(LoadDataViewModel(dr));
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public async Task<decimal> GetTotalBazaryab(string _connectionString, DateTime d1, DateTime d2)
        {
            var res = (decimal)0;
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Contract_GetTotalBazaryab", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@d1", d1);
                    cmd.Parameters.AddWithValue("@d2", d2);
                    await cn.OpenAsync();
                    var obj = await cmd.ExecuteScalarAsync();
                    if (obj != null)
                        res = obj.ToString().ParseToDecimal();
                    cn.Close();
                }
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }

            return res;
        }
        public async Task<ReturnedSaveFuncInfo> RemoveAsync(Guid guid, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_Contract_Remove", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
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
        public async Task<decimal> GetTotalCommitionAsync(string _connectionString, DateTime d1, DateTime d2)
        {
            var res = (decimal)0;
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Contract_GetTotalCommition", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@d1", d1);
                    cmd.Parameters.AddWithValue("@d2", d2);
                    await cn.OpenAsync();
                    var obj = await cmd.ExecuteScalarAsync();
                    if (obj != null)
                        res = obj.ToString().ParseToDecimal();
                    cn.Close();
                }
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }

            return res;
        }
        public async Task<decimal> GetTotalTaxAsync(string _connectionString, DateTime d1, DateTime d2)
        {
            var res = (decimal)0;
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Contract_GetTotalTax", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@d1", d1);
                    cmd.Parameters.AddWithValue("@d2", d2);
                    await cn.OpenAsync();
                    var obj = await cmd.ExecuteScalarAsync();
                    if (obj != null)
                        res = obj.ToString().ParseToDecimal();
                    cn.Close();
                }
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }

            return res;
        }
        private ContractBussines LoadData(SqlDataReader dr)
        {
            var res = new ContractBussines();
            try
            {
                res.Guid = (Guid)dr["Guid"];
                res.BankName = dr["BankName"].ToString();
                if (dr["BazaryabGuid"] != DBNull.Value) res.BazaryabGuid = (Guid)dr["BazaryabGuid"];
                res.Modified = (DateTime)dr["Modified"];
                res.Status = (bool)dr["Status"];
                res.Code = (long)dr["Code"];
                res.IsTemp = (bool)dr["IsTemp"];
                res.FirstSideGuid = (Guid)dr["FirstSideGuid"];
                res.SecondSideGuid = (Guid)dr["SecondSideGuid"];
                if (dr["Term"] != DBNull.Value) res.Term = (int)dr["Term"];
                if (dr["FromDate"] != DBNull.Value) res.FromDate = (DateTime)dr["FromDate"];
                res.TotalPrice = (decimal)dr["TotalPrice"];
                res.MinorPrice = (decimal)dr["MinorPrice"];
                res.CheckNo = dr["CheckNo"].ToString();
                res.Shobe = dr["Shobe"].ToString();
                res.SarResid = dr["SarResid"].ToString();
                res.DischargeDate = (DateTime)dr["DischargeDate"];
                if (dr["SetDocDate"] != DBNull.Value) res.SetDocDate = (DateTime?)dr["SetDocDate"];
                res.SetDocPlace = dr["SetDocPlace"].ToString();
                res.SarQofli = (decimal)dr["SarQofli"];
                res.Delay = (decimal)dr["Delay"];
                res.Description = dr["Description"].ToString();
                res.UserGuid = (Guid)dr["UserGuid"];
                res.BuildingGuid = (Guid)dr["BuildingGuid"];
                res.Type = (EnRequestType)dr["Type"];
                res.DateM = (DateTime)dr["DateM"];
                res.BazaryabPrice = (decimal)dr["BazaryabPrice"];
                res.SanadNumber = (long)dr["SanadNumber"];
                res.fBabat = (EnContractBabat)dr["fBabat"];
                res.sBabat = (EnContractBabat)dr["sBabat"];
                res.FirstDiscount = (decimal)dr["FirstDiscount"];
                res.SecondDiscount = (decimal)dr["SecondDiscount"];
                res.FirstTax = (decimal)dr["FirstTax"];
                res.SecondTax = (decimal)dr["SecondTax"];
                res.FirstAvarez = (decimal)dr["FirstAvarez"];
                res.SecondAvarez = (decimal)dr["SecondAvarez"];
                res.FirstTotalPrice = (decimal)dr["FirstTotalPrice"];
                res.SecondTotalPrice = (decimal)dr["SecondTotalPrice"];
                res.FirstSideName = dr["FirstSideName"].ToString();
                res.SecondSideName = dr["SecondSideName"].ToString();
                res.UserName = dr["UserName"].ToString();
                res.ServerDeliveryDate = (DateTime)dr["ServerDeliveryDate"];
                res.ServerStatus = (ServerStatus)dr["ServerStatus"];
                res.IsModified = true;
                res.CodeInArchive = dr["CodeInArchive"].ToString();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return res;
        }
        private BuildingDischargeViewModel LoadDataViewModel(SqlDataReader dr)
        {
            var res = new BuildingDischargeViewModel();
            try
            {
                res.Code = (long)dr["Code"];
                res.Term = (int)dr["Term"];
                res.FromDate = (DateTime)dr["FromDate"];
                res.FSideName = dr["FirstSideName"].ToString();
                res.FSideGuid = (Guid)dr["FirstSideGuid"];
                res.SSideGuid = (Guid)dr["SecondSideGuid"];
                res.SSideName = dr["SecondSideName"].ToString();
                res.ToDate = (DateTime)dr["ToDate"];
                res.BuildingCode = dr["BuildingCode"].ToString();
                res.BuildingGuid = (Guid) dr["BuildingGuid"];
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return res;
        }
    }
}
