using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Advertise.Properties;
using AutoMapper.Configuration.Conventions;
using EntityCache.Bussines;
using EntityCache.ViewModels;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Nito.AsyncEx;
using Services;
using Services.DefaultCoding;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

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
                list = JsonConvert.DeserializeObject<List<Divar>>(text);
                foreach (var divar in list)
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
        private static List<Divar> GetDataFromUrl(string url, string cityPersianName, Guid cityGuid, string type)
        {
            var list = new List<Divar>();
            try
            {
                var web = new HtmlWeb();
                var doc = web.Load(url);
                var o = doc.DocumentNode.SelectNodes("//script[@type='application/ld+json']")?.LastOrDefault();
                var text = o?.InnerText;
                list = JsonConvert.DeserializeObject<List<Divar>>(text);
                foreach (var divar in list)
                {
                    var newDoc = web.Load(divar.Url);
                    divar.RegionGuid = GetRegionGuid(newDoc, divar.Name, cityPersianName, cityGuid, type);
                    if (divar.RegionGuid == Guid.Empty) continue;
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
        private static Guid GetRegionGuid(HtmlDocument doc, string advertiseName, string cityPersianName, Guid cityGuid, string type)
        {
            try
            {
                var o_ = doc.DocumentNode.SelectNodes("/html[1]/head[1]/title[1]")?.FirstOrDefault();
                var x = o_.InnerText.Replace($"{advertiseName}", "");
                x = x.Replace("دیوار", "").Replace($"{cityPersianName}", "").Replace("|", "")
                    .Replace(type, "").Replace("،", "").Replace("مطب_دفترکار تجاری", "").FixString().Trim();
                if (x.Length > 20) return Guid.Empty;
                var region = RegionsBussines.Get(x);
                if (region == null || region.Guid == Guid.Empty)
                {
                    region = new RegionsBussines()
                    {
                        Guid = Guid.NewGuid(),
                        Name = x,
                        Modified = DateTime.Now,
                        Status = true,
                        CityGuid = cityGuid
                    };
                    AsyncContext.Run(() => region.SaveAsync());
                }

                return region.Guid;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return Guid.Empty;
            }
        }
        private static string DownloadImage(string src)
        {
            try
            {
                var path = Path.Combine(Application.StartupPath, "Images");
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                var name = Guid.NewGuid() + ".jpg";
                var filePath = Path.Combine(path, name);
                var webClient = new WebClient();
                webClient.DownloadFile(src, filePath);
                return name;
            }
            catch (WebException) { return ""; }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return "";
            }
        }
        public static async Task<List<BuildingBussines>> GetApartmentRent(DivarCities model, Guid cityGuid, string regionList)
        {
            var list = new List<BuildingBussines>();
            try
            {
                if (model == null) return list;
                var url = $"https://divar.ir/s/{model.LatinName}/rent-apartment";
                if (!string.IsNullOrEmpty(regionList))
                    url += $"{regionList}";
                url += "&user_type=personal";
                var listDivar = GetDataFromUrl(url, model.Name, cityGuid, "آپارتمان");
                if (listDivar == null || listDivar.Count <= 0) return list;
                foreach (var item in listDivar)
                {
                    if (item.listData == null) continue;
                    var bu = new BuildingBussines()
                    {
                        Guid = Guid.NewGuid(),
                        Modified = DateTime.Now,
                        Status = true,
                        Masahat = item.listData[0].items[0].value.FixString().ParseToInt(),
                        SellPrice = 0,
                        ServerStatus = ServerStatus.None,
                        Code = BuildingBussines.NextCode(),
                        RahnPrice1 = item.listData[1].value.FixString().Replace("٫", "").Replace("تومان", "").ParseToDecimal() * 10,
                        ServerDeliveryDate = DateTime.Now,
                        EjarePrice1 = 0,
                        RegionGuid = item.RegionGuid,
                        Tell = EnKhadamati.Mostaqel,
                        RoomCount = item.listData[0].items[2].value.FixString().ParseToInt(),
                        UserGuid = UserBussines.CurrentUser.Guid,
                        Address = "",
                        GalleryList = null,
                        Image = DownloadImage(item.Image),
                        BuildingAccountTypeGuid = BuildingAccountTypeBussines.GetAll("مسکونی")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        CreateDate = DateTime.Now,
                        SaleSakht = item.listData[0].items[1].value.FixString(),
                        MediaList = null,
                        IsArchive = false,
                        ZirBana = item.listData[0].items[0].value.FixString().ParseToInt(),
                        DocumentType = null,
                        BuildingTypeGuid = BuildingTypeBussines.Get("آپارتمان")?.Guid ?? Guid.Empty,
                        OwnerGuid = ParentDefaults.TafsilCoding.CLSTafsil1030401,
                        Barq = EnKhadamati.Mostaqel,
                        BonBast = false,
                        BuildingConditionGuid = BuildingConditionBussines.GetAll("تخلیه")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        BuildingViewGuid = BuildingViewBussines.GetAll("سنگ")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        CityGuid = cityGuid,
                        Dang = 6,
                        DateParvane = item.listData[0].items[1].value.FixString(),
                        DeliveryDate = null,
                        EjarePrice2 = 0,
                        ErtefaSaqf = 0,
                        FloorCoverGuid = FloorCoverBussines.GetAll("سرامیک")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        Gas = EnKhadamati.Mostaqel,
                        Hashie = 0,
                        IsOwnerHere = null,
                        IsShortTime = false,
                        KitchenServiceGuid = KitchenServiceBussines.GetAll("MDF")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        Water = EnKhadamati.Mostaqel,
                        VamPrice = 0,
                        VahedPerTabaqe = 1,
                        Tarakom = null,
                        Side = EnBuildingSide.One,
                        ShortDesc = item.Description,
                        RentalAutorityGuid = null,
                        RahnPrice2 = 0,
                        QestPrice = 0,
                        MamarJoda = true,
                        MetrazhKouche = 0,
                        MetrazhTejari = 0,
                        MoavezeDesc = "",
                        MosharekatDesc = "",
                        ParvaneSerial = "",
                        PishDesc = "",
                        PishPrice = 0,
                        PishTotalPrice = 0,
                        Priority = EnBuildingPriority.Low
                    };

                    if (item.listData[2].value == "مجانی") bu.EjarePrice1 = 0;
                    else
                        bu.EjarePrice1 = item.listData[2].value.FixString().Replace("٫", "").Replace("تومان", "").ParseToDecimal() *
                                         10;
                    if (item.listData[6].value.Contains("از"))
                    {
                        if (item.listData[6].value.Contains("همکف"))
                        {
                            var a = item.listData[6].value.Replace("همکف از", "");
                            bu.TabaqeNo = 0;
                            bu.TedadTabaqe = a.FixString().ParseToInt();
                        }
                        else
                        {
                            var a = item.listData[6].value.Replace("از", "");
                            bu.TabaqeNo = a.Remove(1, 3).FixString().ParseToInt();
                            bu.TedadTabaqe = a.Remove(0, 2).FixString().ParseToInt();
                        }
                    }
                    else
                    {
                        bu.TabaqeNo = item.listData[6].value.FixString().ParseToInt();
                        bu.TedadTabaqe = bu.TabaqeNo;
                    }


                    var ex = await BuildingBussines.CheckDuplicateAsync(bu.Masahat, bu.RoomCount, bu.RahnPrice1, bu.EjarePrice1, bu.SellPrice, bu.TabaqeNo);
                    if (ex) continue;

                    bu.OptionList = new List<BuildingRelatedOptionsBussines>();

                    var evelator = await BuildingOptionsBussines.GetAsync(item.listData[7].items[0].value.FixString());
                    if (evelator == null)
                    {
                        evelator = new BuildingOptionsBussines()
                        {
                            Guid = Guid.NewGuid(),
                            Modified = DateTime.Now,
                            Name = item.listData[7].items[0].value.FixString(),
                            Status = true
                        };
                        await evelator.SaveAsync();
                    }

                    var op1 = new BuildingRelatedOptionsBussines()
                    {
                        Guid = Guid.NewGuid(),
                        Modified = DateTime.Now,
                        BuildingOptionGuid = evelator.Guid,
                        BuildinGuid = bu.Guid
                    };
                    bu.OptionList.Add(op1);


                    var parking = await BuildingOptionsBussines.GetAsync(item.listData[7].items[1].value.FixString());
                    if (parking == null)
                    {
                        parking = new BuildingOptionsBussines()
                        {
                            Guid = Guid.NewGuid(),
                            Modified = DateTime.Now,
                            Name = item.listData[7].items[1].value.FixString(),
                            Status = true
                        };
                        await parking.SaveAsync();
                    }

                    var op2 = new BuildingRelatedOptionsBussines()
                    {
                        Guid = Guid.NewGuid(),
                        Modified = DateTime.Now,
                        BuildingOptionGuid = parking.Guid,
                        BuildinGuid = bu.Guid
                    };
                    bu.OptionList.Add(op2);

                    var anbari = await BuildingOptionsBussines.GetAsync(item.listData[7].items[2].value.FixString());
                    if (anbari == null)
                    {
                        anbari = new BuildingOptionsBussines()
                        {
                            Guid = Guid.NewGuid(),
                            Modified = DateTime.Now,
                            Name = item.listData[7].items[2].value.FixString(),
                            Status = true
                        };
                        await anbari.SaveAsync();
                    }

                    var op3 = new BuildingRelatedOptionsBussines()
                    {
                        Guid = Guid.NewGuid(),
                        Modified = DateTime.Now,
                        BuildingOptionGuid = anbari.Guid,
                        BuildinGuid = bu.Guid
                    };
                    bu.OptionList.Add(op3);

                    list.Add(bu);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public static async Task<List<BuildingBussines>> GetVillaRent(DivarCities model, Guid cityGuid, string regionList)
        {
            var list = new List<BuildingBussines>();
            try
            {
                if (model == null) return list;
                var url = $"https://divar.ir/s/{model.LatinName}/rent-villa";
                if (!string.IsNullOrEmpty(regionList))
                    url += $"{regionList}";
                url += "&user_type=personal";
                var listDivar = GetDataFromUrl(url, model.Name, cityGuid, "خانه و ویلا");
                if (listDivar == null || listDivar.Count <= 0) return list;
                foreach (var item in listDivar)
                {
                    if (item.listData == null) continue;
                    var bu = new BuildingBussines()
                    {
                        Guid = Guid.NewGuid(),
                        Modified = DateTime.Now,
                        Status = true,
                        Masahat = item.listData[0].items[0].value.FixString().ParseToInt(),
                        SellPrice = 0,
                        ServerStatus = ServerStatus.None,
                        Code = BuildingBussines.NextCode(),
                        RahnPrice1 = item.listData[1].value.FixString().Replace("٫", "").Replace("تومان", "").ParseToDecimal() * 10,
                        ServerDeliveryDate = DateTime.Now,
                        EjarePrice1 = 0,
                        RegionGuid = item.RegionGuid,
                        Tell = EnKhadamati.Mostaqel,
                        RoomCount = item.listData[0].items[2].value.FixString().ParseToInt(),
                        UserGuid = UserBussines.CurrentUser.Guid,
                        Address = "",
                        GalleryList = null,
                        Image = DownloadImage(item.Image),
                        BuildingAccountTypeGuid = BuildingAccountTypeBussines.GetAll("مسکونی")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        CreateDate = DateTime.Now,
                        SaleSakht = item.listData[0].items[1].value.FixString(),
                        MediaList = null,
                        IsArchive = false,
                        ZirBana = item.listData[0].items[0].value.FixString().ParseToInt(),
                        DocumentType = null,
                        BuildingTypeGuid = BuildingTypeBussines.Get("منزل مسکونی")?.Guid ?? Guid.Empty,
                        OwnerGuid = ParentDefaults.TafsilCoding.CLSTafsil1030401,
                        Barq = EnKhadamati.Mostaqel,
                        BonBast = false,
                        BuildingConditionGuid = BuildingConditionBussines.GetAll("تخلیه")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        BuildingViewGuid = BuildingViewBussines.GetAll("سنگ")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        CityGuid = cityGuid,
                        Dang = 6,
                        DateParvane = item.listData[0].items[1].value.FixString(),
                        DeliveryDate = null,
                        EjarePrice2 = 0,
                        ErtefaSaqf = 0,
                        FloorCoverGuid = FloorCoverBussines.GetAll("سرامیک")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        Gas = EnKhadamati.Mostaqel,
                        Hashie = 0,
                        IsOwnerHere = null,
                        IsShortTime = false,
                        KitchenServiceGuid = KitchenServiceBussines.GetAll("MDF")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        Water = EnKhadamati.Mostaqel,
                        VamPrice = 0,
                        VahedPerTabaqe = 1,
                        Tarakom = null,
                        Side = EnBuildingSide.One,
                        ShortDesc = item.Description,
                        RentalAutorityGuid = null,
                        RahnPrice2 = 0,
                        QestPrice = 0,
                        MamarJoda = true,
                        MetrazhKouche = 0,
                        MetrazhTejari = 0,
                        MoavezeDesc = "",
                        MosharekatDesc = "",
                        ParvaneSerial = "",
                        PishDesc = "",
                        PishPrice = 0,
                        PishTotalPrice = 0,
                        Priority = EnBuildingPriority.Low
                    };

                    if (item.listData[2].value == "مجانی") bu.EjarePrice1 = 0;
                    else
                        bu.EjarePrice1 = item.listData[2].value.FixString().Replace("٫", "").Replace("تومان", "").ParseToDecimal() *
                                         10;

                    bu.TabaqeNo = 1;
                    bu.TedadTabaqe = 1;

                    var ex = await BuildingBussines.CheckDuplicateAsync(bu.Masahat, bu.RoomCount, bu.RahnPrice1, bu.EjarePrice1, bu.SellPrice, bu.TabaqeNo);
                    if (ex) continue;

                    bu.OptionList = new List<BuildingRelatedOptionsBussines>();

                    var evelator = await BuildingOptionsBussines.GetAsync(item.listData[6].items[0].value.FixString());
                    if (evelator == null)
                    {
                        evelator = new BuildingOptionsBussines()
                        {
                            Guid = Guid.NewGuid(),
                            Modified = DateTime.Now,
                            Name = item.listData[6].items[0].value.FixString(),
                            Status = true
                        };
                        await evelator.SaveAsync();
                    }

                    var op1 = new BuildingRelatedOptionsBussines()
                    {
                        Guid = Guid.NewGuid(),
                        Modified = DateTime.Now,
                        BuildingOptionGuid = evelator.Guid,
                        BuildinGuid = bu.Guid
                    };
                    bu.OptionList.Add(op1);


                    var parking = await BuildingOptionsBussines.GetAsync(item.listData[6].items[1].value.FixString());
                    if (parking == null)
                    {
                        parking = new BuildingOptionsBussines()
                        {
                            Guid = Guid.NewGuid(),
                            Modified = DateTime.Now,
                            Name = item.listData[6].items[1].value.FixString(),
                            Status = true
                        };
                        await parking.SaveAsync();
                    }

                    var op2 = new BuildingRelatedOptionsBussines()
                    {
                        Guid = Guid.NewGuid(),
                        Modified = DateTime.Now,
                        BuildingOptionGuid = parking.Guid,
                        BuildinGuid = bu.Guid
                    };
                    bu.OptionList.Add(op2);

                    var anbari = await BuildingOptionsBussines.GetAsync(item.listData[6].items[2].value.FixString());
                    if (anbari == null)
                    {
                        anbari = new BuildingOptionsBussines()
                        {
                            Guid = Guid.NewGuid(),
                            Modified = DateTime.Now,
                            Name = item.listData[6].items[2].value.FixString(),
                            Status = true
                        };
                        await anbari.SaveAsync();
                    }

                    var op3 = new BuildingRelatedOptionsBussines()
                    {
                        Guid = Guid.NewGuid(),
                        Modified = DateTime.Now,
                        BuildingOptionGuid = anbari.Guid,
                        BuildinGuid = bu.Guid
                    };
                    bu.OptionList.Add(op3);

                    list.Add(bu);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public static async Task<List<BuildingBussines>> GetOfficeRent(DivarCities model, Guid cityGuid, string regionList)
        {
            var list = new List<BuildingBussines>();
            try
            {
                if (model == null) return list;
                var url = $"https://divar.ir/s/{model.LatinName}/rent-office";
                if (!string.IsNullOrEmpty(regionList))
                    url += $"{regionList}";
                url += "&user_type=personal";
                var listDivar = GetDataFromUrl(url, model.Name, cityGuid, "دفتر کار، اتاق اداری و مطب");
                if (listDivar == null || listDivar.Count <= 0) return list;
                foreach (var item in listDivar)
                {
                    if (item.listData == null) continue;
                    var bu = new BuildingBussines()
                    {
                        Guid = Guid.NewGuid(),
                        Modified = DateTime.Now,
                        Status = true,
                        Masahat = item.listData[0].items[0].value.FixString().ParseToInt(),
                        SellPrice = 0,
                        ServerStatus = ServerStatus.None,
                        Code = BuildingBussines.NextCode(),
                        RahnPrice1 = item.listData[1].value.FixString().Replace("٫", "").Replace("تومان", "").ParseToDecimal() * 10,
                        ServerDeliveryDate = DateTime.Now,
                        EjarePrice1 = 0,
                        RegionGuid = item.RegionGuid,
                        Tell = EnKhadamati.Mostaqel,
                        RoomCount = item.listData[0].items[2].value.FixString().ParseToInt(),
                        UserGuid = UserBussines.CurrentUser.Guid,
                        Address = "",
                        GalleryList = null,
                        Image = DownloadImage(item.Image),
                        BuildingAccountTypeGuid = BuildingAccountTypeBussines.GetAll("دفترکار")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        CreateDate = DateTime.Now,
                        SaleSakht = item.listData[0].items[1].value.FixString(),
                        MediaList = null,
                        IsArchive = false,
                        ZirBana = item.listData[0].items[0].value.FixString().ParseToInt(),
                        DocumentType = null,
                        BuildingTypeGuid = BuildingTypeBussines.Get("تجاری")?.Guid ?? Guid.Empty,
                        OwnerGuid = ParentDefaults.TafsilCoding.CLSTafsil1030401,
                        Barq = EnKhadamati.Mostaqel,
                        BonBast = false,
                        BuildingConditionGuid = BuildingConditionBussines.GetAll("تخلیه")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        BuildingViewGuid = BuildingViewBussines.GetAll("سنگ")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        CityGuid = cityGuid,
                        Dang = 6,
                        DateParvane = item.listData[0].items[1].value.FixString(),
                        DeliveryDate = null,
                        EjarePrice2 = 0,
                        ErtefaSaqf = 0,
                        FloorCoverGuid = FloorCoverBussines.GetAll("سرامیک")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        Gas = EnKhadamati.Mostaqel,
                        Hashie = 0,
                        IsOwnerHere = null,
                        IsShortTime = false,
                        KitchenServiceGuid = KitchenServiceBussines.GetAll("MDF")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        Water = EnKhadamati.Mostaqel,
                        VamPrice = 0,
                        VahedPerTabaqe = 1,
                        Tarakom = null,
                        Side = EnBuildingSide.One,
                        ShortDesc = item.Description,
                        RentalAutorityGuid = null,
                        RahnPrice2 = 0,
                        QestPrice = 0,
                        MamarJoda = true,
                        MetrazhKouche = 0,
                        MetrazhTejari = 0,
                        MoavezeDesc = "",
                        MosharekatDesc = "",
                        ParvaneSerial = "",
                        PishDesc = "",
                        PishPrice = 0,
                        PishTotalPrice = 0,
                        Priority = EnBuildingPriority.Low
                    };

                    if (item.listData[2].value == "مجانی") bu.EjarePrice1 = 0;
                    else
                        bu.EjarePrice1 = item.listData[2].value.FixString().Replace("٫", "").Replace("تومان", "").ParseToDecimal() *
                                         10;
                    if (item.listData[5].value.Contains("از"))
                    {
                        if (item.listData[5].value.Contains("همکف"))
                        {
                            var a = item.listData[5].value.Replace("همکف از", "");
                            bu.TabaqeNo = 0;
                            bu.TedadTabaqe = a.FixString().ParseToInt();
                        }
                        else
                        {
                            var a = item.listData[5].value.Replace("از", "");
                            bu.TabaqeNo = a.Remove(1, 3).FixString().ParseToInt();
                            bu.TedadTabaqe = a.Remove(0, 2).FixString().ParseToInt();
                        }
                    }
                    else
                    {
                        bu.TabaqeNo = item.listData[5].value.FixString().ParseToInt();
                        bu.TedadTabaqe = bu.TabaqeNo;
                    }

                    var ex = await BuildingBussines.CheckDuplicateAsync(bu.Masahat, bu.RoomCount, bu.RahnPrice1, bu.EjarePrice1, bu.SellPrice, bu.TabaqeNo);
                    if (ex) continue;

                    bu.OptionList = new List<BuildingRelatedOptionsBussines>();

                    var evelator = await BuildingOptionsBussines.GetAsync(item.listData[6].items[0].value.FixString());
                    if (evelator == null)
                    {
                        evelator = new BuildingOptionsBussines()
                        {
                            Guid = Guid.NewGuid(),
                            Modified = DateTime.Now,
                            Name = item.listData[6].items[0].value.FixString(),
                            Status = true
                        };
                        await evelator.SaveAsync();
                    }

                    var op1 = new BuildingRelatedOptionsBussines()
                    {
                        Guid = Guid.NewGuid(),
                        Modified = DateTime.Now,
                        BuildingOptionGuid = evelator.Guid,
                        BuildinGuid = bu.Guid
                    };
                    bu.OptionList.Add(op1);


                    var parking = await BuildingOptionsBussines.GetAsync(item.listData[6].items[1].value.FixString());
                    if (parking == null)
                    {
                        parking = new BuildingOptionsBussines()
                        {
                            Guid = Guid.NewGuid(),
                            Modified = DateTime.Now,
                            Name = item.listData[6].items[1].value.FixString(),
                            Status = true
                        };
                        await parking.SaveAsync();
                    }

                    var op2 = new BuildingRelatedOptionsBussines()
                    {
                        Guid = Guid.NewGuid(),
                        Modified = DateTime.Now,
                        BuildingOptionGuid = parking.Guid,
                        BuildinGuid = bu.Guid
                    };
                    bu.OptionList.Add(op2);

                    var anbari = await BuildingOptionsBussines.GetAsync(item.listData[6].items[2].value.FixString());
                    if (anbari == null)
                    {
                        anbari = new BuildingOptionsBussines()
                        {
                            Guid = Guid.NewGuid(),
                            Modified = DateTime.Now,
                            Name = item.listData[6].items[2].value.FixString(),
                            Status = true
                        };
                        await anbari.SaveAsync();
                    }

                    var op3 = new BuildingRelatedOptionsBussines()
                    {
                        Guid = Guid.NewGuid(),
                        Modified = DateTime.Now,
                        BuildingOptionGuid = anbari.Guid,
                        BuildinGuid = bu.Guid
                    };
                    bu.OptionList.Add(op3);

                    list.Add(bu);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public static async Task<List<BuildingBussines>> GetStoreRent(DivarCities model, Guid cityGuid, string regionList)
        {
            var list = new List<BuildingBussines>();
            try
            {
                if (model == null) return list;
                var url = $"https://divar.ir/s/{model.LatinName}/rent-store";
                if (!string.IsNullOrEmpty(regionList))
                    url += $"{regionList}";
                url += "&user_type=personal";
                var listDivar = GetDataFromUrl(url, model.Name, cityGuid, "مغازه و غرفه");
                if (listDivar == null || listDivar.Count <= 0) return list;
                foreach (var item in listDivar)
                {
                    if (item.listData == null) continue;
                    var bu = new BuildingBussines()
                    {
                        Guid = Guid.NewGuid(),
                        Modified = DateTime.Now,
                        Status = true,
                        Masahat = item.listData[0].items[0].value.FixString().ParseToInt(),
                        SellPrice = 0,
                        ServerStatus = ServerStatus.None,
                        Code = BuildingBussines.NextCode(),
                        RahnPrice1 = item.listData[1].value.FixString().Replace("٫", "").Replace("تومان", "").ParseToDecimal() * 10,
                        ServerDeliveryDate = DateTime.Now,
                        EjarePrice1 = 0,
                        RegionGuid = item.RegionGuid,
                        Tell = EnKhadamati.Mostaqel,
                        RoomCount = item.listData[0].items[2].value.FixString().ParseToInt(),
                        UserGuid = UserBussines.CurrentUser.Guid,
                        Address = "",
                        GalleryList = null,
                        Image = DownloadImage(item.Image),
                        BuildingAccountTypeGuid = BuildingAccountTypeBussines.GetAll("مشاغل تجاری")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        CreateDate = DateTime.Now,
                        SaleSakht = item.listData[0].items[1].value.FixString(),
                        MediaList = null,
                        IsArchive = false,
                        ZirBana = item.listData[0].items[0].value.FixString().ParseToInt(),
                        DocumentType = null,
                        BuildingTypeGuid = BuildingTypeBussines.Get("تجاری")?.Guid ?? Guid.Empty,
                        OwnerGuid = ParentDefaults.TafsilCoding.CLSTafsil1030401,
                        Barq = EnKhadamati.Mostaqel,
                        BonBast = false,
                        BuildingConditionGuid = BuildingConditionBussines.GetAll("تخلیه")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        BuildingViewGuid = BuildingViewBussines.GetAll("سنگ")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        CityGuid = cityGuid,
                        Dang = 6,
                        DateParvane = item.listData[0].items[1].value.FixString(),
                        DeliveryDate = null,
                        EjarePrice2 = 0,
                        ErtefaSaqf = 0,
                        FloorCoverGuid = FloorCoverBussines.GetAll("سرامیک")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        Gas = EnKhadamati.Mostaqel,
                        Hashie = 0,
                        IsOwnerHere = null,
                        IsShortTime = false,
                        KitchenServiceGuid = KitchenServiceBussines.GetAll("MDF")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        Water = EnKhadamati.Mostaqel,
                        VamPrice = 0,
                        VahedPerTabaqe = 1,
                        Tarakom = null,
                        Side = EnBuildingSide.One,
                        ShortDesc = item.Description,
                        RentalAutorityGuid = null,
                        RahnPrice2 = 0,
                        QestPrice = 0,
                        MamarJoda = true,
                        MetrazhKouche = 0,
                        MetrazhTejari = 0,
                        MoavezeDesc = "",
                        MosharekatDesc = "",
                        ParvaneSerial = "",
                        PishDesc = "",
                        PishPrice = 0,
                        PishTotalPrice = 0,
                        Priority = EnBuildingPriority.Low
                    };

                    if (item.listData[2].value == "مجانی") bu.EjarePrice1 = 0;
                    else
                        bu.EjarePrice1 = item.listData[2].value.FixString().Replace("٫", "").Replace("تومان", "").ParseToDecimal() *
                                         10;
                    var ex = await BuildingBussines.CheckDuplicateAsync(bu.Masahat, bu.RoomCount, bu.RahnPrice1, bu.EjarePrice1, bu.SellPrice, bu.TabaqeNo);
                    if (ex) continue;
                    list.Add(bu);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public static async Task<List<BuildingBussines>> GetIndustrialRent(DivarCities model, Guid cityGuid, string regionList)
        {
            var list = new List<BuildingBussines>();
            try
            {
                if (model == null) return list;
                var url = $"https://divar.ir/s/{model.LatinName}/rent-industrial-agricultural-property";
                if (!string.IsNullOrEmpty(regionList))
                    url += $"{regionList}";
                url += "&user_type=personal";
                var listDivar = GetDataFromUrl(url, model.Name, cityGuid, "صنعتی، کشاورزی و تجاری");
                if (listDivar == null || listDivar.Count <= 0) return list;
                foreach (var item in listDivar)
                {
                    if (item.listData == null || (item.listData[0].items?.Count ?? 0) < 3) continue;
                    var bu = new BuildingBussines()
                    {
                        Guid = Guid.NewGuid(),
                        Modified = DateTime.Now,
                        Status = true,
                        Masahat = item.listData[0].items[0].value.FixString().ParseToInt(),
                        SellPrice = 0,
                        ServerStatus = ServerStatus.None,
                        Code = BuildingBussines.NextCode(),
                        RahnPrice1 = item.listData[1].value.FixString().Replace("٫", "").Replace("تومان", "").ParseToDecimal() * 10,
                        ServerDeliveryDate = DateTime.Now,
                        EjarePrice1 = 0,
                        RegionGuid = item.RegionGuid,
                        Tell = EnKhadamati.Mostaqel,
                        RoomCount = item.listData[0].items[2].value.FixString().ParseToInt(),
                        UserGuid = UserBussines.CurrentUser.Guid,
                        Address = "",
                        GalleryList = null,
                        Image = DownloadImage(item.Image),
                        BuildingAccountTypeGuid = BuildingAccountTypeBussines.GetAll("مسکونی")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        CreateDate = DateTime.Now,
                        SaleSakht = item.listData[0].items[1].value.FixString(),
                        MediaList = null,
                        IsArchive = false,
                        ZirBana = item.listData[0].items[0].value.FixString().ParseToInt(),
                        DocumentType = null,
                        BuildingTypeGuid = BuildingTypeBussines.Get("زمین مزروعی")?.Guid ?? Guid.Empty,
                        OwnerGuid = ParentDefaults.TafsilCoding.CLSTafsil1030401,
                        Barq = EnKhadamati.Mostaqel,
                        BonBast = false,
                        BuildingConditionGuid = BuildingConditionBussines.GetAll("تخلیه")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        BuildingViewGuid = BuildingViewBussines.GetAll("سنگ")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        CityGuid = cityGuid,
                        Dang = 6,
                        DateParvane = item.listData[0].items[1].value.FixString(),
                        DeliveryDate = null,
                        EjarePrice2 = 0,
                        ErtefaSaqf = 0,
                        FloorCoverGuid = FloorCoverBussines.GetAll("سرامیک")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        Gas = EnKhadamati.Mostaqel,
                        Hashie = 0,
                        IsOwnerHere = null,
                        IsShortTime = false,
                        KitchenServiceGuid = KitchenServiceBussines.GetAll("MDF")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        Water = EnKhadamati.Mostaqel,
                        VamPrice = 0,
                        VahedPerTabaqe = 1,
                        Tarakom = null,
                        Side = EnBuildingSide.One,
                        ShortDesc = item.Description,
                        RentalAutorityGuid = null,
                        RahnPrice2 = 0,
                        QestPrice = 0,
                        MamarJoda = true,
                        MetrazhKouche = 0,
                        MetrazhTejari = 0,
                        MoavezeDesc = "",
                        MosharekatDesc = "",
                        ParvaneSerial = "",
                        PishDesc = "",
                        PishPrice = 0,
                        PishTotalPrice = 0,
                        Priority = EnBuildingPriority.Low
                    };

                    if (item.listData[2].value == "مجانی") bu.EjarePrice1 = 0;
                    else
                        bu.EjarePrice1 = item.listData[2].value.FixString().Replace("٫", "").Replace("تومان", "").ParseToDecimal() *
                                         10;
                    var ex = await BuildingBussines.CheckDuplicateAsync(bu.Masahat, bu.RoomCount, bu.RahnPrice1, bu.EjarePrice1, bu.SellPrice, bu.TabaqeNo);
                    if (ex) continue;
                    list.Add(bu);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }


        public static async Task<List<BuildingBussines>> GetApartmentBuy(DivarCities model, Guid cityGuid, string regionList)
        {
            var list = new List<BuildingBussines>();
            try
            {
                if (model == null) return list;
                var url = $"https://divar.ir/s/{model.LatinName}/buy-apartment";
                if (!string.IsNullOrEmpty(regionList))
                    url += $"{regionList}";
                url += "&user_type=personal&non-negotiable=true";
                var listDivar = GetDataFromUrl(url, model.Name, cityGuid, "آپارتمان");
                if (listDivar == null || listDivar.Count <= 0) return list;
                foreach (var item in listDivar)
                {
                    if (item.listData == null) continue;
                    var bu = new BuildingBussines()
                    {
                        Guid = Guid.NewGuid(),
                        Modified = DateTime.Now,
                        Status = true,
                        Masahat = item.listData[0].items[0].value.FixString().ParseToInt(),
                        SellPrice = item.listData[1].value.FixString().Replace("٫", "").Replace("تومان", "").ParseToDecimal() * 10,
                        ServerStatus = ServerStatus.None,
                        Code = BuildingBussines.NextCode(),
                        RahnPrice1 = 0,
                        ServerDeliveryDate = DateTime.Now,
                        EjarePrice1 = 0,
                        RegionGuid = item.RegionGuid,
                        Tell = EnKhadamati.Mostaqel,
                        RoomCount = item.listData[0].items[2].value.FixString().ParseToInt(),
                        UserGuid = UserBussines.CurrentUser.Guid,
                        Address = "",
                        GalleryList = null,
                        Image = DownloadImage(item.Image),
                        BuildingAccountTypeGuid = BuildingAccountTypeBussines.GetAll("مسکونی")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        CreateDate = DateTime.Now,
                        SaleSakht = item.listData[0].items[1].value.FixString(),
                        MediaList = null,
                        IsArchive = false,
                        ZirBana = item.listData[0].items[0].value.FixString().ParseToInt(),
                        DocumentType = null,
                        BuildingTypeGuid = BuildingTypeBussines.Get("آپارتمان")?.Guid ?? Guid.Empty,
                        OwnerGuid = ParentDefaults.TafsilCoding.CLSTafsil1030401,
                        Barq = EnKhadamati.Mostaqel,
                        BonBast = false,
                        BuildingConditionGuid = BuildingConditionBussines.GetAll("تخلیه")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        BuildingViewGuid = BuildingViewBussines.GetAll("سنگ")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        CityGuid = cityGuid,
                        Dang = 6,
                        DateParvane = item.listData[0].items[1].value.FixString(),
                        DeliveryDate = null,
                        EjarePrice2 = 0,
                        ErtefaSaqf = 0,
                        FloorCoverGuid = FloorCoverBussines.GetAll("سرامیک")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        Gas = EnKhadamati.Mostaqel,
                        Hashie = 0,
                        IsOwnerHere = null,
                        IsShortTime = false,
                        KitchenServiceGuid = KitchenServiceBussines.GetAll("MDF")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        Water = EnKhadamati.Mostaqel,
                        VamPrice = 0,
                        VahedPerTabaqe = 1,
                        Tarakom = null,
                        Side = EnBuildingSide.One,
                        ShortDesc = item.Description,
                        RentalAutorityGuid = null,
                        RahnPrice2 = 0,
                        QestPrice = 0,
                        MamarJoda = true,
                        MetrazhKouche = 0,
                        MetrazhTejari = 0,
                        MoavezeDesc = "",
                        MosharekatDesc = "",
                        ParvaneSerial = "",
                        PishDesc = "",
                        PishPrice = 0,
                        PishTotalPrice = 0,
                        Priority = EnBuildingPriority.Low
                    };

                    if (item.listData[4].value.Contains("از"))
                    {
                        if (item.listData[4].value.Contains("همکف"))
                        {
                            var a = item.listData[4].value.Replace("همکف از", "");
                            bu.TabaqeNo = 0;
                            bu.TedadTabaqe = a.FixString().ParseToInt();
                        }
                        else
                        {
                            var a = item.listData[4].value.Replace("از", "");
                            bu.TabaqeNo = a.Remove(1, 3).FixString().ParseToInt();
                            bu.TedadTabaqe = a.Remove(0, 2).FixString().ParseToInt();
                        }
                    }
                    else
                    {
                        bu.TabaqeNo = item.listData[4].value.FixString().ParseToInt();
                        bu.TedadTabaqe = bu.TabaqeNo;
                    }
                    var ex = await BuildingBussines.CheckDuplicateAsync(bu.Masahat, bu.RoomCount, bu.RahnPrice1, bu.EjarePrice1, bu.SellPrice, bu.TabaqeNo);
                    if (ex) continue;
                    bu.OptionList = new List<BuildingRelatedOptionsBussines>();

                    var evelator = await BuildingOptionsBussines.GetAsync(item.listData[5].items[0].value.FixString());
                    if (evelator == null)
                    {
                        evelator = new BuildingOptionsBussines()
                        {
                            Guid = Guid.NewGuid(),
                            Modified = DateTime.Now,
                            Name = item.listData[5].items[0].value.FixString(),
                            Status = true
                        };
                        await evelator.SaveAsync();
                    }

                    var op1 = new BuildingRelatedOptionsBussines()
                    {
                        Guid = Guid.NewGuid(),
                        Modified = DateTime.Now,
                        BuildingOptionGuid = evelator.Guid,
                        BuildinGuid = bu.Guid
                    };
                    bu.OptionList.Add(op1);


                    var parking = await BuildingOptionsBussines.GetAsync(item.listData[5].items[1].value.FixString());
                    if (parking == null)
                    {
                        parking = new BuildingOptionsBussines()
                        {
                            Guid = Guid.NewGuid(),
                            Modified = DateTime.Now,
                            Name = item.listData[5].items[1].value.FixString(),
                            Status = true
                        };
                        await parking.SaveAsync();
                    }

                    var op2 = new BuildingRelatedOptionsBussines()
                    {
                        Guid = Guid.NewGuid(),
                        Modified = DateTime.Now,
                        BuildingOptionGuid = parking.Guid,
                        BuildinGuid = bu.Guid
                    };
                    bu.OptionList.Add(op2);

                    var anbari = await BuildingOptionsBussines.GetAsync(item.listData[5].items[2].value.FixString());
                    if (anbari == null)
                    {
                        anbari = new BuildingOptionsBussines()
                        {
                            Guid = Guid.NewGuid(),
                            Modified = DateTime.Now,
                            Name = item.listData[5].items[2].value.FixString(),
                            Status = true
                        };
                        await anbari.SaveAsync();
                    }

                    var op3 = new BuildingRelatedOptionsBussines()
                    {
                        Guid = Guid.NewGuid(),
                        Modified = DateTime.Now,
                        BuildingOptionGuid = anbari.Guid,
                        BuildinGuid = bu.Guid
                    };
                    bu.OptionList.Add(op3);

                    list.Add(bu);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public static async Task<List<BuildingBussines>> GetVillaBuy(DivarCities model, Guid cityGuid, string regionList)
        {
            var list = new List<BuildingBussines>();
            try
            {
                if (model == null) return list;
                var url = $"https://divar.ir/s/{model.LatinName}/buy-villa";
                if (!string.IsNullOrEmpty(regionList))
                    url += $"{regionList}";
                url += "&user_type=personal&non-negotiable=true";
                var listDivar = GetDataFromUrl(url, model.Name, cityGuid, "خانه و ویلا");
                if (listDivar == null || listDivar.Count <= 0) return list;
                foreach (var item in listDivar)
                {
                    if (item.listData == null) continue;
                    var bu = new BuildingBussines()
                    {
                        Guid = Guid.NewGuid(),
                        Modified = DateTime.Now,
                        Status = true,
                        Masahat = item.listData[0].items[0].value.FixString().ParseToInt(),
                        SellPrice = item.listData[1].value.FixString().Replace("٫", "").Replace("تومان", "").ParseToDecimal() * 10,
                        ServerStatus = ServerStatus.None,
                        Code = BuildingBussines.NextCode(),
                        RahnPrice1 = 0,
                        ServerDeliveryDate = DateTime.Now,
                        EjarePrice1 = 0,
                        RegionGuid = item.RegionGuid,
                        Tell = EnKhadamati.Mostaqel,
                        RoomCount = item.listData[0].items[2].value.FixString().ParseToInt(),
                        UserGuid = UserBussines.CurrentUser.Guid,
                        Address = "",
                        GalleryList = null,
                        Image = DownloadImage(item.Image),
                        BuildingAccountTypeGuid = BuildingAccountTypeBussines.GetAll("مسکونی")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        CreateDate = DateTime.Now,
                        SaleSakht = item.listData[0].items[1].value.FixString(),
                        MediaList = null,
                        IsArchive = false,
                        ZirBana = item.listData[0].items[0].value.FixString().ParseToInt(),
                        DocumentType = null,
                        BuildingTypeGuid = BuildingTypeBussines.Get("منزل مسکونی")?.Guid ?? Guid.Empty,
                        OwnerGuid = ParentDefaults.TafsilCoding.CLSTafsil1030401,
                        Barq = EnKhadamati.Mostaqel,
                        BonBast = false,
                        BuildingConditionGuid = BuildingConditionBussines.GetAll("تخلیه")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        BuildingViewGuid = BuildingViewBussines.GetAll("سنگ")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        CityGuid = cityGuid,
                        Dang = 6,
                        DateParvane = item.listData[0].items[1].value.FixString(),
                        DeliveryDate = null,
                        EjarePrice2 = 0,
                        ErtefaSaqf = 0,
                        FloorCoverGuid = FloorCoverBussines.GetAll("سرامیک")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        Gas = EnKhadamati.Mostaqel,
                        Hashie = 0,
                        IsOwnerHere = null,
                        IsShortTime = false,
                        KitchenServiceGuid = KitchenServiceBussines.GetAll("MDF")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        Water = EnKhadamati.Mostaqel,
                        VamPrice = 0,
                        VahedPerTabaqe = 1,
                        Tarakom = null,
                        Side = EnBuildingSide.One,
                        ShortDesc = item.Description,
                        RentalAutorityGuid = null,
                        RahnPrice2 = 0,
                        QestPrice = 0,
                        MamarJoda = true,
                        MetrazhKouche = 0,
                        MetrazhTejari = 0,
                        MoavezeDesc = "",
                        MosharekatDesc = "",
                        ParvaneSerial = "",
                        PishDesc = "",
                        PishPrice = 0,
                        PishTotalPrice = 0,
                        Priority = EnBuildingPriority.Low
                    };
                    var ex = await BuildingBussines.CheckDuplicateAsync(bu.Masahat, bu.RoomCount, bu.RahnPrice1, bu.EjarePrice1, bu.SellPrice, bu.TabaqeNo);
                    if (ex) continue;
                    bu.OptionList = new List<BuildingRelatedOptionsBussines>();

                    var evelator = await BuildingOptionsBussines.GetAsync(item.listData[4].items[0].value.FixString());
                    if (evelator == null)
                    {
                        evelator = new BuildingOptionsBussines()
                        {
                            Guid = Guid.NewGuid(),
                            Modified = DateTime.Now,
                            Name = item.listData[5].items[0].value.FixString(),
                            Status = true
                        };
                        await evelator.SaveAsync();
                    }

                    var op1 = new BuildingRelatedOptionsBussines()
                    {
                        Guid = Guid.NewGuid(),
                        Modified = DateTime.Now,
                        BuildingOptionGuid = evelator.Guid,
                        BuildinGuid = bu.Guid
                    };
                    bu.OptionList.Add(op1);


                    var parking = await BuildingOptionsBussines.GetAsync(item.listData[4].items[1].value.FixString());
                    if (parking == null)
                    {
                        parking = new BuildingOptionsBussines()
                        {
                            Guid = Guid.NewGuid(),
                            Modified = DateTime.Now,
                            Name = item.listData[4].items[1].value.FixString(),
                            Status = true
                        };
                        await parking.SaveAsync();
                    }

                    var op2 = new BuildingRelatedOptionsBussines()
                    {
                        Guid = Guid.NewGuid(),
                        Modified = DateTime.Now,
                        BuildingOptionGuid = parking.Guid,
                        BuildinGuid = bu.Guid
                    };
                    bu.OptionList.Add(op2);

                    var anbari = await BuildingOptionsBussines.GetAsync(item.listData[4].items[2].value.FixString());
                    if (anbari == null)
                    {
                        anbari = new BuildingOptionsBussines()
                        {
                            Guid = Guid.NewGuid(),
                            Modified = DateTime.Now,
                            Name = item.listData[4].items[2].value.FixString(),
                            Status = true
                        };
                        await anbari.SaveAsync();
                    }

                    var op3 = new BuildingRelatedOptionsBussines()
                    {
                        Guid = Guid.NewGuid(),
                        Modified = DateTime.Now,
                        BuildingOptionGuid = anbari.Guid,
                        BuildinGuid = bu.Guid
                    };
                    bu.OptionList.Add(op3);

                    list.Add(bu);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public static async Task<List<BuildingBussines>> GetOldHouseBuy(DivarCities model, Guid cityGuid, string regionList)
        {
            var list = new List<BuildingBussines>();
            try
            {
                if (model == null) return list;
                var url = $"https://divar.ir/s/{model.LatinName}/buy-old-house";
                if (!string.IsNullOrEmpty(regionList))
                    url += $"{regionList}";
                url += "&user_type=personal&non-negotiable=true";
                var listDivar = GetDataFromUrl(url, model.Name, cityGuid, "زمین و کلنگی");
                if (listDivar == null || listDivar.Count <= 0) return list;
                foreach (var item in listDivar)
                {
                    if (item.listData == null) continue;
                    var bu = new BuildingBussines()
                    {
                        Guid = Guid.NewGuid(),
                        Modified = DateTime.Now,
                        Status = true,
                        Masahat = item.listData[0].value.FixString().ParseToInt(),
                        SellPrice = item.listData[1].value.FixString().Replace("٫", "").Replace("تومان", "").ParseToDecimal() * 10,
                        ServerStatus = ServerStatus.None,
                        Code = BuildingBussines.NextCode(),
                        RahnPrice1 = 0,
                        ServerDeliveryDate = DateTime.Now,
                        EjarePrice1 = 0,
                        RegionGuid = item.RegionGuid,
                        Tell = EnKhadamati.Mostaqel,
                        RoomCount = 0,
                        UserGuid = UserBussines.CurrentUser.Guid,
                        Address = "",
                        GalleryList = null,
                        Image = DownloadImage(item.Image),
                        BuildingAccountTypeGuid = BuildingAccountTypeBussines.GetAll("مسکونی")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        CreateDate = DateTime.Now,
                        SaleSakht = "",
                        MediaList = null,
                        IsArchive = false,
                        ZirBana = 0,
                        DocumentType = null,
                        BuildingTypeGuid = BuildingTypeBussines.Get("منزل مسکونی")?.Guid ?? Guid.Empty,
                        OwnerGuid = ParentDefaults.TafsilCoding.CLSTafsil1030401,
                        Barq = EnKhadamati.Mostaqel,
                        BonBast = false,
                        BuildingConditionGuid = BuildingConditionBussines.GetAll("تخلیه")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        BuildingViewGuid = BuildingViewBussines.GetAll("سنگ")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        CityGuid = cityGuid,
                        Dang = 6,
                        DateParvane = "",
                        DeliveryDate = null,
                        EjarePrice2 = 0,
                        ErtefaSaqf = 0,
                        FloorCoverGuid = FloorCoverBussines.GetAll("سرامیک")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        Gas = EnKhadamati.Mostaqel,
                        Hashie = 0,
                        IsOwnerHere = null,
                        IsShortTime = false,
                        KitchenServiceGuid = KitchenServiceBussines.GetAll("MDF")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        Water = EnKhadamati.Mostaqel,
                        VamPrice = 0,
                        VahedPerTabaqe = 1,
                        Tarakom = null,
                        Side = EnBuildingSide.One,
                        ShortDesc = item.Description,
                        RentalAutorityGuid = null,
                        RahnPrice2 = 0,
                        QestPrice = 0,
                        MamarJoda = true,
                        MetrazhKouche = 0,
                        MetrazhTejari = 0,
                        MoavezeDesc = "",
                        MosharekatDesc = "",
                        ParvaneSerial = "",
                        PishDesc = "",
                        PishPrice = 0,
                        PishTotalPrice = 0,
                        Priority = EnBuildingPriority.Low
                    };
                    var ex = await BuildingBussines.CheckDuplicateAsync(bu.Masahat, bu.RoomCount, bu.RahnPrice1, bu.EjarePrice1, bu.SellPrice, bu.TabaqeNo);
                    if (ex) continue;
                    list.Add(bu);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public static async Task<List<BuildingBussines>> GetOfficeBuy(DivarCities model, Guid cityGuid, string regionList)
        {
            var list = new List<BuildingBussines>();
            try
            {
                if (model == null) return list;
                var url = $"https://divar.ir/s/{model.LatinName}/buy-office";
                if (!string.IsNullOrEmpty(regionList))
                    url += $"{regionList}";
                url += "&user_type=personal&non-negotiable=true";
                var listDivar = GetDataFromUrl(url, model.Name, cityGuid, "دفتر کار، اتاق اداری و مطب");
                if (listDivar == null || listDivar.Count <= 0) return list;
                foreach (var item in listDivar)
                {
                    if (item.listData == null || item.listData.Count == 6) continue;
                    var bu = new BuildingBussines()
                    {
                        Guid = Guid.NewGuid(),
                        Modified = DateTime.Now,
                        Status = true,
                        Masahat = item.listData[0].items[0].value.FixString().ParseToInt(),
                        SellPrice = item.listData[1].value.FixString().Replace("٫", "").Replace("تومان", "").ParseToDecimal() * 10,
                        ServerStatus = ServerStatus.None,
                        Code = BuildingBussines.NextCode(),
                        RahnPrice1 = 0,
                        ServerDeliveryDate = DateTime.Now,
                        EjarePrice1 = 0,
                        RegionGuid = item.RegionGuid,
                        Tell = EnKhadamati.Mostaqel,
                        RoomCount = item.listData[0].items[2].value.FixString().ParseToInt(),
                        UserGuid = UserBussines.CurrentUser.Guid,
                        Address = "",
                        GalleryList = null,
                        Image = DownloadImage(item.Image),
                        BuildingAccountTypeGuid = BuildingAccountTypeBussines.GetAll("دفترکار")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        CreateDate = DateTime.Now,
                        SaleSakht = item.listData[0].items[1].value.FixString(),
                        MediaList = null,
                        IsArchive = false,
                        ZirBana = item.listData[0].items[0].value.FixString().ParseToInt(),
                        DocumentType = null,
                        BuildingTypeGuid = BuildingTypeBussines.Get("تجاری")?.Guid ?? Guid.Empty,
                        OwnerGuid = ParentDefaults.TafsilCoding.CLSTafsil1030401,
                        Barq = EnKhadamati.Mostaqel,
                        BonBast = false,
                        BuildingConditionGuid = BuildingConditionBussines.GetAll("تخلیه")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        BuildingViewGuid = BuildingViewBussines.GetAll("سنگ")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        CityGuid = cityGuid,
                        Dang = 6,
                        DateParvane = item.listData[0].items[1].value.FixString(),
                        DeliveryDate = null,
                        EjarePrice2 = 0,
                        ErtefaSaqf = 0,
                        FloorCoverGuid = FloorCoverBussines.GetAll("سرامیک")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        Gas = EnKhadamati.Mostaqel,
                        Hashie = 0,
                        IsOwnerHere = null,
                        IsShortTime = false,
                        KitchenServiceGuid = KitchenServiceBussines.GetAll("MDF")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        Water = EnKhadamati.Mostaqel,
                        VamPrice = 0,
                        VahedPerTabaqe = 1,
                        Tarakom = null,
                        Side = EnBuildingSide.One,
                        ShortDesc = item.Description,
                        RentalAutorityGuid = null,
                        RahnPrice2 = 0,
                        QestPrice = 0,
                        MamarJoda = true,
                        MetrazhKouche = 0,
                        MetrazhTejari = 0,
                        MoavezeDesc = "",
                        MosharekatDesc = "",
                        ParvaneSerial = "",
                        PishDesc = "",
                        PishPrice = 0,
                        PishTotalPrice = 0,
                        Priority = EnBuildingPriority.Low
                    };

                    if (item.listData[5]?.value?.Contains("از") ?? false)
                    {
                        if (item.listData[5].value.Contains("همکف"))
                        {
                            var a = item.listData[5].value.Replace("همکف از", "");
                            bu.TabaqeNo = 0;
                            bu.TedadTabaqe = a.FixString().ParseToInt();
                        }
                        else
                        {
                            var a = item.listData[5].value.Replace("از", "");
                            bu.TabaqeNo = a.Remove(1, 3).FixString().ParseToInt();
                            bu.TedadTabaqe = a.Remove(0, 2).FixString().ParseToInt();
                        }
                    }
                    else
                    {
                        bu.TabaqeNo = item.listData[5]?.value?.FixString().ParseToInt() ?? 0;
                        bu.TedadTabaqe = bu.TabaqeNo;
                    }
                    var ex = await BuildingBussines.CheckDuplicateAsync(bu.Masahat, bu.RoomCount, bu.RahnPrice1, bu.EjarePrice1, bu.SellPrice, bu.TabaqeNo);
                    if (ex) continue;
                    bu.OptionList = new List<BuildingRelatedOptionsBussines>();

                    var evelator = await BuildingOptionsBussines.GetAsync(item.listData[6]?.items[0]?.value.FixString());
                    if (evelator == null)
                    {
                        evelator = new BuildingOptionsBussines()
                        {
                            Guid = Guid.NewGuid(),
                            Modified = DateTime.Now,
                            Name = item.listData[6].items[0].value.FixString(),
                            Status = true
                        };
                        await evelator.SaveAsync();
                    }

                    var op1 = new BuildingRelatedOptionsBussines()
                    {
                        Guid = Guid.NewGuid(),
                        Modified = DateTime.Now,
                        BuildingOptionGuid = evelator.Guid,
                        BuildinGuid = bu.Guid
                    };
                    bu.OptionList.Add(op1);


                    var parking = await BuildingOptionsBussines.GetAsync(item.listData[6].items[1].value.FixString());
                    if (parking == null)
                    {
                        parking = new BuildingOptionsBussines()
                        {
                            Guid = Guid.NewGuid(),
                            Modified = DateTime.Now,
                            Name = item.listData[6].items[1].value.FixString(),
                            Status = true
                        };
                        await parking.SaveAsync();
                    }

                    var op2 = new BuildingRelatedOptionsBussines()
                    {
                        Guid = Guid.NewGuid(),
                        Modified = DateTime.Now,
                        BuildingOptionGuid = parking.Guid,
                        BuildinGuid = bu.Guid
                    };
                    bu.OptionList.Add(op2);

                    var anbari = await BuildingOptionsBussines.GetAsync(item.listData[6].items[2].value.FixString());
                    if (anbari == null)
                    {
                        anbari = new BuildingOptionsBussines()
                        {
                            Guid = Guid.NewGuid(),
                            Modified = DateTime.Now,
                            Name = item.listData[6].items[2].value.FixString(),
                            Status = true
                        };
                        await anbari.SaveAsync();
                    }

                    var op3 = new BuildingRelatedOptionsBussines()
                    {
                        Guid = Guid.NewGuid(),
                        Modified = DateTime.Now,
                        BuildingOptionGuid = anbari.Guid,
                        BuildinGuid = bu.Guid
                    };
                    bu.OptionList.Add(op3);

                    list.Add(bu);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public static async Task<List<BuildingBussines>> GetStoreBuy(DivarCities model, Guid cityGuid, string regionList)
        {
            var list = new List<BuildingBussines>();
            try
            {
                if (model == null) return list;
                var url = $"https://divar.ir/s/{model.LatinName}/buy-store";
                if (!string.IsNullOrEmpty(regionList))
                    url += $"{regionList}";
                url += "&user_type=personal&non-negotiable=true";
                var listDivar = GetDataFromUrl(url, model.Name, cityGuid, "مغازه و غرفه");
                if (listDivar == null || listDivar.Count <= 0) return list;
                foreach (var item in listDivar)
                {
                    if (item.listData == null) continue;
                    var bu = new BuildingBussines()
                    {
                        Guid = Guid.NewGuid(),
                        Modified = DateTime.Now,
                        Status = true,
                        Masahat = item.listData[0].items[0].value.FixString().ParseToInt(),
                        SellPrice = item.listData[1].value.FixString().Replace("٫", "").Replace("تومان", "").ParseToDecimal() * 10,
                        ServerStatus = ServerStatus.None,
                        Code = BuildingBussines.NextCode(),
                        RahnPrice1 = 0,
                        ServerDeliveryDate = DateTime.Now,
                        EjarePrice1 = 0,
                        RegionGuid = item.RegionGuid,
                        Tell = EnKhadamati.Mostaqel,
                        RoomCount = item.listData[0].items[2].value.FixString().ParseToInt(),
                        UserGuid = UserBussines.CurrentUser.Guid,
                        Address = "",
                        GalleryList = null,
                        Image = DownloadImage(item.Image),
                        BuildingAccountTypeGuid = BuildingAccountTypeBussines.GetAll("مشاغل تجاری")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        CreateDate = DateTime.Now,
                        SaleSakht = item.listData[0].items[1].value.FixString(),
                        MediaList = null,
                        IsArchive = false,
                        ZirBana = item.listData[0].items[0].value.FixString().ParseToInt(),
                        DocumentType = null,
                        BuildingTypeGuid = BuildingTypeBussines.Get("تجاری")?.Guid ?? Guid.Empty,
                        OwnerGuid = ParentDefaults.TafsilCoding.CLSTafsil1030401,
                        Barq = EnKhadamati.Mostaqel,
                        BonBast = false,
                        BuildingConditionGuid = BuildingConditionBussines.GetAll("تخلیه")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        BuildingViewGuid = BuildingViewBussines.GetAll("سنگ")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        CityGuid = cityGuid,
                        Dang = 6,
                        DateParvane = item.listData[0].items[1].value.FixString(),
                        DeliveryDate = null,
                        EjarePrice2 = 0,
                        ErtefaSaqf = 0,
                        FloorCoverGuid = FloorCoverBussines.GetAll("سرامیک")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        Gas = EnKhadamati.Mostaqel,
                        Hashie = 0,
                        IsOwnerHere = null,
                        IsShortTime = false,
                        KitchenServiceGuid = KitchenServiceBussines.GetAll("MDF")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        Water = EnKhadamati.Mostaqel,
                        VamPrice = 0,
                        VahedPerTabaqe = 1,
                        Tarakom = null,
                        Side = EnBuildingSide.One,
                        ShortDesc = item.Description,
                        RentalAutorityGuid = null,
                        RahnPrice2 = 0,
                        QestPrice = 0,
                        MamarJoda = true,
                        MetrazhKouche = 0,
                        MetrazhTejari = 0,
                        MoavezeDesc = "",
                        MosharekatDesc = "",
                        ParvaneSerial = "",
                        PishDesc = "",
                        PishPrice = 0,
                        PishTotalPrice = 0,
                        Priority = EnBuildingPriority.Low
                    };
                    var ex = await BuildingBussines.CheckDuplicateAsync(bu.Masahat, bu.RoomCount, bu.RahnPrice1, bu.EjarePrice1, bu.SellPrice, bu.TabaqeNo);
                    if (ex) continue;
                    list.Add(bu);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public static async Task<List<BuildingBussines>> GetIndustrialBuy(DivarCities model, Guid cityGuid, string regionList)
        {
            var list = new List<BuildingBussines>();
            try
            {
                if (model == null) return list;
                var url = $"https://divar.ir/s/{model.LatinName}/buy-industrial-agricultural-property";
                if (!string.IsNullOrEmpty(regionList))
                    url += $"{regionList}";
                url += "&user_type=personal&non-negotiable=true";
                var listDivar = GetDataFromUrl(url, model.Name, cityGuid, "صنعتی، کشاورزی و تجاری");
                if (listDivar == null || listDivar.Count <= 0) return list;
                foreach (var item in listDivar)
                {
                    if (item.listData == null || item.listData.Count == 4 || (item.listData[0].items?.Count ?? 0) < 3) continue;
                    var bu = new BuildingBussines()
                    {
                        Guid = Guid.NewGuid(),
                        Modified = DateTime.Now,
                        Status = true,
                        Masahat = item.listData[0].items[0].value.FixString().ParseToInt(),
                        SellPrice = item.listData[1].value.FixString().Replace("٫", "").Replace("تومان", "").ParseToDecimal() * 10,
                        ServerStatus = ServerStatus.None,
                        Code = BuildingBussines.NextCode(),
                        RahnPrice1 = 0,
                        ServerDeliveryDate = DateTime.Now,
                        EjarePrice1 = 0,
                        RegionGuid = item.RegionGuid,
                        Tell = EnKhadamati.Mostaqel,
                        RoomCount = item.listData[0].items[2].value.FixString().ParseToInt(),
                        UserGuid = UserBussines.CurrentUser.Guid,
                        Address = "",
                        GalleryList = null,
                        Image = DownloadImage(item.Image),
                        BuildingAccountTypeGuid = BuildingAccountTypeBussines.GetAll("مسکونی")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        CreateDate = DateTime.Now,
                        SaleSakht = item.listData[0].items[1].value.FixString(),
                        MediaList = null,
                        IsArchive = false,
                        ZirBana = item.listData[0].items[0].value.FixString().ParseToInt(),
                        DocumentType = null,
                        BuildingTypeGuid = BuildingTypeBussines.Get("زمین مزروعی")?.Guid ?? Guid.Empty,
                        OwnerGuid = ParentDefaults.TafsilCoding.CLSTafsil1030401,
                        Barq = EnKhadamati.Mostaqel,
                        BonBast = false,
                        BuildingConditionGuid = BuildingConditionBussines.GetAll("تخلیه")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        BuildingViewGuid = BuildingViewBussines.GetAll("سنگ")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        CityGuid = cityGuid,
                        Dang = 6,
                        DateParvane = item.listData[0].items[1].value.FixString(),
                        DeliveryDate = null,
                        EjarePrice2 = 0,
                        ErtefaSaqf = 0,
                        FloorCoverGuid = FloorCoverBussines.GetAll("سرامیک")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        Gas = EnKhadamati.Mostaqel,
                        Hashie = 0,
                        IsOwnerHere = null,
                        IsShortTime = false,
                        KitchenServiceGuid = KitchenServiceBussines.GetAll("MDF")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        Water = EnKhadamati.Mostaqel,
                        VamPrice = 0,
                        VahedPerTabaqe = 1,
                        Tarakom = null,
                        Side = EnBuildingSide.One,
                        ShortDesc = item.Description,
                        RentalAutorityGuid = null,
                        RahnPrice2 = 0,
                        QestPrice = 0,
                        MamarJoda = true,
                        MetrazhKouche = 0,
                        MetrazhTejari = 0,
                        MoavezeDesc = "",
                        MosharekatDesc = "",
                        ParvaneSerial = "",
                        PishDesc = "",
                        PishPrice = 0,
                        PishTotalPrice = 0,
                        Priority = EnBuildingPriority.Low
                    };
                    var ex = await BuildingBussines.CheckDuplicateAsync(bu.Masahat, bu.RoomCount, bu.RahnPrice1, bu.EjarePrice1, bu.SellPrice, bu.TabaqeNo);
                    if (ex) continue;
                    list.Add(bu);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }

        public static async Task<List<BuildingBussines>> GetContributionConstruction(DivarCities model, Guid cityGuid, string regionList)
        {
            var list = new List<BuildingBussines>();
            try
            {
                if (model == null) return list;
                var url = $"https://divar.ir/s/{model.LatinName}/contribution-construction";
                if (!string.IsNullOrEmpty(regionList))
                    url += $"{regionList}";
                url += "&user_type=personal";
                var listDivar = GetDataFromUrl(url, model.Name, cityGuid, "مشارکت در ساخت");
                if (listDivar == null || listDivar.Count <= 0) return list;
                foreach (var item in listDivar)
                {
                    if (item.listData == null) continue;
                    var bu = new BuildingBussines()
                    {
                        Guid = Guid.NewGuid(),
                        Modified = DateTime.Now,
                        Status = true,
                        Masahat = 0,
                        SellPrice = 0,
                        ServerStatus = ServerStatus.None,
                        Code = BuildingBussines.NextCode(),
                        RahnPrice1 = 0,
                        ServerDeliveryDate = DateTime.Now,
                        EjarePrice1 = 0,
                        RegionGuid = item.RegionGuid,
                        Tell = EnKhadamati.Mostaqel,
                        RoomCount = 0,
                        UserGuid = UserBussines.CurrentUser.Guid,
                        Address = "",
                        GalleryList = null,
                        Image = DownloadImage(item.Image),
                        BuildingAccountTypeGuid = BuildingAccountTypeBussines.GetAll("مسکونی")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        CreateDate = DateTime.Now,
                        SaleSakht = "",
                        MediaList = null,
                        IsArchive = false,
                        ZirBana = 0,
                        DocumentType = null,
                        BuildingTypeGuid = BuildingTypeBussines.Get("زمین مسکونی")?.Guid ?? Guid.Empty,
                        OwnerGuid = ParentDefaults.TafsilCoding.CLSTafsil1030401,
                        Barq = EnKhadamati.Mostaqel,
                        BonBast = false,
                        BuildingConditionGuid = BuildingConditionBussines.GetAll("تخلیه")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        BuildingViewGuid = BuildingViewBussines.GetAll("سنگ")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        CityGuid = cityGuid,
                        Dang = 6,
                        DateParvane = "",
                        DeliveryDate = null,
                        EjarePrice2 = 0,
                        ErtefaSaqf = 0,
                        FloorCoverGuid = FloorCoverBussines.GetAll("سرامیک")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        Gas = EnKhadamati.Mostaqel,
                        Hashie = 0,
                        IsOwnerHere = null,
                        IsShortTime = false,
                        KitchenServiceGuid = KitchenServiceBussines.GetAll("MDF")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        Water = EnKhadamati.Mostaqel,
                        VamPrice = 0,
                        VahedPerTabaqe = 1,
                        Tarakom = null,
                        Side = EnBuildingSide.One,
                        ShortDesc = item.Description,
                        RentalAutorityGuid = null,
                        RahnPrice2 = 0,
                        QestPrice = 0,
                        MamarJoda = true,
                        MetrazhKouche = 0,
                        MetrazhTejari = 0,
                        MoavezeDesc = "",
                        MosharekatDesc = "",
                        ParvaneSerial = "",
                        PishDesc = "",
                        PishPrice = 0,
                        PishTotalPrice = 0,
                        Priority = EnBuildingPriority.Low
                    };
                    var ex = await BuildingBussines.CheckDuplicateAsync(bu.Masahat, bu.RoomCount, bu.RahnPrice1, bu.EjarePrice1, bu.SellPrice, bu.TabaqeNo);
                    if (ex) continue;
                    list.Add(bu);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public static async Task<List<BuildingBussines>> GetPreeSellHome(DivarCities model, Guid cityGuid, string regionList)
        {
            var list = new List<BuildingBussines>();
            try
            {
                if (model == null) return list;
                var url = $"https://divar.ir/s/{model.LatinName}/pre-sell-home";
                if (!string.IsNullOrEmpty(regionList))
                    url += $"{regionList}";
                url += "&user_type=personal";
                var listDivar = GetDataFromUrl(url, model.Name, cityGuid, "پیش‌فروش");
                if (listDivar == null || listDivar.Count <= 0) return list;
                foreach (var item in listDivar)
                {
                    if (item.listData == null) continue;
                    var bu = new BuildingBussines()
                    {
                        Guid = Guid.NewGuid(),
                        Modified = DateTime.Now,
                        Status = true,
                        Masahat = 0,
                        SellPrice = 0,
                        ServerStatus = ServerStatus.None,
                        Code = BuildingBussines.NextCode(),
                        RahnPrice1 = 0,
                        ServerDeliveryDate = DateTime.Now,
                        EjarePrice1 = 0,
                        RegionGuid = item.RegionGuid,
                        Tell = EnKhadamati.Mostaqel,
                        RoomCount = 0,
                        UserGuid = UserBussines.CurrentUser.Guid,
                        Address = "",
                        GalleryList = null,
                        Image = DownloadImage(item.Image),
                        BuildingAccountTypeGuid = BuildingAccountTypeBussines.GetAll("مسکونی")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        CreateDate = DateTime.Now,
                        SaleSakht = "",
                        MediaList = null,
                        IsArchive = false,
                        ZirBana = 0,
                        DocumentType = null,
                        BuildingTypeGuid = BuildingTypeBussines.Get("منزل مسکونی")?.Guid ?? Guid.Empty,
                        OwnerGuid = ParentDefaults.TafsilCoding.CLSTafsil1030401,
                        Barq = EnKhadamati.Mostaqel,
                        BonBast = false,
                        BuildingConditionGuid = BuildingConditionBussines.GetAll("تخلیه")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        BuildingViewGuid = BuildingViewBussines.GetAll("سنگ")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        CityGuid = cityGuid,
                        Dang = 6,
                        DateParvane = "",
                        DeliveryDate = null,
                        EjarePrice2 = 0,
                        ErtefaSaqf = 0,
                        FloorCoverGuid = FloorCoverBussines.GetAll("سرامیک")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        Gas = EnKhadamati.Mostaqel,
                        Hashie = 0,
                        IsOwnerHere = null,
                        IsShortTime = false,
                        KitchenServiceGuid = KitchenServiceBussines.GetAll("MDF")?.FirstOrDefault()?.Guid ?? Guid.Empty,
                        Water = EnKhadamati.Mostaqel,
                        VamPrice = 0,
                        VahedPerTabaqe = 1,
                        Tarakom = null,
                        Side = EnBuildingSide.One,
                        ShortDesc = item.Description,
                        RentalAutorityGuid = null,
                        RahnPrice2 = 0,
                        QestPrice = 0,
                        MamarJoda = true,
                        MetrazhKouche = 0,
                        MetrazhTejari = 0,
                        MoavezeDesc = "",
                        MosharekatDesc = "",
                        ParvaneSerial = "",
                        PishDesc = "",
                        PishPrice = 0,
                        PishTotalPrice = 0,
                        Priority = EnBuildingPriority.Low
                    };
                    var ex = await BuildingBussines.CheckDuplicateAsync(bu.Masahat, bu.RoomCount, bu.RahnPrice1, bu.EjarePrice1, bu.SellPrice, bu.TabaqeNo);
                    if (ex) continue;
                    list.Add(bu);
                }
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
        public Guid RegionGuid { get; set; }
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
