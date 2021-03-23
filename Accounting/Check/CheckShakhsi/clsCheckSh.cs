using System;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;
using Services.DefaultCoding;
using User;

namespace Accounting.Check.CheckShakhsi
{
    public class clsCheckSh
    {
        public static async Task<ReturnedSaveFuncInfo> NaqdAsync(PardakhtCheckShakhsiBussines cls)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var checkPage = await CheckPageBussines.GetAsync(cls.CheckPageGuid);
                var dasteCheck = await DasteCheckBussines.GetAsync(checkPage.CheckGuid);

                var bank = await TafsilBussines.GetAsync(dasteCheck.BankGuid);

                var pardakht = await PardakhtBussines.GetAsync(cls.MasterGuid);
                var girande = await TafsilBussines.GetAsync(pardakht.TafsilGuid);

                var sanad = new SanadBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    Description = $"نقد کردن چک پرداختنی * شماره: {checkPage.Number} بانک صادر کننده: {bank.Name} * گیرنده: {girande.Name}",
                    DateM = DateTime.Now,
                    Number = await SanadBussines.NextNumberAsync(),
                    SanadStatus = EnSanadStatus.Temporary,
                    SanadType = EnSanadType.Auto,
                    UserGuid = clsUser.CurrentUser.Guid
                };

                if (checkPage.CheckStatus == EnCheckSh.Bargashti)
                {
                    res.AddReturnedValue(await NaqdBargashtAsync(cls, sanad));
                    if (res.HasError) return res;
                }

