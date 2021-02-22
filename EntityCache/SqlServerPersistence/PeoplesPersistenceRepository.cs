using EntityCache.Assistence;
using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;
using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Nito.AsyncEx;

namespace EntityCache.SqlServerPersistence
{
    public class PeoplesPersistenceRepository : GenericRepository<PeoplesBussines, Peoples>, IPeoplesRepository
    {
        ModelContext db;
        private string _connectionString;
        public PeoplesPersistenceRepository(ModelContext _db, string connectionString) : base(_db, connectionString)
        {
            db = _db;
            _connectionString = connectionString;
        }

        public async Task<List<PeoplesBussines>> GetAllAsync(Guid parentGuid, bool status)
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
        public override async Task<List<PeoplesBussines>> GetAllAsync()
        {
            var list = new List<PeoplesBussines>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Peoples_GetAll", cn) { CommandType = CommandType.StoredProcedure };

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
        public override async Task<PeoplesBussines> GetAsync(Guid guid)
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
        public override async Task<ReturnedSaveFuncInfo> SaveAsync(PeoplesBussines item, string tranName)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Peoples_Save", cn) { CommandType = CommandType.StoredProcedure };
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
        public override async Task<ReturnedSaveFuncInfo> ChangeStatusAsync(PeoplesBussines item, bool status, string tranName)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Peoples_ChangeStatus", cn) { CommandType = CommandType.StoredProcedure };
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
        public async Task<List<PeoplesBussines>> GetAllBirthDayAsync(string dateSh)
        {
            var list = new List<PeoplesBussines>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Peoples_GetAllBirthDay", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@dateSh", dateSh);

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
        private PeoplesBussines LoadData(SqlDataReader dr)
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
                item.BankList = AsyncContext.Run(() => PeoplesBankAccountBussines.GetAllAsync(item.Guid, true));
                item.TellList = PhoneBookBussines.GetAll(item.Guid, true);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return item;
        }
    }
}
