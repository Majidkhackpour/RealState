using EntityCache.Assistence;
using Persistence;
using Services;
using Servicess.Interfaces.Building;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EntityCache.Bussines
{
    public class AdvertiseLogBussines : IAdvertiseLog
    {
        public Guid Guid { get; set; }
        public long SimcardNumber { get; set; }
        public DateTime DateM { get; set; } = DateTime.Now;
        public string DateSh => Calendar.MiladiToShamsi(DateM);
        public string Category { get; set; } = "-";
        public string SubCategory1 { get; set; } = "-";
        public string SubCategory2 { get; set; } = "-";
        public string FullCategory => $"{Category} - {SubCategory1} - {SubCategory2}";
        public string City { get; set; } = "-";
        public string Region { get; set; } = "-";
        public decimal Price1 { get; set; } = 0;
        public decimal Price2 { get; set; } = 0;
        public string Title { get; set; } = "-";
        public string Content { get; set; } = "-";
        public string URL { get; set; } = "-";
        public string UpdateDesc { get; set; } = "-";
        public StatusCode StatusCode { get; set; }
        public string IP { get; set; } = "-";
        public DateTime LastUpdate { get; set; } = DateTime.Now;
        public int VisitCount { get; set; } = 0;
        public List<string> ImagesPathList { get; set; }
        public AdvertiseType AdvType { get; set; }
        public string State { get; set; } = "-";
        public string ImageList => ImagesPathList != null && ImagesPathList.Count > 0
            ? string.Join("\r\n", ImagesPathList)
            : "---";

        public async Task<ReturnedSaveFuncInfo> SaveAsync(SqlTransaction tr = null)
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = tr == null;
            SqlConnection cn = null;
            try
            {
                if (autoTran)
                {
                    cn = new SqlConnection(Cache.ConnectionString);
                    await cn.OpenAsync();
                    tr = cn.BeginTransaction();
                }

                res.AddReturnedValue(await UnitOfWork.AdvertiseLog.SaveAsync(this, tr));
                if (res.HasError) return res;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (autoTran)
                {
                    res.AddReturnedValue(tr.TransactionDestiny(res.HasError));
                    res.AddReturnedValue(cn?.CloseConnection());
                }
            }
            return res;
        }
        public static async Task<AdvertiseLogBussines> GetAsync(string url) => await UnitOfWork.AdvertiseLog.GetAsync(Cache.ConnectionString, url);
        public static async Task<List<AdvertiseLogBussines>> GetAllAsync(DateTime? d1 = null, DateTime? d2 = null, long number = 0)
            => await UnitOfWork.AdvertiseLog.GetAllAsync(Cache.ConnectionString, d1, d2, number);
        public static async Task<List<AdvertiseLogBussines>> GetAllAsync(string search, DateTime? d1 = null, DateTime? d2 = null, long number = 0)
        {
            try
            {
                if (string.IsNullOrEmpty(search)) search = "";
                var res = await GetAllAsync(d1, d2, number);
                var searchItems = search.SplitString();
                if (searchItems?.Count > 0)
                    foreach (var item in searchItems)
                    {
                        if (!string.IsNullOrEmpty(item) && item.Trim() != "")
                        {
                            res = res.Where(x => x.SimcardNumber.ToString().ToLower().Contains(item.ToLower()) ||
                                                 x.FullCategory.Contains(item) ||
                                                 x.Region.Contains(item) ||
                                                 x.Title.Contains(item) ||
                                                 x.Content.Contains(item))
                                ?.ToList();
                        }
                    }

                res = res?.OrderByDescending(o => o.DateM).ToList();
                return res;
            }
            catch (TaskCanceledException) { return null; }
            catch (OperationCanceledException) { return null; }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return new List<AdvertiseLogBussines>();
            }
        }
    }
}
