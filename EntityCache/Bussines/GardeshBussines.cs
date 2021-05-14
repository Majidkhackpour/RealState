using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Persistence;
using Services;

namespace EntityCache.Bussines
{
    public class GardeshBussines
    {
        public Guid Guid { get; set; }
        public DateTime DateM { get; set; }
        public string DateSh => Calendar.MiladiToShamsi(DateM);
        public long SanadNumber { get; set; }
        public Guid MoeinGuid { get; set; }
        public string MoeinCode { get; set; }
        public string MoeinName { get; set; }
        public Guid TafsilGuid { get; set; }
        public string TafsilCode { get; set; }
        public string TafsilName { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal Rem { get; set; }
        public decimal Rem_ => Math.Abs(Rem);
        public string RemDiagnosis => Rem.AccountDiagnosis();
        public string Description { get; set; }


        public static async Task<List<GardeshBussines>> GetAllGardeshAsync(Guid tafsilGuid)
        {
            IEnumerable<GardeshBussines> list = null;
            try
            {
                list = await UnitOfWork.SanadDetail.GetAllGardeshAsync(Cache.ConnectionString, tafsilGuid);
                list = list?.OrderBy(q => q.DateM);
                decimal rem = 0;
                foreach (var item in list ?? new List<GardeshBussines>())
                {
                    item.Rem = rem + item.Credit - item.Debit;
                    rem = item.Rem;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list?.ToList();
        }
        public static async Task<List<GardeshBussines>> GetAllRooznameAsync(DateTime d1, DateTime d2, string search,CancellationToken token)
        {
            try
            {
                var date1 = new DateTime(d1.Year, d1.Month, d1.Day, 0, 0, 0);
                var date2 = new DateTime(d2.Year, d2.Month, d2.Day, 23, 59, 59);
                if (string.IsNullOrEmpty(search)) search = "";
                var res = await UnitOfWork.SanadDetail.GetAllRooznameAsync(Cache.ConnectionString, date1, date2, token);
                if (token.IsCancellationRequested) return null;
                var searchItems = search.SplitString();
                if (searchItems?.Count > 0)
                    foreach (var item in searchItems)
                    {
                        if (token.IsCancellationRequested) return null;
                        if (!string.IsNullOrEmpty(item) && item.Trim() != "")
                        {
                            res = res.Where(x => x.SanadNumber.ToString().ToLower().Contains(item.ToLower())||
                                                 x.MoeinCode.ToLower().Contains(item.ToLower())||
                                                 x.MoeinName.ToLower().Contains(item.ToLower())||
                                                 x.TafsilCode.ToLower().Contains(item.ToLower())||
                                                 x.TafsilName.ToLower().Contains(item.ToLower())||
                                                 x.Description.ToLower().Contains(item.ToLower())||
                                                 x.Debit.ToString().ToLower().Contains(item.ToLower())||
                                                 x.Credit.ToString().ToLower().Contains(item.ToLower()))
                                ?.ToList();
                        }
                    }

                res = res?.OrderBy(o => o.DateM)?.ThenBy(q => q.SanadNumber)?.ThenBy(q => q.Credit)
                    ?.ThenBy(q => q.Debit)?.ToList();
                return res;
            }
            catch (TaskCanceledException) { return null; }
            catch (OperationCanceledException) { return null; }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return new List<GardeshBussines>();
            }
        }
    }
}
