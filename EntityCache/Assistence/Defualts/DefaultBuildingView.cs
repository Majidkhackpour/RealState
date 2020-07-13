using System;
using System.Collections.Generic;
using EntityCache.Bussines;
using PacketParser.Services;

namespace EntityCache.Assistence.Defualts
{
    public static class DefaultBuildingView
    {
        private static List<BuildingViewBussines> list = new List<BuildingViewBussines>();
        private static BuildingViewBussines SetDef(string name)
        {
            try
            {
                var reg = new BuildingViewBussines()
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

        public static List<BuildingViewBussines> SetDef()
        {
            try
            {
                list.Add(SetDef("آجرنما"));
                list.Add(SetDef("آلومینیوم"));
                list.Add(SetDef("رومی"));
                list.Add(SetDef("سرامیک"));
                list.Add(SetDef("سفال"));
                list.Add(SetDef("سنگ"));
                list.Add(SetDef("سیمان سفید"));
                list.Add(SetDef("شیشه"));
                list.Add(SetDef("متالیکا"));
                list.Add(SetDef("کامپوزیت"));
                list.Add(SetDef("گرانیت"));

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
