﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using Persistence;
using Services;
using Servicess.Interfaces.Building;

namespace EntityCache.Bussines
{
    public class BuildingRelatedOptionsBussines : IBuildingRelatedOptions
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public Guid BuildinGuid { get; set; }
        public Guid BuildingOptionGuid { get; set; }
        public string HardSerial => Cache.HardSerial;
        public string OptionName => BuildingOptionsBussines.Get(BuildingOptionGuid).Name;


        public static async Task<List<BuildingRelatedOptionsBussines>> GetAllAsync(Guid parentGuid, bool status) =>
            await UnitOfWork.BuildingRelatedOptions.GetAllAsync(parentGuid, status);
        public static List<BuildingRelatedOptionsBussines> GetAll(Guid parentGuid, bool status) =>
            AsyncContext.Run(() => GetAllAsync(parentGuid, status));
        public static async Task<ReturnedSaveFuncInfo> ChangeStatusAsync(Guid masterGuid, bool status, string tranName = "")
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = string.IsNullOrEmpty(tranName);
            if (autoTran) tranName = Guid.NewGuid().ToString();
            try
            {
                if (autoTran)
                { //BeginTransaction
                }

                res.AddReturnedValue(await UnitOfWork.BuildingRelatedOptions.ChangeStatusAsync(masterGuid, status));
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
        public static async Task<ReturnedSaveFuncInfo> SaveRangeAsync(List<BuildingRelatedOptionsBussines> list,
            string tranName = "") => await UnitOfWork.BuildingRelatedOptions.SaveRangeAsync(list, tranName);
        public static async Task<ReturnedSaveFuncInfo> RemoveRangeAsync(Guid masterGuid,
            string tranName = "") => await UnitOfWork.BuildingRelatedOptions.RemoveRangeAsync(masterGuid, tranName);
    }
}
