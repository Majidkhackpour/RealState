using EntityCache.Bussines;
using EntityCache.Core;
using Nito.AsyncEx;
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
                        list.Add(LoadData(dr, false));
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
                        list.Add(LoadData(dr, false));
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
                    if (dr.Read()) res = LoadData(dr, true);
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
                    while (dr.Read()) list.Add(LoadData(dr, false));
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        private PeoplesBussines LoadData(SqlDataReader dr, bool isLoadDet)
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
                    item.BankList = AsyncContext.Run(() => PeoplesBankAccountBussines.GetAllAsync(item.Guid));
                    item.TellList = PhoneBookBussines.GetAll(item.Guid, true);
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
