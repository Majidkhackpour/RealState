using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EntityCache.Assistence;
using EntityCache.Mppings;
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
        public ServerStatus ServerStatus { get; set; } = ServerStatus.None;
        public DateTime ServerDeliveryDate { get; set; } = DateTime.Now;
        public string DateSh => Calendar.MiladiToShamsi(DateM);
        public bool Status { get; set; } = true;
        public DateTime DateM { get; set; } = DateTime.Now;
        public long Code { get; set; }
        public string CodeInArchive { get; set; }
        public string RealStateCode { get; set; }
        public string HologramCode { get; set; }
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
        public string CheckNoTo { get; set; }
        public string CheckNo { get; set; }
        public string BankName { get; set; }
        public string BankNameEjare { get; set; }
        public string Shobe { get; set; }
        public string ShobeEjare { get; set; }
        public DateTime? SarResidTo { get; set; }
        public DateTime? SarResid { get; set; }
        public decimal CheckPrice1 { get; set; }
        public decimal CheckPrice2 { get; set; }
        public DateTime? DischargeDate { get; set; }
        public string DischargeDateSh => Calendar.MiladiToShamsi(DischargeDate);
        public DateTime? SetDocDate { get; set; }
        public string SetDocPlace { get; set; }
        public int SetDocNo { get; set; }
        public decimal SarQofli { get; set; }
        public decimal FirstSideDelay { get; set; }
        public decimal SecondSideDelay { get; set; }
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
        public string BuildingPlack { get; set; }
        public string BuildingZip { get; set; }
        public string SanadSerial { get; set; }
        public int PartNo { get; set; }
        public int Page { get; set; }
        public string Office { get; set; }
        public string BuildingNumber { get; set; }
        public int ParkingNo { get; set; }
        public float ParkingMasahat { get; set; }
        public int StoreNo { get; set; }
        public float StoreMasahat { get; set; }
        public int PhoneLineCount { get; set; }
        public string BuildingPhoneNumber { get; set; }
        public int PeopleCount { get; set; }
        public string PayankarNo { get; set; }
        public DateTime? PayankarDate { get; set; }
        public decimal PishPrice { get; set; }
        public string Witness1 { get; set; }
        public string Witness2 { get; set; }
        public string BuildingRegistrationNo { get; set; }
        public string BuildingRegistrationNoSub { get; set; }
        public string BuildingRegistrationNoOrigin { get; set; }
        public string BuildingCosumable { get; set; }
        public string ManufacturingLicensePlace { get; set; }
        public DateTime? ManufacturingLicenseDate { get; set; }
        public DateTime? SettlementDate { get; set; }
        public decimal AmountOfRent { get; set; }
        public string GulidType { get; set; }
        public string DocumentAdjust { get; set; }
        public decimal FirstSum => FirstTotalPrice + FirstAvarez + FirstTax;
        public decimal SecondSum => SecondTotalPrice + SecondAvarez + SecondTax;
        public bool IsModified { get; set; } = false;



        public static async Task<List<ContractBussines>> GetAllAsync(CancellationToken token) => await UnitOfWork.Contract.GetAllAsync(Cache.ConnectionString, token);
        public static async Task<List<ContractBussines>> GetAllAsync(string search, CancellationToken token)
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
                            res = res.Where(x => x.FirstSideName.ToLower().Contains(item.ToLower()) ||
                                                 x.SecondSideName.ToLower().Contains(item.ToLower()) ||
                                                 x.UserName.ToLower().Contains(item.ToLower()) ||
                                                 x.Code.ToString().ToLower().Contains(item.ToLower()))
                                ?.ToList();
                        }
                    }

                return res;
            }
            catch (TaskCanceledException) { return null; }
            catch (OperationCanceledException) { return null; }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return new List<ContractBussines>();
            }
        }
        public static async Task<ContractBussines> GetAsync(Guid guid) => await UnitOfWork.Contract.GetAsync(Cache.ConnectionString, guid);
        public static ContractBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));
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

                res.AddReturnedValue(await CheckValidationAsync());
                if (res.HasError) return res;

                res.AddReturnedValue(await UnitOfWork.Contract.SaveAsync(this, tr));
                if (res.HasError) return res;

                if (FirstTotalPrice > 0 && SecondTotalPrice > 0)
                {
                    var sanad = await GenerateSanadAsync();
                    res.AddReturnedValue(await sanad.SaveAsync(tr));
                    if (res.HasError) return res;
                }

                var action = IsModified ? EnLogAction.Update : EnLogAction.Insert;
                var desc = $"کد قرارداد:( {Code} ) ** شماره پرونده:( {CodeInArchive} ) ** نوع قرارداد: ( {Type.GetDisplay()} )";
                res.AddReturnedValue(await UserLogBussines.SaveAsync(action, EnLogPart.Contracts,Guid,desc, tr));
                if (res.HasError) return res;

                if (Cache.IsSendToServer)
                    _ = Task.Run(() => WebContract.SaveAsync(ContractMapper.Instance.Map(this)));
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

                res.AddReturnedValue(await UnitOfWork.Contract.RemoveAsync(Guid, tr));
                if (res.HasError) return res;

                var sanad = await SanadBussines.GetAsync(SanadNumber);
                if (sanad != null)
                {
                    res.AddReturnedValue(await sanad.RemoveAsync(tr));
                    if (res.HasError) return res;
                }

                var desc = $"کد قرارداد: ( {Code} ) ** شماره پرونده:( {CodeInArchive} ) ** نوع قرارداد:( {Type.GetDisplay()} )";
                res.AddReturnedValue(await UserLogBussines.SaveAsync(EnLogAction.Delete, EnLogPart.Contracts,Guid,desc, tr));
                if (res.HasError) return res;

                //if (Cache.IsSendToServer)
                //    _ = Task.Run(() => WebContract.SaveAsync(this));
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
        public static async Task<string> NextCodeAsync() => await UnitOfWork.Contract.NextCodeAsync(Cache.ConnectionString);
        public static string NextCode() => AsyncContext.Run(NextCodeAsync);
        public static async Task<bool> CheckCodeAsync(string code, Guid guid) =>
            await UnitOfWork.Contract.CheckCodeAsync(Cache.ConnectionString, code, guid);
        public static async Task<int> DbCount(Guid userGuid) => await UnitOfWork.Contract.DbCount(Cache.ConnectionString, userGuid);
        public static async Task<int> DischargeDbCount()
        {
            var d1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            var d2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day, 23, 59, 59);

            return await UnitOfWork.Contract.DischargeDbCount(Cache.ConnectionString, d1, d2);
        }
        public static async Task<List<BuildingDischargeViewModel>> DischargeListAsync()
        {
            try
            {
                var nextMounth = DateTime.Now.AddMonths(1);
                var newYear = nextMounth.Year;
                var newMounth = nextMounth.Month;
                if (newMounth == 12)
                {
                    newMounth = 1;
                    newYear++;
                }
                else newMounth += 1;
                var d1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                var d2 = new DateTime(newYear, newMounth, nextMounth.Day, 23, 59, 59);

                return await UnitOfWork.Contract.DischargeListAsync(Cache.ConnectionString, d1, d2);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
        public static async Task<decimal> GetTotalBazaryabAsync(DateTime d1, DateTime d2) =>
            await UnitOfWork.Contract.GetTotalBazaryab(Cache.ConnectionString, d1, d2);
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
                    MasterGuid = sanad.Guid
                });
                //طرف حساب بستانکار درآمد اول
                sanad.AddToListSanad(new SanadDetailBussines()
                {
                    Credit = FirstTotalPrice - (BazaryabPrice / 2),
                    Debit = 0,
                    MoeinGuid = ParentDefaults.MoeinCoding.CLSMoein60201,
                    TafsilGuid = ParentDefaults.TafsilCoding.CLSTafsil6020101,
                    Description = $"قرارداد({Code}) طرف: {FirstSideName} منعقد شده در تاریخ {DateSh}",
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
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
                if ((BazaryabGuid != null && BazaryabGuid != Guid.Empty) && BazaryabPrice <= 0) res.AddError("لطفا مبلغ پورسانت بازاریاب را مشخص نمایید");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public static async Task<decimal> GetTotalCommitionAsync(DateTime d1, DateTime d2) =>
            await UnitOfWork.Contract.GetTotalCommitionAsync(Cache.ConnectionString, d1, d2);
        public static decimal GetTotalCommition(DateTime d1, DateTime d2) =>
            AsyncContext.Run(() => GetTotalCommitionAsync(d1, d2));
        public static async Task<decimal> GetTotalTaxAsync(DateTime d1, DateTime d2) =>
            await UnitOfWork.Contract.GetTotalTaxAsync(Cache.ConnectionString, d1, d2);
        public static decimal GetTotalTax(DateTime d1, DateTime d2) => AsyncContext.Run(() => GetTotalTaxAsync(d1, d2));
    }
}
