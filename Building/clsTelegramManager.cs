using EntityCache.Bussines;
using Payamak;
using Services;
using Settings.Classes;
using System;
using System.Linq;

namespace Building
{
    public class clsTelegramManager
    {
        public static string TelegramText(BuildingBussines bu, string template)
        {
            var res = "";
            try
            {
                res = template;
                var owner = PeoplesBussines.Get(bu.OwnerGuid, bu?.Guid);
                var list = res.Split('\n').ToList();

                if (res.Contains(Replacor.TelegramBuilding.Code))
                {
                    var code = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.Code));
                    if (!string.IsNullOrEmpty(code))
                    {
                        var index = list.IndexOf(code);
                        code = code.Replace("\r", "");
                        code = code.Replace(Replacor.TelegramBuilding.Code, bu.Code);
                        list[index] = code;
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.Type))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.Type));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.Type, bu.BuildingTypeName);
                        list[index] = type;
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.Contract))
                {
                    var contract = bu.SellPrice > 0 ? "فروش" : "رهن و اجاره";
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.Contract));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.Contract, contract);
                        list[index] = type;
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.AccountType))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.AccountType));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.AccountType, bu.BuildingAccountTypeName);
                        if (!string.IsNullOrEmpty(bu.BuildingAccountTypeName) && bu.BuildingAccountTypeName != "تعیین نشده")
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.Region))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.Region));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.Region, bu.RegionName);
                        if (!string.IsNullOrEmpty(bu.RegionName))
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.SellPrice))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.SellPrice));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.SellPrice, bu.SellPrice.ToString("N0"));
                        if (bu.SellPrice > 0)
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.RahnPrice))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.RahnPrice));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.RahnPrice, bu.RahnPrice1.ToString("N0"));
                        if (bu.RahnPrice1 > 0)
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.EjarePrice))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.EjarePrice));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.EjarePrice, bu.EjarePrice1.ToString("N0"));
                        if (bu.EjarePrice1 > 0)
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.Masahat))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.Masahat));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.Masahat, bu.Masahat.ToString());
                        if (bu.Masahat > 0)
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.ZirBana))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.ZirBana));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.ZirBana, bu.ZirBana.ToString());
                        if (bu.ZirBana > 0)
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.DocumentType))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.DocumentType));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.DocumentType, bu.DocumentTypeName);
                        if ((!string.IsNullOrEmpty(bu.DocumentTypeName) && bu.DocumentTypeName != "تعیین نشده") && bu.SellPrice > 0)
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.Side))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.Side));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.Side, bu.SideName);
                        if (!string.IsNullOrEmpty(bu.SideName))
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.Tarakom))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.Tarakom));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.Tarakom, bu.Tarakom?.GetDisplay());
                        if (bu.RahnPrice1 <= 0 || bu.EjarePrice1 <= 0)
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.TabaqeNo))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.TabaqeNo));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.TabaqeNo, bu.TabaqeNo.ToString());
                        if (bu.TabaqeNo == 0)
                            list[index] = type.Replace("0", "همکف");
                        else
                            list[index] = type;
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.TabaqeCount))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.TabaqeCount));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.TabaqeCount, bu.TedadTabaqe.ToString());
                        if (bu.TedadTabaqe > 0)
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.RoomCount))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.RoomCount));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.RoomCount, bu.RoomCount.ToString());
                        if (bu.RoomCount > 0)
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.SaleSakht))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.SaleSakht));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.SaleSakht, bu.SaleSakht);
                        if (!string.IsNullOrEmpty(bu.SaleSakht))
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.Tejari))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.Tejari));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.Tejari, bu.MetrazhTejari.ToString());
                        if (bu.MetrazhTejari > 0)
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.Channel))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.Channel));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.Channel, clsTelegram.Channel);
                        if (!string.IsNullOrEmpty(clsTelegram.Channel))
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.Address))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.Address));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.Address, clsEconomyUnit.ManagerAddress);
                        if (!string.IsNullOrEmpty(clsEconomyUnit.ManagerAddress))
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.Tell))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.Tell));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.Tell, clsEconomyUnit.ManagerTell);
                        if (!string.IsNullOrEmpty(clsEconomyUnit.ManagerTell))
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.Mobile))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.Mobile));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.Mobile, clsEconomyUnit.ManagerMobile);
                        if (!string.IsNullOrEmpty(clsEconomyUnit.ManagerMobile))
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.KitchenService))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.KitchenService));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.KitchenService, bu.KitchenServiceName);
                        if (!string.IsNullOrEmpty(bu.KitchenServiceName) && bu.KitchenServiceName != "تعیین نشده")
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.FloorCover))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.FloorCover));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.FloorCover, bu.FloorCoverName);
                        if (!string.IsNullOrEmpty(bu.FloorCoverName) && bu.FloorCoverName != "تعیین نشده")
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.View))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.View));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.View, bu.BuildingViewName);
                        if (!string.IsNullOrEmpty(bu.BuildingViewName) && bu.BuildingViewName != "تعیین نشده")
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.PricePerMetr))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.PricePerMetr));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        if (bu.SellPrice > 0 && bu.Masahat > 0)
                        {
                            type = type.Replace("\r", "");
                            var p = bu.SellPrice / bu.Masahat;
                            type = type.Replace(Replacor.TelegramBuilding.PricePerMetr, p.ToString("N0"));
                            list[index] = type;
                        }
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.VahedPerTabaqe))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.VahedPerTabaqe));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.VahedPerTabaqe, bu.VahedPerTabaqe.ToString());
                        if (bu.VahedPerTabaqe > 0)
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.Hitting))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.Hitting));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.Hitting, bu.Hiting);
                        if (!string.IsNullOrEmpty(bu.Hiting))
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.Colling))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.Colling));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.Colling, bu.Colling);
                        if (!string.IsNullOrEmpty(bu.Colling))
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.Dong))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.Dong));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.Dong, bu.Dang.ToString());
                        if (bu.SellPrice > 0)
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.Parking))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.Parking));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        var text = "";
                        if (bu.OptionList == null || bu.OptionList.Count <= 0) text = "❌";
                        else
                        {
                            var ev = bu.OptionList.Any(q => q.OptionName.Contains("پارکینگ"));
                            text = ev ? "✅" : "❌";
                        }
                        type = type.Replace(Replacor.TelegramBuilding.Parking, text);
                        list[index] = type;
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.Elevator))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.Elevator));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        var text = "";
                        if (bu.OptionList == null || bu.OptionList.Count <= 0) text = "❌";
                        else
                        {
                            var ev = bu.OptionList.Any(q => q.OptionName.Contains("سانسور"));
                            text = ev ? "✅" : "❌";
                        }
                        type = type.Replace(Replacor.TelegramBuilding.Elevator, text);
                        list[index] = type;
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.Store))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.Store));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        var text = "";
                        if (bu.OptionList == null || bu.OptionList.Count <= 0) text = "❌";
                        else
                        {
                            var ev = bu.OptionList.Any(q => q.OptionName.Contains("انبار"));
                            text = ev ? "✅" : "❌";
                        }
                        type = type.Replace(Replacor.TelegramBuilding.Store, text);
                        list[index] = type;
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.Balcony))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.Balcony));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        var text = "";
                        if (bu.OptionList == null || bu.OptionList.Count <= 0) text = "❌";
                        else
                        {
                            var ev = bu.OptionList.Any(q => q.OptionName.Contains("تراس") || q.OptionName.Contains("بالکن"));
                            text = ev ? "✅" : "❌";
                        }
                        type = type.Replace(Replacor.TelegramBuilding.Balcony, text);
                        list[index] = type;
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.OwnerName))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.OwnerName));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.OwnerName, owner?.Name ?? "");
                        if (!string.IsNullOrEmpty(owner?.Name ?? ""))
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.OwnerTell))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.OwnerTell));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.OwnerTell, owner?.FirstNumber ?? "");
                        if (!string.IsNullOrEmpty(owner?.FirstNumber ?? ""))
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.OwnerAddress))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.OwnerAddress));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        type = type.Replace("\r", "");
                        type = type.Replace(Replacor.TelegramBuilding.OwnerAddress, bu?.Address ?? "");
                        if (!string.IsNullOrEmpty(bu?.Address ?? ""))
                            list[index] = type;
                        else list[index] = "";
                    }
                }
                if (res.Contains(Replacor.TelegramBuilding.OtherOptions))
                {
                    var type = list.FirstOrDefault(q => q.Contains(Replacor.TelegramBuilding.OtherOptions));
                    if (!string.IsNullOrEmpty(type))
                    {
                        var index = list.IndexOf(type);
                        if (bu.OptionList == null || bu.OptionList.Count <= 0)
                            list[index] = "";
                        else
                        {
                            var str = "";
                            foreach (var item in bu.OptionList)
                                str += item.OptionName + " 🔶 ";
                            type = type.Replace("\r", "");
                            type = type.Replace(Replacor.TelegramBuilding.OtherOptions, str);
                            if (!string.IsNullOrEmpty(str))
                                list[index] = type;
                            else list[index] = "";
                        }
                    }
                }

                list = list.Where(q => !string.IsNullOrEmpty(q)).ToList();
                res = string.Join(Environment.NewLine, list);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return res;
        }
    }
}
