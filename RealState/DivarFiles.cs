using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Advertise.Classes;
using EntityCache.Bussines;
using Notification;
using Services;

namespace RealState
{
    public class DivarFiles
    {
        public static void Init() => _ = Task.Run(GetFilesFromDivarAsync);
        private static async Task GetFilesFromDivarAsync()
        {
            try
            {
                var reg = "";
                var divarCat = await SerializedDataBussines.GetDivarCategoryAsync();
                if (divarCat == null || divarCat.Count <= 0) return;

                var buildingList = new List<BuildingBussines>();
                var preList = new List<BuildingBussines>();
                int rentAppartmentCount = 0, rentVillaCount = 0, rentOfficeCount = 0, rentStoreCount = 0, rentGraund = 0;
                int buyAppartmentCount = 0, buyOldCount = 0, buyVillaCount = 0, buyOfficeCount = 0, buyStoreCount = 0, buyGraund = 0;
                int mosharekatCount = 0, preBuyCount = 0;

                var list = await WorkingRangeBussines.GetAllAsync();
                if (list != null && list.Count > 0)
                {
                    var divarRegions = await SerializedDataBussines.GetDivarRegionAsync();
                    for (var i = 0; i < list.Count; i++)
                    {
                        var regName = RegionsBussines.Get(list[i].RegionGuid)?.Name;
                        var divarReg = divarRegions?.FirstOrDefault(q => q.Name == regName);
                        if (divarReg == null) continue;
                        if (i == 0) reg += $"?districts={divarReg.DivarId}%";
                        else reg += $"2C{divarReg.DivarId}%";
                    }
                }

                foreach (var item in divarCat)
                {
                    switch (item.Category)
                    {
                        case EnDivarCategory.RentAppartment:
                            preList = DivarAPI.GetApartmentRent(reg);
                            if (preList != null && preList.Count > 0)
                            {
                                buildingList.AddRange(preList);
                                rentAppartmentCount = preList.Count;
                            }
                            break;
                        case EnDivarCategory.RentVilla:
                            preList = DivarAPI.GetVillaRent(reg);
                            if (preList != null && preList.Count > 0)
                            {
                                buildingList.AddRange(preList);
                                rentVillaCount = preList.Count;
                            }
                            break;
                        case EnDivarCategory.BuyAppartment:
                            preList = DivarAPI.GetApartmentBuy(reg);
                            if (preList != null && preList.Count > 0)
                            {
                                buildingList.AddRange(preList);
                                buyAppartmentCount = preList.Count;
                            }
                            break;
                        case EnDivarCategory.BuyVilla:
                            preList = DivarAPI.GetVillaBuy(reg);
                            if (preList != null && preList.Count > 0)
                            {
                                buildingList.AddRange(preList);
                                buyVillaCount = preList.Count;
                            }
                            break;
                        case EnDivarCategory.BuyOldHouse:
                            preList = DivarAPI.GetOldHouseBuy(reg);
                            if (preList != null && preList.Count > 0)
                            {
                                buildingList.AddRange(preList);
                                buyOldCount = preList.Count;
                            }
                            break;
                        case EnDivarCategory.BuyOffice:
                            preList = DivarAPI.GetOfficeBuy(reg);
                            if (preList != null && preList.Count > 0)
                            {
                                buildingList.AddRange(preList);
                                buyOfficeCount = preList.Count;
                            }
                            break;
                        case EnDivarCategory.BuyStore:
                            preList = DivarAPI.GetStoreBuy(reg);
                            if (preList != null && preList.Count > 0)
                            {
                                buildingList.AddRange(preList);
                                buyStoreCount = preList.Count;
                            }
                            break;
                        case EnDivarCategory.BuyGuard:
                            preList = DivarAPI.GetIndustrialBuy(reg);
                            if (preList != null && preList.Count > 0)
                            {
                                buildingList.AddRange(preList);
                                buyGraund = preList.Count;
                            }
                            break;
                        case EnDivarCategory.RentOffice:
                            preList = DivarAPI.GetOfficeRent(reg);
                            if (preList != null && preList.Count > 0)
                            {
                                buildingList.AddRange(preList);
                                rentOfficeCount = preList.Count;
                            }
                            break;
                        case EnDivarCategory.RentStore:
                            preList = DivarAPI.GetStoreRent(reg);
                            if (preList != null && preList.Count > 0)
                            {
                                buildingList.AddRange(preList);
                                rentStoreCount = preList.Count;
                            }
                            break;
                        case EnDivarCategory.RentGuard:
                            preList = DivarAPI.GetIndustrialRent(reg);
                            if (preList != null && preList.Count > 0)
                            {
                                buildingList.AddRange(preList);
                                rentGraund = preList.Count;
                            }
                            break;
                        case EnDivarCategory.ContributionConstruction:
                            preList = DivarAPI.GetContributionConstruction(reg);
                            if (preList != null && preList.Count > 0)
                            {
                                buildingList.AddRange(preList);
                                mosharekatCount = preList.Count;
                            }
                            break;
                        case EnDivarCategory.PreBuy:
                            preList = DivarAPI.GetPreeSellHome(reg);
                            if (preList != null && preList.Count > 0)
                            {
                                buildingList.AddRange(preList);
                                preBuyCount = preList.Count;
                            }
                            break;
                    }
                }

                if (buildingList != null && buildingList.Count > 0)
                {
                    await BuildingBussines.SaveRangeAsync(buildingList);
                    var frm = new frmDivarNotification(rentAppartmentCount, rentVillaCount, rentOfficeCount,
                        rentStoreCount,
                        rentGraund, buyAppartmentCount, buyOldCount, buyVillaCount, buyOfficeCount,
                        buyStoreCount, buyGraund, mosharekatCount, preBuyCount);
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
