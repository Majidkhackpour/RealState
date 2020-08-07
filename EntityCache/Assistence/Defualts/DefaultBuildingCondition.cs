using System;
using System.Collections.Generic;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Assistence.Defualts
{
    public static class DefaultBuildingCondition
    {
        private static List<BuildingConditionBussines> list = new List<BuildingConditionBussines>();
        private static BuildingConditionBussines SetDef(string name)
        {
            try
            {
                var reg = new BuildingConditionBussines()
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

        public static List<BuildingConditionBussines> SetDef()
        {
            try
            {
                list.Add(SetDef("اسکلت"));
                list.Add(SetDef("تخلیه"));
                list.Add(SetDef("در اجاره"));
                list.Add(SetDef("نیمه اسکلت"));
                list.Add(SetDef("کلنگی"));
                

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
