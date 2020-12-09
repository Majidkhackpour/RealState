﻿using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using EntityCache.Assistence.Defualts;
using EntityCache.Bussines;
using Persistence;
using Persistence.Model;
using Services;
using Services.Access;

namespace EntityCache.Assistence
{
    public class AddDefaults
    {
        public static async Task InsertDefaultDataAsync()
        {
            var dbContext = new ModelContext(Cache.ConnectionString);
            var res = new ReturnedSaveFuncInfo();

            #region Users

            var allusers = await UserBussines.GetAllAsync();
            var access = new AccessLevel();
            if (allusers == null || allusers.Count <= 0)
            {
                var user = new UserBussines()
                {
                    Guid = Guid.NewGuid(),
                    Name = "کاربر پیش فرض",
                    UserName = "Admin",
                    SecurityQuestion = 0,
                    Access = Json.ToStringJson(access)
                };
                var ue = new UTF8Encoding();
                var bytes = ue.GetBytes("2211");
                var md5 = new MD5CryptoServiceProvider();
                var hashBytes = md5.ComputeHash(bytes);
                user.Password = System.Text.RegularExpressions.Regex.Replace(BitConverter.ToString(hashBytes), "-", "")
                    .ToLower();
                res.AddReturnedValue(await user.SaveAsync(true, false));
                res.ThrowExceptionIfError();
            }
            #endregion

            #region States
            var allStates = await StatesBussines.GetAllAsync();
            if (allStates == null || allStates.Count <= 0)
            {
                var states = DefaultStates.SetDef();
                res.AddReturnedValue(await StatesBussines.SaveRangeAsync(states, false));
                res.ThrowExceptionIfError();
            }
            #endregion

            #region Cities
            var allCities = await CitiesBussines.GetAllAsyncEf();
            if (allCities == null || allCities.Count <= 0)
            {
                var city = DefaultCities.SetDef();
                res.AddReturnedValue(await CitiesBussines.SaveRangeAsync(city, false));
                res.ThrowExceptionIfError();
            }
            #endregion

            #region Regions
            var allRegions = await RegionsBussines.GetAllAsyncEf();
            if (allRegions == null || allRegions.Count <= 0)
            {
                var reg = DefaultRegions.SetDef();
                res.AddReturnedValue(await RegionsBussines.SaveRangeAsync(reg, false));
                res.ThrowExceptionIfError();
            }
            #endregion

            #region Naqz
            var allNaqz = await NaqzBussines.GetAllAsync();
            if (allNaqz == null || allNaqz.Count <= 0)
            {
                var naqz = DefaultNaqz.SetDef();
                res.AddReturnedValue(await NaqzBussines.SaveRangeAsync(naqz));
                res.ThrowExceptionIfError();
            }
            #endregion

            #region BuildingOption
            var allbo = await BuildingOptionsBussines.GetAllAsync();
            if (allbo == null || allbo.Count <= 0)
            {
                var bo = DefaultBuildingOptions.SetDef();
                res.AddReturnedValue(await BuildingOptionsBussines.SaveRangeAsync(bo));
                res.ThrowExceptionIfError();
            }
            #endregion

            #region BuildingAccountType
            var allbat = await BuildingAccountTypeBussines.GetAllAsync();
            if (allbat == null || allbat.Count <= 0)
            {
                var bat = DefaultBuildingAccountType.SetDef();
                res.AddReturnedValue(await BuildingAccountTypeBussines.SaveRangeAsync(bat, false));
                res.ThrowExceptionIfError();
            }
            #endregion

            #region FloorCover
            var allfc = await FloorCoverBussines.GetAllAsync();
            if (allfc == null || allfc.Count <= 0)
            {
                var fc = DefaultFloorCover.SetDef();
                res.AddReturnedValue(await FloorCoverBussines.SaveRangeAsync(fc, false));
                res.ThrowExceptionIfError();
            }
            #endregion

            #region KitchenService
            var allks = await KitchenServiceBussines.GetAllAsync();
            if (allks == null || allks.Count <= 0)
            {
                var ks = DefaultKitchenService.SetDef();
                res.AddReturnedValue(await KitchenServiceBussines.SaveRangeAsync(ks, false));
                res.ThrowExceptionIfError();
            }
            #endregion

            #region DocumentType
            var alldt = await DocumentTypeBussines.GetAllAsync();
            if (alldt == null || alldt.Count <= 0)
            {
                var dt = DefaultDocumentType.SetDef();
                res.AddReturnedValue(await DocumentTypeBussines.SaveRangeAsync(dt, false));
                res.ThrowExceptionIfError();
            }
            #endregion

            #region RentalAuthority
            var allra = await RentalAuthorityBussines.GetAllAsync();
            if (allra == null || allra.Count <= 0)
            {
                var ra = DefaultRentalAuthority.SetDef();
                res.AddReturnedValue(await RentalAuthorityBussines.SaveRangeAsync(ra, false));
                res.ThrowExceptionIfError();
            }
            #endregion

            #region BuildingView
            var allbv = await BuildingViewBussines.GetAllAsync();
            if (allbv == null || allbv.Count <= 0)
            {
                var bv = DefaultBuildingView.SetDef();
                res.AddReturnedValue(await BuildingViewBussines.SaveRangeAsync(bv, false));
                res.ThrowExceptionIfError();
            }
            #endregion

            #region BuildingCondition
            var allbc = await BuildingConditionBussines.GetAllAsync();
            if (allbc == null || allbc.Count <= 0)
            {
                var bc = DefaultBuildingCondition.SetDef();
                res.AddReturnedValue(await BuildingConditionBussines.SaveRangeAsync(bc, false));
                res.ThrowExceptionIfError();
            }
            #endregion

            #region BuildingType
            var allbt = await BuildingTypeBussines.GetAllAsync();
            if (allbt == null || allbt.Count <= 0)
            {
                var bo = DefaultBuildingType.SetDef();
                res.AddReturnedValue(await BuildingTypeBussines.SaveRangeAsync(bo, false));
                res.ThrowExceptionIfError();
            }
            #endregion

            #region PeopleGroup
            var allpg = await PeopleGroupBussines.GetAllAsync();
            if (allpg == null || allpg.Count <= 0)
            {
                var reg = DefaultPeopleGroup.SetDef();
                res.AddReturnedValue(await PeopleGroupBussines.SaveRangeAsync(reg, false));
                res.ThrowExceptionIfError();
            }
            #endregion

            #region Hazine
            var allhazine = await HazineBussines.GetAllAsync();
            if (allhazine == null || allhazine.Count <= 0)
            {
                var reg = DefaultHazine.SetDef();
                res.AddReturnedValue(await HazineBussines.SaveRangeAsync(reg, false));
                res.ThrowExceptionIfError();
            }
            #endregion

            #region Setting
            var allSetting = await SettingsBussines.GetAllAsync();
            if (allSetting == null || allSetting.Count <= 0)
            {
                res.AddReturnedValue(SettingsBussines.Save("ArzeshAfzoude", "9"));
                res.AddReturnedValue(SettingsBussines.Save("Tabdil", "2"));
                res.ThrowExceptionIfError();
            }
            #endregion

            await dbContext.SaveChangesAsync();
            dbContext.Dispose();
        }
    }
}
