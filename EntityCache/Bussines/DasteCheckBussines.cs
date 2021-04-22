using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using Persistence;
using Services;
using Services.Interfaces.Building;

namespace EntityCache.Bussines
{
    public class DasteCheckBussines : IDasteCheck
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public ServerStatus ServerStatus { get; set; } = ServerStatus.None;
        public DateTime ServerDeliveryDate { get; set; } = DateTime.Now;
        public string SerialNumber { get; set; }
        public string Name => $"{BankName} سریال {SerialNumber} / {PageCount} برگی";
        public Guid BankGuid { get; set; }
        public string BankName { get; set; }
        public long FromNumber { get; set; }
        public long ToNumber { get; set; }
        public string Description { get; set; }
        public long PageCount => (ToNumber - FromNumber) + 1;
        public List<CheckPageBussines> CheckPages { get; set; }


        public static async Task<List<DasteCheckBussines>> GetAllAsync() => await UnitOfWork.DasteCheck.GetAllAsync(Cache.ConnectionString);
        public static async Task<List<DasteCheckBussines>> GetAllAsync(string search)
        {
            try
            {
                if (string.IsNullOrEmpty(search))
                    search = "";
                var res = await GetAllAsync();
                var searchItems = search.SplitString();
                if (searchItems?.Count > 0)
                    foreach (var item in searchItems)
                    {
                        if (!string.IsNullOrEmpty(item) && item.Trim() != "")
                        {
                            res = res.Where(x => x.SerialNumber.ToLower().Contains(item.ToLower()) ||
                                                 x.BankName.ToLower().Contains(item.ToLower()) ||
                                                 x.FromNumber.ToString().ToLower().Contains(item.ToLower()) ||
                                                 x.ToNumber.ToString().ToLower().Contains(item.ToLower()) ||
                                                 x.PageCount.ToString().ToLower().Contains(item.ToLower()) ||
                                                 x.Description.ToLower().Contains(item.ToLower()))
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
                return new List<DasteCheckBussines>();
            }
        }
        public static async Task<DasteCheckBussines> GetAsync(Guid guid) => await UnitOfWork.DasteCheck.GetAsync(Cache.ConnectionString, guid);
        public static DasteCheckBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));
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

                res.AddReturnedValue(CheckValidation());
                if (res.HasError) return res;
                res.AddReturnedValue(await CheckPageBussines.RemoveAllAsync(Guid, tr));
                if (res.HasError) return res;
                res.AddReturnedValue(await UnitOfWork.DasteCheck.SaveAsync(this, tr));
                if (res.HasError) return res;
                res.AddReturnedValue(await CheckPageBussines.SaveRangeAsync(CheckPages, tr));
                if (res.HasError) return res;

                //if (Cache.IsSendToServer)
                //    _ = Task.Run(() => WebUser.SaveAsync(this));
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
        public async Task<ReturnedSaveFuncInfo> ChangeStatusAsync(bool status, SqlTransaction tr = null)
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

                res.AddReturnedValue(await UnitOfWork.DasteCheck.ChangeStatusAsync(this, status, tr));
                if (res.HasError) return res;

                //if (Cache.IsSendToServer)
                //    _ = Task.Run(() => WebHazine.SaveAsync(this));
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
        private ReturnedSaveFuncInfo CheckValidation()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (string.IsNullOrEmpty(SerialNumber)) res.AddError("سریال دسته چک نمی تواند خالی باشد");
                if (BankGuid == Guid.Empty) res.AddError("بانک نمی تواند خالی باشد");
                if (FromNumber > ToNumber) res.AddError("شماره چک ها را صحیح وارد نمایید");
                if (CheckPages == null || CheckPages.Count <= 0) res.AddError("لطفا برگه چک ها را وارد نمایید");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return res;
        }
    }
}
