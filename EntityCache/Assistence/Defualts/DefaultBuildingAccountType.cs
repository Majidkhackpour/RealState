using System;
using System.Collections.Generic;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Assistence.Defualts
{
    public static class DefaultBuildingAccountType
    {
        private static List<BuildingAccountTypeBussines> list = new List<BuildingAccountTypeBussines>();
        private static BuildingAccountTypeBussines SetDef(string name)
        {
            try
            {
                var reg = new BuildingAccountTypeBussines()
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
        public static List<BuildingAccountTypeBussines> SetDef()
        {
            try
            {
                list.Add(SetDef("انبار"));
                list.Add(SetDef("دامداری"));
                list.Add(SetDef("دفترکار"));
                list.Add(SetDef("زراعی"));
                list.Add(SetDef("فرهنگی و آموزشی"));
                list.Add(SetDef("مرغداری"));
                list.Add(SetDef("مسکونی"));
                list.Add(SetDef("مشاغل تجاری"));
                list.Add(SetDef("مطب"));
                list.Add(SetDef("ورزشی"));
                list.Add(SetDef("کارگاه"));
                

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
