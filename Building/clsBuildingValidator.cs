using System;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace Building
{
    public static class clsBuildingValidator
    {
        public static async Task<ReturnedSaveFuncInfo> CheckValidationAsync(BuildingBussines bu, EnBuildingParent parent)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                res.AddReturnedValue(await bu.CheckValidationAsync());
                switch (parent)
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
                        break;
                    case EnBuildingParent.SellStore:
                        break;
                    case EnBuildingParent.SellOffice:
                        break;
                    case EnBuildingParent.SellGarden:
                        break;
                    case EnBuildingParent.SellOldHouse:
                        break;
                    case EnBuildingParent.RentAprtment:
                        break;
                    case EnBuildingParent.RentHome:
                        break;
                    case EnBuildingParent.RentStore:
                        break;
                    case EnBuildingParent.RentOffice:
                        break;
                    case EnBuildingParent.FullRentAprtment:
                        break;
                    case EnBuildingParent.FullRentHome:
                        break;
                    case EnBuildingParent.FullRentStore:
                        break;
                    case EnBuildingParent.FullRentOffice:
                        break;
                    case EnBuildingParent.PreSellAprtment:
                        break;
                    case EnBuildingParent.PreSellHome:
                        break;
                    case EnBuildingParent.PreSellStore:
                        break;
                    case EnBuildingParent.PreSellOffice:
                        break;
                    case EnBuildingParent.MoavezeAprtment:
                        break;
                    case EnBuildingParent.MoavezeHome:
                        break;
                    case EnBuildingParent.MoavezeStore:
                        break;
                    case EnBuildingParent.MoavezeOffice:
                        break;
                    case EnBuildingParent.MosharekatAprtment:
                        break;
                    case EnBuildingParent.MosharekatHome:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(parent), parent, null);
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
                if (bu.Masahat > bu.ZirBana) res.AddError($"متراژ زمین ({bu.Masahat}) از زیربنا ({bu.ZirBana}) بزرگتر است");
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
                if (bu.Masahat > bu.ZirBana) res.AddError($"متراژ زمین ({bu.Masahat}) از زیربنا ({bu.ZirBana}) بزرگتر است");
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
