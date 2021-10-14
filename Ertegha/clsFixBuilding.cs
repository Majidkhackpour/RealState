using EntityCache.Bussines;
using Services;
using System;
using System.Linq;
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
        public static async Task<ReturnedSaveFuncInfo> FixBuildingParentAsync()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var list = await BuildingBussines.GetAllWithoutParentAsync();
                list = list?.OrderByDescending(q => q.CreateDate)?.ToList();
                if (list == null || list.Count <= 0) return res;
                foreach (var bu in list)
                    res.AddReturnedValue(await FixBuildingParentAsync_(bu));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public static async Task<ReturnedSaveFuncInfo> FixBuildingParentAsync_(BuildingBussines bu)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (bu.SellPrice > 0)
                {
                    if (bu.BuildingConditionName.Contains("کلنگی"))
                        bu.Parent = EnBuildingParent.SellOldHouse;
                    else if (bu.BuildingAccountTypeName.Contains("دفتر") || bu.BuildingTypeName.Contains("دفتر"))
                        bu.Parent = EnBuildingParent.SellOffice;
                    else if (bu.BuildingTypeName.Contains("مسکونی") || bu.BuildingTypeName.Contains("خانه"))
                        bu.Parent = EnBuildingParent.SellHome;
                    else if (bu.BuildingTypeName.Contains("پارتمان"))
                        bu.Parent = EnBuildingParent.SellAprtment;
                    else if (bu.BuildingTypeName.Contains("باغ"))
                        bu.Parent = EnBuildingParent.SellGarden;
                    else if (bu.BuildingTypeName.Contains("زمین"))
                        bu.Parent = EnBuildingParent.SellLand;
                    else if (bu.BuildingTypeName.Contains("تجاری"))
                        bu.Parent = EnBuildingParent.SellStore;
                    else if (bu.BuildingTypeName.Contains("سوئیت") || bu.BuildingAccountTypeName.Contains("سوییت"))
                        bu.Parent = EnBuildingParent.SellAprtment;
                    else if (bu.BuildingTypeName.Contains("ویلا"))
                        bu.Parent = EnBuildingParent.SellVilla;
                    else if (bu.BuildingTypeName.Contains("مغازه"))
                        bu.Parent = EnBuildingParent.SellStore;
                    else if (bu.BuildingAccountTypeName.Contains("مسکونی"))
                        bu.Parent = EnBuildingParent.SellHome;
                    else await bu.ChangeStatusAsync(false);
                }
                else if ((bu.RahnPrice1 > 0 && bu.EjarePrice1 > 0)|| (bu.RahnPrice1 <= 0 && bu.EjarePrice1 > 0))
                {
                    if (bu.BuildingAccountTypeName.Contains("دفتر") || bu.BuildingTypeName.Contains("دفتر"))
                        bu.Parent = EnBuildingParent.RentOffice;
                    else if (bu.BuildingTypeName.Contains("مسکونی") || bu.BuildingTypeName.Contains("خانه"))
                        bu.Parent = EnBuildingParent.RentHome;
                    else if (bu.BuildingTypeName.Contains("پارتمان"))
                        bu.Parent = EnBuildingParent.RentAprtment;
                    else if (bu.BuildingTypeName.Contains("تجاری"))
                        bu.Parent = EnBuildingParent.RentStore;
                    else if (bu.BuildingTypeName.Contains("سوئیت") || bu.BuildingAccountTypeName.Contains("سوییت"))
                        bu.Parent = EnBuildingParent.RentAprtment;
                    else if (bu.BuildingTypeName.Contains("مغازه"))
                        bu.Parent = EnBuildingParent.RentStore;
                    else if (bu.BuildingAccountTypeName.Contains("مسکونی"))
                        bu.Parent = EnBuildingParent.RentHome;
                    else await bu.ChangeStatusAsync(false);
                }
                else if (bu.RahnPrice1 > 0 && bu.EjarePrice1 <= 0)
                {
                    if (bu.BuildingAccountTypeName.Contains("دفتر") || bu.BuildingTypeName.Contains("دفتر"))
                        bu.Parent = EnBuildingParent.FullRentOffice;
                    else if (bu.BuildingTypeName.Contains("مسکونی") || bu.BuildingTypeName.Contains("خانه"))
                        bu.Parent = EnBuildingParent.FullRentHome;
                    else if (bu.BuildingTypeName.Contains("پارتمان"))
                        bu.Parent = EnBuildingParent.FullRentAprtment;
                    else if (bu.BuildingTypeName.Contains("تجاری"))
                        bu.Parent = EnBuildingParent.FullRentStore;
                    else if (bu.BuildingTypeName.Contains("سوئیت") || bu.BuildingTypeName.Contains("سوییت"))
                        bu.Parent = EnBuildingParent.FullRentAprtment;
                    else if (bu.BuildingTypeName.Contains("مغازه"))
                        bu.Parent = EnBuildingParent.FullRentStore;
                    else if (bu.BuildingAccountTypeName.Contains("مسکونی"))
                        bu.Parent = EnBuildingParent.FullRentHome;
                    else await bu.ChangeStatusAsync(false);
                }
                else if (bu.PishTotalPrice > 0 || !string.IsNullOrEmpty(bu.PishDesc))
                {
                    if (bu.BuildingAccountTypeName.Contains("دفتر") || bu.BuildingTypeName.Contains("دفتر"))
                        bu.Parent = EnBuildingParent.PreSellOffice;
                    else if (bu.BuildingTypeName.Contains("مسکونی") || bu.BuildingTypeName.Contains("خانه"))
                        bu.Parent = EnBuildingParent.PreSellHome;
                    else if (bu.BuildingTypeName.Contains("پارتمان"))
                        bu.Parent = EnBuildingParent.PreSellAprtment;
                    else if (bu.BuildingTypeName.Contains("تجاری"))
                        bu.Parent = EnBuildingParent.PreSellStore;
                    else if (bu.BuildingTypeName.Contains("سوئیت") || bu.BuildingTypeName.Contains("سوییت"))
                        bu.Parent = EnBuildingParent.PreSellAprtment;
                    else if (bu.BuildingTypeName.Contains("مغازه"))
                        bu.Parent = EnBuildingParent.PreSellStore;
                    else if (bu.BuildingAccountTypeName.Contains("مسکونی"))
                        bu.Parent = EnBuildingParent.PreSellHome;
                    else await bu.ChangeStatusAsync(false);
                }
                else if (!string.IsNullOrEmpty(bu.MosharekatDesc))
                {
                    if (bu.BuildingTypeName.Contains("مسکونی") || bu.BuildingTypeName.Contains("خانه") || bu.BuildingAccountTypeName.Contains("مسکونی"))
                        bu.Parent = EnBuildingParent.MosharekatHome;
                    else if (bu.BuildingTypeName.Contains("پارتمان"))
                        bu.Parent = EnBuildingParent.MosharekatAprtment;
                    else await bu.ChangeStatusAsync(false);
                }
                if (bu.Parent != null)
                    res.AddReturnedValue(await bu.ChangeParentAsync(bu.Parent.Value));
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
