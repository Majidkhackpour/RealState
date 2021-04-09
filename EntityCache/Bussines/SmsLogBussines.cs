using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using Services;
using Servicess.Interfaces.Building;

namespace EntityCache.Bussines
{
    public class SmsLogBussines : ISmsLog
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public DateTime Date { get; set; } = DateTime.Now;
        public string DateSh => Calendar.MiladiToShamsi(Date);
        public Guid UserGuid { get; set; }
        public string UserName { get; set; }
        public string Sender { get; set; }
        public string Reciver { get; set; }
        public string Message { get; set; }
        public decimal Cost { get; set; }
        public long MessageId { get; set; }
        public string StatusText { get; set; }



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

                res.AddReturnedValue(await UnitOfWork.SmsLog.SaveAsync(this, tranName));
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
        public static async Task<SmsLogBussines> GetAsync(Guid guid) => await UnitOfWork.SmsLog.GetAsync(guid);
        public static async Task<List<SmsLogBussines>> GetAllAsync() => await UnitOfWork.SmsLog.GetAllBySpAsync();
        public static async Task<List<SmsLogBussines>> GetAllAsync(string search, Guid userGuid)
        {
            try
            {
                if (string.IsNullOrEmpty(search)) search = "";
                var res = await GetAllAsync();
                if (userGuid != Guid.Empty) res = res.Where(q => q.UserGuid == userGuid).ToList();
                var searchItems = search.SplitString();
                if (searchItems?.Count > 0)
                    foreach (var item in searchItems)
                    {
                        if (!string.IsNullOrEmpty(item) && item.Trim() != "")
                        {
                            res = res.Where(x => x.UserName.Contains(item) ||
                                                 x.Sender.Contains(item) ||
                                                 x.Reciver.Contains(item) ||
                                                 x.Message.Contains(item) ||
                                                 x.StatusText.Contains(item))
                                ?.ToList();
                        }
                    }

                res = res?.OrderByDescending(o => o.Date).ToList();
                return res;
            }
            catch (OperationCanceledException)
            {
                return null;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return new List<SmsLogBussines>();
            }
        }
        public static SmsLogBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));
        public static async Task<SmsLogBussines> GetAsync(long messageId) =>
            await UnitOfWork.SmsLog.GetAsync(messageId);
    }
}
