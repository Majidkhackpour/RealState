using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;
using Services;

namespace EntityCache.SqlServerPersistence
{
    public class KolPersistenceRepository : IKolRepository
    {
        public async Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<KolBussines> items, SqlTransaction tr)
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
        public async Task<ReturnedSaveFuncInfo> SaveAsync(KolBussines item, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_Kol_Save", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@guid", item.Guid);
                cmd.Parameters.AddWithValue("@modif", item.Modified);
                cmd.Parameters.AddWithValue("@name", item.Name ?? "");
                cmd.Parameters.AddWithValue("@code", item.Code ?? "");
                cmd.Parameters.AddWithValue("@account", item.Account);
                cmd.Parameters.AddWithValue("@hGroup", (short)item.HesabGroup);

                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public async Task<List<KolBussines>> GetAllAsync(string _connectionString, CancellationToken token)
        {
            var list = new List<KolBussines>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Kol_SelectAll", cn) { CommandType = CommandType.StoredProcedure };
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
        public async Task<KolBussines> GetAsync(string _connectionString, Guid guid)
        {
            KolBussines res = null;
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Kol_SelectRow", cn) { CommandType = CommandType.StoredProcedure };
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
        private static KolBussines LoadData(SqlDataReader dr)
        {
            var item = new KolBussines();
            try
            {
                item.Guid = (Guid)dr["Guid"];
                item.Modified = (DateTime)dr["Modified"];
                item.Name = dr["Name"].ToString();
                item.Code = dr["Code"].ToString();
                item.Account = (decimal)dr["Account"];
                item.HesabGroup = (EnHesabGroup)dr["HesabGroup"];
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return item;
        }
    }
}
