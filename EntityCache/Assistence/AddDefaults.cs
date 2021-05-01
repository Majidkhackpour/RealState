using EntityCache.Assistence.Defualts;
using EntityCache.Bussines;
using Services;
using Services.Access;
using Services.DefaultCoding;
using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Persistence;

namespace EntityCache.Assistence
{
    public class AddDefaults
    {
        public static async Task InsertDefaultDataAsync()
        {
            var res = new ReturnedSaveFuncInfo();
            SqlTransaction tr = null;
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection(Cache.ConnectionString);
                await cn.OpenAsync();
                tr = cn.BeginTransaction();

                #region Kol
                var allKol = await KolBussines.GetAllAsync();
                if (allKol == null || allKol.Count <= 0)
                {
                    var kol = DefaultKol.SetDef();
                    res.AddReturnedValue(await KolBussines.SaveRangeAsync(kol, tr));
                    if (res.HasError) return;
                }
                #endregion

                #region Moein
                var allMoein = await MoeinBussines.GetAllAsync();
                if (allMoein == null || allMoein.Count <= 0)
                {
                    var moein = DefaultMoein.SetDef();
                    res.AddReturnedValue(await MoeinBussines.SaveRangeAsync(moein, tr));
                    if (res.HasError) return;
                }
                #endregion

                #region Tafsil
                var allTafsil = await TafsilBussines.GetAllAsync();
                if (allTafsil == null || allTafsil.Count <= 0)
                {
                    var tafsil = DefaultTafsil.SetDef();
                    res.AddReturnedValue(await TafsilBussines.SaveRangeAsync(tafsil, tr));
                    if (res.HasError) return;
                }
                #endregion

                #region Bank
                var allBank = await BankBussines.GetAllAsync();
                if (allBank == null || allBank.Count <= 0)
                {
                    var user = new BankBussines()
                    {
                        Guid = ParentDefaults.TafsilCoding.CLSTafsil1010101,
                        Name = "حساب بانکی مرکزی",
                        Code = "1010101",
                    };
                    res.AddReturnedValue(await user.SaveAsync(tr));
                    if (res.HasError) return;
                }
                #endregion

                #region Bank Segest
                var allbs = await BankSegestBussines.GetAllAsync();
                if (allbs == null || allbs.Count <= 0)
                {
                    var bs = DefaultBankSegest.SetDef();
                    res.AddReturnedValue(await BankSegestBussines.SaveRangeAsync(bs, tr));
                    if (res.HasError) return;
                }
                #endregion

                #region Users
                var allusers = await UserBussines.GetAllAsync();
                var access = new AccessLevel();
                if (allusers == null || allusers.Count <= 0)
                {
                    var user = new UserBussines()
                    {
                        Guid = ParentDefaults.TafsilCoding.CLSTafsil1030401,
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
                    res.AddReturnedValue(await user.SaveAsync(tr));
                    if (res.HasError) return;
                }
                #endregion

                #region States
                var allStates = await StatesBussines.GetAllAsync(new CancellationToken());
                if (allStates == null || allStates.Count <= 0)
                {
                    var states = DefaultStates.SetDef();
                    res.AddReturnedValue(await StatesBussines.SaveRangeAsync(states, tr));
                    if (res.HasError) return;
                }
                #endregion

                #region Cities
                var allCities = await CitiesBussines.GetAllAsync(new CancellationToken());
                if (allCities == null || allCities.Count <= 0)
                {
                    var city = DefaultCities.SetDef();
                    res.AddReturnedValue(await CitiesBussines.SaveRangeAsync(city, tr));
                    if (res.HasError) return;
                }
                #endregion

                #region Regions
                var allRegions = await RegionsBussines.GetAllAsync(new CancellationToken());
                if (allRegions == null || allRegions.Count <= 0)
                {
                    var reg = DefaultRegions.SetDef();
                    res.AddReturnedValue(await RegionsBussines.SaveRangeAsync(reg, tr));
                    if (res.HasError) return;
                }
                #endregion

                #region Naqz
                var allNaqz = await NaqzBussines.GetAllAsync();
                if (allNaqz == null || allNaqz.Count <= 0)
                {
                    var naqz = DefaultNaqz.SetDef();
                    res.AddReturnedValue(await NaqzBussines.SaveRangeAsync(naqz, tr));
                    if (res.HasError) return;
                }
                #endregion

                #region BuildingOption
                var allbo = await BuildingOptionsBussines.GetAllAsync(new CancellationToken());
                if (allbo == null || allbo.Count <= 0)
                {
                    var bo = DefaultBuildingOptions.SetDef();
                    res.AddReturnedValue(await BuildingOptionsBussines.SaveRangeAsync(bo, tr));
                    if (res.HasError) return;
                }
                #endregion

                #region BuildingAccountType
                var allbat = await BuildingAccountTypeBussines.GetAllAsync(new CancellationToken());
                if (allbat == null || allbat.Count <= 0)
                {
                    var bat = DefaultBuildingAccountType.SetDef();
                    res.AddReturnedValue(await BuildingAccountTypeBussines.SaveRangeAsync(bat, tr));
                    if (res.HasError) return;
                }
                #endregion

                #region FloorCover
                var allfc = await FloorCoverBussines.GetAllAsync(new CancellationToken());
                if (allfc == null || allfc.Count <= 0)
                {
                    var fc = DefaultFloorCover.SetDef();
                    res.AddReturnedValue(await FloorCoverBussines.SaveRangeAsync(fc, tr));
                    if (res.HasError) return;
                }
                #endregion

                #region KitchenService
                var allks = await KitchenServiceBussines.GetAllAsync(new CancellationToken());
                if (allks == null || allks.Count <= 0)
                {
                    var ks = DefaultKitchenService.SetDef();
                    res.AddReturnedValue(await KitchenServiceBussines.SaveRangeAsync(ks, tr));
                    if (res.HasError) return;
                }
                #endregion

                #region DocumentType
                var alldt = await DocumentTypeBussines.GetAllAsync(new CancellationToken());
                if (alldt == null || alldt.Count <= 0)
                {
                    var dt = DefaultDocumentType.SetDef();
                    res.AddReturnedValue(await DocumentTypeBussines.SaveRangeAsync(dt, tr));
                    if (res.HasError) return;
                }
                #endregion

                #region RentalAuthority
                var allra = await RentalAuthorityBussines.GetAllAsync(new CancellationToken());
                if (allra == null || allra.Count <= 0)
                {
                    var ra = DefaultRentalAuthority.SetDef();
                    res.AddReturnedValue(await RentalAuthorityBussines.SaveRangeAsync(ra, tr));
                    if (res.HasError) return;
                }
                #endregion

                #region BuildingView
                var allbv = await BuildingViewBussines.GetAllAsync(new CancellationToken());
                if (allbv == null || allbv.Count <= 0)
                {
                    var bv = DefaultBuildingView.SetDef();
                    res.AddReturnedValue(await BuildingViewBussines.SaveRangeAsync(bv, tr));
                    if (res.HasError) return;
                }
                #endregion

                #region BuildingCondition
                var allbc = await BuildingConditionBussines.GetAllAsync(new CancellationToken());
                if (allbc == null || allbc.Count <= 0)
                {
                    var bc = DefaultBuildingCondition.SetDef();
                    res.AddReturnedValue(await BuildingConditionBussines.SaveRangeAsync(bc, tr));
                    if (res.HasError) return;
                }
                #endregion

                #region BuildingType
                var allbt = await BuildingTypeBussines.GetAllAsync(new CancellationToken());
                if (allbt == null || allbt.Count <= 0)
                {
                    var bo = DefaultBuildingType.SetDef();
                    res.AddReturnedValue(await BuildingTypeBussines.SaveRangeAsync(bo, tr));
                    if (res.HasError) return;
                }
                #endregion

                #region PeopleGroup
                var allpg = await PeopleGroupBussines.GetAllAsync();
                if (allpg == null || allpg.Count <= 0)
                {
                    var reg = DefaultPeopleGroup.SetDef();
                    res.AddReturnedValue(await PeopleGroupBussines.SaveRangeAsync(reg, tr));
                    if (res.HasError) return;
                }
                #endregion

                #region Setting
                var allSetting = await SettingsBussines.GetAllAsync();
                if (allSetting == null || allSetting.Count <= 0)
                {
                    res.AddReturnedValue(SettingsBussines.Save("ArzeshAfzoude", "9", tr));
                    res.AddReturnedValue(SettingsBussines.Save("Tabdil", "2", tr));
                    if (res.HasError) return;
                }
                #endregion
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                res.AddReturnedValue(tr.TransactionDestiny(res.HasError));
                res.AddReturnedValue(cn.CloseConnection());
            }
        }
    }
}
