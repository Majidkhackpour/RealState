using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using Services;
using Services.DefaultCoding;
using Services.Interfaces.Building;

namespace EntityCache.Bussines
{
    public class ReceptionBussines : IReception
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; } = true;
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
                if (CheckList == null || CheckList.Count <= 0) return 0;
                return CheckList.Sum(q => q.Price);
            }
        }
        public decimal SumHavale
        {
            get
            {
                if (HavaleList == null || HavaleList.Count <= 0) return 0;
                return HavaleList.Sum(q => q.Price);
            }
        }
        public decimal SumNaqd
        {
            get
            {
                if (NaqdList == null || NaqdList.Count <= 0) return 0;
                return NaqdList.Sum(q => q.Price);
            }
        }
        public decimal Sum => SumCheck + SumNaqd + SumHavale;
        public int CountNaqd => NaqdList?.Count ?? 0;
        public int CountHavale => HavaleList?.Count ?? 0;
        public int CountCheck => CheckList?.Count() ?? 0;
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
        public static async Task<List<ReceptionBussines>> GetAllAsync() => await UnitOfWork.Reception.GetAllAsync();
        public static async Task<List<ReceptionBussines>> GetAllAsync(string search)
        {
            try
            {
                if (string.IsNullOrEmpty(search)) search = "";
                var res = await GetAllAsync();
                var searchItems = search.SplitString();
                if (searchItems?.Count > 0)
                    foreach (var item in searchItems)
                    {
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
            catch (OperationCanceledException)
            { return null; }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return new List<ReceptionBussines>();
            }
        }
        public static async Task<ReceptionBussines> GetAsync(Guid guid) => await UnitOfWork.Reception.GetAsync(guid);
        public static ReceptionBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));
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

                res.AddReturnedValue(CheckValidation());
                if (res.HasError) return res;

                res.AddReturnedValue(await UnitOfWork.Reception.SaveAsync(this, tranName));
                if (res.HasError) return res;

                res.AddReturnedValue(await ReceptionNaqdBussines.SaveRangeAsync(NaqdList));
                if (res.HasError) return res;
                res.AddReturnedValue(await ReceptionHavaleBussines.SaveRangeAsync(HavaleList));
                if (res.HasError) return res;
                res.AddReturnedValue(await ReceptionCheckBussines.SaveRangeAsync(CheckList));
                if (res.HasError) return res;

                var sanad = await GenerateSanadAsync();
                res.AddReturnedValue(await sanad.SaveAsync());
                if (res.HasError) return res;

                if (autoTran)
                {
                    //CommitTransAction
                }

                //if (Cache.IsSendToServer)
                //    _ = Task.Run(() => WebRental.SaveAsync(list));
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
        public async Task<ReturnedSaveFuncInfo> RemoveAsync(string tranName = "")
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = string.IsNullOrEmpty(tranName);
            if (autoTran) tranName = Guid.NewGuid().ToString();
            try
            {
                if (autoTran)
                { //BeginTransaction
                }

                res.AddReturnedValue(await UnitOfWork.Sanad.RemoveAsync(Guid, tranName));
                if (res.HasError) return res;
                if (autoTran)
                {
                    //CommitTransAction
                }

                //if (Cache.IsSendToServer)
                //    _ = Task.Run(() => WebRental.SaveAsync(list));
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
                    }

                if (NaqdList?.Count > 0)
                    foreach (var naghd in NaqdList)
                    {
                        if (naghd == null)
                        {
                            res.AddError("در لیست دریافتی های نقدی مقدار نال موجود میباشد");
                            continue;
                        }
                        if (naghd.SandouqTafsilGuid== Guid.Empty) res.AddError("حساب وارد شده جهت صندوق معتبر نمیباشد");
                        if (naghd.Price <= 0) res.AddError("مبلغ وارد شده جهت واریز به صندوق معتبر نمیباشد");
                    }

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
                    Status = true,
                    SanadStatus = EnSanadStatus.Temporary,
                    SanadType = EnSanadType.Auto
                };
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
                    Status = true,
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
                            Status = true,
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
                            Description = $"دریافت({null} {Description} {bank.Description})",
                            Guid = Guid.NewGuid(),
                            Modified = DateTime.Now,
                            Status = true,
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
                            Status = true,
                            MasterGuid = sanad.Guid
                        });
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return sanad;
        }
        public static async Task<long> NextCodeAsync() => await UnitOfWork.Reception.NextNumberAsync();
        public async Task<bool> CheckCodeAsync(Guid guid, long number) => await UnitOfWork.Reception.CheckCodeAsync(guid, number);
    }
}
