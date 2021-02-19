using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Services;
using Services.Interfaces.Building;

namespace EntityCache.Bussines
{
    public class CheckPageBussines : ICheckPage
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public Guid CheckGuid { get; set; }
        public DateTime? DatePardakht { get; set; }
        public string DatePardakhtSh => Calendar.MiladiToShamsi(DatePardakht);
        public long Number { get; set; }
        public Guid? ReceptorGuid { get; set; }
        public string ReceptorName => TafsilBussines.Get(ReceptorGuid ?? Guid.Empty)?.Name;
        public DateTime? DateSarresid { get; set; }
        public string DateSarresidSh => Calendar.MiladiToShamsi(DateSarresid);
        public string Description { get; set; }
        public decimal Price { get; set; }
        public EnCheckSh CheckStatus { get; set; }
        public string StatusName => CheckStatus.GetDisplay();


        public static async Task<List<CheckPageBussines>> GetAllAsync(Guid checkGuid) =>
            await UnitOfWork.CheckPage.GetAllAsync(checkGuid);
        public static async Task<ReturnedSaveFuncInfo> RemoveAllAsync(Guid checkGuid)
            => await UnitOfWork.CheckPage.RemoveAllAsync(checkGuid);
        public static async Task<ReturnedSaveFuncInfo> SaveRangeAsync(List<CheckPageBussines> lst, string tranName = "")
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = string.IsNullOrEmpty(tranName);
            if (autoTran) tranName = Guid.NewGuid().ToString();
            try
            {
                if (autoTran)
                { //BeginTransaction
                }

                res.AddReturnedValue(await UnitOfWork.CheckPage.SaveRangeAsync(lst, tranName));
                if (res.HasError) return res;

                if (autoTran)
                {
                    //CommitTransAction
                }

                //if (Cache.IsSendToServer)
                //    _ = Task.Run(() => WebUser.SaveAsync(this));
            }
            catch (Exception ex)
            {
                if (autoTran)
                {
                    //RollBackTransAction
                }
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
    }
}
