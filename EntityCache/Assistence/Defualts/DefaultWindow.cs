using System;
using System.Collections.Generic;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Assistence.Defualts
{
    public class DefaultWindow
    {
        private static List<BuildingWindowBussines> list = new List<BuildingWindowBussines>();
        private static BuildingWindowBussines SetDef(string name)
        {
            try
            {
                var reg = new BuildingWindowBussines()
                {
                    Name = name,
                    Guid = Guid.NewGuid()
                };
                return reg;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
        public static List<BuildingWindowBussines> SetDef()
        {
            try
            {
                list.Add(SetDef("چوبی"));
                list.Add(SetDef("آلومینیومی"));
                list.Add(SetDef("استیل"));
                list.Add(SetDef("آهنی"));
                list.Add(SetDef("فایبرگلاس"));
                list.Add(SetDef("UPVC"));
                list.Add(SetDef("رفلکس"));
                list.Add(SetDef("سکوریت"));

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
