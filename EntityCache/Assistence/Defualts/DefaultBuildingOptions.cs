using System;
using System.Collections.Generic;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Assistence.Defualts
{
    public static class DefaultBuildingOptions
    {
        private static List<BuildingOptionsBussines> list = new List<BuildingOptionsBussines>();
        private static BuildingOptionsBussines SetDef(string name)
        {
            try
            {
                var reg = new BuildingOptionsBussines()
                {
                    Name = name,
                    Guid = Guid.NewGuid(),
                };
                return reg;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }

        public static List<BuildingOptionsBussines> SetDef()
        {
            try
            {
                list.Add(SetDef("انباری"));
                list.Add(SetDef("پارکینگ"));
                list.Add(SetDef("حیاط"));
                list.Add(SetDef("آبنما"));
                list.Add(SetDef("آنتن مرکزی"));
                list.Add(SetDef("استخر"));
                list.Add(SetDef("باربی کیو"));
                list.Add(SetDef("بالکن"));
                list.Add(SetDef("برق اضطراری"));
                list.Add(SetDef("جارو مرکزی"));
                list.Add(SetDef("جکوزی"));
                list.Add(SetDef("درب برقی"));
                list.Add(SetDef("سرویس فرنگی"));
                list.Add(SetDef("سرویس مستر"));
                list.Add(SetDef("سونا"));
                list.Add(SetDef("سیستم اعلان حریق"));
                list.Add(SetDef("شوتینگ زباله"));
                list.Add(SetDef("قفل اثر انگشت"));
                list.Add(SetDef("نور مخفی"));
                list.Add(SetDef("هود"));
                list.Add(SetDef("وان"));
                list.Add(SetDef("پنجره دو جداره"));
                list.Add(SetDef("پکیج"));
                list.Add(SetDef("کلید الکترونیکی"));
                return list;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
    }
}
