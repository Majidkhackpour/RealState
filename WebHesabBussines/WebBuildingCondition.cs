﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;
using Servicess.Interfaces.Building;

namespace WebHesabBussines
{
    public class WebBuildingCondition : IBuildingCondition
    {
        private static string Url = Utilities.WebApi + "/api/BuildingCondition/SaveAsync";


        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public string Name { get; set; }
        public ServerStatus ServerStatus { get; set; }
        public DateTime ServerDeliveryDate { get; set; }
        public string HardSerial { get; set; }

        public async Task SaveAsync()
        {
            try
            {
                var res = await Extentions.PostToApi<BuildingConditionBussines, WebBuildingCondition>(this, Url);
                if (res.ResponseStatus != ResponseStatus.Success)
                {
                    var temp = new TempBussines()
                    {
                        ObjectGuid = Guid,
                        Type = EnTemp.BuildingCondition
                    };
                    await temp.SaveAsync();
                    return;
                }
                var bu = res.Data;
                if (bu == null) return;
                await TempBussines.UpdateEntityAsync(EnTemp.BuildingCondition, bu.Guid, ServerStatus.Delivered, DateTime.Now);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(BuildingConditionBussines cls)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var obj = new WebBuildingCondition()
                {
                    Guid = cls.Guid,
                    Name = cls.Name,
                    Modified = cls.Modified,
                    Status = cls.Status,
                    HardSerial = cls.HardSerial,
                    ServerStatus = cls.ServerStatus,
                    ServerDeliveryDate = cls.ServerDeliveryDate
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
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(List<BuildingConditionBussines> cls)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                foreach (var item in cls)
                    res.AddReturnedValue(await SaveAsync(item));
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
