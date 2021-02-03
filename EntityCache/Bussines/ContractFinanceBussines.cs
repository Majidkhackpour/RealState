using System;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using Services;
using Servicess.Interfaces.Building;

namespace EntityCache.Bussines
{
    public class ContractFinanceBussines : IContractFinance
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public Guid ConGuid { get; set; }
        public EnContractBabat fBabat { get; set; }
        public EnContractBabat sBabat { get; set; }
        public decimal FirstDiscount { get; set; }
        public decimal SecondDiscount { get; set; }
        public decimal FirstAddedValue { get; set; }
        public decimal SecondAddedValue { get; set; }
        public decimal FirstTotalPrice { get; set; }
        public decimal SecondTotalPrice { get; set; }

        public static async Task<ContractFinanceBussines> GetAsync(Guid parentGuid, bool status) =>
            await UnitOfWork.ContractFinance.GetAsync(parentGuid, status);
        public static ContractFinanceBussines Get(Guid parentGuid, bool status) =>
            AsyncContext.Run(() => GetAsync(parentGuid, status));
        public async Task<ReturnedSaveFuncInfo> ChangeStatusAsync(bool status, string tranName = "")
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = string.IsNullOrEmpty(tranName);
            if (autoTran) tranName = Guid.NewGuid().ToString();
            try
            {
                if (autoTran)
                { //BeginTransaction
                }

                res.AddReturnedValue(await UnitOfWork.ContractFinance.ChangeStatusAsync(this, status, tranName));
                if (res.HasError) return res;
                if (autoTran)
                {
                    //CommitTransAction
                }
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
        public static async Task<decimal> GetTotalCommitionAsync(DateTime d1, DateTime d2) =>
            await UnitOfWork.ContractFinance.GetTotalCommitionAsync(d1, d2);
        public static decimal GetTotalCommition(DateTime d1, DateTime d2) =>
            AsyncContext.Run(() => GetTotalCommitionAsync(d1, d2));
        public static async Task<decimal> GetTotalTaxAsync(DateTime d1, DateTime d2) =>
            await UnitOfWork.ContractFinance.GetTotalTaxAsync(d1, d2);
        public static decimal GetTotalTax(DateTime d1, DateTime d2) =>
            AsyncContext.Run(() => GetTotalTaxAsync(d1, d2));
    }
}
