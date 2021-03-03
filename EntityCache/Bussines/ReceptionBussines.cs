using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using Services;
using Services.Interfaces.Building;

namespace EntityCache.Bussines
{
    public class ReceptionBussines : IReception
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public long Number { get; set; }
        public DateTime DateM { get; set; }
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


        public static async Task<List<ReceptionBussines>> GetAllAsync() => await UnitOfWork.Reception.GetAllAsync();
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

                res.AddReturnedValue(await UnitOfWork.Reception.SaveAsync(this, tranName));
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
        public async Task<ReturnedSaveFuncInfo> CheckValidationAsync()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                //ChangeIntegrity.CheckChangesValidation(res, this);
                //if (ListBank?.Count > 0)
                //    foreach (var bank in ListBank)
                //    {
                //        if (bank == null)
                //        {
                //            res.AddReturnedValue(ReturnedState.Error, "در لیست حواله ها مقدار نال موجود میباشد.");
                //            continue;
                //        }
                //        if (bank.TafsilGuid == Guid.Empty || (bank.bankInfo?.HType != HesabType.Bank))
                //            res.AddReturnedValue(ReturnedState.Error, "حساب وارد شده جهت بانک معتبر نمیباشد.");
                //        if (bank.Price <= 0)
                //            res.AddReturnedValue(ReturnedState.Error, "مبلغ وارد شده جهت حواله بانکی معتبر نمیباشد.");
                //    }

                //if (ListNaghd?.Count > 0)
                //    foreach (var naghd in ListNaghd)
                //    {
                //        if (naghd == null)
                //        {
                //            res.AddReturnedValue(ReturnedState.Error, "در لیست در یافتی های نقدی مقدار نال موجود میباشد.");
                //            continue;
                //        }
                //        if (naghd.sandoghInfo?.HType != HesabType.Sandogh)
                //            res.AddReturnedValue(ReturnedState.Error, "حساب وارد شده جهت صندوق معتبر نمیباشد.");
                //        if (naghd.Price <= 0)
                //            res.AddReturnedValue(ReturnedState.Error, "مبلغ وارد شده جهت واریز به صندوق بانکی معتبر نمیباشد.");
                //    }

                //if (Date < new DateTime(2010, 01, 01) || Date > new DateTime(2099, 01, 01))
                //    res.AddReturnedValue(ReturnedState.Error, "تاریخ وارد شده جهت برگه دریافت معتبر نمی باشد");
                //if (TafsilGuid == Guid.Empty)
                //    res.AddReturnedValue(ReturnedState.Error, "ردیف طرف حساب انتخاب شده جهت صدور برگه دریافت معتبر نمی باشد");
                //if (UserGuid == Guid.Empty)
                //    res.AddReturnedValue(ReturnedState.Error, "ردیف کاربر انتخاب شده جهت برگه دریافت معتبر نمی باشد");
                //if (Sum <= 0)
                //    res.AddReturnedValue(ReturnedState.Error, "برگه دریافت با مبلغ صفر یا منفی قابل ثبت نمیباشد.");
                //if (Guid == null || Guid == Guid.Empty)
                //    Guid = Guid.NewGuid();
            }
            catch (Exception ex)
            {
                res.AddReturnedValue(ex);
            }
            return res;
        }
        public SanadBussines GenerateSanad()
        {
            var sanad = new SanadBussines();
            //{
            //    Description = $"دریافت({Id2}) {Description }",
            //    SanadNo = SanadNo,
            //    DateM = Date,
            //    UserGuid = UserGuid
            //};
            try
            {
                //طرف حساب بستانکار دریافت
                //sanad.AddToListSanad(new Sanad_DetBusiness()
                //{
                //    Credit = Sum,
                //    Debit = 0,
                //    MoeinGuid = MoeinGuid,
                //    TafsilGuid = TafsilGuid,
                //    Description = $"دریافت({ Id2} {Description})",
                //    DecimalGuid = Guid.Empty,
                //    Guid = Guid.NewGuid(),
                //    Qt = 0
                //});

                //if (ListNaghd?.Count > 0)
                //    foreach (ReceptionNaghdBusiness naghd in ListNaghd)
                //        sanad.AddToListSanad(new Sanad_DetBusiness()
                //        {
                //            Credit = 0,
                //            Debit = naghd.Price,
                //            MoeinGuid = naghd.MoeinGuid,
                //            TafsilGuid = naghd.TafsilGuid,
                //            Description = $"دریافت({ Id2} {Description} {naghd.Description})",
                //            DecimalGuid = naghd.DecimalGuid,
                //            Guid = naghd.Guid,
                //            Qt = 0
                //        });

                //if (ListBank?.Count > 0)
                //    foreach (ReceptionHavaleBusiness bank in ListBank)
                //        sanad.AddToListSanad(new Sanad_DetBusiness()
                //        {
                //            Credit = 0,
                //            Debit = bank.Price,
                //            MoeinGuid = bank.MoeinGuid,
                //            TafsilGuid = bank.TafsilGuid,
                //            Description = $"دریافت({Id2} {Description} {bank.Description})",
                //            DecimalGuid = bank.DecimalGuid,
                //            Guid = Guid.NewGuid(),
                //            Qt = bank.Qt
                //        });

                //if (ListCheck?.Count > 0)
                //    foreach (ReceptionCheckBusiness check in ListCheck)
                //        sanad.AddToListSanad(new Sanad_DetBusiness()
                //        {
                //            Credit = 0,
                //            Debit = check.Price,
                //            MoeinGuid = LocalSettingBusiness.Settings.CodeSetting.CheckMCoding.Debit_MoeinGuid_Reception,
                //            TafsilGuid = LocalSettingBusiness.Settings.CodeSetting.CheckMCoding.Debit_TafsilGuid_Reception,
                //            Description = $"دریافت({ Id2} {Description} {check.Description})",
                //            DecimalGuid = check.DecimalGuid,
                //            Guid = check.Guid,
                //            Qt = 0
                //        });

                //if (ListEnteghal?.Count > 0)
                //    foreach (Sanad_DetBusiness enteghal in ListEnteghal)
                //        sanad.AddToListSanad(new Sanad_DetBusiness()
                //        {
                //            Credit = enteghal.Credit,
                //            Debit = enteghal.Debit,
                //            MoeinGuid = enteghal.MoeinGuid,
                //            TafsilGuid = enteghal.TafsilGuid,
                //            Description = $"دریافت({ Id2} {Description} {enteghal.Description})",
                //            DecimalGuid = enteghal.DecimalGuid,
                //            Guid = enteghal.Guid,
                //            Qt = enteghal.Qt
                //        });
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return sanad;
        }
    }
}
