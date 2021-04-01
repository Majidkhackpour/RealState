using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EntityCache.Assistence;
using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;
using Services;
using Servicess.Interfaces.Building;

namespace EntityCache.SqlServerPersistence
{
    public class AdvertiseLogPersistenceRepository : GenericRepository<AdvertiseLogBussines, AdvertiseLog>, IAdvertiseLogRepository
    {
        private ModelContext db;
        private string _connectionString;
        public AdvertiseLogPersistenceRepository(ModelContext _db, string connectionString) : base(_db, connectionString)
        {
            db = _db;
            _connectionString = connectionString;
        }
        private AdvertiseLogBussines LoadData(SqlDataReader dr)
        {
            var item = new AdvertiseLogBussines();
            try
            {
                item.Guid = (Guid)dr["Guid"];
                item.Modified = (DateTime)dr["Modified"];
                item.Status = (bool)dr["Status"];
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
        public async Task<AdvertiseLogBussines> GetAsync(string url)
        {
            AdvertiseLogBussines res = null;
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_AdvertiseLog_GetByUrl", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@url", url ?? "");

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
        public override async Task<ReturnedSaveFuncInfo> SaveAsync(AdvertiseLogBussines item, string tranName)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_AdvertiseLog_Save", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@guid", item.Guid);
                    cmd.Parameters.AddWithValue("@modif", item.Modified);
                    cmd.Parameters.AddWithValue("@st", item.Status);
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
    }
}
