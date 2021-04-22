using EntityCache.Bussines;
using EntityCache.Core;
using Services;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace EntityCache.SqlServerPersistence
{
    public class AdvertiseLogPersistenceRepository : IAdvertiseLogRepository
    {
        public AdvertiseLogPersistenceRepository() { }
        private AdvertiseLogBussines LoadData(SqlDataReader dr)
        {
            var item = new AdvertiseLogBussines();
            try
            {
                item.Guid = (Guid)dr["Guid"];
                item.SimcardNumber = (long)dr["SimcardNumber"];
                item.DateM = (DateTime)dr["DateM"];
                item.Category = dr["Category"].ToString();
                item.SubCategory1 = dr["SubCategory1"].ToString();
                item.SubCategory2 = dr["SubCategory2"].ToString();
                item.City = dr["City"].ToString();
                item.Region = dr["Region"].ToString();
                item.Price1 = (decimal)dr["Price1"];
                item.Price2 = (decimal)dr["Price2"];
                item.Title = dr["Title"].ToString();
                item.Content = dr["Content"].ToString();
                item.URL = dr["URL"].ToString();
                item.UpdateDesc = dr["UpdateDesc"].ToString();
                item.StatusCode = (StatusCode)dr["StatusCode"];
                item.IP = dr["IP"].ToString();
                item.LastUpdate = (DateTime)dr["LastUpdate"];
                item.VisitCount = (int)dr["VisitCount"];
                item.AdvType = (AdvertiseType)dr["AdvType"];
                item.State = dr["State"].ToString();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return item;
        }
        public async Task<AdvertiseLogBussines> GetAsync(string connectionString, string url)
        {
            AdvertiseLogBussines res = null;
            try
            {
                using (var cn = new SqlConnection(connectionString))
                {
                    var cmd = new SqlCommand("sp_AdvertiseLog_GetByUrl", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@url", url ?? "");

                    await cn.OpenAsync();
                    var dr = await cmd.ExecuteReaderAsync();
                    if (dr.Read()) res = LoadData(dr);
                    dr.Close();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return res;
        }
        public async Task<ReturnedSaveFuncInfo> SaveAsync(AdvertiseLogBussines item, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_AdvertiseLog_Save", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@guid", item.Guid);
                cmd.Parameters.AddWithValue("@number", item.SimcardNumber);
                cmd.Parameters.AddWithValue("@dateM", item.DateM);
                cmd.Parameters.AddWithValue("@cat", item.Category ?? "");
                cmd.Parameters.AddWithValue("@subCat1", item.SubCategory1 ?? "");
                cmd.Parameters.AddWithValue("@subCat2", item.SubCategory2 ?? "");
                cmd.Parameters.AddWithValue("@city", item.City ?? "");
                cmd.Parameters.AddWithValue("@region", item.Region ?? "");
                cmd.Parameters.AddWithValue("@price1", item.Price1);
                cmd.Parameters.AddWithValue("@price2", item.Price2);
                cmd.Parameters.AddWithValue("@title", item.Title ?? "");
                cmd.Parameters.AddWithValue("@content", item.Content ?? "");
                cmd.Parameters.AddWithValue("@url", item.URL ?? "");
                cmd.Parameters.AddWithValue("@updateDesc", item.UpdateDesc ?? "");
                cmd.Parameters.AddWithValue("@statusCode", (int)item.StatusCode);
                cmd.Parameters.AddWithValue("@cat", item.Category ?? "");
                cmd.Parameters.AddWithValue("@ip", item.IP ?? "");
                cmd.Parameters.AddWithValue("@lastUpdate", item.LastUpdate);
                cmd.Parameters.AddWithValue("@visitCount", item.VisitCount);
                cmd.Parameters.AddWithValue("@type", (short)item.AdvType);
                cmd.Parameters.AddWithValue("@state", item.State ?? "");

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
