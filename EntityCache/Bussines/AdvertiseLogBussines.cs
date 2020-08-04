﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EntityCache.Assistence;
using PacketParser;
using PacketParser.Interfaces;
using PacketParser.Services;

namespace EntityCache.Bussines
{
    public class AdvertiseLogBussines : IAdvertiseLog
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public long SimcardNumber { get; set; }
        public DateTime DateM { get; set; } = DateTime.Now;
        public string DateSh => Calendar.MiladiToShamsi(DateM);
        public string Category { get; set; } = "-";
        public string SubCategory1 { get; set; } = "-";
        public string SubCategory2 { get; set; } = "-";
        public string City { get; set; } = "-";
        public string Region { get; set; } = "-";
        public decimal Price1 { get; set; } = 0;
        public decimal Price2 { get; set; } = 0;
        public string Title { get; set; } = "-";
        public string Content { get; set; } = "-";
        public string URL { get; set; } = "-";
        public string UpdateDesc { get; set; } = "-";
        public StatusCode StatusCode { get; set; }
        public string IP { get; set; } = "-";
        public DateTime LastUpdate { get; set; } = DateTime.Now;
        public int VisitCount { get; set; } = 0;
        public string ImagesPath { get; set; }
        public List<string> ImagesPathList { get; set; }




        public async Task<ReturnedSaveFuncInfo> SaveAsync(string tranName = "")
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = string.IsNullOrEmpty(tranName);
            if (autoTran) tranName = Guid.NewGuid().ToString();
            try
            {
                if (autoTran)
                { //BeginTransaction
                }

                res.AddReturnedValue(await UnitOfWork.AdvertiseLog.SaveAsync(this, tranName));
                res.ThrowExceptionIfError();
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
        public static async Task<AdvertiseLogBussines> GetAsync(string url) => await UnitOfWork.AdvertiseLog.GetAsync(url);

        public static async Task<List<AdvertiseLogBussines>> GetAllSpecialAsync(
            Expression<Func<IAdvertiseLog, bool>> @where = null,
            Func<IQueryable<IAdvertiseLog>, IOrderedQueryable<IAdvertiseLog>> @orderby = null, string includes = "",
            int takeCount = -1) =>
            await UnitOfWork.AdvertiseLog.GetAllSpecialAsync(@where, orderby, includes, takeCount);
    }
}
