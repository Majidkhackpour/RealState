using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Persistence;
using Services;
using Servicess.Interfaces.Building;

namespace EntityCache.Bussines
{
    public class PeoplesBankAccountBussines : IPeopleBankAccount
    {
        public Guid Guid { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string Shobe { get; set; }
        public Guid ParentGuid { get; set; }


        public static async Task<List<PeoplesBankAccountBussines>> GetAllAsync(Guid parentGuid) =>
            await UnitOfWork.PeopleBankAccount.GetAllAsync(Cache.ConnectionString, parentGuid);
        public static async Task<List<PeoplesBankAccountBussines>> GetAllAsync(Guid parentGuid, string search)
        {
            try
            {
                if (string.IsNullOrEmpty(search))
                    search = "";
                var res = await GetAllAsync(parentGuid);
                var searchItems = search.SplitString();
                if (searchItems?.Count > 0)
                    foreach (var item in searchItems)
                    {
                        if (!string.IsNullOrEmpty(item) && item.Trim() != "")
                        {
                            res = res.Where(x => x.BankName.ToLower().Contains(item.ToLower()) ||
                                                 x.Shobe.ToLower().Contains(item.ToLower()) ||
                                                 x.AccountNumber.ToLower().Contains(item.ToLower()))
                                ?.ToList();
                        }
                    }

                res = res?.OrderBy(o => o.BankName).ToList();
                return res;
            }
            catch (OperationCanceledException)
            { return null; }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return new List<PeoplesBankAccountBussines>();
            }
        }
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

                res.AddReturnedValue(await UnitOfWork.PeopleBankAccount.SaveAsync(this, tr));
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
        public static async Task<ReturnedSaveFuncInfo> SaveRangeAsync(List<PeoplesBankAccountBussines> list, SqlTransaction tr = null)
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

                res.AddReturnedValue(await UnitOfWork.PeopleBankAccount.SaveRangeAsync(list, tr));
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
        public static async Task<ReturnedSaveFuncInfo> RemoveAsync(Guid parentGuid, SqlTransaction tr = null)
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

                res.AddReturnedValue(await UnitOfWork.PeopleBankAccount.RemoveAsync(parentGuid, tr));
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
