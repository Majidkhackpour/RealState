﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Persistence;
using Services;
using Services.Interfaces.Building;

namespace EntityCache.Bussines
{
    public class CheckPageBussines : ICheckPage
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public Guid CheckGuid { get; set; }
        public DateTime? DatePardakht { get; set; }
        public string DatePardakhtSh => Calendar.MiladiToShamsi(DatePardakht);
        public long Number { get; set; }
        public Guid? ReceptorGuid { get; set; }
        public DateTime? DateSarresid { get; set; }
        public string DateSarresidSh => Calendar.MiladiToShamsi(DateSarresid);
        public string Description { get; set; }
        public decimal Price { get; set; }
        public EnCheckSh CheckStatus { get; set; }
        public string StatusName => CheckStatus.GetDisplay();


        public static async Task<List<CheckPageBussines>> GetAllAsync(Guid checkGuid, CancellationToken token) =>
            await UnitOfWork.CheckPage.GetAllAsync(Cache.ConnectionString, checkGuid, token);
        public static async Task<CheckPageBussines> GetAsync(Guid guid) => await UnitOfWork.CheckPage.GetAsync(Cache.ConnectionString, guid);
        public async Task<ReturnedSaveFuncInfo> SaveAsync(SqlTransaction tr = null)
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

                res.AddReturnedValue(await UnitOfWork.CheckPage.SaveAsync(this, tr));
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
