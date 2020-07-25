using System;
using System.Collections.Generic;
using EntityCache.Bussines;
using PacketParser.Services;

namespace EntityCache.Assistence.Defualts
{
    public static class DefaultPeopleGroup
    {
        private static List<PeopleGroupBussines> list = new List<PeopleGroupBussines>();
        private static PeopleGroupBussines SetDef(string name)
        {
            try
            {
                var reg = new PeopleGroupBussines()
                {
                    Name = name,
                    Guid = Guid.NewGuid(),
                    ParentGuid = Guid.Empty
                };
                return reg;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }

        public static List<PeopleGroupBussines> SetDef()
        {
            try
            {
                list.Add(SetDef("حقوقی دولتی"));
                list.Add(SetDef("حقوقی غیردولتی"));
                list.Add(SetDef("حقیقی"));
                list.Add(SetDef("مالکان"));
                list.Add(SetDef("متقاضیان"));
                list.Add(SetDef("واحدهای اقتصادی"));

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
