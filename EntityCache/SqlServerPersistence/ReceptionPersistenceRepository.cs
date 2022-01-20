using EntityCache.Bussines;
using EntityCache.Core;
using Services;
using Services.DefaultCoding;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace EntityCache.SqlServerPersistence
{
    public class ReceptionPersistenceRepository : IReceptionRepository
    {
        private ReceptionNaqdPersistenceRepository _naghd = null;
        private ReceptionHavalePersistenceRepository _havale = null;
        private ReceptionCheckPersistenceRepository _check = null;

        public ReceptionPersistenceRepository()
        {
            _naghd = new ReceptionNaqdPersistenceRepository();
            _havale = new ReceptionHavalePersistenceRepository();
            _check = new ReceptionCheckPersistenceRepository();
        }
        private async Task<ReceptionBussines> LoadDataAsync(SqlDataReader dr, string connectionString)
        {
            var item = new ReceptionBussines();

            try
            {
                item.Guid = (Guid)dr["Guid"];
                item.Modified = (DateTime)dr["Modified"];
                item.DateM = (DateTime)dr["DateM"];
                item.Description = dr["Description"].ToString();
                item.Number = (long)dr["Number"];
                item.TafsilGuid = (Guid)dr["TafsilGuid"];
                item.MoeinGuid = (Guid)dr["MoeinGuid"];
                item.UserGuid = (Guid)dr["UserGuid"];
                item.SanadNumber = (long)dr["SanadNumber"];
                item.TafsilName = dr["TafsilName"].ToString();
                item.UserName = dr["UserName"].ToString();
                item.IsModified = true;
                item.CheckList = await _check.GetAllAsync(connectionString, item.Guid);
                item.HavaleList = await _havale.GetAllAsync(connectionString, item.Guid);
                item.NaqdList = await _naghd.GetAllAsync(connectionString, item.Guid);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return item;
        }
        public async Task<List<ReceptionBussines>> GetAllAsync(string _connectionString, CancellationToken token)
        {
            var list = new List<ReceptionBussines>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Reception_GetAll", cn) { CommandType = CommandType.StoredProcedure };
                    if (token.IsCancellationRequested) return null;
                    await cn.OpenAsync();
                    var dr = await cmd.ExecuteReaderAsync();
                    while (dr.Read())
                    {
                        if (token.IsCancellationRequested) return null;
                        list.Add(await LoadDataAsync(dr, _connectionString));
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
        public async Task<ReceptionBussines> GetAsync(string _connectionString, Guid guid)
        {
            ReceptionBussines res = null;
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Reception_GetByGuid", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@guid", guid);

                    await cn.OpenAsync();
                    var dr = await cmd.ExecuteReaderAsync();
                    if (dr.Read()) res = await LoadDataAsync(dr, _connectionString);
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return res;
        }
        public async Task<long> NextNumberAsync(string _connectionString)
        {
            long res = 0;
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Reception_NextCode", cn) { CommandType = CommandType.StoredProcedure };

                    await cn.OpenAsync();
                    var obj = await cmd.ExecuteScalarAsync();
                    if (obj != null) res = obj.ToString().ParseToLong();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return res;
        }
        public async Task<bool> CheckCodeAsync(string _connectionString, Guid guid, long code)
        {
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Reception_CheckCode", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@guid", guid);
                    cmd.Parameters.AddWithValue("@code", code);

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
        public async Task<ReturnedSaveFuncInfo> SaveAsync(ReceptionBussines item, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                res.AddReturnedValue(await SaveAsync_(item, tr));

                res.AddReturnedValue(await _naghd.RemoveRangeAsync(item.Guid, tr));
                if (res.HasError) return res;
                res.AddReturnedValue(await _check.RemoveRangeAsync(item.Guid, tr));
                if (res.HasError) return res;
                res.AddReturnedValue(await _havale.RemoveRangeAsync(item.Guid, tr));
                if (res.HasError) return res;

                if (item.NaqdList != null && item.NaqdList.Count > 0)
                {
                    res.AddReturnedValue(await _naghd.SaveRangeAsync(item.NaqdList, tr));
                    if (res.HasError) return res;
                }
                if (item.HavaleList != null && item.HavaleList.Count > 0)
                {
                    res.AddReturnedValue(await _havale.SaveRangeAsync(item.HavaleList, tr));
                    if (res.HasError) return res;
                }
                if (item.CheckList != null && item.CheckList.Count > 0)
                {
                    res.AddReturnedValue(await _check.SaveRangeAsync(item.CheckList, tr));
                    if (res.HasError) return res;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private async Task<ReturnedSaveFuncInfo> SaveAsync_(ReceptionBussines item, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_Reception_Save", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@guid", item.Guid);
                cmd.Parameters.AddWithValue("@modif", item.Modified);
                cmd.Parameters.AddWithValue("@dateM", item.DateM);
                cmd.Parameters.AddWithValue("@desc", item.Description ?? "");
                cmd.Parameters.AddWithValue("@number", item.Number);
                cmd.Parameters.AddWithValue("@tafsilGuid", item.TafsilGuid);
                cmd.Parameters.AddWithValue("@userGuid", item.UserGuid);
                cmd.Parameters.AddWithValue("@moeinGuid", ParentDefaults.MoeinCoding.CLSMoein10304);
                cmd.Parameters.AddWithValue("@sanadNumber", item.SanadNumber);
                cmd.Parameters.AddWithValue("@sumCheck", item.SumCheck);
                cmd.Parameters.AddWithValue("@sumHavale", item.SumHavale);
                cmd.Parameters.AddWithValue("@sumNaqd", item.SumNaqd);
                cmd.Parameters.AddWithValue("@sum", item.Sum);

                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public async Task<ReturnedSaveFuncInfo> RemoveAsync(Guid guid, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                res.AddReturnedValue(await _naghd.RemoveRangeAsync(guid, tr));
                if (res.HasError) return res;

                res.AddReturnedValue(await _havale.RemoveRangeAsync(guid, tr));
                if (res.HasError) return res;

                res.AddReturnedValue(await _check.RemoveRangeAsync(guid, tr));
                if (res.HasError) return res;
                res.AddReturnedValue(await RemoveAsync_(guid, tr));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private async Task<ReturnedSaveFuncInfo> RemoveAsync_(Guid guid, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_Reception_Remove", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
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
    }
}
