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
using Persistence;

namespace EntityCache.SqlServerPersistence
{
    public class PardakhtPersistenceRepository : IPardakhtRepository
    {
        private PardakhtCheckShakhsiPersistenceRepository _checkSh = null;
        private PardakhtCheckMoshtariPersistenceRepository _checkM = null;
        private PardakhtNaqdPersistenceRepository _naghd = null;
        private PardakhtHavalePersistenceRepository _havale = null;
        private CheckPagePersistenceRepository _page = null;
        public PardakhtPersistenceRepository()
        {
            _checkM = new PardakhtCheckMoshtariPersistenceRepository();
            _checkSh = new PardakhtCheckShakhsiPersistenceRepository();
            _naghd = new PardakhtNaqdPersistenceRepository();
            _havale = new PardakhtHavalePersistenceRepository();
            _page = new CheckPagePersistenceRepository();
        }
        private async Task<PardakhtBussines> LoadDataAsync(SqlDataReader dr, string connectionString)
        {
            var item = new PardakhtBussines();

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
                item.CheckMoshtariList = await _checkM.GetAllAsync(connectionString, item.Guid);
                item.CheckShakhsiList = await _checkSh.GetAllAsync(connectionString, item.Guid);
                item.HavaleList = await _havale.GetAllAsync(connectionString, item.Guid);
                item.NaqdList = await _naghd.GetAllAsync(connectionString, item.Guid);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return item;
        }
        public async Task<List<PardakhtBussines>> GetAllAsync(string _connectionString, CancellationToken token)
        {
            var list = new List<PardakhtBussines>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Pardakht_GetAll", cn) { CommandType = CommandType.StoredProcedure };
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
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public async Task<PardakhtBussines> GetAsync(string _connectionString, Guid guid)
        {
            PardakhtBussines res = null;
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Pardakht_GetByGuid", cn) { CommandType = CommandType.StoredProcedure };
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
                    var cmd = new SqlCommand("sp_Tafsil_NextCode", cn) { CommandType = CommandType.StoredProcedure };

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
                    var cmd = new SqlCommand("sp_Pardakht_CheckCode", cn) { CommandType = CommandType.StoredProcedure };
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
        public async Task<ReturnedSaveFuncInfo> SaveAsync(PardakhtBussines item, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cn = Cache.ConnectionString;
                var oldPardakht = await GetAsync(cn, item.Guid);
                if (oldPardakht != null)
                {
                    var checkSh = await _checkSh.GetAllAsync(cn, item.Guid);
                    if (checkSh != null && checkSh.Count > 0)
                    {
                        foreach (var sh in checkSh)
                        {
                            var check = await _page.GetAsync(cn, sh.CheckPageGuid);
                            if (check == null) continue;
                            check.CheckStatus = EnCheckSh.Mojoud;
                            check.DatePardakht = null;
                            check.DateSarresid = null;
                            check.Description = "";
                            check.Modified = DateTime.Now;
                            check.Price = 0;
                            check.ReceptorGuid = null;
                            res.AddReturnedValue(await check.SaveAsync(tr));
                            if (res.HasError) return res;
                        }
                    }

                    var checkM = await _checkM.GetAllAsync(cn, item.Guid);
                    if (checkM != null && checkM.Count > 0)
                    {
                        foreach (var m in checkM)
                        {
                            var check = await ReceptionCheckBussines.GetAsync(m.CheckGuid);
                            if (check == null) continue;
                            check.CheckStatus = EnCheckM.Mojoud;
                            check.Modified = DateTime.Now;
                            if (check.isAvalDore) check.MasterGuid = null;
                            res.AddReturnedValue(await check.SaveAsync(tr));
                            if (res.HasError) return res;
                        }
                    }
                }

                res.AddReturnedValue(await SaveAsync_(item, tr));
                if (res.HasError) return res;

                res.AddReturnedValue(await _naghd.RemoveRangeAsync(item.Guid, tr));
                if (res.HasError) return res;
                res.AddReturnedValue(await _havale.RemoveRangeAsync(item.Guid, tr));
                if (res.HasError) return res;
                res.AddReturnedValue(await _checkSh.RemoveRangeAsync(item.Guid, tr));
                if (res.HasError) return res;
                res.AddReturnedValue(await _checkM.RemoveRangeAsync(item.Guid, tr));
                if (res.HasError) return res;

                if (item.NaqdList != null && item.NaqdList.Count > 0)
                {
                    res.AddReturnedValue(await _naghd.SaveRangeAsync(item.NaqdList, tr));
                    if (res.HasError) return res;
                }
                if (item.NaqdList != null && item.NaqdList.Count > 0)
                {
                    res.AddReturnedValue(await _havale.SaveRangeAsync(item.HavaleList, tr));
                    if (res.HasError) return res;
                }
                if (item.NaqdList != null && item.NaqdList.Count > 0)
                {
                    res.AddReturnedValue(await _checkSh.SaveRangeAsync(item.CheckShakhsiList, tr));
                    if (res.HasError) return res;
                }
                if (item.CheckShakhsiList?.Count > 0)
                {
                    foreach (var m in item.CheckShakhsiList)
                    {
                        var checkPage = await CheckPageBussines.GetAsync(m.CheckPageGuid);
                        checkPage.CheckStatus = EnCheckSh.KharjShode;
                        checkPage.DatePardakht = DateTime.Now;
                        checkPage.DateSarresid = m.DateSarResid;
                        checkPage.Description = m.Description;
                        checkPage.Modified = DateTime.Now;
                        checkPage.Price = m.Price;
                        checkPage.ReceptorGuid = item.TafsilGuid;
                        res.AddReturnedValue(await checkPage.SaveAsync(tr));
                        if (res.HasError) return res;
                    }

                    res.AddReturnedValue(await _checkM.SaveRangeAsync(item.CheckMoshtariList, tr));
                    if (res.HasError) return res;
                }
                if (item.CheckMoshtariList?.Count > 0)
                {
                    foreach (var sh in item.CheckMoshtariList)
                    {
                        var rec = await ReceptionCheckBussines.GetAsync(sh.CheckGuid);
                        rec.CheckStatus = EnCheckM.Kharj;
                        rec.Modified = DateTime.Now;
                        res.AddReturnedValue(await rec.SaveAsync(tr));
                        if (res.HasError) return res;
                    }
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private async Task<ReturnedSaveFuncInfo> SaveAsync_(PardakhtBussines item, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_Pardakht_Save", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@guid", item.Guid);
                cmd.Parameters.AddWithValue("@modif", item.Modified);
                cmd.Parameters.AddWithValue("@dateM", item.DateM);
                cmd.Parameters.AddWithValue("@desc", item.Description ?? "");
                cmd.Parameters.AddWithValue("@number", item.Number);
                cmd.Parameters.AddWithValue("@tafsilGuid", item.TafsilGuid);
                cmd.Parameters.AddWithValue("@userGuid", item.UserGuid);
                cmd.Parameters.AddWithValue("@moeinGuid", ParentDefaults.MoeinCoding.CLSMoein10304);
                cmd.Parameters.AddWithValue("@sanadNumber", item.SanadNumber);
                cmd.Parameters.AddWithValue("@sumCheckM", item.SumCheckMoshtari);
                cmd.Parameters.AddWithValue("@sumCheckSh", item.SumCheckShakhsi);
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
                var cn = Cache.ConnectionString;
                var oldPardakht = await GetAsync(cn, guid);
                if (oldPardakht != null)
                {
                    var checkSh = await _checkSh.GetAllAsync(cn, guid);
                    if (checkSh != null && checkSh.Count > 0)
                    {
                        foreach (var item in checkSh)
                        {
                            var check = await CheckPageBussines.GetAsync(item.CheckPageGuid);
                            if (check == null) continue;
                            check.CheckStatus = EnCheckSh.Mojoud;
                            check.DatePardakht = null;
                            check.DateSarresid = null;
                            check.Description = "";
                            check.Modified = DateTime.Now;
                            check.Price = 0;
                            check.ReceptorGuid = null;
                            res.AddReturnedValue(await check.SaveAsync(tr));
                            if (res.HasError) return res;
                        }
                    }

                    var checkM = await _checkM.GetAllAsync(cn, guid);
                    if (checkM != null && checkM.Count > 0)
                    {
                        foreach (var item in checkM)
                        {
                            var check = await ReceptionCheckBussines.GetAsync(item.CheckGuid);
                            if (check == null) continue;
                            check.CheckStatus = EnCheckM.Mojoud;
                            check.Modified = DateTime.Now;
                            if (check.isAvalDore) check.MasterGuid = null;
                            res.AddReturnedValue(await check.SaveAsync(tr));
                            if (res.HasError) return res;
                        }
                    }
                }

                res.AddReturnedValue(await _naghd.RemoveRangeAsync(guid, tr));
                if (res.HasError) return res;

                res.AddReturnedValue(await _havale.RemoveRangeAsync(guid, tr));
                if (res.HasError) return res;

                res.AddReturnedValue(await _checkM.RemoveRangeAsync(guid, tr));
                if (res.HasError) return res;

                res.AddReturnedValue(await _checkSh.RemoveRangeAsync(guid, tr));
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
                var cmd = new SqlCommand("sp_Pardakht_Remove", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
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
