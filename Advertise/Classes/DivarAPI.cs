using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Properties;
using EntityCache.Bussines;
using EntityCache.ViewModels;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Services;

namespace Advertise.Classes
{
    public static class DivarAPI
    {
        public static List<DivarCities> GetAllDivarCities()
        {
            var list = new List<DivarCities>();
            try
            {
                var str = Resources.Text;
                var test = str.Replace(@"\", "").Replace("\"{\"browse", "{\"browse");
                var root = JObject.Parse(test);
                var city = root["city"]["compressedData"];
                foreach (var item in city.Children().ToList())
                {
                    var itemList = item.Children().ToList();
                    list.Add(new DivarCities()
                    {
                        Guid = Guid.NewGuid(),
                        Modified = DateTime.Now,
                        Name = itemList[1]?.Value<string>() ?? "",
                        Status = true,
                        DivarId = itemList[0]?.Value<int>() ?? 0,
                        LatinName = itemList[2]?.Value<string>() ?? ""
                    });
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public static async Task<List<DivarRegion>> GetAllRegionsAsync(string cityGuid)
        {
            var list = new List<DivarRegion>();
            try
            {
                var cities = await SerializedDataBussines.GetDivarCityAsync();
                var cityLocal = await CitiesBussines.GetAsync(Guid.Parse(cityGuid));
                var cityName = cities.FirstOrDefault(q => q.Name == cityLocal.Name)?.Guid ?? Guid.Empty;
                var text = "";
                switch (cityLocal.Name)
                {
                    case "مشهد": text = Resources.MashhadRegions; break;
                    case "تهران": text = Resources.TehranRegions; break;
                    case "کرج": text = Resources.KarajRegions; break;
                    case "اهواز": text = Resources.AhvazRegions; break;
                    case "اصفهان": text = Resources.IsfahanRegions; break;
                    case "شیراز": text = Resources.ShirazRegions; break;
                    case "قم": text = Resources.QomRegions; break;
                }
                list.AddRange(GetAllFromApi(cityName, text));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        private static List<DivarRegion> GetAllFromApi(Guid cityGuid, string text)
        {
            var list = new List<DivarRegion>();
            try
            {
                if (cityGuid == Guid.Empty) return list;
                var test = text.Replace(@"\", "").Replace("\"{\"browse", "{\"browse");
                var root = JObject.Parse(test);
                var search = root["search"]["schema"]["ui_schema"]["districts"]["vacancies"]["ui:options"]["data"]["children"];
                var reg = new Regions { Children = JsonConvert.DeserializeObject<List<RegionData>>(search.ToString()) };
                foreach (var item in reg.Children)
                {
                    list.Add(new DivarRegion()
                    {
                        Guid = Guid.NewGuid(),
                        Modified = DateTime.Now,
                        Name = item.EnumName,
                        Status = true,
                        CityGuid = cityGuid,
                        DivarId = (int)item.Enum
                    });
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public static async Task<List<BuildingBussines>> GetAllFromDivarAsync(EnRequestType reqType, BuildingAccountTypeBussines accType,
            BuildingTypeBussines type,
            decimal fPrice1, decimal fPrice2, decimal sPrice1, decimal sPrice2, int masahat1, int masahat2,
            int roomCount)
        {
            var list = new List<BuildingBussines>();
            try
            {
                var url = await UrlMakerAsync(reqType, accType, type, fPrice1, fPrice2, sPrice1, sPrice2, masahat1,
                    masahat2, roomCount);
                var divarList = GetDataFromUrl(url);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        private static async Task<string> UrlMakerAsync(EnRequestType reqType, BuildingAccountTypeBussines accType,
            BuildingTypeBussines type,
            decimal fPrice1, decimal fPrice2, decimal sPrice1, decimal sPrice2, int masahat1, int masahat2,
            int roomCount)
        {
            var url = "";
            try
            {
                url = "https://divar.ir/s/";
                var cityGuid = Guid.Parse(Settings.Classes.clsEconomyUnit.EconomyCity);
                var cities = await SerializedDataBussines.GetDivarCityAsync();
                var cityLocal = await CitiesBussines.GetAsync(cityGuid);
                var divarCity = cities.FirstOrDefault(q => q.Name == cityLocal.Name);
                if (divarCity == null) return null;
                url += $"{divarCity.Name}/";
                if (reqType == EnRequestType.Moavezeh) return null;
                if (reqType == EnRequestType.Mosharekat) url += "contribution-construction?user_type=personal";
                else if (reqType == EnRequestType.PishForush) url += "pre-sell-home?user_type=personal";
                else if (reqType == EnRequestType.Rahn)
                {
                    if (accType.Name.Contains("مسکونی") && !accType.Name.Contains("زمین"))
                    {
                        if (type == null) return null;
                        if (type.Name.Contains("پارتمان"))
                            url +=
                                $"rent-apartment?credit={fPrice1}-{fPrice2}&rent={sPrice1}-{sPrice2}&size={masahat1}-{masahat2}&rooms={roomCount}&user_type=personal";
                        else if (type.Name.Contains("خانه") || accType.Name.Contains("ویلا"))
                            url +=
                                $"rent-villa?credit={fPrice1}-{fPrice2}&rent={sPrice1}-{sPrice2}&size={masahat1}-{masahat2}&rooms={roomCount}&user_type=personal";
                    }
                    else if (accType.Name.Contains("دفتر") || accType.Name.Contains("اداری") ||
                             accType.Name.Contains("مطب"))
                        url +=
                            $"rent-office?credit={fPrice1}-{fPrice2}&rent={sPrice1}-{sPrice2}&size={masahat1}-{masahat2}&rooms={roomCount}&user_type=personal";
                    else if (accType.Name.Contains("صنعتی") || accType.Name.Contains("کشاورزی") ||
                             accType.Name.Contains("دامداری") || accType.Name.Contains("مرغداری") ||
                             accType.Name.Contains("زراعی"))
                        url +=
                            $"rent-industrial-agricultural-property?credit={fPrice1}-{fPrice2}&rent={sPrice1}-{sPrice2}&size={masahat1}-{masahat2}&rooms={roomCount}&user_type=personal";

                    else if (accType.Name.Contains("مغازه") || accType.Name.Contains("غرفه") ||
                             accType.Name.Contains("تجاری"))
                        url +=
                            $"rent-store?credit={fPrice1}-{fPrice2}&rent={sPrice1}-{sPrice2}&size={masahat1}-{masahat2}&rooms={roomCount}&user_type=personal";
                }
                else if (reqType == EnRequestType.Forush)
                {
                    if (accType.Name.Contains("مسکونی"))
                    {
                        if (type.Name.Contains("پارتمان"))
                            url +=
                                $"buy-apartment?price={fPrice1}-{fPrice2}&size={masahat1}-{masahat2}&rooms={roomCount}&user_type=personal&non-negotiable=true";
                        else if (type.Name.Contains("خانه") || accType.Name.Contains("ویلا"))
                            url +=
                                $"buy-villa?price={fPrice1}-{fPrice2}&size={masahat1}-{masahat2}&rooms={roomCount}&user_type=personal&non-negotiable=true";
                        else if (type.Name.Contains("زمین") || type.Name.Contains("کلنگی"))
                            url +=
                                $"buy-old-house?price={fPrice1}-{fPrice2}&size={masahat1}-{masahat2}&user_type=personal&non-negotiable=true";
                    }
                    else if (accType.Name.Contains("زمین") || accType.Name.Contains("کلنگی"))
                        url +=
                            $"buy-old-house?price={fPrice1}-{fPrice2}&size={masahat1}-{masahat2}&user_type=personal&non-negotiable=true";
                    else if (accType.Name.Contains("دفتر") || accType.Name.Contains("اداری") ||
                             accType.Name.Contains("مطب"))
                        url +=
                            $"buy-office?price={fPrice1}-{fPrice2}&size={masahat1}-{masahat2}&rooms={roomCount}&user_type=personal&non-negotiable=true&bizzDeed=true";
                    else if (accType.Name.Contains("صنعتی") || accType.Name.Contains("کشاورزی") ||
                             accType.Name.Contains("دامداری") || accType.Name.Contains("مرغداری") ||
                             accType.Name.Contains("زراعی"))
                        url +=
                            $"buy-industrial-agricultural-property?price={fPrice1}-{fPrice2}&size={masahat1}-{masahat2}&rooms={roomCount}&user_type=personal&non-negotiable=true&bizzDeed=true";
                    else if (accType.Name.Contains("مغازه") || accType.Name.Contains("غرفه") ||
                             accType.Name.Contains("تجاری"))
                        url +=
                            $"buy-store?price={fPrice1}-{fPrice2}&size={masahat1}-{masahat2}&rooms={roomCount}&user_type=personal&bizzDeed=true";
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return url;
        }

        private static List<Divar> GetDataFromUrl(string url)
        {
            var list = new List<Divar>();
            try
            {
                var web = new HtmlWeb();
                var doc = web.Load(url);
                var o = doc.DocumentNode.SelectNodes("//script[@type='application/ld+json']")?.LastOrDefault();
                var text = o?.InnerText;
                var items = JsonConvert.DeserializeObject<List<Divar>>(text);
                foreach (var divar in items)
                {
                    var newDoc = web.Load(divar.Url);
                    var o_ = newDoc.DocumentNode.SelectNodes("/html[1]/body[1]/script[1]")?.FirstOrDefault();
                    if (o_ == null) continue;
                    var text_ = o_.InnerText.Replace(@"\", "").Replace("window.production = true;", "")
                        .Replace("window.__PRELOADED_STATE__ = \"{", "{")
                        .Replace(",\"PERFORMANCE_MONITOR_RULE\":\"[0۰]$\"}\";", "}");
                    var index = text_.IndexOf("  window.env");
                    text_ = text_.Remove(index - 3);
                    index = text_.IndexOf(",\"exitLinkWarn");
                    var index2 = text_.IndexOf("u003Cu002Fau003Eu003Cu002Fpu003E\"");
                    text_ = text_.Remove(index, index2 - index).Replace("u003Cu002Fau003Eu003Cu002Fpu003E\"", "");
                    var root = JObject.Parse(text_);
                    var guestValues = root["currentPost"]["post"]["widgets"]["listData"];
                    divar.listData = JsonConvert.DeserializeObject<List<ListData>>(guestValues.ToString());
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }

        public static List<BuildingBussines> GetApartmentRent(string cityName, string regionList)
        {
            var list = new List<BuildingBussines>();
            try
            {
                if (string.IsNullOrEmpty(cityName)) return list;
                var url = $"https://divar.ir/s/{cityName}/rent-apartment";
                if (!string.IsNullOrEmpty(regionList))
                    url += $"?districts={regionList}";
                url += "&user_type=personal";
                var listDivar = GetDataFromUrl(url);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public static List<BuildingBussines> GetVillaRent(string cityName, string regionList)
        {
            var list = new List<BuildingBussines>();
            try
            {
                if (string.IsNullOrEmpty(cityName)) return list;
                var url = $"https://divar.ir/s/{cityName}/rent-villa";
                if (!string.IsNullOrEmpty(regionList))
                    url += $"?districts={regionList}";
                url += "&user_type=personal";
                var listDivar = GetDataFromUrl(url);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public static List<BuildingBussines> GetOfficeRent(string cityName, string regionList)
        {
            var list = new List<BuildingBussines>();
            try
            {
                if (string.IsNullOrEmpty(cityName)) return list;
                var url = $"https://divar.ir/s/{cityName}/rent-office";
                if (!string.IsNullOrEmpty(regionList))
                    url += $"?districts={regionList}";
                url += "&user_type=personal";
                var listDivar = GetDataFromUrl(url);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public static List<BuildingBussines> GetStoreRent(string cityName, string regionList)
        {
            var list = new List<BuildingBussines>();
            try
            {
                if (string.IsNullOrEmpty(cityName)) return list;
                var url = $"https://divar.ir/s/{cityName}/rent-store";
                if (!string.IsNullOrEmpty(regionList))
                    url += $"?districts={regionList}";
                url += "&user_type=personal";
                var listDivar = GetDataFromUrl(url);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public static List<BuildingBussines> GetIndustrialRent(string cityName, string regionList)
        {
            var list = new List<BuildingBussines>();
            try
            {
                if (string.IsNullOrEmpty(cityName)) return list;
                var url = $"https://divar.ir/s/{cityName}/rent-industrial-agricultural-property";
                if (!string.IsNullOrEmpty(regionList))
                    url += $"?districts={regionList}";
                url += "&user_type=personal";
                var listDivar = GetDataFromUrl(url);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }


        public static List<BuildingBussines> GetApartmentBuy(string cityName, string regionList)
        {
            var list = new List<BuildingBussines>();
            try
            {
                if (string.IsNullOrEmpty(cityName)) return list;
                var url = $"https://divar.ir/s/{cityName}/buy-apartment";
                if (!string.IsNullOrEmpty(regionList))
                    url += $"?districts={regionList}";
                url += "&user_type=personal&non-negotiable=true";
                var listDivar = GetDataFromUrl(url);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public static List<BuildingBussines> GetVillaBuy(string cityName, string regionList)
        {
            var list = new List<BuildingBussines>();
            try
            {
                if (string.IsNullOrEmpty(cityName)) return list;
                var url = $"https://divar.ir/s/{cityName}/buy-villa";
                if (!string.IsNullOrEmpty(regionList))
                    url += $"?districts={regionList}";
                url += "&user_type=personal&non-negotiable=true";
                var listDivar = GetDataFromUrl(url);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public static List<BuildingBussines> GetOldHouseBuy(string cityName, string regionList)
        {
            var list = new List<BuildingBussines>();
            try
            {
                if (string.IsNullOrEmpty(cityName)) return list;
                var url = $"https://divar.ir/s/{cityName}/buy-old-house";
                if (!string.IsNullOrEmpty(regionList))
                    url += $"?districts={regionList}";
                url += "&user_type=personal&non-negotiable=true";
                var listDivar = GetDataFromUrl(url);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public static List<BuildingBussines> GetOfficeBuy(string cityName, string regionList)
        {
            var list = new List<BuildingBussines>();
            try
            {
                if (string.IsNullOrEmpty(cityName)) return list;
                var url = $"https://divar.ir/s/{cityName}/buy-office";
                if (!string.IsNullOrEmpty(regionList))
                    url += $"?districts={regionList}";
                url += "&user_type=personal&non-negotiable=true";
                var listDivar = GetDataFromUrl(url);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public static List<BuildingBussines> GetStoreBuy(string cityName, string regionList)
        {
            var list = new List<BuildingBussines>();
            try
            {
                if (string.IsNullOrEmpty(cityName)) return list;
                var url = $"https://divar.ir/s/{cityName}/buy-store";
                if (!string.IsNullOrEmpty(regionList))
                    url += $"?districts={regionList}";
                url += "&user_type=personal&non-negotiable=true";
                var listDivar = GetDataFromUrl(url);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public static List<BuildingBussines> GetIndustrialBuy(string cityName, string regionList)
        {
            var list = new List<BuildingBussines>();
            try
            {
                if (string.IsNullOrEmpty(cityName)) return list;
                var url = $"https://divar.ir/s/{cityName}/buy-industrial-agricultural-property";
                if (!string.IsNullOrEmpty(regionList))
                    url += $"?districts={regionList}";
                url += "&user_type=personal&non-negotiable=true";
                var listDivar = GetDataFromUrl(url);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }

        public static List<BuildingBussines> GetContributionConstruction(string cityName, string regionList)
        {
            var list = new List<BuildingBussines>();
            try
            {
                if (string.IsNullOrEmpty(cityName)) return list;
                var url = $"https://divar.ir/s/{cityName}/contribution-construction";
                if (!string.IsNullOrEmpty(regionList))
                    url += $"?districts={regionList}";
                url += "&user_type=personal";
                var listDivar = GetDataFromUrl(url);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public static List<BuildingBussines> GetPreeSellHome(string cityName, string regionList)
        {
            var list = new List<BuildingBussines>();
            try
            {
                if (string.IsNullOrEmpty(cityName)) return list;
                var url = $"https://divar.ir/s/{cityName}/pre-sell-home";
                if (!string.IsNullOrEmpty(regionList))
                    url += $"?districts={regionList}";
                url += "&user_type=personal";
                var listDivar = GetDataFromUrl(url);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
    }
    public class Regions
    {
        public List<RegionData> Children { get; set; }
    }
    public class RegionData
    {
        public long Enum { get; set; }
        public string EnumName { get; set; }
        public List<string> Tags { get; set; }
    }
    public class Divar
    {
        public string Url { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public IList<ListData> listData { get; set; }
    }
    public class Item
    {
        public int id { get; set; }
        public bool disabled { get; set; }
        public string title { get; set; }
        public string value { get; set; }
        public string iconName { get; set; }
        public string iconColor { get; set; }
    }
    public class ListData
    {
        public string format { get; set; }
        public IList<Item> items { get; set; }
        public bool hasDivider { get; set; }
        public string title { get; set; }
        public string value { get; set; }
    }
}
