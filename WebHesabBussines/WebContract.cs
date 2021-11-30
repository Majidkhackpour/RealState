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
        public string RealStateCode { get; set; }
        public string HologramCode { get; set; }
        public bool IsTemp { get; set; }
        public Guid FirstSideGuid { get; set; }
        public Guid SecondSideGuid { get; set; }
        public Guid BuildingGuid { get; set; }
        public Guid UserGuid { get; set; }
        public int? Term { get; set; }
        public DateTime? FromDate { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal MinorPrice { get; set; }
        public string CheckNoTo { get; set; }
        public string CheckNo { get; set; }
        public string BankName { get; set; }
        public string BankNameEjare { get; set; }
        public string Shobe { get; set; }
        public string ShobeEjare { get; set; }
        public DateTime? SarResidTo { get; set; }
        public DateTime? SarResid { get; set; }
        public decimal CheckPrice1 { get; set; }
        public decimal CheckPrice2 { get; set; }
        public DateTime? DischargeDate { get; set; }
        public DateTime? SetDocDate { get; set; }
        public string SetDocPlace { get; set; }
        public int SetDocNo { get; set; }
        public decimal SarQofli { get; set; }
        public decimal FirstSideDelay { get; set; }
        public decimal SecondSideDelay { get; set; }
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
        public string BuildingPlack { get; set; }
        public string BuildingZip { get; set; }
        public string SanadSerial { get; set; }
        public int PartNo { get; set; }
        public int Page { get; set; }
        public string Office { get; set; }
        public string BuildingNumber { get; set; }
        public int ParkingNo { get; set; }
        public float ParkingMasahat { get; set; }
        public int StoreNo { get; set; }
        public float StoreMasahat { get; set; }
        public int PhoneLineCount { get; set; }
        public string BuildingPhoneNumber { get; set; }
        public int PeopleCount { get; set; }
        public string PayankarNo { get; set; }
        public DateTime? PayankarDate { get; set; }
        public decimal PishPrice { get; set; }
        public string Witness1 { get; set; }
        public string Witness2 { get; set; }
        public string BuildingRegistrationNo { get; set; }
        public string BuildingRegistrationNoSub { get; set; }
        public string BuildingRegistrationNoOrigin { get; set; }
        public string BuildingCosumable { get; set; }
        public string ManufacturingLicensePlace { get; set; }
        public DateTime? ManufacturingLicenseDate { get; set; }
        public DateTime? SettlementDate { get; set; }
        public decimal AmountOfRent { get; set; }
        public string GulidType { get; set; }
        public string DocumentAdjust { get; set; }


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
