using EntityCache.Assistence;
using Nito.AsyncEx;
using Persistence;
using Services;
using Services.Interfaces.Building;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebHesabBussines;

namespace EntityCache.Bussines
{
    public class CalendarBussines : ICalendar
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public DateTime DateM { get; set; }
        public string DateSh => Calendar.MiladiToShamsi(DateM);
        public string DayName => Calendar.GetDayNameOfWeek(DateM);
        public string Monasebat { get; set; }
        public string Description { get; set; }
        public bool isTatil { get; set; }


        public static async Task<List<CalendarBussines>> GetAllAsync(CancellationToken token) => await UnitOfWork.Calendar.GetAllAsync(Cache.ConnectionString, token);
        public static async Task<ReturnedSaveFuncInfo> SaveRangeAsync(List<CalendarBussines> list, SqlTransaction tr = null)
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

                res.AddReturnedValue(await UnitOfWork.Calendar.SaveRangeAsync(list, tr));
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
        public static async Task<CalendarBussines> GetAsync(Guid guid) => await UnitOfWork.Calendar.GetAsync(Cache.ConnectionString, guid);
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

                res.AddReturnedValue(await UnitOfWork.Calendar.SaveAsync(this, tr));
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
        public static async Task<List<CalendarBussines>> GetAllAsync(string search, int year, CancellationToken token)
        {
            try
            {
                var startDate = Calendar.ShamsiToMiladi($"{year}/01/01");
                var d1 = new DateTime(startDate.Year, startDate.Month, startDate.Day, 0, 0, 0);
                var endDate = Calendar.ShamsiToMiladi($"{year}/12/29");
                var d2 = new DateTime(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59);
                if (string.IsNullOrEmpty(search)) search = "";
                var res = await GetAllAsync(token);
                res = res?.Where(q => q.DateM >= d1 && q.DateM <= d2)?.ToList();
                if (token.IsCancellationRequested) return null;
                var searchItems = search.SplitString();
                if (searchItems?.Count > 0)
                    foreach (var item in searchItems)
                    {
                        if (token.IsCancellationRequested) return null;
                        if (!string.IsNullOrEmpty(item) && item.Trim() != "")
                        {
                            res = res.Where(x => x.Monasebat.ToLower().Contains(item.ToLower()) ||
                                                 x.Description.ToLower().Contains(item.ToLower()))
                                ?.ToList();
                        }
                    }

                res = res?.OrderBy(o => o.DateM).ToList();
                return res;
            }
            catch (TaskCanceledException) { return null; }
            catch (OperationCanceledException) { return null; }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return new List<CalendarBussines>();
            }
        }
        public static CalendarBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));
        public async Task<ReturnedSaveFuncInfo> RemoveAsync(SqlTransaction tr = null)
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

                res.AddReturnedValue(await UnitOfWork.Calendar.RemoveAsync(Guid, tr));
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
        public static async Task<ReturnedSaveFuncInfo> RemoveAllAsync(SqlTransaction tr = null)
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

                res.AddReturnedValue(await UnitOfWork.Calendar.RemoveAllAsync(tr));
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
        public static async Task<ReturnedSaveFuncInfo> SaveFromServerAsync()
        {
            var res = new ReturnedSaveFuncInfo();
            SqlConnection cn = null;
            SqlTransaction tr = null;
            try
            {
                cn = new SqlConnection(Cache.ConnectionString);

                var list = await WebCalendar.GetAllAsync();
                res.AddReturnedValue(list);
                if (res.HasError) return res;
                if (list.value == null || list.value.Count <= 0) return res;

                await cn.OpenAsync();
                tr = cn.BeginTransaction();

                var listBus = new List<CalendarBussines>();

                foreach (var item in list.value)
                {
                    listBus.Add(new CalendarBussines()
                    {
                        Guid = Guid.NewGuid(),
                        Modified = DateTime.Now,
                        Description = item.Description,
                        DateM = item.DateM,
                        Monasebat = item.Monasebat,
                        isTatil = item.STRasmi
                    });
                }

                res.AddReturnedValue(await RemoveAllAsync(tr));
                if (res.HasError) return res;
                res.AddReturnedValue(await SaveRangeAsync(listBus, tr));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                res.AddReturnedValue(tr.TransactionDestiny(res.HasError));
                res.AddReturnedValue(cn.CloseConnection());
            }
            return res;
        }
    }
}
