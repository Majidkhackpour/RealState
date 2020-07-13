using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using EntityCache.Assistence.Defualts;
using EntityCache.Bussines;
using PacketParser.Services;
using Persistence.Model;

namespace EntityCache.Assistence
{
    public class AddDefaults
    {
        public static async Task InsertDefaultDataAsync()
        {
            var dbContext = new ModelContext();
            var res = new ReturnedSaveFuncInfo();

            #region Users

            var allusers = await UserBussines.GetAllAsync();
            if (allusers == null || allusers.Count <= 0)
            {
                var user = new UserBussines()
                {
                    Guid = Guid.NewGuid(),
                    Name = "کاربر پیش فرض",
                    UserName = "Admin",
                };
                var ue = new UTF8Encoding();
                var bytes = ue.GetBytes("1111");
                var md5 = new MD5CryptoServiceProvider();
                var hashBytes = md5.ComputeHash(bytes);
                user.Password = System.Text.RegularExpressions.Regex.Replace(BitConverter.ToString(hashBytes), "-", "")
                    .ToLower();
                res.AddReturnedValue(await user.SaveAsync());
                res.ThrowExceptionIfError();
            }
            #endregion

            #region States
            var allStates = await StatesBussines.GetAllAsync();
            if (allStates == null || allStates.Count <= 0)
            {
                var states = DefaultStates.SetDef();
                res.AddReturnedValue(await StatesBussines.SaveRangeAsync(states));
                res.ThrowExceptionIfError();
            }
            #endregion

            #region Cities
            var allCities = await CitiesBussines.GetAllAsync();
            if (allCities == null || allCities.Count <= 0)
            {
                var city = DefaultCities.SetDef();
                res.AddReturnedValue(await CitiesBussines.SaveRangeAsync(city));
                res.ThrowExceptionIfError();
            }
            #endregion

            #region Regions
            var allRegions = await RegionsBussines.GetAllAsync();
            if (allRegions == null || allRegions.Count <= 0)
            {
                var reg = DefaultRegions.SetDef();
                res.AddReturnedValue(await RegionsBussines.SaveRangeAsync(reg));
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
                res.AddReturnedValue(await BuildingAccountTypeBussines.SaveRangeAsync(bat));
                res.ThrowExceptionIfError();
            }
            #endregion

            #region FloorCover
            var allfc = await FloorCoverBussines.GetAllAsync();
            if (allfc == null || allfc.Count <= 0)
            {
                var fc = DefaultFloorCover.SetDef();
                res.AddReturnedValue(await FloorCoverBussines.SaveRangeAsync(fc));
                res.ThrowExceptionIfError();
            }
            #endregion

            #region KitchenService
            var allks = await KitchenServiceBussines.GetAllAsync();
            if (allks == null || allks.Count <= 0)
            {
                var ks = DefaultKitchenService.SetDef();
                res.AddReturnedValue(await KitchenServiceBussines.SaveRangeAsync(ks));
                res.ThrowExceptionIfError();
            }
            #endregion

            #region DocumentType
            var alldt = await DocumentTypeBussines.GetAllAsync();
            if (alldt == null || alldt.Count <= 0)
            {
                var dt = DefaultDocumentType.SetDef();
                res.AddReturnedValue(await DocumentTypeBussines.SaveRangeAsync(dt));
                res.ThrowExceptionIfError();
            }
            #endregion

            #region RentalAuthority
            var allra = await RentalAuthorityBussines.GetAllAsync();
            if (allra == null || allra.Count <= 0)
            {
                var ra = DefaultRentalAuthority.SetDef();
                res.AddReturnedValue(await RentalAuthorityBussines.SaveRangeAsync(ra));
                res.ThrowExceptionIfError();
            }
            #endregion

            #region BuildingView
            var allbv = await BuildingViewBussines.GetAllAsync();
            if (allbv == null || allbv.Count <= 0)
            {
                var bv = DefaultBuildingView.SetDef();
                res.AddReturnedValue(await BuildingViewBussines.SaveRangeAsync(bv));
                res.ThrowExceptionIfError();
            }
            #endregion

            #region BuildingCondition
            var allbc = await BuildingConditionBussines.GetAllAsync();
            if (allbc == null || allbc.Count <= 0)
            {
                var bc = DefaultBuildingCondition.SetDef();
                res.AddReturnedValue(await BuildingConditionBussines.SaveRangeAsync(bc));
                res.ThrowExceptionIfError();
            }
            #endregion

            await dbContext.SaveChangesAsync();
            dbContext.Dispose();
        }
    }
}
