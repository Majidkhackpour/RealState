using System;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;
using Services.DefaultCoding;
using User;

namespace Accounting.Check.CheckMoshtari
{
    public static class clsCheckM
    {
        public static async Task<ReturnedSaveFuncInfo> NaqdAsync(ReceptionCheckBussines cls)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var tafsil = await TafsilBussines.GetAsync(cls.SandouqTafsilGuid);
                var moeinGuid = tafsil.HesabType == HesabType.Bank
                    ? ParentDefaults.MoeinCoding.CLSMoein10101
                    : ParentDefaults.MoeinCoding.CLSMoein10102;

                var reception = await ReceptionBussines.GetAsync(cls.MasterGuid);
                var pardazande = await TafsilBussines.GetAsync(reception.TafsilGuid);

                var sanad = new SanadBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    Description = $"نقد کردن چک {cls.CheckNumber} {cls.BankName} * پردازنده: {pardazande.Name}",
                    DateM = DateTime.Now,
                    Number = await SanadBussines.NextNumberAsync(),
                    SanadStatus = EnSanadStatus.Temporary,
                    SanadType = EnSanadType.Auto,
                    UserGuid = clsUser.CurrentUser.Guid
                };

                if (cls.CheckStatus == EnCheckM.Bargashti)
                {
                    res.AddReturnedValue(await NaqdBargashtAsync(cls, sanad));
                    if (res.HasError) return res;
                }

