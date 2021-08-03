using Advertise.Classes;
using EntityCache.Bussines;
using Notification;
using Services;
using Settings.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealState
{
    public class DivarFiles
    {
        public static void Init() => _ = Task.Run(GetFilesFromDivarAsync);
        private static async Task GetFilesFromDivarAsync()
        {
            try
            {
                if (!VersionAccess.Advertise) return;
                if (!clsAdvertise.IsGiveFile) return;

                var getDate = clsAdvertise.GetFileDate;
                var newDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                if (getDate != null && getDate > newDate) return;

                var reg = "";

                var divarCat = await SerializedDataBussines.GetDivarCategoryAsync();
                if (divarCat == null || divarCat.Count <= 0) return;

                if (string.IsNullOrEmpty(Settings.Classes.clsEconomyUnit.EconomyCity)) return;
                var cities = await SerializedDataBussines.GetDivarCityAsync();
                var cityLocal = await CitiesBussines.GetAsync(Guid.Parse(Settings.Classes.clsEconomyUnit.EconomyCity));
                var divarCity = cities.FirstOrDefault(q => q.Name == cityLocal.Name);
                var cityName = cities.FirstOrDefault(q => q.Name == cityLocal.Name)?.LatinName;

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
                        var divarReg = divarRegions?.FirstOrDefault(q => q.Name.Trim() == regName?.Trim());
                        if (divarReg == null) continue;
                        if (string.IsNullOrEmpty(reg)) reg += $"?districts={divarReg.DivarId}";
                        else reg += $"%2C{divarReg.DivarId}";
                    }
                }

                foreach (var item in divarCat)
                {
                    switch (item.Category)
                    {
                        case EnDivarCategory.RentAppartment:
                            preList = await DivarAPI.GetApartmentRent(divarCity, cityLocal.Guid, reg);
                            if (preList != null && preList.Count > 0)
                            {
                                buildingList.AddRange(preList);
                                rentAppartmentCount = preList.Count;
                            }
                            break;
                        case EnDivarCategory.RentVilla:
                            preList = await DivarAPI.GetVillaRent(divarCity, cityLocal.Guid, reg);
                            if (preList != null && preList.Count > 0)
                            {
                                buildingList.AddRange(preList);
                                rentVillaCount = preList.Count;
                            }
                            break;
                        case EnDivarCategory.BuyAppartment:
                            preList = await DivarAPI.GetApartmentBuy(divarCity, cityLocal.Guid, reg);
                            if (preList != null && preList.Count > 0)
                            {
                                buildingList.AddRange(preList);
                                buyAppartmentCount = preList.Count;
                            }
                            break;
                        case EnDivarCategory.BuyVilla:
                            preList = await DivarAPI.GetVillaBuy(divarCity, cityLocal.Guid, reg);
                            if (preList != null && preList.Count > 0)
                            {
                                buildingList.AddRange(preList);
                                buyVillaCount = preList.Count;
                            }
                            break;
                        case EnDivarCategory.BuyOldHouse:
                            preList = await DivarAPI.GetOldHouseBuy(divarCity, cityLocal.Guid, reg);
                            if (preList != null && preList.Count > 0)
                            {
                                buildingList.AddRange(preList);
                                buyOldCount = preList.Count;
                            }
                            break;
                        case EnDivarCategory.BuyOffice:
                            preList = await DivarAPI.GetOfficeBuy(divarCity, cityLocal.Guid, reg);
                            if (preList != null && preList.Count > 0)
                            {
                                buildingList.AddRange(preList);
                                buyOfficeCount = preList.Count;
                            }
                            break;
                        case EnDivarCategory.BuyStore:
                            preList = await DivarAPI.GetStoreBuy(divarCity, cityLocal.Guid, reg);
                            if (preList != null && preList.Count > 0)
                            {
                                buildingList.AddRange(preList);
                                buyStoreCount = preList.Count;
                            }
                            break;
                        case EnDivarCategory.BuyGuard:
                            preList = await DivarAPI.GetIndustrialBuy(divarCity, cityLocal.Guid, reg);
                            if (preList != null && preList.Count > 0)
                            {
                                buildingList.AddRange(preList);
                                buyGraund = preList.Count;
                            }
                            break;
                        case EnDivarCategory.RentOffice:
                            preList = await DivarAPI.GetOfficeRent(divarCity, cityLocal.Guid, reg);
                            if (preList != null && preList.Count > 0)
                            {
                                buildingList.AddRange(preList);
                                rentOfficeCount = preList.Count;
                            }
                            break;
                        case EnDivarCategory.RentStore:
                            preList = await DivarAPI.GetStoreRent(divarCity, cityLocal.Guid, reg);
                            if (preList != null && preList.Count > 0)
                            {
                                buildingList.AddRange(preList);
                                rentStoreCount = preList.Count;
                            }
                            break;
                        case EnDivarCategory.RentGuard:
                            preList = await DivarAPI.GetIndustrialRent(divarCity, cityLocal.Guid, reg);
                            if (preList != null && preList.Count > 0)
                            {
                                buildingList.AddRange(preList);
                                rentGraund = preList.Count;
                            }
                            break;
                        case EnDivarCategory.ContributionConstruction:
                            preList = await DivarAPI.GetContributionConstruction(divarCity, cityLocal.Guid, reg);
                            if (preList != null && preList.Count > 0)
                            {
                                buildingList.AddRange(preList);
                                mosharekatCount = preList.Count;
                            }
                            break;
                        case EnDivarCategory.PreBuy:
                            preList = await DivarAPI.GetPreeSellHome(divarCity, cityLocal.Guid, reg);
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

                clsAdvertise.GetFileDate = DateTime.Now;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
