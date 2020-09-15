using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using PacketParser.Interfaces;
using Services;

namespace EntityCache.Bussines
{
    public class NoteBussines : INote
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateSabt { get; set; } = DateTime.Now;
        public string DateSabtSh => Calendar.MiladiToShamsi(DateSabt);
        public DateTime? DateSarresid { get; set; }
        public string DateSarresidSh => Calendar.MiladiToShamsi(DateSarresid);
        public Guid UserGuid { get; set; }
        public string UserName => UserBussines.Get(UserGuid).Name;
        public EnNotePriority Priority { get; set; }
        public string PriorityName => Priority.GetDisplay();
        public EnNoteStatus NoteStatus { get; set; }
        public string StatusName => NoteStatus.GetDisplay();



        public static async Task<NoteBussines> GetAsync(Guid guid) => await UnitOfWork.Note.GetAsync(guid);

        public static async Task<List<NoteBussines>> GetAllAsync() => await UnitOfWork.Note.GetAllAsync();

        public static List<NoteBussines> GetAll() => AsyncContext.Run(GetAllAsync);

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

                res.AddReturnedValue(await UnitOfWork.Note.SaveAsync(this, tranName));
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

        public async Task<ReturnedSaveFuncInfo> ChangeStatusAsync(bool status, string tranName = "")
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = string.IsNullOrEmpty(tranName);
            if (autoTran) tranName = Guid.NewGuid().ToString();
            try
            {
                if (autoTran)
                { //BeginTransaction
                }


                res.AddReturnedValue(await UnitOfWork.Note.ChangeStatusAsync(this, status, tranName));
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

        public static List<NoteBussines> GetAll(string search, Guid userGuid, EnNoteStatus status,
            EnNotePriority priority) => AsyncContext.Run(() => GetAllAsync(search, userGuid, status, priority));

        public static NoteBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));
    }
}
