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
