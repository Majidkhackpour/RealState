using Services;
using Servicess.Interfaces.Building;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebHesabBussines
{
    public class WebContract : IContract
    {
        private static string Url = Utilities.WebApi + "/api/Contract/SaveAsync";
        public static event Func<Guid, ServerStatus, DateTime, Task> OnSaveResult;

        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public ServerStatus ServerStatus { get; set; }
        public DateTime ServerDeliveryDate { get; set; }
        public DateTime DateM { get; set; }
        public long Code { get; set; }
        public string CodeInArchive { get; set; }
        public bool IsTemp { get; set; }
        public Guid FirstSideGuid { get; set; }
        public Guid SecondSideGuid { get; set; }
        public Guid BuildingGuid { get; set; }
        public Guid UserGuid { get; set; }
        public int? Term { get; set; }
        public DateTime? FromDate { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal MinorPrice { get; set; }
        public string CheckNo { get; set; }
        public string BankName { get; set; }
        public string Shobe { get; set; }
        public string SarResid { get; set; }
        public DateTime DischargeDate { get; set; }
        public DateTime? SetDocDate { get; set; }
        public string SetDocPlace { get; set; }
        public decimal SarQofli { get; set; }
        public decimal Delay { get; set; }
        public string Description { get; set; }
        public EnRequestType Type { get; set; }
        public Guid? BazaryabGuid { get; set; }
        public decimal BazaryabPrice { get; set; }
        public long SanadNumber { get; set; }
        public EnContractBabat fBabat { get; set; }
        public EnContractBabat sBabat { get; set; }
        public decimal FirstDiscount { get; set; }
        public decimal SecondDiscount { get; set; }
        public decimal FirstTax { get; set; }
        public decimal FirstAvarez { get; set; }
        public decimal SecondTax { get; set; }
        public decimal SecondAvarez { get; set; }
        public decimal FirstTotalPrice { get; set; }
        public decimal SecondTotalPrice { get; set; }


        private static void RaiseEvent(Guid objGuid, ServerStatus st, DateTime dateM)
        {
            try
            {
                var handler = OnSaveResult;
                if (handler != null)
                    OnSaveResult?.Invoke(objGuid, st, dateM);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task SaveAsync()
        {
            try
            {
                var res = await Extentions.PostToApi<WebContract, WebContract>(this, Url, WebCustomer.Customer.Guid);
                if (res.ResponseStatus != ResponseStatus.Success)
                {
                    RaiseEvent(Guid, ServerStatus.DeliveryError, DateTime.Now);
                    return;
                }
                RaiseEvent(Guid, ServerStatus.Delivered, DateTime.Now);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(WebContract cls)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                await cls.SaveAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(List<WebContract> item)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                foreach (var cls in item)
                    res.AddReturnedValue(await SaveAsync(cls));
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