                //بستانکار--اسناد
                sanad.AddToListSanad(new SanadDetailBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    Description = $"نقد کردن چک {cls.CheckNumber} {cls.BankName} * پردازنده: {pardazande.Name}",
                    Debit = 0,
                    Credit = cls.Price,
                    TafsilGuid = cls.SandouqTafsilGuid,
                    MasterGuid = sanad.Guid,
                    MoeinGuid = cls.SandouqMoeinGuid
                });
                //بدهکار--موجودی
                sanad.AddToListSanad(new SanadDetailBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    Description = $"نقد کردن چک {cls.CheckNumber} {cls.BankName} * پردازنده: {pardazande.Name}",
                    Debit = cls.Price,
                    Credit = 0,
                    TafsilGuid = tafsil.Guid,
                    MasterGuid = sanad.Guid,
                    MoeinGuid = moeinGuid
                });

                res.AddReturnedValue(await sanad.SaveAsync());


                cls.CheckStatus = EnCheckM.Naqd;
                cls.Modified = DateTime.Now;
                res.AddReturnedValue(await cls.SaveAsync());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public static async Task<ReturnedSaveFuncInfo> NaqdAvalDoreAsync(ReceptionCheckAvalDoreBussines cls)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {


                var tafsil = await TafsilBussines.GetAsync(cls.SandouqTafsilGuid);
                var moeinGuid = tafsil.HesabType == HesabType.Bank
                    ? ParentDefaults.MoeinCoding.CLSMoein10101
                    : ParentDefaults.MoeinCoding.CLSMoein10102;



                var pardazande = await TafsilBussines.GetAsync(cls.TafsilGuid);

                var sanad = new SanadBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    Description = $"نقد کردن چک {cls.CheckNumber} {cls.BankName} * پردازنده: {pardazande.Name}",
                    DateM = DateTime.Now,
                    Number = await SanadBussines.NextNumberAsync(),
                    SanadStatus = EnSanadStatus.Temporary,
                    SanadType = EnSanadType.Auto,
                    UserGuid = clsUser.CurrentUser.Guid
                };

                if (cls.CheckStatus == EnCheckM.Bargashti)
                {
                    res.AddReturnedValue(await NaqdBargashtAvalDoreAsync(cls, sanad));
                    if (res.HasError) return res;
                }

                //بستانکار--اسناد
                sanad.AddToListSanad(new SanadDetailBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    Description = $"نقد کردن چک {cls.CheckNumber} {cls.BankName} * پردازنده: {pardazande.Name}",
                    Debit = 0,
                    Credit = cls.Price,
                    TafsilGuid = cls.SandouqTafsilGuid,
                    MasterGuid = sanad.Guid,
                    MoeinGuid = cls.SandouqMoeinGuid
                });
                //بدهکار--موجودی
                sanad.AddToListSanad(new SanadDetailBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    Description = $"نقد کردن چک {cls.CheckNumber} {cls.BankName} * پردازنده: {pardazande.Name}",
                    Debit = cls.Price,
                    Credit = 0,
                    TafsilGuid = tafsil.Guid,
                    MasterGuid = sanad.Guid,
                    MoeinGuid = moeinGuid
                });

                res.AddReturnedValue(await sanad.SaveAsync());


                cls.CheckStatus = EnCheckM.Naqd;
                cls.Modified = DateTime.Now;
                res.AddReturnedValue(await cls.SaveAsync(false));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public static async Task<ReturnedSaveFuncInfo> VagozarSandouq(ReceptionCheckBussines cls, TafsilBussines newSandouq)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var reception = await ReceptionBussines.GetAsync(cls.MasterGuid);
                var pardazande = await TafsilBussines.GetAsync(reception.TafsilGuid);

                var sanad = new SanadBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    Description = $"واگذار کردن چک {cls.CheckNumber} {cls.BankName} * پردازنده: {pardazande.Name}",
                    DateM = DateTime.Now,
                    Number = await SanadBussines.NextNumberAsync(),
                    SanadStatus = EnSanadStatus.Temporary,
                    SanadType = EnSanadType.Auto,
                    UserGuid = clsUser.CurrentUser.Guid
                };
                //بستانکار--اسناد قبلی
                sanad.AddToListSanad(new SanadDetailBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    Description = $"واگذار کردن چک {cls.CheckNumber} {cls.BankName} * پردازنده: {pardazande.Name}",
                    Debit = 0,
                    Credit = cls.Price,
                    TafsilGuid = cls.SandouqTafsilGuid,
                    MasterGuid = sanad.Guid,
                    MoeinGuid = cls.SandouqMoeinGuid
                });
                //بدهکار--اسناد جدید
                sanad.AddToListSanad(new SanadDetailBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    Description = $"واگذار کردن چک {cls.CheckNumber} {cls.BankName} * پردازنده: {pardazande.Name}",
                    Debit = cls.Price,
                    Credit = 0,
                    TafsilGuid = newSandouq.Guid,
                    MasterGuid = sanad.Guid,
                    MoeinGuid = ParentDefaults.MoeinCoding.CLSMoein10104
                });

                res.AddReturnedValue(await sanad.SaveAsync());


                cls.CheckStatus = EnCheckM.Vagozar;
                cls.Modified = DateTime.Now;
                cls.SandouqTafsilGuid = newSandouq.Guid;
                cls.SandouqMoeinGuid = ParentDefaults.MoeinCoding.CLSMoein10104;
                res.AddReturnedValue(await cls.SaveAsync());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public static async Task<ReturnedSaveFuncInfo> VagozarSandouqAvalDore(ReceptionCheckAvalDoreBussines cls, TafsilBussines newSandouq)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var pardazande = await TafsilBussines.GetAsync(cls.TafsilGuid);

                var sanad = new SanadBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    Description = $"واگذار کردن چک {cls.CheckNumber} {cls.BankName} * پردازنده: {pardazande.Name}",
                    DateM = DateTime.Now,
                    Number = await SanadBussines.NextNumberAsync(),
                    SanadStatus = EnSanadStatus.Temporary,
                    SanadType = EnSanadType.Auto,
                    UserGuid = clsUser.CurrentUser.Guid
                };
                //بستانکار--اسناد قبلی
                sanad.AddToListSanad(new SanadDetailBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    Description = $"واگذار کردن چک {cls.CheckNumber} {cls.BankName} * پردازنده: {pardazande.Name}",
                    Debit = 0,
                    Credit = cls.Price,
                    TafsilGuid = cls.SandouqTafsilGuid,
                    MasterGuid = sanad.Guid,
                    MoeinGuid = cls.SandouqMoeinGuid
                });
                //بدهکار--اسناد جدید
                sanad.AddToListSanad(new SanadDetailBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    Description = $"واگذار کردن چک {cls.CheckNumber} {cls.BankName} * پردازنده: {pardazande.Name}",
                    Debit = cls.Price,
                    Credit = 0,
                    TafsilGuid = newSandouq.Guid,
                    MasterGuid = sanad.Guid,
                    MoeinGuid = ParentDefaults.MoeinCoding.CLSMoein10104
                });

                res.AddReturnedValue(await sanad.SaveAsync());


                cls.CheckStatus = EnCheckM.Vagozar;
                cls.Modified = DateTime.Now;
                cls.SandouqTafsilGuid = newSandouq.Guid;
                cls.SandouqMoeinGuid = ParentDefaults.MoeinCoding.CLSMoein10104;
                res.AddReturnedValue(await cls.SaveAsync(false));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public static async Task<ReturnedSaveFuncInfo> VagozarBank(ReceptionCheckBussines cls, TafsilBussines newBank)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var reception = await ReceptionBussines.GetAsync(cls.MasterGuid);
                var pardazande = await TafsilBussines.GetAsync(reception.TafsilGuid);

                var sanad = new SanadBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    Description = $"واگذار کردن چک {cls.CheckNumber} {cls.BankName} * پردازنده: {pardazande.Name}",
                    DateM = DateTime.Now,
                    Number = await SanadBussines.NextNumberAsync(),
                    SanadStatus = EnSanadStatus.Temporary,
                    SanadType = EnSanadType.Auto,
                    UserGuid = clsUser.CurrentUser.Guid
                };
                //بستانکار--اسناد قبلی
                sanad.AddToListSanad(new SanadDetailBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    Description = $"واگذار کردن چک {cls.CheckNumber} {cls.BankName} * پردازنده: {pardazande.Name}",
                    Debit = 0,
                    Credit = cls.Price,
                    TafsilGuid = cls.SandouqTafsilGuid,
                    MasterGuid = sanad.Guid,
                    MoeinGuid = cls.SandouqMoeinGuid
                });
                //بدهکار--اسناد جدید
                sanad.AddToListSanad(new SanadDetailBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    Description = $"واگذار کردن چک {cls.CheckNumber} {cls.BankName} * پردازنده: {pardazande.Name}",
                    Debit = cls.Price,
                    Credit = 0,
                    TafsilGuid = newBank.Guid,
                    MasterGuid = sanad.Guid,
                    MoeinGuid = ParentDefaults.MoeinCoding.CLSMoein10105
                });

                res.AddReturnedValue(await sanad.SaveAsync());


                cls.CheckStatus = EnCheckM.Vagozar;
                cls.Modified = DateTime.Now;
                cls.SandouqTafsilGuid = newBank.Guid;
                cls.SandouqMoeinGuid = ParentDefaults.MoeinCoding.CLSMoein10105;
                res.AddReturnedValue(await cls.SaveAsync());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public static async Task<ReturnedSaveFuncInfo> VagozarBankAvalDore(ReceptionCheckAvalDoreBussines cls, TafsilBussines newBank)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var pardazande = await TafsilBussines.GetAsync(cls.TafsilGuid);

                var sanad = new SanadBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    Description = $"واگذار کردن چک {cls.CheckNumber} {cls.BankName} * پردازنده: {pardazande.Name}",
                    DateM = DateTime.Now,
                    Number = await SanadBussines.NextNumberAsync(),
                    SanadStatus = EnSanadStatus.Temporary,
                    SanadType = EnSanadType.Auto,
                    UserGuid = clsUser.CurrentUser.Guid
                };
                //بستانکار--اسناد قبلی
                sanad.AddToListSanad(new SanadDetailBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    Description = $"واگذار کردن چک {cls.CheckNumber} {cls.BankName} * پردازنده: {pardazande.Name}",
                    Debit = 0,
                    Credit = cls.Price,
                    TafsilGuid = cls.SandouqTafsilGuid,
                    MasterGuid = sanad.Guid,
                    MoeinGuid = cls.SandouqMoeinGuid
                });
                //بدهکار--اسناد جدید
                sanad.AddToListSanad(new SanadDetailBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    Description = $"واگذار کردن چک {cls.CheckNumber} {cls.BankName} * پردازنده: {pardazande.Name}",
                    Debit = cls.Price,
                    Credit = 0,
                    TafsilGuid = newBank.Guid,
                    MasterGuid = sanad.Guid,
                    MoeinGuid = ParentDefaults.MoeinCoding.CLSMoein10105
                });

                res.AddReturnedValue(await sanad.SaveAsync());


                cls.CheckStatus = EnCheckM.Vagozar;
                cls.Modified = DateTime.Now;
                cls.SandouqTafsilGuid = newBank.Guid;
                cls.SandouqMoeinGuid = ParentDefaults.MoeinCoding.CLSMoein10105;
                res.AddReturnedValue(await cls.SaveAsync(false));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public static async Task<ReturnedSaveFuncInfo> BargashtAsync(ReceptionCheckBussines cls)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                cls.CheckStatus = EnCheckM.Bargashti;
                cls.Modified = DateTime.Now;
                res.AddReturnedValue(await cls.SaveAsync());

                var reception = await ReceptionBussines.GetAsync(cls.MasterGuid);
                var pardazande = await TafsilBussines.GetAsync(reception.TafsilGuid);

                var sanad = new SanadBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    Description = $"برگشت زدن چک {cls.CheckNumber} {cls.BankName} * پردازنده: {pardazande.Name}",
                    DateM = DateTime.Now,
                    Number = await SanadBussines.NextNumberAsync(),
                    SanadStatus = EnSanadStatus.Temporary,
                    SanadType = EnSanadType.Auto,
                    UserGuid = clsUser.CurrentUser.Guid
                };
                //بستانکار--اسناد
                sanad.AddToListSanad(new SanadDetailBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    Description = $"برگشت زدن چک {cls.CheckNumber} {cls.BankName} * پردازنده: {pardazande.Name}",
                    Debit = 0,
                    Credit = cls.Price,
                    TafsilGuid = cls.SandouqTafsilGuid,
                    MasterGuid = sanad.Guid,
                    MoeinGuid = cls.SandouqMoeinGuid
                });
                //بدهکار--شخص
                sanad.AddToListSanad(new SanadDetailBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    Description = $"برگشت زدن چک {cls.CheckNumber} {cls.BankName} * پردازنده: {pardazande.Name}",
                    Debit = cls.Price,
                    Credit = 0,
                    TafsilGuid = pardazande.Guid,
                    MasterGuid = sanad.Guid,
                    MoeinGuid = ParentDefaults.MoeinCoding.CLSMoein10304
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
        public static async Task<ReturnedSaveFuncInfo> BargashtAvalDoreAsync(ReceptionCheckAvalDoreBussines cls)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                cls.CheckStatus = EnCheckM.Bargashti;
                cls.Modified = DateTime.Now;
                res.AddReturnedValue(await cls.SaveAsync(false));

                var pardazande = await TafsilBussines.GetAsync(cls.TafsilGuid);

                var sanad = new SanadBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    Description = $"برگشت زدن چک {cls.CheckNumber} {cls.BankName} * پردازنده: {pardazande.Name}",
                    DateM = DateTime.Now,
                    Number = await SanadBussines.NextNumberAsync(),
                    SanadStatus = EnSanadStatus.Temporary,
                    SanadType = EnSanadType.Auto,
                    UserGuid = clsUser.CurrentUser.Guid
                };
                //بستانکار--اسناد
                sanad.AddToListSanad(new SanadDetailBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    Description = $"برگشت زدن چک {cls.CheckNumber} {cls.BankName} * پردازنده: {pardazande.Name}",
                    Debit = 0,
                    Credit = cls.Price,
                    TafsilGuid = cls.SandouqTafsilGuid,
                    MasterGuid = sanad.Guid,
                    MoeinGuid = cls.SandouqMoeinGuid
                });
                //بدهکار--شخص
                sanad.AddToListSanad(new SanadDetailBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    Description = $"برگشت زدن چک {cls.CheckNumber} {cls.BankName} * پردازنده: {pardazande.Name}",
                    Debit = cls.Price,
                    Credit = 0,
                    TafsilGuid = pardazande.Guid,
                    MasterGuid = sanad.Guid,
                    MoeinGuid = ParentDefaults.MoeinCoding.CLSMoein10304
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
        private static async Task<ReturnedSaveFuncInfo> NaqdBargashtAsync(ReceptionCheckBussines cls, SanadBussines sanad)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var reception = await ReceptionBussines.GetAsync(cls.MasterGuid);
                var pardazande = await TafsilBussines.GetAsync(reception.TafsilGuid);

                //بستانکار--شخص
                sanad.AddToListSanad(new SanadDetailBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    Description = $"استرداد چک {cls.CheckNumber} {cls.BankName} * پردازنده: {pardazande.Name}",
                    Debit = 0,
                    Credit = cls.Price,
                    TafsilGuid = pardazande.Guid,
                    MasterGuid = sanad.Guid,
                    MoeinGuid = ParentDefaults.MoeinCoding.CLSMoein10304
                });
                //بدهکار--اسناد
                sanad.AddToListSanad(new SanadDetailBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    Description = $"استرداد چک {cls.CheckNumber} {cls.BankName} * پردازنده: {pardazande.Name}",
                    Debit = cls.Price,
                    Credit = 0,
                    TafsilGuid = cls.SandouqTafsilGuid,
                    MasterGuid = sanad.Guid,
                    MoeinGuid = cls.SandouqMoeinGuid
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
        private static async Task<ReturnedSaveFuncInfo> NaqdBargashtAvalDoreAsync(ReceptionCheckAvalDoreBussines cls, SanadBussines sanad)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                cls.CheckStatus = EnCheckM.Bargashti;
                cls.Modified = DateTime.Now;
                res.AddReturnedValue(await cls.SaveAsync(false));

                var pardazande = await TafsilBussines.GetAsync(cls.TafsilGuid);

                //بستانکار--شخص
                sanad.AddToListSanad(new SanadDetailBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    Description = $"استرداد چک {cls.CheckNumber} {cls.BankName} * پردازنده: {pardazande.Name}",
                    Debit = 0,
                    Credit = cls.Price,
                    TafsilGuid = pardazande.Guid,
                    MasterGuid = sanad.Guid,
                    MoeinGuid = ParentDefaults.MoeinCoding.CLSMoein10304
                });
                //بدهکار--اسناد
                sanad.AddToListSanad(new SanadDetailBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Status = true,
                    Description = $"استرداد چک {cls.CheckNumber} {cls.BankName} * پردازنده: {pardazande.Name}",
                    Debit = cls.Price,
                    Credit = 0,
                    TafsilGuid = cls.SandouqTafsilGuid,
                    MasterGuid = sanad.Guid,
                    MoeinGuid = cls.SandouqMoeinGuid
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
