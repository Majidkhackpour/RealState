using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using Persistence;
using Services;
using Servicess.Interfaces.Building;

namespace EntityCache.Bussines
{
    public class SmsLogBussines : ISmsLog
    {
        public Guid Guid { get; set; }
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

                res.AddReturnedValue(await UnitOfWork.SmsLog.SaveAsync(this, tr));
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
        public static async Task<SmsLogBussines> GetAsync(Guid guid) => await UnitOfWork.SmsLog.GetAsync(Cache.ConnectionString, guid);
        public static async Task<List<SmsLogBussines>> GetAllAsync() => await UnitOfWork.SmsLog.GetAllAsync(Cache.ConnectionString);
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
        public static async Task<SmsLogBussines> GetAsync(long messageId) => await UnitOfWork.SmsLog.GetAsync(Cache.ConnectionString, messageId);
    }
}
