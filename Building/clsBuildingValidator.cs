using System;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace Building
{
    public static class clsBuildingValidator
    {
        public static async Task<ReturnedSaveFuncInfo> CheckValidationAsync(BuildingBussines bu)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                res.AddReturnedValue(await bu.CheckValidationAsync());
                switch (bu.Parent)
                {
                    case EnBuildingParent.SellAprtment:
                        res.AddReturnedValue(SellApartmentValidation(bu));
                        break;
                    case EnBuildingParent.SellHome:
                        res.AddReturnedValue(SellHomeValidation(bu));
                        break;
                    case EnBuildingParent.SellLand:
                        res.AddReturnedValue(SellLandValidation(bu));
                        break;
                    case EnBuildingParent.SellVilla:
                        res.AddReturnedValue(SellVillaValidation(bu));
                        break;
                    case EnBuildingParent.SellStore:
                        res.AddReturnedValue(SellStoreValidation(bu));
                        break;
                    case EnBuildingParent.SellOffice:
                        res.AddReturnedValue(SellOfficeValidation(bu));
                        break;
                    case EnBuildingParent.SellGarden:
                        res.AddReturnedValue(SellGardenValidation(bu));
                        break;
                    case EnBuildingParent.SellOldHouse:
                        res.AddReturnedValue(SellOldHouseValidation(bu));
                        break;
                    case EnBuildingParent.RentAprtment:
                        res.AddReturnedValue(RahnAppartmentValidation(bu, false));
                        break;
                    case EnBuildingParent.RentHome:
                        res.AddReturnedValue(RahnHomeValidation(bu, false));
                        break;
                    case EnBuildingParent.RentStore:
                        res.AddReturnedValue(RahnStoreValidation(bu, false));
                        break;
                    case EnBuildingParent.RentOffice:
                        res.AddReturnedValue(RahnOfficeValidation(bu, false));
                        break;
                    case EnBuildingParent.FullRentAprtment:
                        res.AddReturnedValue(RahnAppartmentValidation(bu, true));
                        break;
                    case EnBuildingParent.FullRentHome:
                        res.AddReturnedValue(RahnHomeValidation(bu, true));
                        break;
                    case EnBuildingParent.FullRentStore:
                        res.AddReturnedValue(RahnStoreValidation(bu, true));
                        break;
                    case EnBuildingParent.FullRentOffice:
                        res.AddReturnedValue(RahnOfficeValidation(bu, true));
                        break;
                    case EnBuildingParent.PreSellAprtment:
                        res.AddReturnedValue(OtherAppartmentValidation(bu));
                        break;
                    case EnBuildingParent.PreSellHome:
                        res.AddReturnedValue(OtherHomeValidation(bu));
                        break;
                    case EnBuildingParent.PreSellStore:
                        res.AddReturnedValue(OtherStoreValidation(bu));
                        break;
                    case EnBuildingParent.PreSellOffice:
                        res.AddReturnedValue(OtherOfficeValidation(bu));
                        break;
                    case EnBuildingParent.MoavezeAprtment:
                        res.AddReturnedValue(OtherAppartmentValidation(bu));
                        break;
                    case EnBuildingParent.MoavezeHome:
                        res.AddReturnedValue(OtherHomeValidation(bu));
                        break;
                    case EnBuildingParent.MoavezeStore:
                        res.AddReturnedValue(OtherStoreValidation(bu));
                        break;
                    case EnBuildingParent.MoavezeOffice:
                        res.AddReturnedValue(OtherOfficeValidation(bu));
                        break;
                    case EnBuildingParent.MosharekatAprtment:
                        res.AddReturnedValue(OtherAppartmentValidation(bu));
                        break;
                    case EnBuildingParent.MosharekatHome:
                        res.AddReturnedValue(OtherHomeValidation(bu));
                        break;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private static ReturnedSaveFuncInfo SellApartmentValidation(BuildingBussines bu)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (bu.ZirBana <= 0) res.AddError("وارد کردن زیربنا اجباری می باشد");
                //if (bu.Masahat > bu.ZirBana) res.AddError($"متراژ زمین ({bu.Masahat}) از زیربنا ({bu.ZirBana}) بزرگتر است");
                if (bu.TedadTabaqe <= 0) res.AddError("وارد کردن تعداد طبقات اجباری است");
                if (bu.SellPrice <= 0) res.AddError("وارد کردن قیمت کل اجباری است");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private static ReturnedSaveFuncInfo SellHomeValidation(BuildingBussines bu)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (bu.Masahat <= 0) res.AddError("وارد کردن متراژ زمین اجباری می باشد");
                if (bu.SellPrice <= 0) res.AddError("وارد کردن قیمت کل اجباری است");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private static ReturnedSaveFuncInfo SellLandValidation(BuildingBussines bu)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (bu.Masahat <= 0) res.AddError("وارد کردن متراژ زمین اجباری می باشد");
                if (bu.SellPrice <= 0) res.AddError("وارد کردن قیمت کل اجباری است");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private static ReturnedSaveFuncInfo SellVillaValidation(BuildingBussines bu)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (bu.ZirBana <= 0) res.AddError("وارد کردن زیربنا اجباری می باشد");
                if (bu.Masahat <= 0) res.AddError("وارد کردن متراژ زمین اجباری می باشد");
                //if (bu.Masahat > bu.ZirBana) res.AddError($"متراژ زمین ({bu.Masahat}) از زیربنا ({bu.ZirBana}) بزرگتر است");
                if (bu.SellPrice <= 0) res.AddError("وارد کردن قیمت کل اجباری است");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private static ReturnedSaveFuncInfo SellStoreValidation(BuildingBussines bu)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (bu.ZirBana <= 0) res.AddError("وارد کردن زیربنا اجباری می باشد");
                if (bu.SellPrice <= 0) res.AddError("وارد کردن قیمت کل اجباری است");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private static ReturnedSaveFuncInfo SellOfficeValidation(BuildingBussines bu)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (bu.ZirBana <= 0) res.AddError("وارد کردن زیربنا اجباری می باشد");
                if (bu.TedadTabaqe <= 0) res.AddError("وارد کردن تعداد طبقات اجباری است");
                if (bu.SellPrice <= 0) res.AddError("وارد کردن قیمت کل اجباری است");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private static ReturnedSaveFuncInfo SellGardenValidation(BuildingBussines bu)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (bu.ZirBana <= 0) res.AddError("وارد کردن زیربنا اجباری می باشد");
                if (bu.Masahat <= 0) res.AddError("وارد کردن متراژ زمین اجباری می باشد");
                //if (bu.Masahat > bu.ZirBana) res.AddError($"متراژ زمین ({bu.Masahat}) از زیربنا ({bu.ZirBana}) بزرگتر است");
                if (bu.SellPrice <= 0) res.AddError("وارد کردن قیمت کل اجباری است");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private static ReturnedSaveFuncInfo SellOldHouseValidation(BuildingBussines bu)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (bu.Masahat <= 0) res.AddError("وارد کردن متراژ زمین اجباری می باشد");
                if (bu.SellPrice <= 0) res.AddError("وارد کردن قیمت کل اجباری است");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private static ReturnedSaveFuncInfo RahnAppartmentValidation(BuildingBussines bu, bool isFullRahn)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (bu.ZirBana <= 0) res.AddError("وارد کردن زیربنا اجباری می باشد");
                if (bu.TedadTabaqe <= 0) res.AddError("وارد کردن تعداد طبقات اجباری است");
                if (bu.RahnPrice1 <= 0) res.AddError("وارد کردن رهن اجباری است");
                if (!isFullRahn)
                    if (bu.EjarePrice1 <= 0) res.AddError("وارد کردن اجاره اجباری است");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private static ReturnedSaveFuncInfo RahnHomeValidation(BuildingBussines bu, bool isFullRahn)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (bu.Masahat <= 0) res.AddError("وارد کردن متراژ زمین اجباری می باشد");
                if (bu.RahnPrice1 <= 0) res.AddError("وارد کردن رهن اجباری است");
                if (!isFullRahn)
                    if (bu.EjarePrice1 <= 0) res.AddError("وارد کردن اجاره اجباری است");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private static ReturnedSaveFuncInfo RahnStoreValidation(BuildingBussines bu, bool isFullRahn)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (bu.ZirBana <= 0) res.AddError("وارد کردن زیربنا اجباری می باشد");
                if (bu.RahnPrice1 <= 0) res.AddError("وارد کردن رهن اجباری است");
                if (!isFullRahn)
                    if (bu.EjarePrice1 <= 0) res.AddError("وارد کردن اجاره اجباری است");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private static ReturnedSaveFuncInfo RahnOfficeValidation(BuildingBussines bu, bool isFullRahn)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (bu.ZirBana <= 0) res.AddError("وارد کردن زیربنا اجباری می باشد");
                if (bu.TedadTabaqe <= 0) res.AddError("وارد کردن تعداد طبقات اجباری است");
                if (bu.RahnPrice1 <= 0) res.AddError("وارد کردن رهن اجباری است");
                if (!isFullRahn)
                    if (bu.EjarePrice1 <= 0) res.AddError("وارد کردن اجاره اجباری است");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private static ReturnedSaveFuncInfo OtherAppartmentValidation(BuildingBussines bu)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (bu.ZirBana <= 0) res.AddError("وارد کردن زیربنا اجباری می باشد");
                if (bu.TedadTabaqe <= 0) res.AddError("وارد کردن تعداد طبقات اجباری است");
                if (bu.SellPrice <= 0) res.AddError("وارد کردن قیمت کل اجباری است");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private static ReturnedSaveFuncInfo OtherHomeValidation(BuildingBussines bu)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (bu.ZirBana <= 0) res.AddError("وارد کردن زیربنا اجباری می باشد");
                if (bu.SellPrice <= 0) res.AddError("وارد کردن قیمت کل اجباری است");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private static ReturnedSaveFuncInfo OtherStoreValidation(BuildingBussines bu)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (bu.ZirBana <= 0) res.AddError("وارد کردن زیربنا اجباری می باشد");
                if (bu.SellPrice <= 0) res.AddError("وارد کردن قیمت کل اجباری است");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private static ReturnedSaveFuncInfo OtherOfficeValidation(BuildingBussines bu)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (bu.ZirBana <= 0) res.AddError("وارد کردن زیربنا اجباری می باشد");
                if (bu.TedadTabaqe <= 0) res.AddError("وارد کردن تعداد طبقات اجباری است");
                if (bu.SellPrice <= 0) res.AddError("وارد کردن قیمت کل اجباری است");
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
