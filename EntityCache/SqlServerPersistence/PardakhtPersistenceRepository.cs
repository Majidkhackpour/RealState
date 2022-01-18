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
    public class PardakhtPersistenceRepository : IPardakhtRepository
    {
        private async Task<PardakhtBussines> LoadDataAsync(SqlDataReader dr)
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
                item.CheckMoshtariList = await PardakhtCheckMoshtariBussines.GetAllAsync(item.Guid);
                item.CheckShakhsiList = await PardakhtCheckShakhsiBussines.GetAllAsync(item.Guid);
                item.HavaleList = await PardakhtHavaleBussines.GetAllAsync(item.Guid);
                item.NaqdList = await PardakhtNaqdBussines.GetAllAsync(item.Guid);
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
                        list.Add(await LoadDataAsync(dr));
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
                    if (dr.Read()) res = await LoadDataAsync(dr);
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
