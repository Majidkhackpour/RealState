using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Bussines;
using EntityCache.Core;
using EntityCache.ViewModels;
using Persistence.Entities;
using Persistence.Model;
using Services;
using Services.DefaultCoding;

namespace EntityCache.SqlServerPersistence
{
    public class PardakhtCheckShakhsiPersistenceRepository : IPardakhtCheckShakhsiRepository
    {
        private PardakhtCheckShakhsiBussines LoadData(SqlDataReader dr)
        {
            var item = new PardakhtCheckShakhsiBussines();

            try
            {
                item.Guid = (Guid)dr["Guid"];
                item.Modified = (DateTime)dr["Modified"];
                item.MasterGuid = (Guid)dr["MasterGuid"];
                item.Description = dr["Description"].ToString();
                item.Price = (decimal)dr["Price"];
                item.Number = dr["Number"].ToString();
                item.DateSarResid = (DateTime)dr["DateSarResid"];
                item.DateM = (DateTime)dr["DateM"];
                item.CheckPageGuid = (Guid)dr["CheckPageGuid"];
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return item;
        }
        private PardakhtCheckViewModel LoadDataViewModel(SqlDataReader dr)
        {
            var item = new PardakhtCheckViewModel();

            try
            {
                item.Guid = (Guid)dr["Guid"];
                item.BankName = dr["BankName"].ToString();
                item.BankGuid = (Guid)dr["BankGuid"];
                item.DateM = (DateTime)dr["DateM"];
                item.Description = dr["Description"].ToString();
                item.CheckNumber = dr["Number"].ToString();
                item.Price = (decimal)dr["Price"];
                item.CheckStatus = (EnCheckSh)dr["CheckStatus"];
                item.DateSarResid = (DateTime)dr["DateSarResid"];
                item.Girande = dr["Girande"].ToString();
                item.IsAvalDore = (bool)dr["AvalDore"];
                item.GirandeGuid = (Guid)dr["GirandeGuid"];
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return item;
        }
        public async Task<List<PardakhtCheckShakhsiBussines>> GetAllAsync(string _connectionString, Guid masterGuid)
        {
            var list = new List<PardakhtCheckShakhsiBussines>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_PardakhtCheckSh_GetAllByMaster", cn)
                    { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@masterGuid", masterGuid);

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
        public async Task<List<PardakhtCheckViewModel>> GetAllViewModelAsync(string _connectionString)
        {
            var list = new List<PardakhtCheckViewModel>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_PardakhtCheckShakhsi_GetAllFromView", cn)
                    { CommandType = CommandType.StoredProcedure };

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
        public async Task<ReturnedSaveFuncInfo> RemoveRangeAsync(Guid masterGuid, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_PardakhtChackSh_RemoveByMaster", tr.Connection, tr)
                { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@masterGuid", masterGuid);

                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public async Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<PardakhtCheckShakhsiBussines> items, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (items == null || !items.Any()) return res;
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
        public async Task<ReturnedSaveFuncInfo> SaveAsync(PardakhtCheckShakhsiBussines item, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_PardakhtCheckSh_Insert", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@guid", item.Guid);
                cmd.Parameters.AddWithValue("@modif", item.Modified);
                cmd.Parameters.AddWithValue("@desc", item.Description ?? "");
                cmd.Parameters.AddWithValue("@masterGuid", item.MasterGuid);
                cmd.Parameters.AddWithValue("@checkGuid", item.CheckPageGuid);
                cmd.Parameters.AddWithValue("@sarresid", item.DateSarResid);
                cmd.Parameters.AddWithValue("@price", item.Price);
                cmd.Parameters.AddWithValue("@dateM", item.DateM);
                cmd.Parameters.AddWithValue("@number", item.Number);

                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public async Task<PardakhtCheckShakhsiBussines> GetAsync(string _connectionString, Guid guid)
        {
            PardakhtCheckShakhsiBussines item = null;
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_PardakhtCheckShakhsi_Get", cn)
                    { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@Guid", guid);

                    await cn.OpenAsync();
                    var dr = await cmd.ExecuteReaderAsync();
                    if (dr.Read()) item = LoadData(dr);
                    cn.Close();
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
