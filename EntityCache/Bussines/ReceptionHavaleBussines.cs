﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Persistence;
using Services;
using Services.Interfaces.Building;

namespace EntityCache.Bussines
{
    public class ReceptionHavaleBussines : IReceptionHavale
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public DateTime DateM { get; set; }
        public Guid MasterGuid { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PeygiriNumber { get; set; }
        public Guid BankTafsilGuid { get; set; }
        public Guid BankMoeinGuid { get; set; }



        //public static async Task<List<ReceptionHavaleBussines>> GetAllAsync(Guid masterGuid) => await UnitOfWork.ReceptionHavale.GetAllAsync(Cache.ConnectionString, masterGuid);
        //public static async Task<ReturnedSaveFuncInfo> SaveRangeAsync(List<ReceptionHavaleBussines> list, SqlTransaction tr = null)
        //{
        //    var res = new ReturnedSaveFuncInfo();
        //    var autoTran = tr == null;
        //    SqlConnection cn = null;
        //    try
        //    {
        //        if (autoTran)
        //        {
        //            cn = new SqlConnection(Cache.ConnectionString);
        //            await cn.OpenAsync();
        //            tr = cn.BeginTransaction();
        //        }

        //        res.AddReturnedValue(await UnitOfWork.ReceptionHavale.SaveRangeAsync(list, tr));
        //    }
        //    catch (Exception ex)
        //    {
        //        WebErrorLog.ErrorInstence.StartErrorLog(ex);
        //        res.AddReturnedValue(ex);
        //    }
        //    finally
        //    {
        //        if (autoTran)
        //        {
        //            res.AddReturnedValue(tr.TransactionDestiny(res.HasError));
        //            res.AddReturnedValue(cn.CloseConnection());
        //        }
        //    }
        //    return res;
        //}
        //public static async Task<ReturnedSaveFuncInfo> RemoveRangeAsync(Guid masterGuid, SqlTransaction tr = null)
        //{
        //    var res = new ReturnedSaveFuncInfo();
        //    var autoTran = tr == null;
        //    SqlConnection cn = null;
        //    try
        //    {
        //        if (autoTran)
        //        {
        //            cn = new SqlConnection(Cache.ConnectionString);
        //            await cn.OpenAsync();
        //            tr = cn.BeginTransaction();
        //        }

        //        res.AddReturnedValue(await UnitOfWork.ReceptionHavale.RemoveRangeAsync(masterGuid, tr));
        //        if (res.HasError) return res;
        //    }
        //    catch (Exception ex)
        //    {
        //        WebErrorLog.ErrorInstence.StartErrorLog(ex);
        //        res.AddReturnedValue(ex);
        //    }
        //    finally
        //    {
        //        if (autoTran)
        //        {
        //            res.AddReturnedValue(tr.TransactionDestiny(res.HasError));
        //            res.AddReturnedValue(cn.CloseConnection());
        //        }
        //    }
        //    return res;
        //}
    }
}
