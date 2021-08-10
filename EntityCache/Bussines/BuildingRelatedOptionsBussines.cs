﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Assistence;
using EntityCache.Mppings;
using Nito.AsyncEx;
using Persistence;
using Services;
using Servicess.Interfaces.Building;
using WebHesabBussines;

namespace EntityCache.Bussines
{
    public class BuildingRelatedOptionsBussines : IBuildingRelatedOptions
    {
        public Guid Guid { get; set; }
        public Guid BuildinGuid { get; set; }
        public DateTime Modified { get; set; }
        public ServerStatus ServerStatus { get; set; } = ServerStatus.None;
        public DateTime ServerDeliveryDate { get; set; } = DateTime.Now;
        public Guid BuildingOptionGuid { get; set; }
        public string HardSerial => Cache.HardSerial;
        public string OptionName => BuildingOptionsBussines.Get(BuildingOptionGuid).Name;


        public static async Task<List<BuildingRelatedOptionsBussines>> GetAllAsync(Guid parentGuid) =>
            await UnitOfWork.BuildingRelatedOptions.GetAllAsync(Cache.ConnectionString,parentGuid);
        public static List<BuildingRelatedOptionsBussines> GetAll(Guid parentGuid) =>
            AsyncContext.Run(() => GetAllAsync(parentGuid));
        public static async Task<BuildingRelatedOptionsBussines> GetAsync(Guid guid) =>
            await UnitOfWork.BuildingRelatedOptions.GetAsync(Cache.ConnectionString, guid);
        public static async Task<ReturnedSaveFuncInfo> SaveRangeAsync(List<BuildingRelatedOptionsBussines> list, SqlTransaction tr = null)
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = tr == null;
            SqlConnection cn = null;
            try
            {
                if (autoTran)
                {
                    cn = new SqlConnection(Cache.ConnectionString);
                    await cn.OpenAsync();
                    tr = cn.BeginTransaction();
                }

                res.AddReturnedValue(await UnitOfWork.BuildingRelatedOptions.SaveRangeAsync(list, tr));
                if (res.HasError) return res;

                if (Cache.IsSendToServer)
                    _ = Task.Run(() => WebBuildingRelatedOptions.SaveAsync(BuildingRelatedOptionMapper.Instance.MapList(list)));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (autoTran)
                {
                    res.AddReturnedValue(tr.TransactionDestiny(res.HasError));
                    res.AddReturnedValue(cn.CloseConnection());
                }
            }
            return res;
        }
        public static async Task<ReturnedSaveFuncInfo> RemoveRangeAsync(Guid masterGuid, SqlTransaction tr = null)
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = tr == null;
            SqlConnection cn = null;
            try
            {
                if (autoTran)
                {
                    cn = new SqlConnection(Cache.ConnectionString);
                    await cn.OpenAsync();
                    tr = cn.BeginTransaction();
                }

                res.AddReturnedValue(await UnitOfWork.BuildingRelatedOptions.RemoveRangeAsync(masterGuid, tr));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (autoTran)
                {
                    res.AddReturnedValue(tr.TransactionDestiny(res.HasError));
                    res.AddReturnedValue(cn.CloseConnection());
                }
            }
            return res;
        }
    }
}
