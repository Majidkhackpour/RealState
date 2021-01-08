using System;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace Ertegha
{
    public class clsFixBuilding
    {
        public static async Task<ReturnedSaveFuncInfo> FixBuildingImage()
        {
            var res=new ReturnedSaveFuncInfo();
            try
            {
                var all = await BuildingBussines.GetAllAsync();
                all = all.Where(q => string.IsNullOrEmpty(q.Image) && q.GalleryList.Any()).ToList();
                foreach (var item in all)
                {
                    item.Image = item.GalleryList[0].ImageName;
                    res.AddReturnedValue(await item.SaveAsync());
                }
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
