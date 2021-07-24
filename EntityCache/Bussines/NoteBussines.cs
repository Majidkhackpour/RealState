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
    public class NoteBussines : INote
    {
        public Guid Guid { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateSabt { get; set; } = DateTime.Now;
        public string DateSabtSh => Calendar.MiladiToShamsi(DateSabt);
        public DateTime? DateSarresid { get; set; }
        public string DateSarresidSh => Calendar.MiladiToShamsi(DateSarresid);
        public Guid UserGuid { get; set; }
        public string UserName { get; set; }
        public EnNotePriority Priority { get; set; }
        public string PriorityName => Priority.GetDisplay();
        public EnNoteStatus NoteStatus { get; set; }
        public string StatusName => NoteStatus.GetDisplay();



        public static async Task<NoteBussines> GetAsync(Guid guid) => await UnitOfWork.Note.GetAsync(Cache.ConnectionString, guid);
        public static async Task<List<NoteBussines>> GetAllAsync() => await UnitOfWork.Note.GetAllAsync(Cache.ConnectionString);
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

                res.AddReturnedValue(await UnitOfWork.Note.SaveAsync(this, tr));
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
        public static async Task<List<NoteBussines>> GetAllAsync(string search, Guid userGuid, EnNoteStatus status, EnNotePriority priority)
        {
            try
            {
                if (string.IsNullOrEmpty(search))
                    search = "";
                var res = await GetAllAsync();
                if (userGuid != Guid.Empty) res = res.Where(q => q.UserGuid == userGuid).ToList();
                if (status != EnNoteStatus.All) res = res.Where(q => q.NoteStatus == status).ToList();
                if (priority != EnNotePriority.All) res = res.Where(q => q.Priority == priority).ToList();
                var searchItems = search.SplitString();
                if (searchItems?.Count > 0)
                    foreach (var item in searchItems)
                    {
                        if (!string.IsNullOrEmpty(item) && item.Trim() != "")
                        {
                            res = res.Where(x => x.Title.Contains(item) ||
                                                 x.Description.Contains(item))
                                ?.ToList();
                        }
                    }

                res = res?.OrderByDescending(o => o.DateSabt).ToList();
                return res;
            }
            catch (OperationCanceledException)
            {
                return null;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return new List<NoteBussines>();
            }
        }
        public static NoteBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));
        public static async Task<List<NoteBussines>> GetAllTodayNotesAsync(Guid userGuid)
        {
            try
            {
                var d1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                var d2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
                return await UnitOfWork.Note.GetAllTodayNotesAsync(Cache.ConnectionString, d1, d2, userGuid);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
    }
}
