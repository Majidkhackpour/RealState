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
                var condition = await BuildingConditionBussines.GetAsync(bu.BuildingConditionGuid ?? Guid.Empty);
                var accountType = await BuildingAccountTypeBussines.GetAsync(bu.BuildingAccountTypeGuid);
                var type = await BuildingTypeBussines.GetAsync(bu.BuildingTypeGuid);
                if (bu.SellPrice > 0)
                {
                    if (condition?.Name?.Contains("کلنگی") ?? false)
                        bu.Parent = EnBuildingParent.SellOldHouse;
                    else if ((accountType?.Name?.Contains("دفتر") ?? false) || (type?.Name?.Contains("دفتر") ?? false))
                        bu.Parent = EnBuildingParent.SellOffice;
                    else if ((type?.Name?.Contains("مسکونی") ?? false) || (type?.Name?.Contains("خانه") ?? false))
                        bu.Parent = EnBuildingParent.SellHome;
                    else if (type?.Name?.Contains("پارتمان") ?? false)
                        bu.Parent = EnBuildingParent.SellAprtment;
                    else if (type?.Name?.Contains("باغ") ?? false)
                        bu.Parent = EnBuildingParent.SellGarden;
                    else if (type?.Name?.Contains("زمین") ?? false)
                        bu.Parent = EnBuildingParent.SellLand;
                    else if (type?.Name?.Contains("تجاری") ?? false)
                        bu.Parent = EnBuildingParent.SellStore;
                    else if ((type?.Name?.Contains("سوئیت") ?? false) || (accountType?.Name?.Contains("سوییت") ?? false))
                        bu.Parent = EnBuildingParent.SellAprtment;
                    else if (type?.Name?.Contains("ویلا") ?? false)
                        bu.Parent = EnBuildingParent.SellVilla;
                    else if (type?.Name?.Contains("مغازه") ?? false)
                        bu.Parent = EnBuildingParent.SellStore;
                    else if (accountType?.Name?.Contains("مسکونی") ?? false)
                        bu.Parent = EnBuildingParent.SellHome;
                    else await bu.ChangeStatusAsync(false);
                }
                else if ((bu.RahnPrice1 > 0 && bu.EjarePrice1 > 0) || (bu.RahnPrice1 <= 0 && bu.EjarePrice1 > 0))
                {
                    if ((accountType?.Name?.Contains("دفتر") ?? false) || (type?.Name?.Contains("دفتر") ?? false))
                        bu.Parent = EnBuildingParent.RentOffice;
                    else if ((type?.Name?.Contains("مسکونی") ?? false) || (type?.Name?.Contains("خانه") ?? false))
                        bu.Parent = EnBuildingParent.RentHome;
                    else if (type?.Name?.Contains("پارتمان") ?? false)
                        bu.Parent = EnBuildingParent.RentAprtment;
                    else if (type?.Name?.Contains("تجاری") ?? false)
                        bu.Parent = EnBuildingParent.RentStore;
                    else if ((type?.Name?.Contains("سوئیت") ?? false) || (accountType?.Name?.Contains("سوییت") ?? false))
                        bu.Parent = EnBuildingParent.RentAprtment;
                    else if (type?.Name?.Contains("مغازه") ?? false)
                        bu.Parent = EnBuildingParent.RentStore;
                    else if (accountType?.Name?.Contains("مسکونی") ?? false)
                        bu.Parent = EnBuildingParent.RentHome;
                    else await bu.ChangeStatusAsync(false);
                }
                else if (bu.RahnPrice1 > 0 && bu.EjarePrice1 <= 0)
                {
                    if ((accountType?.Name?.Contains("دفتر") ?? false) || (type?.Name?.Contains("دفتر") ?? false))
                        bu.Parent = EnBuildingParent.FullRentOffice;
                    else if ((type?.Name?.Contains("مسکونی") ?? false) || (type?.Name?.Contains("خانه") ?? false))
                        bu.Parent = EnBuildingParent.FullRentHome;
                    else if (type?.Name?.Contains("پارتمان") ?? false)
                        bu.Parent = EnBuildingParent.FullRentAprtment;
                    else if (type?.Name?.Contains("تجاری") ?? false)
                        bu.Parent = EnBuildingParent.FullRentStore;
                    else if ((type?.Name?.Contains("سوئیت") ?? false) || (type?.Name?.Contains("سوییت") ?? false))
                        bu.Parent = EnBuildingParent.FullRentAprtment;
                    else if (type?.Name?.Contains("مغازه") ?? false)
                        bu.Parent = EnBuildingParent.FullRentStore;
                    else if (accountType?.Name?.Contains("مسکونی") ?? false)
                        bu.Parent = EnBuildingParent.FullRentHome;
                    else await bu.ChangeStatusAsync(false);
                }
                else if (bu.PishTotalPrice > 0 || !string.IsNullOrEmpty(bu.PishDesc))
                {
                    if ((accountType?.Name?.Contains("دفتر") ?? false) || (type?.Name?.Contains("دفتر") ?? false))
                        bu.Parent = EnBuildingParent.PreSellOffice;
                    else if ((type?.Name?.Contains("مسکونی") ?? false) || (type?.Name?.Contains("خانه") ?? false))
                        bu.Parent = EnBuildingParent.PreSellHome;
                    else if (type?.Name?.Contains("پارتمان") ?? false)
                        bu.Parent = EnBuildingParent.PreSellAprtment;
                    else if (type?.Name?.Contains("تجاری") ?? false)
                        bu.Parent = EnBuildingParent.PreSellStore;
                    else if ((type?.Name?.Contains("سوئیت") ?? false) || (type?.Name?.Contains("سوییت") ?? false))
                        bu.Parent = EnBuildingParent.PreSellAprtment;
                    else if (type?.Name?.Contains("مغازه") ?? false)
                        bu.Parent = EnBuildingParent.PreSellStore;
                    else if (accountType?.Name?.Contains("مسکونی") ?? false)
                        bu.Parent = EnBuildingParent.PreSellHome;
                    else await bu.ChangeStatusAsync(false);
                }
                else if (!string.IsNullOrEmpty(bu.MosharekatDesc))
                {
                    if ((type?.Name?.Contains("مسکونی") ?? false) || (type?.Name?.Contains("خانه") ?? false) || (accountType?.Name?.Contains("مسکونی") ?? false))
                        bu.Parent = EnBuildingParent.MosharekatHome;
                    else if (type?.Name?.Contains("پارتمان") ?? false)
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
