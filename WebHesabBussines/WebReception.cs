﻿using System;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;
using Servicess.Interfaces.Building;

namespace WebHesabBussines
{
    public class WebReception : IReception
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public Guid Receptor { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }
        public decimal NaqdPrice { get; set; }
        public decimal BankPrice { get; set; }
        public string FishNo { get; set; }
        public decimal Check { get; set; }
        public string CheckNo { get; set; }
        public string SarResid { get; set; }
        public string BankName { get; set; }




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
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(ReceptionBussines cls)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var obj = new WebReception()
                {
                    Guid = cls.Guid,
                    Modified = cls.Modified,
                    Status = cls.Status,
                    Description = cls.Description,
                    CreateDate = cls.CreateDate,
                    NaqdPrice = cls.NaqdPrice,
                    BankPrice = cls.BankPrice,
                    BankName = cls.BankName,
                    CheckNo = cls.CheckNo,
                    SarResid = cls.SarResid,
                    Receptor = cls.Receptor,
                    Check = cls.Check,
                    FishNo = cls.FishNo
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

    }
}
