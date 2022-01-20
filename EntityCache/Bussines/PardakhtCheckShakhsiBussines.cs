using EntityCache.Assistence;
using EntityCache.ViewModels;
using Persistence;
using Services;
using Services.Interfaces.Building;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityCache.Bussines
{
    public class PardakhtCheckShakhsiBussines : IPardakhtCheckShakhsi
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public DateTime DateSarResid { get; set; } = DateTime.Now;
        public string DateSarresidSh => Calendar.MiladiToShamsi(DateSarResid);
        public string Description { get; set; }
        public string Number { get; set; }
        public decimal Price { get; set; }
        public DateTime DateM { get; set; } = DateTime.Now;
        public Guid CheckPageGuid { get; set; }
        public Guid MasterGuid { get; set; }
        public static async Task<List<PardakhtCheckViewModel>> GetAllViewModeAsync(string search = "")
        {
            try
            {
                if (string.IsNullOrEmpty(search)) search = "";
                var res = await UnitOfWork.PardakhtCheckShakhsi.GetAllViewModelAsync(Cache.ConnectionString);
                var searchItems = search.SplitString();
                if (searchItems?.Count > 0)
                    foreach (var item in searchItems)
                    {
                        if (!string.IsNullOrEmpty(item) && item.Trim() != "")
                        {
                            res = res.Where(x => x.BankName.ToLower().Contains(item.ToLower()) ||
                                                 x.Girande.ToLower().Contains(item.ToLower()) ||
                                                 x.CheckNumber.ToLower().Contains(item.ToLower()) ||
                                                 x.Price.ToString().ToLower().Contains(item.ToLower()) ||
                                                 x.StatusName.ToLower().Contains(item.ToLower()) ||
                                                 x.Description.ToLower().Contains(item.ToLower()))
                                ?.ToList();
                        }
                    }

                res = res?.OrderByDescending(o => o.DateSarResid).ToList();
                return res;
            }
            catch (OperationCanceledException)
            { return null; }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return new List<PardakhtCheckViewModel>();
            }
        }
        public static async Task<PardakhtCheckShakhsiBussines> GetAsync(Guid guid) => await UnitOfWork.PardakhtCheckShakhsi.GetAsync(Cache.ConnectionString, guid);
    }
}
