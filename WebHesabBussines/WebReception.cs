﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;
using Servicess.Interfaces.Building;

namespace WebHesabBussines
{
    public class WebReception : IReception
    {
        private static string Url = Utilities.WebApi + "/api/BuildingReception/SaveAsync";


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
        public string HardSerial { get; set; }




        public async Task SaveAsync()
        {
            try
            {
                var res = await Extentions.PostToApi<ReceptionBussines, WebReception>(this, Url);
                if (res.ResponseStatus != ResponseStatus.Success)
                {
                    var temp = new TempBussines()
                    {
                        ObjectGuid = Guid,
                        Type = EnTemp.Reception
                    };
                    await temp.SaveAsync();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
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
                    FishNo = cls.FishNo,
                    HardSerial = cls.HardSerial
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
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(List<ReceptionBussines> item)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                foreach (var cls in item)
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
                        FishNo = cls.FishNo,
                        HardSerial = cls.HardSerial
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
