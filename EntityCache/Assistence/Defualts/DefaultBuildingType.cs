using System;
using System.Collections.Generic;
using EntityCache.Bussines;
using PacketParser.Services;

namespace EntityCache.Assistence.Defualts
{
    public static class DefaultBuildingType
    {
        private static List<BuildingTypeBussines> list = new List<BuildingTypeBussines>();
        private static BuildingTypeBussines SetDef(string name)
        {
            try
            {
                var reg = new BuildingTypeBussines()
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

        public static List<BuildingTypeBussines> SetDef()
        {
            try
            {
                list.Add(SetDef("آپارتمان"));
                list.Add(SetDef("انبار"));
                list.Add(SetDef("باغ"));
                list.Add(SetDef("تالار"));
                list.Add(SetDef("دامداری")); 
                list.Add(SetDef("زمین تجاری"));
                list.Add(SetDef("زمین مزروعی"));
                list.Add(SetDef("زمین مسکونی")); 
                list.Add(SetDef("سالن")); 
                list.Add(SetDef("سوئیت"));
                list.Add(SetDef("سوله")); 
                list.Add(SetDef("طبقه")); 
                list.Add(SetDef("مرغداری"));
                list.Add(SetDef("مسکونی"));
                list.Add(SetDef("تجاری")); 
                list.Add(SetDef("مغازه"));
                list.Add(SetDef("منزل مسکونی"));
                list.Add(SetDef("هتل"));
                list.Add(SetDef("ویلا"));
                list.Add(SetDef("کارخانه"));
                list.Add(SetDef("کارگاه"));
                list.Add(SetDef("گاراژ")); 

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
