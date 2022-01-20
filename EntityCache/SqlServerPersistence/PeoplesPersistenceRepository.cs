﻿using EntityCache.Bussines;
using EntityCache.Core;
using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace EntityCache.SqlServerPersistence
{
    public class PeoplesPersistenceRepository : IPeoplesRepository
    {
        private PeopleBankAccountPersistenceRepository _bank = null;
        private PhoneBookPersistenceRepository _tell = null;

        public PeoplesPersistenceRepository()
        {
            _bank = new PeopleBankAccountPersistenceRepository();
            _tell = new PhoneBookPersistenceRepository();
        }
        public async Task<List<PeoplesBussines>> GetAllAsync(string _connectionString, Guid parentGuid, bool status, CancellationToken token)
        {
            var list = new List<PeoplesBussines>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Peoples_SelectRowByGroupGuid", cn)
                    { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@GroupGuid", parentGuid);
                    cmd.Parameters.AddWithValue("@st", status);
                    if (token.IsCancellationRequested) return null;
                    await cn.OpenAsync();
                    var dr = await cmd.ExecuteReaderAsync();
                    while (dr.Read())
                    {
                        if (token.IsCancellationRequested) return null;
                        list.Add(await LoadDataAsync(dr, false, false, _connectionString));
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
        public async Task<List<PeoplesBussines>> GetAllAsync(string _connectionString, CancellationToken token)
        {
            var list = new List<PeoplesBussines>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Peoples_GetAll", cn) { CommandType = CommandType.StoredProcedure };
                    if (token.IsCancellationRequested) return null;
                    await cn.OpenAsync();
                    var dr = await cmd.ExecuteReaderAsync();
                    while (dr.Read())
                    {
                        if (token.IsCancellationRequested) return null;
                        list.Add(await LoadDataAsync(dr, false, false, _connectionString));
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
        public async Task<PeoplesBussines> GetAsync(string _connectionString, Guid guid)
        {
            PeoplesBussines res = null;
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Peoples_SelectRow", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@guid", guid);

                    await cn.OpenAsync();
                    var dr = await cmd.ExecuteReaderAsync();
                    if (dr.Read()) res = await LoadDataAsync(dr, true, false, _connectionString);
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return res;
        }
        public async Task<PeoplesBussines> GetByBuildingGuidAsync(string _connectionString, Guid guid, Guid buildingGuid)
        {
            PeoplesBussines res = null;
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Peoples_SelectRowByBuildingGuid", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@guid", guid);
                    cmd.Parameters.AddWithValue("@buGuid", buildingGuid);

                    await cn.OpenAsync();
                    var dr = await cmd.ExecuteReaderAsync();
                    if (dr.Read()) res = await LoadDataAsync(dr, true, true, _connectionString);
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return res;
        }
        public async Task<ReturnedSaveFuncInfo> SaveAsync(PeoplesBussines item, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                res.AddReturnedValue(await SaveTafsilAsync(item,tr));
                if (res.HasError) return res;

                if (item.TellList?.Count > 0)
                {
                    res.AddReturnedValue(await SaveMobileAsync(item, tr));
                    if (res.HasError) return res;
                }
                if (item.BankList?.Count > 0)
                {
                    res.AddReturnedValue(await SaveBankAccountAsync(item, tr));
                    if (res.HasError) return res;
                }

                res.AddReturnedValue(await SaveAsync_(item, tr));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private async Task<ReturnedSaveFuncInfo> SaveAsync_(PeoplesBussines item, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_Peoples_Save", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@guid", item.Guid);
                cmd.Parameters.AddWithValue("@modif", item.Modified);
                cmd.Parameters.AddWithValue("@st", item.Status);
                cmd.Parameters.AddWithValue("@name", item.Name);
                cmd.Parameters.AddWithValue("@code", item.Code);
                cmd.Parameters.AddWithValue("@nCode", item.NationalCode ?? "");
                cmd.Parameters.AddWithValue("@idCode", item.IdCode ?? "");
                cmd.Parameters.AddWithValue("@fName", item.FatherName ?? "");
                cmd.Parameters.AddWithValue("@pBirth", item.PlaceBirth ?? "");
                cmd.Parameters.AddWithValue("@dBirth", item.DateBirth ?? "");
                cmd.Parameters.AddWithValue("@address", item.Address ?? "");
                cmd.Parameters.AddWithValue("@issued", item.IssuedFrom ?? "");
                cmd.Parameters.AddWithValue("@postalCode", item.PostalCode ?? "");
                cmd.Parameters.AddWithValue("@groupGuid", item.GroupGuid);
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
        private async Task<ReturnedSaveFuncInfo> SaveBankAccountAsync(PeoplesBussines item, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                res.AddReturnedValue(await _bank.RemoveAsync(item.Guid, tr));
                if (res.HasError) return res;

                foreach (var b in item.BankList)
                {
                    b.ParentGuid = item.Guid;
                    res.AddReturnedValue(await BankSegestBussines.CheckBankAsync(b.BankName, tr));
                    if (res.HasError) return res;
                }
                res.AddReturnedValue(await _bank.SaveRangeAsync(item.BankList, tr));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private async Task<ReturnedSaveFuncInfo> SaveTafsilAsync(PeoplesBussines item, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var tf = await TafsilBussines.GetAsync(item.Guid) ?? new TafsilBussines
                {
                    Guid = item.Guid,
                    DateM = DateTime.Now,
                    Account = 0,
                    HesabType = HesabType.Customer,
                    Modified = item.Modified,
                    Status = true,
                    isSystem = false
                };

                tf.Code = item.Code;
                tf.Name = item.Name;
                tf.Description = "";
                tf.AccountFirst = item.AccountFirst;

                res.AddReturnedValue(await tf.SaveAsync(tr));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private async Task<ReturnedSaveFuncInfo> SaveMobileAsync(PeoplesBussines item, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                res.AddReturnedValue(await _tell.RemoveAsync(item.Guid, tr));
                if (res.HasError) return res;

                foreach (var t in item.TellList)
                {
                    t.ParentGuid = item.Guid;
                    t.Name = item.Name;
                }

                res.AddReturnedValue(await _tell.SaveRangeAsync(item.TellList, tr));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public async Task<ReturnedSaveFuncInfo> ChangeStatusAsync(PeoplesBussines item, bool status, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_Peoples_ChangeStatus", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
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
        public async Task<List<PeoplesBussines>> GetAllBirthDayAsync(string _connectionString, string dateSh)
        {
            var list = new List<PeoplesBussines>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Peoples_GetAllBirthDay", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@dateSh", $"%{dateSh}");

                    await cn.OpenAsync();
                    var dr = await cmd.ExecuteReaderAsync();
                    while (dr.Read()) list.Add(await LoadDataAsync(dr, false, false, _connectionString));
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public async Task<List<PeoplesBussines>> GetAllNotSentAsync(string connectionString)
        {
            var list = new List<PeoplesBussines>();
            try
            {
                using (var cn = new SqlConnection(connectionString))
                {
                    var cmd = new SqlCommand("sp_Peoples_GetAllNotSent", cn) { CommandType = CommandType.StoredProcedure };
                    await cn.OpenAsync();
                    var dr = await cmd.ExecuteReaderAsync();
                    while (dr.Read()) list.Add(await LoadDataBussinesAsync(dr, connectionString));
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
                    var cmd = new SqlCommand("sp_Peoples_SetSaveResult", cn)
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
                    var cmd = new SqlCommand("sp_Peoples_Reset", cn)
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
        private async Task<PeoplesBussines> LoadDataAsync(SqlDataReader dr, bool isLoadDet, bool isLoadRelatedNumber, string connectionString)
        {
            var item = new PeoplesBussines();
            try
            {
                item.Guid = (Guid)dr["Guid"];
                item.Modified = (DateTime)dr["Modified"];
                item.Status = (bool)dr["Status"];
                item.Name = dr["Name"].ToString();
                item.Code = dr["Code"].ToString();
                item.Account = (decimal)dr["Account"];
                item.AccountFirst = (decimal)dr["AccountFirst"];
                item.NationalCode = dr["NationalCode"].ToString();
                item.IdCode = dr["IdCode"].ToString();
                item.FatherName = dr["FatherName"].ToString();
                item.PlaceBirth = dr["PlaceBirth"].ToString();
                item.DateBirth = dr["DateBirth"].ToString();
                item.Address = dr["Address"].ToString();
                item.IssuedFrom = dr["IssuedFrom"].ToString();
                item.PostalCode = dr["PostalCode"].ToString();
                item.GroupGuid = (Guid)dr["GroupGuid"];
                item.ServerDeliveryDate = (DateTime)dr["ServerDeliveryDate"];
                item.ServerStatus = (ServerStatus)dr["ServerStatus"];
                item.IsModified = true;
                if (dr["GroupName"] != DBNull.Value) item.GroupName = dr["GroupName"].ToString();
                if (dr["CodeInArchive"] != DBNull.Value) item.CodeInArchive = dr["CodeInArchive"].ToString();
                if (isLoadDet)
                {
                    item.BankList = await _bank.GetAllAsync(connectionString, item.Guid);
                    item.TellList = await _tell.GetAllAsync(connectionString, item.Guid, true);
                }

                if (isLoadRelatedNumber)
                {
                    if (item.TellList != null && item.TellList.Count > 0) return item;
                    if (dr["Number"] != DBNull.Value && !string.IsNullOrEmpty(dr["Number"].ToString()))
                    {
                        if (item.TellList == null) item.TellList = new List<PhoneBookBussines>();
                        item.TellList.Add(new PhoneBookBussines()
                        {
                            Guid = Guid.NewGuid(),
                            Modified = DateTime.Now,
                            Name = item.Name,
                            Status = true,
                            Tell = dr["Number"].ToString(),
                            ParentGuid = item.Guid,
                            Title = "دریافت شده",
                            Group = EnPhoneBookGroup.Divar
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return item;
        }
        private async Task<PeoplesBussines> LoadDataBussinesAsync(SqlDataReader dr, string connectionString)
        {
            var item = new PeoplesBussines();
            try
            {
                item.Guid = (Guid)dr["Guid"];
                item.Modified = (DateTime)dr["Modified"];
                item.Status = (bool)dr["Status"];
                item.Name = dr["Name"].ToString();
                item.Code = dr["Code"].ToString();
                item.Account = (decimal)dr["Account"];
                item.AccountFirst = (decimal)dr["AccountFirst"];
                item.NationalCode = dr["NationalCode"].ToString();
                item.IdCode = dr["IdCode"].ToString();
                item.FatherName = dr["FatherName"].ToString();
                item.PlaceBirth = dr["PlaceBirth"].ToString();
                item.DateBirth = dr["DateBirth"].ToString();
                item.Address = dr["Address"].ToString();
                item.IssuedFrom = dr["IssuedFrom"].ToString();
                item.PostalCode = dr["PostalCode"].ToString();
                item.GroupGuid = (Guid)dr["GroupGuid"];
                item.ServerDeliveryDate = (DateTime)dr["ServerDeliveryDate"];
                item.ServerStatus = (ServerStatus)dr["ServerStatus"];
                item.TellList = await _tell.GetAllAsync(connectionString, item.Guid, true);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return item;
        }
    }
}
