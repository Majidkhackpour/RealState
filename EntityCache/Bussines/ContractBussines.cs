using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using EntityCache.ViewModels;
using Nito.AsyncEx;
using Persistence;
using Services;
using Services.DefaultCoding;
using Servicess.Interfaces.Building;
using WebHesabBussines;

namespace EntityCache.Bussines
{
    public class ContractBussines : IContract
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public string DateSh => Calendar.MiladiToShamsi(DateM);
        public bool Status { get; set; } = true;
        public DateTime DateM { get; set; } = DateTime.Now;
        public long Code { get; set; }
        public bool IsTemp { get; set; }
        public Guid FirstSideGuid { get; set; }
        public string FirstSideName { get; set; }
        public Guid SecondSideGuid { get; set; }
        public Guid BuildingGuid { get; set; }
        public Guid UserGuid { get; set; }
        public string UserName { get; set; }
        public string SecondSideName { get; set; }
        public int? Term { get; set; }
        public DateTime? FromDate { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal MinorPrice { get; set; }
        public string CheckNo { get; set; }
        public string BankName { get; set; }
        public string Shobe { get; set; }
        public string SarResid { get; set; }
        public DateTime DischargeDate { get; set; }
        public string DischargeDateSh => Calendar.MiladiToShamsi(DischargeDate);
        public DateTime? SetDocDate { get; set; }
        public string SetDocPlace { get; set; }
        public decimal SarQofli { get; set; }
        public decimal Delay { get; set; }
        public string Description { get; set; }
        public EnRequestType Type { get; set; }
        public Guid? BazaryabGuid { get; set; }
        public decimal BazaryabPrice { get; set; }
        public long SanadNumber { get; set; }
        public EnContractBabat fBabat { get; set; }
        public EnContractBabat sBabat { get; set; }
        public decimal FirstDiscount { get; set; }
        public decimal SecondDiscount { get; set; }
        public decimal FirstTax { get; set; }
        public decimal FirstAvarez { get; set; }
        public decimal SecondTax { get; set; }
        public decimal SecondAvarez { get; set; }
        public decimal FirstTotalPrice { get; set; }
        public decimal SecondTotalPrice { get; set; }
        public decimal FirstSum => FirstTotalPrice + FirstAvarez + FirstTax;
        public decimal SecondSum => SecondTotalPrice + SecondAvarez + SecondTax;
        public string HardSerial => Cache.HardSerial;



        public static async Task<List<ContractBussines>> GetAllAsync() => await UnitOfWork.Contract.GetAllAsync();
        public static async Task<List<ContractBussines>> GetAllAsync(string search)
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
                            res = res.Where(x => x.FirstSideName.ToLower().Contains(item.ToLower()) ||
                                                 x.SecondSideName.ToLower().Contains(item.ToLower()) ||
                                                 x.UserName.ToLower().Contains(item.ToLower()) ||
                                                 x.Code.ToString().ToLower().Contains(item.ToLower()))
                                ?.ToList();
                        }
                    }

                return res;
            }
            catch (OperationCanceledException)
            { return null; }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return new List<ContractBussines>();
            }
        }
        public static async Task<ContractBussines> GetAsync(Guid guid) => await UnitOfWork.Contract.GetAsync(guid);
        public static ContractBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));
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

                res.AddReturnedValue(await CheckValidationAsync());
                if (res.HasError) return res;

                res.AddReturnedValue(await UnitOfWork.Contract.SaveAsync(this, tranName));
                if (res.HasError) return res;

                var sanad = await GenerateSanadAsync();
                res.AddReturnedValue(await sanad.SaveAsync());
                if (res.HasError) return res;

                if (autoTran)
                {
                    //CommitTransAction
                }

                //if (Cache.IsSendToServer)
                //    _ = Task.Run(() => WebContract.SaveAsync(this));
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


                res.AddReturnedValue(await UnitOfWork.Contract.RemoveAsync(Guid, tranName));
                if (res.HasError) return res;

                var sanad = await SanadBussines.GetAsync(SanadNumber);
                if (sanad != null)
                {
                    res.AddReturnedValue(await sanad.RemoveAsync());
                    if (res.HasError) return res;
                }

                if (autoTran)
                {
                    //CommitTransAction
                }

                //if (Cache.IsSendToServer)
                //    _ = Task.Run(() => WebContract.SaveAsync(this));
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
        public static async Task<string> NextCodeAsync() => await UnitOfWork.Contract.NextCodeAsync();
        public static async Task<bool> CheckCodeAsync(string code, Guid guid) =>
            await UnitOfWork.Contract.CheckCodeAsync(code, guid);
        public static async Task<int> DbCount(Guid userGuid) => await UnitOfWork.Contract.DbCount(userGuid);
        public static async Task<int> DischargeDbCount()
        {
            var d1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            var d2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day, 23, 59, 59);

            return await UnitOfWork.Contract.DischargeDbCount(d1, d2);
        }
        public static async Task<List<BuildingDischargeViewModel>> DischargeListAsync()
        {
            var d1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            var d2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day, 23, 59, 59);

            return await UnitOfWork.Contract.DischargeListAsync(d1, d2);
        }
        public static async Task<decimal> GetTotalBazaryabAsync(DateTime d1, DateTime d2) =>
            await UnitOfWork.Contract.GetTotalBazaryab(d1, d2);
        public static decimal GetTotalBazaryab(DateTime d1, DateTime d2) =>
            AsyncContext.Run(() => GetTotalBazaryabAsync(d1, d2));
        public async Task<SanadBussines> GenerateSanadAsync()
        {
            SanadBussines sanad = null;
            try
            {
                sanad = await SanadBussines.GetAsync(SanadNumber) ?? new SanadBussines()
                {
                    Description = $"قرارداد({Code}) منعقد شده در تاریخ {DateSh}",
                    Number = SanadNumber,
                    DateM = DateM,
                    UserGuid = UserGuid,
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    SanadStatus = EnSanadStatus.Temporary,
                    SanadType = EnSanadType.Auto
                };
                sanad.DetailClear();
                //طرف حساب بدهکار اول
                sanad.AddToListSanad(new SanadDetailBussines()
                {
                    Credit = 0,
                    Debit = FirstSum - FirstDiscount,
                    MoeinGuid = ParentDefaults.MoeinCoding.CLSMoein10304,
                    TafsilGuid = FirstSideGuid,
                    Description = $"قرارداد({Code}) طرف: {FirstSideName} منعقد شده در تاریخ {DateSh}",
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    MasterGuid = sanad.Guid
                });
                //طرف حساب بدهکار دوم
                sanad.AddToListSanad(new SanadDetailBussines()
                {
                    Credit = 0,
                    Debit = SecondSum - SecondDiscount,
                    MoeinGuid = ParentDefaults.MoeinCoding.CLSMoein10304,
                    TafsilGuid = SecondSideGuid,
                    Description = $"قرارداد({Code}) طرف: {SecondSideName} منعقد شده در تاریخ {DateSh}",
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    MasterGuid = sanad.Guid
                });
                //طرف حساب بستانکار درآمد اول
                sanad.AddToListSanad(new SanadDetailBussines()
                {
                    Credit = FirstTotalPrice  - (BazaryabPrice / 2),
                    Debit = 0,
                    MoeinGuid = ParentDefaults.MoeinCoding.CLSMoein60201,
                    TafsilGuid = ParentDefaults.TafsilCoding.CLSTafsil6020101,
                    Description = $"قرارداد({Code}) طرف: {FirstSideName} منعقد شده در تاریخ {DateSh}",
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    MasterGuid = sanad.Guid
                });
                //طرف حساب بستانکار درآمد دوم
                sanad.AddToListSanad(new SanadDetailBussines()
                {
                    Credit = SecondTotalPrice - (BazaryabPrice / 2),
                    Debit = 0,
                    MoeinGuid = ParentDefaults.MoeinCoding.CLSMoein60201,
                    TafsilGuid = ParentDefaults.TafsilCoding.CLSTafsil6020101,
                    Description = $"قرارداد({Code}) طرف: {SecondSideName} منعقد شده در تاریخ {DateSh}",
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    MasterGuid = sanad.Guid
                });

                if (FirstDiscount > 0)
                {
                    //طرف حساب بدهکار تخفیف اول
                    sanad.AddToListSanad(new SanadDetailBussines()
                    {
                        Credit = 0,
                        Debit = FirstDiscount,
                        MoeinGuid = ParentDefaults.MoeinCoding.CLSMoein60103,
                        TafsilGuid = ParentDefaults.TafsilCoding.CLSTafsil6010301,
                        Description = $"قرارداد({Code}) طرف: {FirstSideName} منعقد شده در تاریخ {DateSh}",
                        Guid = Guid.NewGuid(),
                        Modified = DateTime.Now,
                        Status = true,
                        MasterGuid = sanad.Guid
                    });
                }
                if (SecondDiscount > 0)
                {
                    //طرف حساب بدهکار تخفیف دوم
                    sanad.AddToListSanad(new SanadDetailBussines()
                    {
                        Credit = 0,
                        Debit = SecondDiscount,
                        MoeinGuid = ParentDefaults.MoeinCoding.CLSMoein60103,
                        TafsilGuid = ParentDefaults.TafsilCoding.CLSTafsil6010301,
                        Description = $"قرارداد({Code}) طرف: {SecondSideName} منعقد شده در تاریخ {DateSh}",
                        Guid = Guid.NewGuid(),
                        Modified = DateTime.Now,
                        Status = true,
                        MasterGuid = sanad.Guid
                    });
                }

                if (FirstTax > 0)
                {
                    //طرف حساب بستانکار مالیات اول
                    sanad.AddToListSanad(new SanadDetailBussines()
                    {
                        Credit = FirstTax,
                        Debit = 0,
                        MoeinGuid = ParentDefaults.MoeinCoding.CLSMoein30204,
                        TafsilGuid = ParentDefaults.TafsilCoding.CLSTafsil3020305,
                        Description = $"قرارداد({Code}) طرف: {FirstSideName} منعقد شده در تاریخ {DateSh}",
                        Guid = Guid.NewGuid(),
                        Modified = DateTime.Now,
                        Status = true,
                        MasterGuid = sanad.Guid
                    });
                }
                if (SecondTax > 0)
                {
                    //طرف حساب بستانکار مالیات دوم
                    sanad.AddToListSanad(new SanadDetailBussines()
                    {
                        Credit = SecondTax,
                        Debit = 0,
                        MoeinGuid = ParentDefaults.MoeinCoding.CLSMoein30204,
                        TafsilGuid = ParentDefaults.TafsilCoding.CLSTafsil3020305,
                        Description = $"قرارداد({Code}) طرف: {SecondSideName} منعقد شده در تاریخ {DateSh}",
                        Guid = Guid.NewGuid(),
                        Modified = DateTime.Now,
                        Status = true,
                        MasterGuid = sanad.Guid
                    });
                }

                if (FirstAvarez > 0)
                {
                    //طرف حساب بستانکار عوارض اول
                    sanad.AddToListSanad(new SanadDetailBussines()
                    {
                        Credit = FirstAvarez,
                        Debit = 0,
                        MoeinGuid = ParentDefaults.MoeinCoding.CLSMoein30207,
                        TafsilGuid = ParentDefaults.TafsilCoding.CLSTafsil3020306,
                        Description = $"قرارداد({Code}) طرف: {FirstSideName} منعقد شده در تاریخ {DateSh}",
                        Guid = Guid.NewGuid(),
                        Modified = DateTime.Now,
                        Status = true,
                        MasterGuid = sanad.Guid
                    });
                }
                if (SecondTax > 0)
                {
                    //طرف حساب بستانکار عوارض دوم
                    sanad.AddToListSanad(new SanadDetailBussines()
                    {
                        Credit = SecondAvarez,
                        Debit = 0,
                        MoeinGuid = ParentDefaults.MoeinCoding.CLSMoein30207,
                        TafsilGuid = ParentDefaults.TafsilCoding.CLSTafsil3020306,
                        Description = $"قرارداد({Code}) طرف: {SecondSideName} منعقد شده در تاریخ {DateSh}",
                        Guid = Guid.NewGuid(),
                        Modified = DateTime.Now,
                        Status = true,
                        MasterGuid = sanad.Guid
                    });
                }

                if (BazaryabPrice > 0 && BazaryabGuid != null && BazaryabGuid != Guid.Empty)
                {
                    //طرف حساب بستانکار مشاور
                    sanad.AddToListSanad(new SanadDetailBussines()
                    {
                        Credit = BazaryabPrice,
                        Debit = 0,
                        MoeinGuid = ParentDefaults.MoeinCoding.CLSMoein10304,
                        TafsilGuid = BazaryabGuid.Value,
                        Description = $"پورسانت عقدقرارداد({Code}) فی مابین {FirstSideName} و {SecondSideName} منعقد شده در تاریخ {DateSh}",
                        Guid = Guid.NewGuid(),
                        Modified = DateTime.Now,
                        Status = true,
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
        private async Task<ReturnedSaveFuncInfo> CheckValidationAsync()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (Code <= 0) res.AddError("کد قرارداد نمی تواند خالی باشد");
                if (!await CheckCodeAsync(Code.ToString().Trim(), Guid)) res.AddError("کد ملک وارد شده تکراری است");
                if (FirstSideGuid == Guid.Empty) res.AddError("لطفا طرف اول قرارداد را انتخاب نمایید");
                if (SecondSideGuid == Guid.Empty) res.AddError("لطفا طرف دوم قرارداد را انتخاب نمایید");
                if (SecondSideGuid == FirstSideGuid) res.AddError("دوطرف قرارداد نمی تواند یکسان باشد");
                if (BuildingGuid == Guid.Empty) res.AddError("لطفا ملک موضوع قرارداد را انتخاب نمایید");
                if (MinorPrice == 0 && TotalPrice == 0) res.AddError("لطفا یکی از فیلدهای مبلغ را وارد نمایید");
                if ((BazaryabGuid == null || BazaryabGuid == Guid.Empty) && BazaryabPrice > 0) res.AddError("لطفا بازاریاب را انتخاب نمایید");
                if (BazaryabGuid != Guid.Empty && BazaryabPrice <= 0) res.AddError("لطفا مبلغ پورسانت بازاریاب را مشخص نمایید");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
    }
}
