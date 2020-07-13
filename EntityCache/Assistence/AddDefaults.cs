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
            if (allusers.Count <= 0)
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
            if (allStates.Count <= 0)
            {
                var states = DefaultStates.SetDef();
                res.AddReturnedValue(await StatesBussines.SaveRangeAsync(states));
                res.ThrowExceptionIfError();
            }
            #endregion

            #region Cities
            var allCities = await CitiesBussines.GetAllAsync();
            if (allCities.Count <= 0)
            {
                var city = DefaultCities.SetDef();
                res.AddReturnedValue(await CitiesBussines.SaveRangeAsync(city));
                res.ThrowExceptionIfError();
            }
            #endregion

            #region Regions
            var allRegions = await RegionsBussines.GetAllAsync();
            if (allRegions.Count <= 0)
            {
                var reg = DefaultRegions.SetDef();
                res.AddReturnedValue(await RegionsBussines.SaveRangeAsync(reg));
                res.ThrowExceptionIfError();
            }
            #endregion

            #region Naqz
            var allNaqz = await NaqzBussines.GetAllAsync();
            if (allNaqz.Count <= 0)
            {
                var naqz = DefaultNaqz.SetDef();
                res.AddReturnedValue(await NaqzBussines.SaveRangeAsync(naqz));
                res.ThrowExceptionIfError();
            }
            #endregion

            await dbContext.SaveChangesAsync();
            dbContext.Dispose();
        }
    }
}
