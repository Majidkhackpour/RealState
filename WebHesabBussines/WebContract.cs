using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;
using Servicess.Interfaces.Building;

namespace WebHesabBussines
{
    public class WebContract : IContract
    {
        private static string Url = Utilities.WebApi + "/api/Contract/SaveAsync";


        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public ServerStatus ServerStatus { get; set; }
        public DateTime ServerDeliveryDate { get; set; }
        public DateTime DateM { get; set; }
        public long Code { get; set; }
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
        public string HardSerial { get; set; }
        public ContractFinanceBussines Finance { get; set; }


        public async Task SaveAsync()
        {
            try
            {
                var res = await Extentions.PostToApi<ContractBussines, WebContract>(this, Url);
                if (res.ResponseStatus != ResponseStatus.Success)
                {
                    var temp = new TempBussines()
                    {
                        ObjectGuid = Guid,
                        Type = EnTemp.Contract
                    };
                    await temp.SaveAsync();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(ContractBussines cls)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var obj = new WebContract()
                {
                    Guid = cls.Guid,
                    Modified = cls.Modified,
                    Status = cls.Status,
                    Code = cls.Code,
                    MinorPrice = cls.MinorPrice,
                    UserGuid = cls.UserGuid,
                    TotalPrice = cls.TotalPrice,
                    Description = cls.Description,
                    Type = cls.Type,
                    Term = cls.Term,
                    SecondSideGuid = cls.SecondSideGuid,
                    Delay = cls.Delay,
                    SarQofli = cls.SarQofli,
                    BankName = cls.BankName,
                    IsTemp = cls.IsTemp,
                    FirstSideGuid = cls.FirstSideGuid,
                    Shobe = cls.Shobe,
                    CheckNo = cls.CheckNo,
                    FromDate = cls.FromDate,
                    DischargeDate = cls.DischargeDate,
                    SarResid = cls.SarResid,
                    BuildingGuid = cls.BuildingGuid,
                    SetDocDate = cls.SetDocDate,
                    SetDocPlace = cls.SetDocPlace,
                    DateM = cls.DateM,
                    HardSerial = cls.HardSerial,
                    BazaryabGuid = cls.BazaryabGuid,
                    BazaryabPrice = cls.BazaryabPrice,
                    Finance = cls.Finance
                };
                await obj.SaveAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(List<ContractBussines> item)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                foreach (var cls in item)
                {
                    var obj = new WebContract()
                    {
                        Guid = cls.Guid,
                        Modified = cls.Modified,
                        Status = cls.Status,
                        Code = cls.Code,
                        MinorPrice = cls.MinorPrice,
                        UserGuid = cls.UserGuid,
                        TotalPrice = cls.TotalPrice,
                        Description = cls.Description,
                        Type = cls.Type,
                        Term = cls.Term,
                        SecondSideGuid = cls.SecondSideGuid,
                        Delay = cls.Delay,
                        SarQofli = cls.SarQofli,
                        BankName = cls.BankName,
                        IsTemp = cls.IsTemp,
                        FirstSideGuid = cls.FirstSideGuid,
                        Shobe = cls.Shobe,
                        CheckNo = cls.CheckNo,
                        FromDate = cls.FromDate,
                        DischargeDate = cls.DischargeDate,
                        SarResid = cls.SarResid,
                        BuildingGuid = cls.BuildingGuid,
                        SetDocDate = cls.SetDocDate,
                        SetDocPlace = cls.SetDocPlace,
                        DateM = cls.DateM,
                        HardSerial = cls.HardSerial,
                        BazaryabGuid = cls.BazaryabGuid,
                        BazaryabPrice = cls.BazaryabPrice,
                        Finance = cls.Finance
                    };
                    await obj.SaveAsync();
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
