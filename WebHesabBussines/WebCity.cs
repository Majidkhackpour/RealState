﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;
using Servicess.Interfaces.Building;

namespace WebHesabBussines
{
    public class WebCity : ICities
    {
        private static string Url = Utilities.WebApi + "/api/Cities/SaveAsync";


        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public string Name { get; set; }
        public Guid StateGuid { get; set; }
        public string HardSerial { get; set; }


        public async Task SaveAsync()
        {
            try
            {
                var res = await Extentions.PostToApi<StatesBussines, WebCity>(this, Url);
                if (res.ResponseStatus != ResponseStatus.Success)
                {
                    var temp = new TempBussines()
                    {
                        ObjectGuid = Guid,
                        Type = EnTemp.Cities
                    };
                    await temp.SaveAsync();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(CitiesBussines cls)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var obj = new WebCity()
                {
                    Guid = cls.Guid,
                    Name = cls.Name,
                    Modified = cls.Modified,
                    Status = cls.Status,
                    StateGuid = cls.StateGuid,
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
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(List<CitiesBussines> cls)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                foreach (var item in cls)
                {
                    var obj = new WebCity()
                    {
                        Guid = item.Guid,
                        Name = item.Name,
                        Modified = item.Modified,
                        Status = item.Status,
                        StateGuid = item.StateGuid,
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
