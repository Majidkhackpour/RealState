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
    public class PardakhtBussines : IPardakht
    {
        private decimal _sumCheckM = 0, _sumCheckSh = 0, _sumHavale = 0, _sumNaqd = 0, _sum = 0;

        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public ServerStatus ServerStatus { get; set; } = ServerStatus.None;
        public DateTime ServerDeliveryDate { get; set; } = DateTime.Now;
        public Guid TafsilGuid { get; set; }
        public string TafsilName { get; set; }
        public Guid MoeinGuid { get; set; }
        public string MoeinName { get; set; }
        public DateTime DateM { get; set; } = DateTime.Now;
        public string DateSh => Calendar.MiladiToShamsi(DateM);
        public string Description { get; set; }
        public Guid UserGuid { get; set; }
        public string UserName { get; set; }
        public long Number { get; set; }
        public long SanadNumber { get; set; }
        public List<PardakhtNaqdBussines> NaqdList { get; set; }
        public List<PardakhtHavaleBussines> HavaleList { get; set; }
        public List<PardakhtCheckShakhsiBussines> CheckShakhsiList { get; set; }
        public List<PardakhtCheckMoshtariBussines> CheckMoshtariList { get; set; }
        public decimal SumCheckMoshtari
        {
            get
            {
                _sumCheckM = CheckMoshtariList?.Sum(q => q.Price) ?? 0;
                return _sumCheckM;
            }
            set => _sumCheckM = value;
        }
        public decimal SumCheckShakhsi
        {
            get
            {
                _sumCheckSh = CheckShakhsiList?.Sum(q => q.Price) ?? 0;
                return _sumCheckSh;
            }
            set => _sumCheckSh = value;
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
                _sum = SumCheckMoshtari + SumNaqd + SumHavale + SumCheckShakhsi;
                return _sum;
            }
            set => _sum = value;
        }

        public int CountNaqd => NaqdList?.Count ?? 0;
        public int CountHavale => HavaleList?.Count ?? 0;
        public int CountCheckMoshtari => CheckMoshtariList?.Count() ?? 0;
        public int CountCheckShakhsi => CheckShakhsiList?.Count() ?? 0;
        public bool IsModified { get; set; } = false;

        public void ListBankClear() => HavaleList?.Clear();
        public void ListNaghdClear() => NaqdList?.Clear();
        public void ListCheckShakhsiClear() => CheckShakhsiList?.Clear();
        public void ListCheckMoshtariClear() => CheckMoshtariList?.Clear();
        public void RemoveFromDetList<T>(T item)
        {
            try
            {
                switch (item)
                {
                    case PardakhtNaqdBussines naghd:
                        var itemNaghd = NaqdList?.FirstOrDefault(p => p.Guid == naghd.Guid);
                        if (itemNaghd != null) NaqdList.Remove(itemNaghd);
                        break;
                    case PardakhtCheckShakhsiBussines check:
                        var itemCheckSh = CheckShakhsiList?.FirstOrDefault(p => p.Guid == check.Guid);
                        if (itemCheckSh != null) CheckShakhsiList?.Remove(itemCheckSh);
                        break;
                    case PardakhtCheckMoshtariBussines check:
                        var itemCheckM = CheckMoshtariList?.FirstOrDefault(p => p.Guid == check.Guid);
                        if (itemCheckM != null) CheckMoshtariList?.Remove(itemCheckM);
                        break;
                    case PardakhtHavaleBussines havale:
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
                    case PardakhtNaqdBussines naghd:
                        if (NaqdList == null) NaqdList = new List<PardakhtNaqdBussines>();
                        if (NaqdList.All(p => p.Guid != naghd.Guid))
                        {
                            naghd.MasterGuid = Guid;
                            NaqdList.Add(naghd);
                        }
                        break;
                    case PardakhtCheckShakhsiBussines check:
                        if (CheckShakhsiList == null) CheckShakhsiList = new List<PardakhtCheckShakhsiBussines>();
                        if (CheckShakhsiList.All(p => p.Guid != check.Guid))
                        {
                            check.MasterGuid = Guid;
                            CheckShakhsiList.Add(check);
                        }
                        break;
                    case PardakhtCheckMoshtariBussines check:
                        if (CheckMoshtariList == null) CheckMoshtariList = new List<PardakhtCheckMoshtariBussines>();
                        if (CheckMoshtariList.All(p => p.Guid != check.Guid))
                        {
                            check.MasterGuid = Guid;
                            CheckMoshtariList.Add(check);
                        }
                        break;
                    case PardakhtHavaleBussines havale:
                        if (HavaleList == null) HavaleList = new List<PardakhtHavaleBussines>();
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
        public string CheckShDesc => $"{NumberToString.Num2Str(CountCheckShakhsi.ToString())} فقره - جمع: {NumberToString.Num2Str(SumCheckShakhsi.ToString())} ریال";
        public string CheckMDesc => $"{NumberToString.Num2Str(CountCheckMoshtari.ToString())} فقره - جمع: {NumberToString.Num2Str(SumCheckMoshtari.ToString())} ریال";
        public static async Task<List<PardakhtBussines>> GetAllAsync(CancellationToken token) => await UnitOfWork.Pardakht.GetAllAsync(Cache.ConnectionString, token);
        public static async Task<List<PardakhtBussines>> GetAllAsync(string search, CancellationToken token)
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
                                                 x.SumCheckShakhsi.ToString().ToLower().Contains(item.ToLower()) ||
                                                 x.SumCheckMoshtari.ToString().ToLower().Contains(item.ToLower()) ||
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
                return new List<PardakhtBussines>();
            }
        }
        public static async Task<PardakhtBussines> GetAsync(Guid guid) => await UnitOfWork.Pardakht.GetAsync(Cache.ConnectionString, guid);
        public static PardakhtBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));
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

                var oldPardakht = await GetAsync(Guid);
                if (oldPardakht != null)
                {
                    var checkSh = await PardakhtCheckShakhsiBussines.GetAllAsync(Guid);
                    if (checkSh != null && checkSh.Count > 0)
                    {
                        foreach (var item in checkSh)
                        {
                            var check = await CheckPageBussines.GetAsync(item.CheckPageGuid);
                            if (check == null) continue;
                            check.CheckStatus = EnCheckSh.Mojoud;
                            check.DatePardakht = null;
                            check.DateSarresid = null;
                            check.Description = "";
                            check.Modified = DateTime.Now;
                            check.Price = 0;
                            check.ReceptorGuid = null;
                            res.AddReturnedValue(await check.SaveAsync(tr));
                            if (res.HasError) return res;
                        }
                    }

                    var checkM = await PardakhtCheckMoshtariBussines.GetAllAsync(Guid);
                    if (checkM != null && checkM.Count > 0)
                    {
                        foreach (var item in checkM)
                        {
                            var check = await ReceptionCheckBussines.GetAsync(item.CheckGuid);
                            if (check == null) continue;
                            check.CheckStatus = EnCheckM.Mojoud;
                            check.Modified = DateTime.Now;
                            if (check.isAvalDore) check.MasterGuid = null;
                            res.AddReturnedValue(await check.SaveAsync(tr));
                            if (res.HasError) return res;
                        }
                    }
                }

                res.AddReturnedValue(CheckValidation());
                if (res.HasError) return res;

                res.AddReturnedValue(await UnitOfWork.Pardakht.SaveAsync(this, tr));
                if (res.HasError) return res;

                res.AddReturnedValue(await PardakhtNaqdBussines.RemoveRangeAsync(Guid, tr));
                if (res.HasError) return res;
                res.AddReturnedValue(await PardakhtNaqdBussines.SaveRangeAsync(NaqdList, tr));
                if (res.HasError) return res;

                res.AddReturnedValue(await PardakhtHavaleBussines.RemoveRangeAsync(Guid, tr));
                if (res.HasError) return res;
                res.AddReturnedValue(await PardakhtHavaleBussines.SaveRangeAsync(HavaleList, tr));
                if (res.HasError) return res;

                res.AddReturnedValue(await PardakhtCheckShakhsiBussines.RemoveRangeAsync(Guid, tr));
                if (res.HasError) return res;
                res.AddReturnedValue(await PardakhtCheckShakhsiBussines.SaveRangeAsync(CheckShakhsiList, tr));
                if (res.HasError) return res;

                if (CheckShakhsiList?.Count > 0)
                {
                    foreach (var item in CheckShakhsiList)
                    {
                        var checkPage = await CheckPageBussines.GetAsync(item.CheckPageGuid);
                        checkPage.CheckStatus = EnCheckSh.KharjShode;
                        checkPage.DatePardakht = DateTime.Now;
                        checkPage.DateSarresid = item.DateSarResid;
                        checkPage.Description = item.Description;
                        checkPage.Modified = DateTime.Now;
                        checkPage.Price = item.Price;
                        checkPage.ReceptorGuid = TafsilGuid;
                        res.AddReturnedValue(await checkPage.SaveAsync(tr));
                        if (res.HasError) return res;
                    }
                }

                res.AddReturnedValue(await PardakhtCheckMoshtariBussines.RemoveRangeAsync(Guid, tr));
                if (res.HasError) return res;
                res.AddReturnedValue(await PardakhtCheckMoshtariBussines.SaveRangeAsync(CheckMoshtariList, tr));
                if (res.HasError) return res;

                if (CheckMoshtariList?.Count > 0)
                {
                    foreach (var item in CheckMoshtariList)
                    {
                        var rec = await ReceptionCheckBussines.GetAsync(item.CheckGuid);
                        rec.CheckStatus = EnCheckM.Kharj;
                        rec.Modified = DateTime.Now;
                        res.AddReturnedValue(await rec.SaveAsync(tr));
                        if (res.HasError) return res;
                    }
                }

                var sanad = await GenerateSanadAsync();
                res.AddReturnedValue(await sanad.SaveAsync(tr));
                if (res.HasError) return res;

                if (VersionAccess.Accounting)
                {
                    var action = IsModified ? EnLogAction.Update : EnLogAction.Insert;
                    res.AddReturnedValue(await UserLogBussines.SaveAsync(action, EnLogPart.Pardakht, tr));
                    if (res.HasError) return res;
                }

                if (Cache.IsSendToServer)
                    _ = Task.Run(() => WebPardakht.SaveAsync(PardakhtMapper.Instance.Map(this)));
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

                var oldPardakht = await GetAsync(Guid);
                if (oldPardakht != null)
                {
                    var checkSh = await PardakhtCheckShakhsiBussines.GetAllAsync(Guid);
                    if (checkSh != null && checkSh.Count > 0)
                    {
                        foreach (var item in checkSh)
                        {
                            var check = await CheckPageBussines.GetAsync(item.CheckPageGuid);
                            if (check == null) continue;
                            check.CheckStatus = EnCheckSh.Mojoud;
                            check.DatePardakht = null;
                            check.DateSarresid = null;
                            check.Description = "";
                            check.Modified = DateTime.Now;
                            check.Price = 0;
                            check.ReceptorGuid = null;
                            res.AddReturnedValue(await check.SaveAsync(tr));
                            if (res.HasError) return res;
                        }
                    }

                    var checkM = await PardakhtCheckMoshtariBussines.GetAllAsync(Guid);
                    if (checkM != null && checkM.Count > 0)
                    {
                        foreach (var item in checkM)
                        {
                            var check = await ReceptionCheckBussines.GetAsync(item.CheckGuid);
                            if (check == null) continue;
                            check.CheckStatus = EnCheckM.Mojoud;
                            check.Modified = DateTime.Now;
                            if (check.isAvalDore) check.MasterGuid = null;
                            res.AddReturnedValue(await check.SaveAsync(tr));
                            if (res.HasError) return res;
                        }
                    }
                }

                res.AddReturnedValue(await PardakhtNaqdBussines.RemoveRangeAsync(Guid, tr));
                if (res.HasError) return res;

                res.AddReturnedValue(await PardakhtHavaleBussines.RemoveRangeAsync(Guid, tr));
                if (res.HasError) return res;

                res.AddReturnedValue(await PardakhtCheckMoshtariBussines.RemoveRangeAsync(Guid, tr));
                if (res.HasError) return res;

                res.AddReturnedValue(await PardakhtCheckShakhsiBussines.RemoveRangeAsync(Guid, tr));
                if (res.HasError) return res;

                res.AddReturnedValue(await UnitOfWork.Pardakht.RemoveAsync(Guid, tr));
                if (res.HasError) return res;

                var sanad = await SanadBussines.GetAsync(SanadNumber);
                if (sanad != null)
                {
                    res.AddReturnedValue(await sanad.RemoveAsync(tr));
                    if (res.HasError) return res;
                }

                if (VersionAccess.Accounting)
                {
                    res.AddReturnedValue(await UserLogBussines.SaveAsync(EnLogAction.Delete, EnLogPart.Pardakht, tr));
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
                            res.AddError("در لیست پرداختی های نقدی مقدار نال موجود میباشد");
                            continue;
                        }
                        if (naghd.SandouqTafsilGuid == Guid.Empty) res.AddError("حساب وارد شده جهت صندوق معتبر نمیباشد");
                        if (naghd.Price <= 0) res.AddError("مبلغ وارد شده جهت واریز به صندوق معتبر نمیباشد");
                        naghd.MasterGuid = Guid;
                    }

                if (CheckShakhsiList?.Count > 0)
                    foreach (var check in CheckShakhsiList)
                        check.MasterGuid = Guid;

                if (CheckMoshtariList?.Count > 0)
                    foreach (var check in CheckMoshtariList)
                        check.MasterGuid = Guid;

                if (TafsilGuid == Guid.Empty) res.AddError("ردیف طرف حساب انتخاب شده جهت صدور برگه پرداخت معتبر نمی باشد");
                if (Sum <= 0) res.AddError("برگه پرداخت با مبلغ صفر یا منفی قابل ثبت نمیباشد");
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
                    Description = $"پرداخت({Number}) {Description }",
                    Number = SanadNumber,
                    DateM = DateM,
                    UserGuid = UserGuid,
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    SanadStatus = EnSanadStatus.Temporary,
                    SanadType = EnSanadType.Auto
                };
                sanad.DetailClear();
                //طرف حساب بدهکار پرداخت
                sanad.AddToListSanad(new SanadDetailBussines()
                {
                    Credit = 0,
                    Debit = Sum,
                    MoeinGuid = ParentDefaults.MoeinCoding.CLSMoein30103,
                    TafsilGuid = TafsilGuid,
                    Description = $"پرداخت({ Number} {Description})",
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    MasterGuid = sanad.Guid
                });

                if (NaqdList?.Count > 0)
                    foreach (var naghd in NaqdList)
                        sanad.AddToListSanad(new SanadDetailBussines()
                        {
                            Credit = naghd.Price,
                            Debit = 0,
                            MoeinGuid = ParentDefaults.MoeinCoding.CLSMoein10102,
                            TafsilGuid = naghd.SandouqTafsilGuid,
                            Description = $"پرداخت({ Number} {Description} {naghd.Description})",
                            Guid = Guid.NewGuid(),
                            Modified = DateTime.Now,
                            MasterGuid = sanad.Guid
                        });

                if (HavaleList?.Count > 0)
                    foreach (var bank in HavaleList)
                        sanad.AddToListSanad(new SanadDetailBussines()
                        {
                            Credit = bank.Price,
                            Debit = 0,
                            MoeinGuid = ParentDefaults.MoeinCoding.CLSMoein10101,
                            TafsilGuid = bank.BankTafsilGuid,
                            Description = $"پرداخت({Number} {Description} {bank.Description})",
                            Guid = Guid.NewGuid(),
                            Modified = DateTime.Now,
                            MasterGuid = sanad.Guid
                        });

                if (CheckShakhsiList?.Count > 0)
                    foreach (var checkSh in CheckShakhsiList)
                    {
                        var checkPage = await CheckPageBussines.GetAsync(checkSh.CheckPageGuid);
                        var check = await DasteCheckBussines.GetAsync(checkPage.CheckGuid);
                        sanad.AddToListSanad(new SanadDetailBussines()
                        {
                            Credit = checkSh.Price,
                            Debit = 0,
                            MoeinGuid = ParentDefaults.MoeinCoding.CLSMoein30101,
                            TafsilGuid = check.BankGuid,
                            Description = $"پرداخت({Number} {Description} {checkSh.Description})",
                            Guid = Guid.NewGuid(),
                            Modified = DateTime.Now,
                            MasterGuid = sanad.Guid
                        });
                    }

                if (CheckMoshtariList?.Count > 0)
                    foreach (var checkM in CheckMoshtariList)
                    {
                        var rec = await ReceptionCheckBussines.GetAsync(checkM.CheckGuid);
                        sanad.AddToListSanad(new SanadDetailBussines()
                        {
                            Credit = checkM.Price,
                            Debit = 0,
                            MoeinGuid = rec.SandouqMoeinGuid,
                            TafsilGuid = rec.SandouqTafsilGuid,
                            Description = $"پرداخت({Number} {Description} {checkM.Description})",
                            Guid = Guid.NewGuid(),
                            Modified = DateTime.Now,
                            MasterGuid = sanad.Guid
                        });
                    }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return sanad;
        }
        public static async Task<long> NextCodeAsync() => await UnitOfWork.Pardakht.NextNumberAsync(Cache.ConnectionString);
        public async Task<bool> CheckCodeAsync(Guid guid, long number) => await UnitOfWork.Pardakht.CheckCodeAsync(Cache.ConnectionString, guid, number);
    }
}
