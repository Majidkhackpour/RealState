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
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
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
        public Guid BazaryabGuid { get; set; }
        public decimal BazaryabPrice { get; set; }


        public async Task<ReturnedSaveFuncInfo> SaveAsync()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                //using (var client = new HttpClient())
                //{
                //    var json = Json.ToStringJson(cls);
                //    var content = new StringContent(json, Encoding.UTF8, "application/json");
                //    var result = await client.PostAsync(Utilities.WebApi + "/api/Order/SaveAsync", content);
                //}
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
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
                    UserGuid =cls.UserGuid,
                    TotalPrice = cls.TotalPrice,
                    Description = cls.Description,
                    //Type = cls.Type,
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
                    //DateM = cls.DateM
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
                        //Type = cls.Type,
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
                        //DateM = cls.DateM
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
