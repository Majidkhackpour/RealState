using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using PacketParser.Interfaces;
using Services;

namespace EntityCache.Bussines
{
    public class UserLogBussines : IUserLog
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public Guid UserGuid { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string DateSh => Calendar.MiladiToShamsi(Date);
        public string Time => Date.ToShortTimeString();
        public EnLogAction Action { get; set; }
        public string ActionName => Action.GetDisplay();
        public EnLogPart Part { get; set; }
        public string PartName => Part.GetDisplay();
        public string Description { get; set; }



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

                res.AddReturnedValue(await UnitOfWork.UserLog.SaveAsync(this, tranName));
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

        public ReturnedSaveFuncInfo Save(string tranName = "") => AsyncContext.Run(() => SaveAsync(tranName));

        public static async Task<List<UserLogBussines>> GetAllAsync(Guid userGuid, DateTime d1, DateTime d2) =>
            await UnitOfWork.UserLog.GetAllAsync(userGuid, d1, d2);

    }
}
