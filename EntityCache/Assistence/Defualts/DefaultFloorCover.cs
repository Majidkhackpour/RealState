using System;
using System.Collections.Generic;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Assistence.Defualts
{
    public static class DefaultFloorCover
    {
        private static List<FloorCoverBussines> list = new List<FloorCoverBussines>();
        private static FloorCoverBussines SetDef(string name)
        {
            try
            {
                var reg = new FloorCoverBussines()
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

        public static List<FloorCoverBussines> SetDef()
        {
            try
            {
                list.Add(SetDef("سرامیک"));
                list.Add(SetDef("سنگ"));
                list.Add(SetDef("سیمان"));
                list.Add(SetDef("موزاییک"));
                list.Add(SetDef("موکت"));
                list.Add(SetDef("پارکت"));
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
