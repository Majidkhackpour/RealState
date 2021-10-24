using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EntityCache.Assistence;
using EntityCache.Mppings;
using Nito.AsyncEx;
using Persistence;
using Services;
using Services.DefaultCoding;
using Services.Interfaces.Building;
using WebHesabBussines;

namespace EntityCache.Bussines
{
    public class ReceptionBussines : IReception
    {
        private decimal _sumCheck = 0, _sumHavale = 0, _sumNaqd = 0, _sum = 0;

        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public ServerStatus ServerStatus { get; set; } = ServerStatus.None;
        public DateTime ServerDeliveryDate { get; set; } = DateTime.Now;
        public long Number { get; set; }
        public DateTime DateM { get; set; } = DateTime.Now;
        public string DateSh => Calendar.MiladiToShamsi(DateM);
        public string Description { get; set; }
        public Guid TafsilGuid { get; set; }
        public string TafsilName { get; set; }
        public Guid MoeinGuid { get; set; }
        public Guid UserGuid { get; set; }
        public string UserName { get; set; }
        public long SanadNumber { get; set; }
        public decimal SumCheck
        {
            get
            {
                _sumCheck = CheckList?.Sum(q => q.Price) ?? 0;
                return _sumCheck;
            }
            set => _sumCheck = value;
        }
        public decimal SumHavale
        {
            get
            {
                _sumHavale = HavaleList?.Sum(q => q.Price) ?? 0;
                return _sumHavale;
            }
            set => _sumHavale = value;
        }
        public decimal SumNaqd
        {
            get
            {
                _sumNaqd = NaqdList?.Sum(q => q.Price) ?? 0;
                return _sumNaqd;
            }
            set => _sumNaqd = value;
        }
        public decimal Sum
        {
            get
            {
                _sum = SumCheck + SumNaqd + SumHavale;
                return _sum;
            }
            set => _sum = value;
        }
        public int CountNaqd => NaqdList?.Count ?? 0;
        public int CountHavale => HavaleList?.Count ?? 0;
        public int CountCheck => CheckList?.Count() ?? 0;
        public bool IsModified { get; set; } = false;
        public List<ReceptionCheckBussines> CheckList { get; set; }
        public List<ReceptionHavaleBussines> HavaleList { get; set; }
        public List<ReceptionNaqdBussines> NaqdList { get; set; }