                //بستانکار--موجودی
                sanad.AddToListSanad(new SanadDetailBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    Description = $"نقد کردن چک {checkPage.Number} {bank.Name} * گیرنده: {girande.Name}",
                    Debit = 0,
                    Credit = cls.Price,
                    TafsilGuid = bank.Guid,
                    MasterGuid = sanad.Guid,
                    MoeinGuid = ParentDefaults.MoeinCoding.CLSMoein10101
                });
                //بدهکار--اسناد
                sanad.AddToListSanad(new SanadDetailBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    Description = $"نقد کردن چک {checkPage.Number} {bank.Name} * گیرنده: {girande.Name}",
                    Debit = cls.Price,
                    Credit = 0,
                    TafsilGuid = bank.Guid,
                    MasterGuid = sanad.Guid,
                    MoeinGuid = ParentDefaults.MoeinCoding.CLSMoein30101
                });

                res.AddReturnedValue(await sanad.SaveAsync());


                checkPage.CheckStatus = EnCheckSh.Pass;
                checkPage.Modified = DateTime.Now;
                res.AddReturnedValue(await checkPage.SaveAsync());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public static async Task<ReturnedSaveFuncInfo> NaqdAvalDoreAsync(PardakhtCheckAvalDoreBussines cls)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var checkPage = await CheckPageBussines.GetAsync(cls.CheckPageGuid);
                var dasteCheck = await DasteCheckBussines.GetAsync(checkPage.CheckGuid);

                var bank = await TafsilBussines.GetAsync(dasteCheck.BankGuid);

                var girande = await TafsilBussines.GetAsync(cls.TafsilGuid);

                var sanad = new SanadBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    Description = $"نقد کردن چک پرداختنی * شماره: {checkPage.Number} بانک صادر کننده: {bank.Name} * گیرنده: {girande.Name}",
                    DateM = DateTime.Now,
                    Number = await SanadBussines.NextNumberAsync(),
                    SanadStatus = EnSanadStatus.Temporary,
                    SanadType = EnSanadType.Auto,
                    UserGuid = clsUser.CurrentUser.Guid
                };

                if (checkPage.CheckStatus == EnCheckSh.Bargashti)
                {
                    res.AddReturnedValue(await NaqdBargashtAvalDoreAsync(cls, sanad));
                    if (res.HasError) return res;
                }

                //بستانکار--موجودی
                sanad.AddToListSanad(new SanadDetailBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    Description = $"نقد کردن چک {checkPage.Number} {bank.Name} * گیرنده: {girande.Name}",
                    Debit = 0,
                    Credit = cls.Price,
                    TafsilGuid = bank.Guid,
                    MasterGuid = sanad.Guid,
                    MoeinGuid = ParentDefaults.MoeinCoding.CLSMoein10101
                });
                //بدهکار--اسناد
                sanad.AddToListSanad(new SanadDetailBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    Description = $"نقد کردن چک {checkPage.Number} {bank.Name} * گیرنده: {girande.Name}",
                    Debit = cls.Price,
                    Credit = 0,
                    TafsilGuid = bank.Guid,
                    MasterGuid = sanad.Guid,
                    MoeinGuid = ParentDefaults.MoeinCoding.CLSMoein30101
                });

                res.AddReturnedValue(await sanad.SaveAsync());


                checkPage.CheckStatus = EnCheckSh.Pass;
                checkPage.Modified = DateTime.Now;
                res.AddReturnedValue(await checkPage.SaveAsync());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public static async Task<ReturnedSaveFuncInfo> BargashtAsync(PardakhtCheckShakhsiBussines cls)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var checkPage = await CheckPageBussines.GetAsync(cls.CheckPageGuid);
                var dasteCheck = await DasteCheckBussines.GetAsync(checkPage.CheckGuid);

                var bank = await TafsilBussines.GetAsync(dasteCheck.BankGuid);

                var pardakht = await PardakhtBussines.GetAsync(cls.MasterGuid);
                var girande = await TafsilBussines.GetAsync(pardakht.TafsilGuid);


                checkPage.CheckStatus = EnCheckSh.Bargashti;
                checkPage.Modified = DateTime.Now;
                res.AddReturnedValue(await checkPage.SaveAsync());

                var sanad = new SanadBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    Description = $"برگشت زدن چک پرداختنی * شماره: {checkPage.Number} بانک صادرکننده: {bank.Name} * گیرنده: {girande.Name}",
                    DateM = DateTime.Now,
                    Number = await SanadBussines.NextNumberAsync(),
                    SanadStatus = EnSanadStatus.Temporary,
                    SanadType = EnSanadType.Auto,
                    UserGuid = clsUser.CurrentUser.Guid
                };
                //بستانکار--شخص
                sanad.AddToListSanad(new SanadDetailBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    Description = $"برگشت زدن چک {checkPage.Number} {bank.Name} * گیرنده: {girande.Name}",
                    Debit = 0,
                    Credit = cls.Price,
                    TafsilGuid = pardakht.TafsilGuid,
                    MasterGuid = sanad.Guid,
                    MoeinGuid = pardakht.MoeinGuid
                });
                //بدهکار--اسناد
                sanad.AddToListSanad(new SanadDetailBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    Description = $"برگشت زدن چک {checkPage.Number} {bank.Name} * گیرنده: {girande.Name}",
                    Debit = cls.Price,
                    Credit = 0,
                    TafsilGuid = bank.Guid,
                    MasterGuid = sanad.Guid,
                    MoeinGuid = ParentDefaults.MoeinCoding.CLSMoein30101
                });

                res.AddReturnedValue(await sanad.SaveAsync());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public static async Task<ReturnedSaveFuncInfo> BargashtAvalDoreAsync(PardakhtCheckAvalDoreBussines cls)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var checkPage = await CheckPageBussines.GetAsync(cls.CheckPageGuid);
                var dasteCheck = await DasteCheckBussines.GetAsync(checkPage.CheckGuid);

                var bank = await TafsilBussines.GetAsync(dasteCheck.BankGuid);

                var girande = await TafsilBussines.GetAsync(cls.TafsilGuid);


                checkPage.CheckStatus = EnCheckSh.Bargashti;
                checkPage.Modified = DateTime.Now;
                res.AddReturnedValue(await checkPage.SaveAsync());

                var sanad = new SanadBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    Description = $"برگشت زدن چک پرداختنی * شماره: {checkPage.Number} بانک صادرکننده: {bank.Name} * گیرنده: {girande.Name}",
                    DateM = DateTime.Now,
                    Number = await SanadBussines.NextNumberAsync(),
                    SanadStatus = EnSanadStatus.Temporary,
                    SanadType = EnSanadType.Auto,
                    UserGuid = clsUser.CurrentUser.Guid
                };
                //بستانکار--شخص
                sanad.AddToListSanad(new SanadDetailBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    Description = $"برگشت زدن چک {checkPage.Number} {bank.Name} * گیرنده: {girande.Name}",
                    Debit = 0,
                    Credit = cls.Price,
                    TafsilGuid = cls.TafsilGuid,
                    MasterGuid = sanad.Guid,
                    MoeinGuid = ParentDefaults.MoeinCoding.CLSMoein30103
                });
                //بدهکار--اسناد
                sanad.AddToListSanad(new SanadDetailBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    Description = $"برگشت زدن چک {checkPage.Number} {bank.Name} * گیرنده: {girande.Name}",
                    Debit = cls.Price,
                    Credit = 0,
                    TafsilGuid = bank.Guid,
                    MasterGuid = sanad.Guid,
                    MoeinGuid = ParentDefaults.MoeinCoding.CLSMoein30101
                });

                res.AddReturnedValue(await sanad.SaveAsync());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private static async Task<ReturnedSaveFuncInfo> NaqdBargashtAsync(PardakhtCheckShakhsiBussines cls, SanadBussines sanad)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var checkPage = await CheckPageBussines.GetAsync(cls.CheckPageGuid);
                var dasteCheck = await DasteCheckBussines.GetAsync(checkPage.CheckGuid);

                var bank = await TafsilBussines.GetAsync(dasteCheck.BankGuid);

                var pardakht = await PardakhtBussines.GetAsync(cls.MasterGuid);
                var girande = await TafsilBussines.GetAsync(pardakht.TafsilGuid);

                //بستانکار--اسناد
                sanad.AddToListSanad(new SanadDetailBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    Description = $"استرداد چک پرداختنی * شماره: {checkPage.Number} بانک صادرکننده: {bank.Name} * گیرنده: {girande.Name}",
                    Debit = 0,
                    Credit = cls.Price,
                    TafsilGuid = bank.Guid,
                    MasterGuid = sanad.Guid,
                    MoeinGuid = ParentDefaults.MoeinCoding.CLSMoein30101
                });
                //بدهکار--شخص
                sanad.AddToListSanad(new SanadDetailBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    Description = $"استرداد چک پرداختنی * شماره: {checkPage.Number} بانک صادرکننده: {bank.Name} * گیرنده: {girande.Name}",
                    Debit = cls.Price,
                    Credit = 0,
                    TafsilGuid = pardakht.TafsilGuid,
                    MasterGuid = sanad.Guid,
                    MoeinGuid = pardakht.MoeinGuid
                });

                res.AddReturnedValue(await sanad.SaveAsync());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private static async Task<ReturnedSaveFuncInfo> NaqdBargashtAvalDoreAsync(PardakhtCheckAvalDoreBussines cls, SanadBussines sanad)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var checkPage = await CheckPageBussines.GetAsync(cls.CheckPageGuid);
                var dasteCheck = await DasteCheckBussines.GetAsync(checkPage.CheckGuid);

                var bank = await TafsilBussines.GetAsync(dasteCheck.BankGuid);

                var girande = await TafsilBussines.GetAsync(cls.TafsilGuid);

                //بستانکار--اسناد
                sanad.AddToListSanad(new SanadDetailBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    Description = $"استرداد چک پرداختنی * شماره: {checkPage.Number} بانک صادرکننده: {bank.Name} * گیرنده: {girande.Name}",
                    Debit = 0,
                    Credit = cls.Price,
                    TafsilGuid = bank.Guid,
                    MasterGuid = sanad.Guid,
                    MoeinGuid = ParentDefaults.MoeinCoding.CLSMoein30101
                });
                //بدهکار--شخص
                sanad.AddToListSanad(new SanadDetailBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    Description = $"استرداد چک پرداختنی * شماره: {checkPage.Number} بانک صادرکننده: {bank.Name} * گیرنده: {girande.Name}",
                    Debit = cls.Price,
                    Credit = 0,
                    TafsilGuid = cls.TafsilGuid,
                    MasterGuid = sanad.Guid,
                    MoeinGuid = ParentDefaults.MoeinCoding.CLSMoein30103
                });

                res.AddReturnedValue(await sanad.SaveAsync());
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
