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
    public class MoeinPersistenceRepository : GenericRepository<MoeinBussines, Moein>, IMoeinRepository
    {
        private ModelContext db;
        private string _connectionString;
        public MoeinPersistenceRepository(ModelContext _db, string connectionString) : base(_db, connectionString)
        {
            db = _db;
            _connectionString = connectionString;
        }
        public override async Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<MoeinBussines> items, string tranName)
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
        public async Task<ReturnedSaveFuncInfo> UpdateAccountAsync(Guid guid, decimal price)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Moein_UpdateAccount", cn) { CommandType = CommandType.StoredProcedure };
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
        public override async Task<ReturnedSaveFuncInfo> SaveAsync(MoeinBussines item, string tranName)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Moein_Save", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@guid", item.Guid);
                    cmd.Parameters.AddWithValue("@modif", item.Modified);
                    cmd.Parameters.AddWithValue("@st", item.Status);
                    cmd.Parameters.AddWithValue("@name", item.Name ?? "");
                    cmd.Parameters.AddWithValue("@code", item.Code ?? "");
                    cmd.Parameters.AddWithValue("@account", item.Account);
                    cmd.Parameters.AddWithValue("@kolGuid", item.KolGuid);

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
        public override async Task<List<MoeinBussines>> GetAllAsync()
        {
            var list = new List<MoeinBussines>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Moein_SelectAll", cn) { CommandType = CommandType.StoredProcedure };

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
        public override async Task<MoeinBussines> GetAsync(Guid guid)
        {
            MoeinBussines res = null;
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Moein_SelectRow", cn) { CommandType = CommandType.StoredProcedure };
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
        private static MoeinBussines LoadData(SqlDataReader dr)
        {
            var item = new MoeinBussines();
            try
            {
                item.Guid = (Guid)dr["Guid"];
                item.Modified = (DateTime)dr["Modified"];
                item.Status = (bool)dr["Status"];
                item.Name = dr["Name"].ToString();
                item.Code = dr["Code"].ToString();
                item.Account = (decimal)dr["Account"];
                item.KolGuid = (Guid)dr["KolGuid"];
                item.DateM = (DateTime)dr["DateM"];
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return item;
        }
    }
}