        public void ListBankClear() => HavaleList?.Clear();
        public void ListNaghdClear() => NaqdList?.Clear();
        public void ListCheckClear() => CheckList?.Clear();
        public void RemoveFromDetList<T>(T item)
        {
            try
            {
                switch (item)
                {
                    case ReceptionNaqdBussines naghd:
                        var itemNaghd = NaqdList?.FirstOrDefault(p => p.Guid == naghd.Guid);
                        if (itemNaghd != null) NaqdList.Remove(itemNaghd);
                        break;
                    case ReceptionCheckBussines check:
                        var itemCheck = CheckList?.FirstOrDefault(p => p.Guid == check.Guid);
                        if (itemCheck != null) CheckList?.Remove(itemCheck);
                        break;
                    case ReceptionHavaleBussines havale:
                        var itemHavale = HavaleList?.FirstOrDefault(p => p.Guid == havale.Guid);
                        if (itemHavale != null) HavaleList.Remove(itemHavale);
                        break;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public void AddToDetList<T>(T item)
        {
            try
            {
                if (item == null) return;
                switch (item)
                {
                    case ReceptionNaqdBussines naghd:
                        if (NaqdList == null) NaqdList = new List<ReceptionNaqdBussines>();
                        if (NaqdList.All(p => p.Guid != naghd.Guid))
                        {
                            naghd.MasterGuid = Guid;
                            NaqdList.Add(naghd);
                        }
                        break;
                    case ReceptionCheckBussines check:
                        if (CheckList == null) CheckList = new List<ReceptionCheckBussines>();
                        if (CheckList.All(p => p.Guid != check.Guid))
                        {
                            check.MasterGuid = Guid;
                            CheckList.Add(check);
                        }
                        break;
                    case ReceptionHavaleBussines havale:
                        if (HavaleList == null) HavaleList = new List<ReceptionHavaleBussines>();
                        if (HavaleList.All(p => p.Guid != havale.Guid))
                        {
                            havale.MasterGuid = Guid;
                            HavaleList.Add(havale);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public void AddRangeToDetList<T>(List<T> detList)
        {
            try
            {
                if (detList == null || detList.Count <= 0) return;
                foreach (var item in detList)
                    AddToDetList(item);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public string NaqdDesc => $"{NumberToString.Num2Str(CountNaqd.ToString())} فقره - جمع: {NumberToString.Num2Str(SumNaqd.ToString())} ریال";
        public string HavaleDesc => $"{NumberToString.Num2Str(CountHavale.ToString())} فقره - جمع: {NumberToString.Num2Str(SumHavale.ToString())} ریال";
        public string CheckDesc => $"{NumberToString.Num2Str(CountCheck.ToString())} فقره - جمع: {NumberToString.Num2Str(SumCheck.ToString())} ریال";
        public static async Task<List<ReceptionBussines>> GetAllAsync(CancellationToken token) => await UnitOfWork.Reception.GetAllAsync(Cache.ConnectionString, token);
        public static async Task<List<ReceptionBussines>> GetAllAsync(string search, CancellationToken token)
        {
            try
            {
                if (string.IsNullOrEmpty(search)) search = "";
                var res = await GetAllAsync(token);
                if (token.IsCancellationRequested) return null;
                var searchItems = search.SplitString();
                if (searchItems?.Count > 0)
                    foreach (var item in searchItems)
                    {
                        if (token.IsCancellationRequested) return null;
                        if (!string.IsNullOrEmpty(item) && item.Trim() != "")
                        {
                            res = res.Where(x => x.Number.ToString().ToLower().Contains(item.ToLower()) ||
                                                 x.TafsilName.ToLower().Contains(item.ToLower()) ||
                                                 x.Description.ToLower().Contains(item.ToLower()) ||
                                                 x.Sum.ToString().ToLower().Contains(item.ToLower()) ||
                                                 x.SumHavale.ToString().ToLower().Contains(item.ToLower()) ||
                                                 x.SumCheck.ToString().ToLower().Contains(item.ToLower()) ||
                                                 x.SumNaqd.ToString().ToLower().Contains(item.ToLower()) ||
                                                 x.UserName.ToLower().Contains(item.ToLower()))
                                ?.ToList();
                        }
                    }

                res = res?.OrderByDescending(o => o.Number).ToList();
                return res;
            }
            catch (TaskCanceledException) { return null; }
            catch (OperationCanceledException) { return null; }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return new List<ReceptionBussines>();
            }
        }
        public static async Task<ReceptionBussines> GetAsync(Guid guid) => await UnitOfWork.Reception.GetAsync(Cache.ConnectionString, guid);
        public static ReceptionBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));
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

                res.AddReturnedValue(await UnitOfWork.Reception.SaveAsync(this, tr));
                if (res.HasError) return res;

                res.AddReturnedValue(await ReceptionNaqdBussines.RemoveRangeAsync(Guid, tr));
                if (res.HasError) return res;
                res.AddReturnedValue(await ReceptionNaqdBussines.SaveRangeAsync(NaqdList, tr));
                if (res.HasError) return res;

                res.AddReturnedValue(await ReceptionHavaleBussines.RemoveRangeAsync(Guid, tr));
                if (res.HasError) return res;
                res.AddReturnedValue(await ReceptionHavaleBussines.SaveRangeAsync(HavaleList, tr));
                if (res.HasError) return res;

                res.AddReturnedValue(await ReceptionCheckBussines.RemoveRangeAsync(Guid, tr));
                if (res.HasError) return res;
                res.AddReturnedValue(await ReceptionCheckBussines.SaveRangeAsync(CheckList, tr));
                if (res.HasError) return res;

                var sanad = await GenerateSanadAsync();
                res.AddReturnedValue(await sanad.SaveAsync(tr));
                if (res.HasError) return res;

                if (VersionAccess.Accounting)
                {
                    var action = IsModified ? EnLogAction.Update : EnLogAction.Insert;
                    res.AddReturnedValue(await UserLogBussines.SaveAsync(action, EnLogPart.Reception, tr));
                    if (res.HasError) return res;
                }

                if (Cache.IsSendToServer)
                    _ = Task.Run(() => WebReception.SaveAsync(ReceptionMapper.Instance.Map(this)));
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

                res.AddReturnedValue(await ReceptionNaqdBussines.RemoveRangeAsync(Guid, tr));
                if (res.HasError) return res;

                res.AddReturnedValue(await ReceptionHavaleBussines.RemoveRangeAsync(Guid, tr));
                if (res.HasError) return res;

                res.AddReturnedValue(await ReceptionCheckBussines.RemoveRangeAsync(Guid, tr));
                if (res.HasError) return res;

                res.AddReturnedValue(await UnitOfWork.Reception.RemoveAsync(Guid, tr));
                if (res.HasError) return res;

                var sanad = await SanadBussines.GetAsync(SanadNumber);
                if (sanad != null)
                {
                    res.AddReturnedValue(await sanad.RemoveAsync(tr));
                    if (res.HasError) return res;
                }

                if (VersionAccess.Accounting)
                {
                    res.AddReturnedValue(await UserLogBussines.SaveAsync(EnLogAction.Delete, EnLogPart.Reception, tr));
                    if (res.HasError) return res;
                }

                //if (Cache.IsSendToServer)
                //    _ = Task.Run(() => WebRental.SaveAsync(list));
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
        public ReturnedSaveFuncInfo CheckValidation()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (HavaleList?.Count > 0)
                    foreach (var bank in HavaleList)
                    {
                        if (bank == null)
                        {
                            res.AddError("در لیست حواله ها مقدار نال موجود میباشد");
                            continue;
                        }
                        if (bank.BankTafsilGuid == Guid.Empty) res.AddError("حساب وارد شده جهت بانک معتبر نمیباشد");
                        if (bank.Price <= 0) res.AddError("مبلغ وارد شده جهت حواله بانکی معتبر نمیباشد");
                        bank.MasterGuid = Guid;
                    }

                if (NaqdList?.Count > 0)
                    foreach (var naghd in NaqdList)
                    {
                        if (naghd == null)
                        {
                            res.AddError("در لیست دریافتی های نقدی مقدار نال موجود میباشد");
                            continue;
                        }
                        if (naghd.SandouqTafsilGuid == Guid.Empty) res.AddError("حساب وارد شده جهت صندوق معتبر نمیباشد");
                        if (naghd.Price <= 0) res.AddError("مبلغ وارد شده جهت واریز به صندوق معتبر نمیباشد");
                        naghd.MasterGuid = Guid;
                    }

                if (CheckList?.Count > 0)
                    foreach (var check in CheckList)
                        check.MasterGuid = Guid;

                if (TafsilGuid == Guid.Empty) res.AddError("ردیف طرف حساب انتخاب شده جهت صدور برگه دریافت معتبر نمی باشد");
                if (Sum <= 0) res.AddError("برگه دریافت با مبلغ صفر یا منفی قابل ثبت نمیباشد");
                if (Guid == Guid.Empty) Guid = Guid.NewGuid();
            }
            catch (Exception ex)
            {
                res.AddReturnedValue(ex);
            }
            return res;
        }
        public async Task<SanadBussines> GenerateSanadAsync()
        {
            SanadBussines sanad = null;
            try
            {
                sanad = await SanadBussines.GetAsync(SanadNumber) ?? new SanadBussines()
                {
                    Description = $"دریافت({Number}) {Description }",
                    Number = SanadNumber,
                    DateM = DateM,
                    UserGuid = UserGuid,
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    SanadStatus = EnSanadStatus.Temporary,
                    SanadType = EnSanadType.Auto
                };
                sanad.DetailClear();
                //طرف حساب بستانکار دریافت
                sanad.AddToListSanad(new SanadDetailBussines()
                {
                    Credit = Sum,
                    Debit = 0,
                    MoeinGuid = ParentDefaults.MoeinCoding.CLSMoein10304,
                    TafsilGuid = TafsilGuid,
                    Description = $"دریافت({ Number} {Description})",
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    MasterGuid = sanad.Guid
                });

                if (NaqdList?.Count > 0)
                    foreach (var naghd in NaqdList)
                        sanad.AddToListSanad(new SanadDetailBussines()
                        {
                            Credit = 0,
                            Debit = naghd.Price,
                            MoeinGuid = ParentDefaults.MoeinCoding.CLSMoein10102,
                            TafsilGuid = naghd.SandouqTafsilGuid,
                            Description = $"دریافت({ Number} {Description} {naghd.Description})",
                            Guid = Guid.NewGuid(),
                            Modified = DateTime.Now,
                            MasterGuid = sanad.Guid
                        });

                if (HavaleList?.Count > 0)
                    foreach (var bank in HavaleList)
                        sanad.AddToListSanad(new SanadDetailBussines()
                        {
                            Credit = 0,
                            Debit = bank.Price,
                            MoeinGuid = ParentDefaults.MoeinCoding.CLSMoein10101,
                            TafsilGuid = bank.BankTafsilGuid,
                            Description = $"دریافت({Number} {Description} {bank.Description})",
                            Guid = Guid.NewGuid(),
                            Modified = DateTime.Now,
                            MasterGuid = sanad.Guid
                        });

                if (CheckList?.Count > 0)
                    foreach (var check in CheckList)
                        sanad.AddToListSanad(new SanadDetailBussines()
                        {
                            Credit = 0,
                            Debit = check.Price,
                            MoeinGuid = ParentDefaults.MoeinCoding.CLSMoein10104,
                            TafsilGuid = check.SandouqTafsilGuid,
                            Description = $"دریافت({ Number} {Description} {check.Description})",
                            Guid = Guid.NewGuid(),
                            Modified = DateTime.Now,
                            MasterGuid = sanad.Guid
                        });
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return sanad;
        }
        public static async Task<long> NextCodeAsync() => await UnitOfWork.Reception.NextNumberAsync(Cache.ConnectionString);
        public async Task<bool> CheckCodeAsync(Guid guid, long number) => await UnitOfWork.Reception.CheckCodeAsync(Cache.ConnectionString, guid, number);
    }
}
