using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    public class SanadDetailPersistenceRepository : ISanadDetailRepository
    {
        private SanadDetailBussines LoadData(SqlDataReader dr)
        {
            var item = new SanadDetailBussines();
            try
            {
                item.Guid = (Guid)dr["Guid"];
                item.Modified = (DateTime)dr["Modified"];
                item.MoeinGuid = (Guid)dr["MoeinGuid"];
                item.MoeinCode = dr["MoeinCode"].ToString();
                item.MoeinName = dr["MoeinName"].ToString();
                item.TafsilGuid = (Guid)dr["TafsilGuid"];
                item.TafsilCode = dr["TafsilCode"].ToString();
                item.TafsilName = dr["TafsilName"].ToString();
                item.Description = dr["Description"].ToString();
                item.MasterGuid = (Guid)dr["MasterGuid"];
                item.Debit = (decimal)dr["Debit"];
                item.Credit = (decimal)dr["Credit"];
                item.ServerDeliveryDate = (DateTime)dr["ServerDeliveryDate"];
                item.ServerStatus = (ServerStatus)dr["ServerStatus"];
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return item;
        }
        private GardeshBussines LoadDataGardesh(SqlDataReader dr, bool isLoadNumber)
        {
            var item = new GardeshBussines();
            try
            {
                item.Guid = (Guid)dr["Guid"];
                item.MoeinGuid = (Guid)dr["MoeinGuid"];
                item.MoeinCode = dr["MoeinCode"].ToString();
                item.MoeinName = dr["MoeinName"].ToString();
                item.TafsilGuid = (Guid)dr["TafsilGuid"];
                item.TafsilCode = dr["TafsilCode"].ToString();
                item.TafsilName = dr["TafsilName"].ToString();
                item.Description = dr["Description"].ToString();
                item.Debit = (decimal)dr["Debit"];
                item.Credit = (decimal)dr["Credit"];
                item.DateM = (DateTime)dr["DateM"];
                if (isLoadNumber)
                    item.SanadNumber = (long)dr["SanadNumber"];
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return item;
        }
        private TarazAzmayeshiViewModel LoadDataTarazAzmayeshi(SqlDataReader dr)
        {
            var item = new TarazAzmayeshiViewModel();
            try
            {
                item.Guid = (Guid)dr["Guid"];
                item.Debit = (decimal)dr["Rem_Debit"];
                item.Credit = (decimal)dr["Rem_Credit"];
                item.Code = dr["Code"].ToString().ParseToLong();
                item.Name = dr["Name"].ToString();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return item;
        }
        private TarazHesabViewModel LoadDataTarazHesab(SqlDataReader dr)
        {
            var item = new TarazHesabViewModel();
            try
            {
                item.Debit = (decimal)dr["Debit"];
                item.Credit = (decimal)dr["Credit"];
                item.Code = dr["Code"].ToString().ParseToLong();
                item.KolGuid = (Guid)dr["KolGuid"];
                item.MoeinGuid = (Guid)dr["MoeinGuid"];
                item.TafsilGuid = (Guid)dr["TafsilGuid"];
                item.Account = (decimal)dr["Account"];
                item.SD_Debit = (decimal)dr["SD_Debit"];
                item.SD_Credit = (decimal)dr["SD_Credit"];
                item.DD_Debit = (decimal)dr["DD_Debit"];
                item.DD_Credit = (decimal)dr["DD_Credit"];
                item.ED_Debit = (decimal)dr["ED_Debit"];
                item.ED_Credit = (decimal)dr["ED_Credit"];
                item.RemPayan2ReCredit = (decimal)dr["RemPayan2reCredit"];
                item.RemPayan2ReDebit = (decimal)dr["RemPayan2reDebit"];
                item.TafsilName = dr["TafsilName"].ToString();
                item.MoeinName = dr["MoeinName"].ToString();
                item.TafsilCode = dr["TafsilCode"].ToString().ParseToLong();
                item.MoeinCode = dr["MoeinCode"].ToString().ParseToLong();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return item;
        }
        public async Task<List<SanadDetailBussines>> GetAllAsync(string _connectionString, Guid masterGuid)
        {
            var list = new List<SanadDetailBussines>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_SanadDetail_GetAllByMaster", cn)
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
        public async Task<ReturnedSaveFuncInfo> RemoveRangeAsync(Guid masterGuid, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_SanadDetail_RemoveByMasterGuid", tr.Connection, tr)
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
        public async Task<List<GardeshBussines>> GetAllGardeshAsync(string _connectionString, Guid tafsilGuid)
        {
            var list = new List<GardeshBussines>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Gardesh_GetAll", cn)
                    { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@tafsilGuid", tafsilGuid);

                    await cn.OpenAsync();
                    var dr = await cmd.ExecuteReaderAsync();
                    while (dr.Read()) list.Add(LoadDataGardesh(dr, false));
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public async Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<SanadDetailBussines> items, SqlTransaction tr)
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
        public async Task<ReturnedSaveFuncInfo> SaveAsync(SanadDetailBussines item, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_SanadDetail_Save", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@guid", item.Guid);
                cmd.Parameters.AddWithValue("@modif", item.Modified);
                cmd.Parameters.AddWithValue("@moeinGuid", item.MoeinGuid);
                cmd.Parameters.AddWithValue("@desc", item.Description ?? "");
                cmd.Parameters.AddWithValue("@tafsilGuid", item.TafsilGuid);
                cmd.Parameters.AddWithValue("@debit", item.Debit);
                cmd.Parameters.AddWithValue("@credit", item.Credit);
                cmd.Parameters.AddWithValue("@masterGuid", item.MasterGuid);
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
        public async Task<SanadDetailBussines> GetAsync(string _connectionString, Guid guid)
        {
            var list = new SanadDetailBussines();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_SanadDetail_Get", cn) { CommandType = CommandType.StoredProcedure };
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
        public async Task<List<GardeshBussines>> GetAllRooznameAsync(string _connectionString, DateTime d1, DateTime d2, CancellationToken token)
        {
            var list = new List<GardeshBussines>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Roozname", cn)
                    { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@d1", d1);
                    cmd.Parameters.AddWithValue("@d2", d2);
                    if (token.IsCancellationRequested) return null;
                    await cn.OpenAsync();
                    var dr = await cmd.ExecuteReaderAsync();
                    while (dr.Read())
                    {
                        if (token.IsCancellationRequested) return null;
                        list.Add(LoadDataGardesh(dr, true));
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
        public async Task<List<TarazAzmayeshiViewModel>> GetAllTarazAzmayeshiAsync(string _connectionString, CancellationToken token)
        {
            var list = new List<TarazAzmayeshiViewModel>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_TarazAzmayeshi", cn) { CommandType = CommandType.StoredProcedure };
                    if (token.IsCancellationRequested) return null;
                    await cn.OpenAsync();
                    var dr = await cmd.ExecuteReaderAsync();
                    while (dr.Read())
                    {
                        if (token.IsCancellationRequested) return null;
                        list.Add(LoadDataTarazAzmayeshi(dr));
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
        public async Task<List<TarazHesabViewModel>> GetAllTarazHesabAsync(string _connectionString, DateTime d1, DateTime d2, long code1, long code2, CancellationToken token)
        {
            var list = new List<TarazHesabViewModel>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_TarazHesab", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@Date1", d1);
                    cmd.Parameters.AddWithValue("@Date2", d2);
                    cmd.Parameters.AddWithValue("@Code1", code1);
                    cmd.Parameters.AddWithValue("@Code2", code2);
                    if (token.IsCancellationRequested) return null;
                    await cn.OpenAsync();
                    var dr = await cmd.ExecuteReaderAsync();
                    while (dr.Read())
                    {
                        if (token.IsCancellationRequested) return null;
                        list.Add(LoadDataTarazHesab(dr));
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
    }
}
