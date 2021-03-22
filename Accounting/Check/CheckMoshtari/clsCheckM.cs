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

                cls.CheckStatus = EnCheckM.Naqd;
                cls.Modified = DateTime.Now;
                res.AddReturnedValue(await cls.SaveAsync());

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

                cls.CheckStatus = EnCheckM.Naqd;
                cls.Modified = DateTime.Now;
                res.AddReturnedValue(await cls.SaveAsync());

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
