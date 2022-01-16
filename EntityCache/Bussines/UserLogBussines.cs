using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Persistence;
using Services;
using Servicess.Interfaces.Building;

namespace EntityCache.Bussines
{
    public class UserLogBussines : IUserLog
    {
        public Guid Guid { get; set; }
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
        public Guid? BuildingGuid { get; set; }


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

                res.AddReturnedValue(await UnitOfWork.UserLog.SaveAsync(this, tr));
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
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(EnLogAction action, EnLogPart part, Guid? objGuid, string desc, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = tr == null;
            SqlConnection cn = null;
            try
            {
                if (UserBussines.CurrentUser == null) return res;
                if (autoTran)
                {
                    cn = new SqlConnection(Cache.ConnectionString);
                    await cn.OpenAsync();
                    tr = cn.BeginTransaction();
                }

                var log = new UserLogBussines
                {
                    Guid = Guid.NewGuid(),
                    UserGuid = UserBussines.CurrentUser.Guid,
                    Action = action,
                    Part = part,
                    BuildingGuid = objGuid,
                    Date = DateTime.Now,
                    Description = string.IsNullOrEmpty(desc)
                        ? $"انجام عملیات {action.GetDisplay()} در بخش {part.GetDisplay()} در تاریخ {Calendar.MiladiToShamsi(DateTime.Now)} در ساعت {DateTime.Now.ToShortTimeString()}"
                        : desc
                };
                res.AddReturnedValue(await UnitOfWork.UserLog.SaveAsync(log, tr));
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
        public static async Task<List<UserLogBussines>> GetAllAsync(Guid userGuid, DateTime d1, DateTime d2) =>
            await UnitOfWork.UserLog.GetAllAsync(Cache.ConnectionString, userGuid, d1, d2);
        public static async Task<ReturnedSaveFuncInfo> SaveBuildingLogAsync(EnLogAction action, Guid buGuid, string desc, SqlTransaction tr = null)
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = tr == null;
            SqlConnection cn = null;
            try
            {
                if (UserBussines.CurrentUser == null) return res;
                if (autoTran)
                {
                    cn = new SqlConnection(Cache.ConnectionString);
                    await cn.OpenAsync();
                    tr = cn.BeginTransaction();
                }
                var log = new UserLogBussines
                {
                    Guid = Guid.NewGuid(),
                    UserGuid = UserBussines.CurrentUser.Guid,
                    Description = desc,
                    Action = action,
                    Part = EnLogPart.Building,
                    BuildingGuid = buGuid,
                    Date = DateTime.Now
                };
                res.AddReturnedValue(await UnitOfWork.UserLog.SaveAsync(log, tr));
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
        public static async Task<List<UserLogBussines>> GetBuildingLogAsync(Guid buGuid) => await UnitOfWork.UserLog.GetBuildingLogAsync(Cache.ConnectionString, buGuid);
    }
}
