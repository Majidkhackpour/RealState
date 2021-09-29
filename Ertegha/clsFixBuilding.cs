using EntityCache.Bussines;
using Services;
using System;
using System.Threading.Tasks;

namespace Ertegha
{
    public class clsFixBuilding
    {
        public static async Task<ReturnedSaveFuncInfo> FixBuildingImage()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                res.AddReturnedValue(await BuildingBussines.FixImageAsync());
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
