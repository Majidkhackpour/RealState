using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Services;
using Services.Interfaces.Building;

namespace EntityCache.Bussines
{
    public class DasteCheckBussines : IDasteCheck
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public string SerialNumber { get; set; }
        public Guid BankGuid { get; set; }
        public string BankName { get; set; }
        public long FromNumber { get; set; }
        public long ToNumber { get; set; }
        public string Description { get; set; }
        public long PageCount => (ToNumber - FromNumber) + 1;
        public List<CheckPageBussines> CheckPages { get; set; }


        public static async Task<List<DasteCheckBussines>> GetAllAsync() => await UnitOfWork.DasteCheck.GetAllAsync();
        public static async Task<List<DasteCheckBussines>> GetAllAsync(string search)
        {
            try
            {
                if (string.IsNullOrEmpty(search))
                    search = "";
                var res = await GetAllAsync();
                var searchItems = search.SplitString();
                if (searchItems?.Count > 0)
                    foreach (var item in searchItems)
                    {
                        if (!string.IsNullOrEmpty(item) && item.Trim() != "")
                        {
                            res = res.Where(x => x.SerialNumber.ToLower().Contains(item.ToLower()) ||
                                                 x.BankName.ToLower().Contains(item.ToLower()) ||
                                                 x.FromNumber.ToString().ToLower().Contains(item.ToLower()) ||
                                                 x.ToNumber.ToString().ToLower().Contains(item.ToLower()) ||
                                                 x.PageCount.ToString().ToLower().Contains(item.ToLower()) ||
                                                 x.Description.ToLower().Contains(item.ToLower()))
                                ?.ToList();
                        }
                    }

                res = res?.OrderBy(o => o.BankName).ToList();
                return res;
            }
            catch (OperationCanceledException)
            { return null; }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return new List<DasteCheckBussines>();
            }
        }
    }
}
