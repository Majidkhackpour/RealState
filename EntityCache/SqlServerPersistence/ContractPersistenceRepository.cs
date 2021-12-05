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
                cmd.Parameters.AddWithValue("@RealStateCode", item.RealStateCode);
                cmd.Parameters.AddWithValue("@HologramCode", item.HologramCode);
                cmd.Parameters.AddWithValue("@CheckNoTo", item.CheckNoTo);
                cmd.Parameters.AddWithValue("@BankNameEjare", item.BankNameEjare);
                cmd.Parameters.AddWithValue("@ShobeEjare", item.ShobeEjare);
                cmd.Parameters.AddWithValue("@SarResidTo", item.SarResidTo);
                cmd.Parameters.AddWithValue("@SetDocNo", item.SetDocNo);
                cmd.Parameters.AddWithValue("@FirstSideDelay", item.FirstSideDelay);
                cmd.Parameters.AddWithValue("@SecondSideDelay", item.SecondSideDelay);
                cmd.Parameters.AddWithValue("@BuildingPlack", item.BuildingPlack);
                cmd.Parameters.AddWithValue("@BuildingZip", item.BuildingZip);
                cmd.Parameters.AddWithValue("@SanadSerial", item.SanadSerial);
                cmd.Parameters.AddWithValue("@PartNo", item.PartNo);
                cmd.Parameters.AddWithValue("@Page", item.Page);
                cmd.Parameters.AddWithValue("@Office", item.Office);
                cmd.Parameters.AddWithValue("@BuildingNumber", item.BuildingNumber);
                cmd.Parameters.AddWithValue("@ParkingNo", item.ParkingNo);
                cmd.Parameters.AddWithValue("@ParkingMasahat", item.ParkingMasahat);
                cmd.Parameters.AddWithValue("@StoreNo", item.StoreNo);
                cmd.Parameters.AddWithValue("@StoreMasahat", item.StoreMasahat);
                cmd.Parameters.AddWithValue("@PhoneLineCount", item.PhoneLineCount);
                cmd.Parameters.AddWithValue("@BuildingPhoneNumber", item.BuildingPhoneNumber);
                cmd.Parameters.AddWithValue("@PeopleCount", item.PeopleCount);
                cmd.Parameters.AddWithValue("@PayankarNo", item.PayankarNo);
                cmd.Parameters.AddWithValue("@PayankarDate", item.PayankarDate);
                cmd.Parameters.AddWithValue("@PishPrice", item.PishPrice);
                cmd.Parameters.AddWithValue("@Witness1", item.Witness1);
                cmd.Parameters.AddWithValue("@Witness2", item.Witness2);
                cmd.Parameters.AddWithValue("@BuildingRegistrationNo", item.BuildingRegistrationNo);
                cmd.Parameters.AddWithValue("@BuildingRegistrationNoSub", item.BuildingRegistrationNoSub);
                cmd.Parameters.AddWithValue("@BuildingRegistrationNoOrigin", item.BuildingRegistrationNoOrigin);
                cmd.Parameters.AddWithValue("@BuildingCosumable", item.BuildingCosumable);
                cmd.Parameters.AddWithValue("@ManufacturingLicensePlace", item.ManufacturingLicensePlace);
                cmd.Parameters.AddWithValue("@ManufacturingLicenseDate", item.ManufacturingLicenseDate);
                cmd.Parameters.AddWithValue("@SettlementDate", item.SettlementDate);
                cmd.Parameters.AddWithValue("@AmountOfRent", item.AmountOfRent);
                cmd.Parameters.AddWithValue("@GulidType", item.GulidType);
                cmd.Parameters.AddWithValue("@DocumentAdjust", item.DocumentAdjust);
                cmd.Parameters.AddWithValue("@checkPrice1", item.CheckPrice1);
                cmd.Parameters.AddWithValue("@checkPrice2", item.CheckPrice2);

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
                if (dr["Guid"] != DBNull.Value) res.Guid = (Guid)dr["Guid"];
                if (dr["BankName"] != DBNull.Value) res.BankName = dr["BankName"].ToString();
                if (dr["BazaryabGuid"] != DBNull.Value) res.BazaryabGuid = (Guid)dr["BazaryabGuid"];
                if (dr["Modified"] != DBNull.Value) res.Modified = (DateTime)dr["Modified"];
                if (dr["Status"] != DBNull.Value) res.Status = (bool)dr["Status"];
                if (dr["Code"] != DBNull.Value) res.Code = (long)dr["Code"];
                if (dr["IsTemp"] != DBNull.Value) res.IsTemp = (bool)dr["IsTemp"];
                if (dr["FirstSideGuid"] != DBNull.Value) res.FirstSideGuid = (Guid)dr["FirstSideGuid"];
                if (dr["SecondSideGuid"] != DBNull.Value) res.SecondSideGuid = (Guid)dr["SecondSideGuid"];
                if (dr["Term"] != DBNull.Value) res.Term = (int)dr["Term"];
                if (dr["FromDate"] != DBNull.Value) res.FromDate = (DateTime)dr["FromDate"];
                if (dr["TotalPrice"] != DBNull.Value) res.TotalPrice = (decimal)dr["TotalPrice"];
                if (dr["MinorPrice"] != DBNull.Value) res.MinorPrice = (decimal)dr["MinorPrice"];
                if (dr["CheckNo"] != DBNull.Value) res.CheckNo = dr["CheckNo"].ToString();
                if (dr["Shobe"] != DBNull.Value) res.Shobe = dr["Shobe"].ToString();
                if (dr["SarResid"] != DBNull.Value) res.SarResid = (DateTime)dr["SarResid"];
                if (dr["DischargeDate"] != DBNull.Value) res.DischargeDate = (DateTime)dr["DischargeDate"];
                if (dr["SetDocDate"] != DBNull.Value) res.SetDocDate = (DateTime?)dr["SetDocDate"];
                if (dr["SetDocPlace"] != DBNull.Value) res.SetDocPlace = dr["SetDocPlace"].ToString();
                if (dr["SarQofli"] != DBNull.Value) res.SarQofli = (decimal)dr["SarQofli"];
                if (dr["Description"] != DBNull.Value) res.Description = dr["Description"].ToString();
                if (dr["UserGuid"] != DBNull.Value) res.UserGuid = (Guid)dr["UserGuid"];
                if (dr["BuildingGuid"] != DBNull.Value) res.BuildingGuid = (Guid)dr["BuildingGuid"];
                if (dr["Type"] != DBNull.Value) res.Type = (EnRequestType)dr["Type"];
                if (dr["DateM"] != DBNull.Value) res.DateM = (DateTime)dr["DateM"];
                if (dr["BazaryabPrice"] != DBNull.Value) res.BazaryabPrice = (decimal)dr["BazaryabPrice"];
                if (dr["SanadNumber"] != DBNull.Value) res.SanadNumber = (long)dr["SanadNumber"];
                if (dr["fBabat"] != DBNull.Value) res.fBabat = (EnContractBabat)dr["fBabat"];
                if (dr["sBabat"] != DBNull.Value) res.sBabat = (EnContractBabat)dr["sBabat"];
                if (dr["FirstDiscount"] != DBNull.Value) res.FirstDiscount = (decimal)dr["FirstDiscount"];
                if (dr["SecondDiscount"] != DBNull.Value) res.SecondDiscount = (decimal)dr["SecondDiscount"];
                if (dr["FirstTax"] != DBNull.Value) res.FirstTax = (decimal)dr["FirstTax"];
                if (dr["SecondTax"] != DBNull.Value) res.SecondTax = (decimal)dr["SecondTax"];
                if (dr["FirstAvarez"] != DBNull.Value) res.FirstAvarez = (decimal)dr["FirstAvarez"];
                if (dr["SecondAvarez"] != DBNull.Value) res.SecondAvarez = (decimal)dr["SecondAvarez"];
                if (dr["FirstTotalPrice"] != DBNull.Value) res.FirstTotalPrice = (decimal)dr["FirstTotalPrice"];
                if (dr["SecondTotalPrice"] != DBNull.Value) res.SecondTotalPrice = (decimal)dr["SecondTotalPrice"];
                if (dr["FirstSideName"] != DBNull.Value) res.FirstSideName = dr["FirstSideName"].ToString();
                if (dr["SecondSideName"] != DBNull.Value) res.SecondSideName = dr["SecondSideName"].ToString();
                if (dr["UserName"] != DBNull.Value) res.UserName = dr["UserName"].ToString();
                if (dr["ServerDeliveryDate"] != DBNull.Value) res.ServerDeliveryDate = (DateTime)dr["ServerDeliveryDate"];
                if (dr["ServerStatus"] != DBNull.Value) res.ServerStatus = (ServerStatus)dr["ServerStatus"];
                res.IsModified = true;
                if (dr["CodeInArchive"] != DBNull.Value) res.CodeInArchive = dr["CodeInArchive"].ToString();
                if (dr["RealStateCode"] != DBNull.Value) res.RealStateCode = dr["RealStateCode"].ToString();
                if (dr["HologramCode"] != DBNull.Value) res.HologramCode = dr["HologramCode"].ToString();
                if (dr["CheckNoTo"] != DBNull.Value) res.CheckNoTo = dr["CheckNoTo"].ToString();
                if (dr["BankNameEjare"] != DBNull.Value) res.BankNameEjare = dr["BankNameEjare"].ToString();
                if (dr["ShobeEjare"] != DBNull.Value) res.ShobeEjare = dr["ShobeEjare"].ToString();
                if (dr["SarResidTo"] != DBNull.Value) res.SarResidTo = (DateTime)dr["SarResidTo"];
                if (dr["SetDocNo"] != DBNull.Value) res.SetDocNo = (int)dr["SetDocNo"];
                if (dr["FirstSideDelay"] != DBNull.Value) res.FirstSideDelay = (decimal)dr["FirstSideDelay"];
                if (dr["SecondSideDelay"] != DBNull.Value) res.SecondSideDelay = (decimal)dr["SecondSideDelay"];
                if (dr["BuildingPlack"] != DBNull.Value) res.BuildingPlack = dr["BuildingPlack"].ToString();
                if (dr["BuildingZip"] != DBNull.Value) res.BuildingZip = dr["BuildingZip"].ToString();
                if (dr["SanadSerial"] != DBNull.Value) res.SanadSerial = dr["SanadSerial"].ToString();
                if (dr["PartNo"] != DBNull.Value) res.PartNo = (int)dr["PartNo"];
                if (dr["Page"] != DBNull.Value) res.Page = (int)dr["Page"];
                if (dr["Office"] != DBNull.Value) res.Office = dr["Office"].ToString();
                if (dr["BuildingNumber"] != DBNull.Value) res.BuildingNumber = dr["BuildingNumber"].ToString();
                if (dr["ParkingNo"] != DBNull.Value) res.ParkingNo = (int)dr["ParkingNo"];
                if (dr["ParkingMasahat"] != DBNull.Value) res.ParkingMasahat = (float)dr["ParkingMasahat"];
                if (dr["StoreNo"] != DBNull.Value) res.StoreNo = (int)dr["StoreNo"];
                if (dr["StoreMasahat"] != DBNull.Value) res.StoreMasahat = (float)dr["StoreMasahat"];
                if (dr["PhoneLineCount"] != DBNull.Value) res.PhoneLineCount = (int)dr["PhoneLineCount"];
                if (dr["BuildingPhoneNumber"] != DBNull.Value) res.BuildingPhoneNumber = dr["BuildingPhoneNumber"].ToString();
                if (dr["PeopleCount"] != DBNull.Value) res.PeopleCount = (int)dr["PeopleCount"];
                if (dr["PayankarNo"] != DBNull.Value) res.PayankarNo = dr["PayankarNo"].ToString();
                if (dr["PayankarDate"] != DBNull.Value) res.PayankarDate = (DateTime)dr["PayankarDate"];
                if (dr["PishPrice"] != DBNull.Value) res.PishPrice = (decimal)dr["PishPrice"];
                if (dr["Witness1"] != DBNull.Value) res.Witness1 = dr["Witness1"].ToString();
                if (dr["Witness2"] != DBNull.Value) res.Witness2 = dr["Witness2"].ToString();
                if (dr["BuildingRegistrationNo"] != DBNull.Value) res.BuildingRegistrationNo = dr["BuildingRegistrationNo"].ToString();
                if (dr["BuildingRegistrationNoSub"] != DBNull.Value) res.BuildingRegistrationNoSub = dr["BuildingRegistrationNoSub"].ToString();
                if (dr["BuildingRegistrationNoOrigin"] != DBNull.Value) res.BuildingRegistrationNoOrigin = dr["BuildingRegistrationNoOrigin"].ToString();
                if (dr["BuildingCosumable"] != DBNull.Value) res.BuildingCosumable = dr["BuildingCosumable"].ToString();
                if (dr["ManufacturingLicensePlace"] != DBNull.Value) res.ManufacturingLicensePlace = dr["ManufacturingLicensePlace"].ToString();
                if (dr["ManufacturingLicenseDate"] != DBNull.Value) res.ManufacturingLicenseDate = (DateTime)dr["ManufacturingLicenseDate"];
                if (dr["SettlementDate"] != DBNull.Value) res.SettlementDate = (DateTime)dr["SettlementDate"];
                if (dr["AmountOfRent"] != DBNull.Value) res.AmountOfRent = (decimal)dr["AmountOfRent"];
                if (dr["GulidType"] != DBNull.Value) res.GulidType = dr["GulidType"].ToString();
                if (dr["DocumentAdjust"] != DBNull.Value) res.DocumentAdjust = dr["DocumentAdjust"].ToString();
                if (dr["CheckPrice1"] != DBNull.Value) res.CheckPrice1 = (decimal)dr["CheckPrice1"];
                if (dr["CheckPrice2"] != DBNull.Value) res.CheckPrice2 = (decimal)dr["CheckPrice2"];
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
                res.BuildingGuid = (Guid)dr["BuildingGuid"];
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return res;
        }
    }
}
