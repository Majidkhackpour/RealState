using System;
using System.Collections.Generic;
using System.Linq;
using Advertise.Properties;
using EntityCache.ViewModels;
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
    }
}
