﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;
using Servicess.Interfaces.Building;

namespace WebHesabBussines
{
    public class WebDocumentType : IDocumentType
    {
        private static string Url = Utilities.WebApi + "/api/DocumentType/SaveAsync";


        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public ServerStatus ServerStatus { get; set; }
        public DateTime ServerDeliveryDate { get; set; }
        public string Name { get; set; }
        public string HardSerial { get; set; }


        public async Task SaveAsync()
        {
            try
            {
                var res = await Extentions.PostToApi<DocumentTypeBussines, WebDocumentType>(this, Url);
                if (res.ResponseStatus != ResponseStatus.Success)
                {
                    var temp = new TempBussines()
                    {
                        ObjectGuid = Guid,
                        Type = EnTemp.DocumentType
                    };
                    await temp.SaveAsync();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(DocumentTypeBussines cls)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var obj = new WebDocumentType()
                {
                    Guid = cls.Guid,
                    Name = cls.Name,
                    Modified = cls.Modified,
                    Status = cls.Status,
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
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(List<DocumentTypeBussines> cls)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                foreach (var item in cls)
                {
                    var obj = new WebDocumentType()
                    {
                        Guid = item.Guid,
                        Name = item.Name,
                        Modified = item.Modified,
                        Status = item.Status,
                        HardSerial = item.HardSerial
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
