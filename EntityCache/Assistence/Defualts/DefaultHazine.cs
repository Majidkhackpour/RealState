using System;
using System.Collections.Generic;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Assistence.Defualts
{
    public static class DefaultHazine
    {
        private static List<HazineBussines> list = new List<HazineBussines>();
        private static HazineBussines SetDef(string name)
        {
            try
            {
                var state = new HazineBussines()
                {
                    Name = name,
                    Account = 0,
                    Guid = Guid.NewGuid()
                };
                return state;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }

        public static List<HazineBussines> SetDef()
        {
            try
            {
                list.Add(SetDef("کرایه حمل"));
                list.Add(SetDef("پورسانت"));
                list.Add(SetDef("کارمزد بانکی"));
                list.Add(SetDef("بهره پرداختی"));
                list.Add(SetDef("عوارض و مالیات"));
                list.Add(SetDef("دستمزد"));
                list.Add(SetDef("عیدی و پاداش"));
                list.Add(SetDef("هزینه اجاره"));
                list.Add(SetDef("پذیرایی"));
                list.Add(SetDef("کالای مصرفی (ملزومات)"));
                list.Add(SetDef("قبض آب"));
                list.Add(SetDef("قبض برق"));
                list.Add(SetDef("قبض گاز"));
                list.Add(SetDef("قبض تلفن"));

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
