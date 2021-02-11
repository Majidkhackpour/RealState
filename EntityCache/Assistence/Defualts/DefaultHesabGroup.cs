using System;
using System.Collections.Generic;
using EntityCache.Bussines;
using Services;
using Services.DefaultCoding;

namespace EntityCache.Assistence.Defualts
{
    public class DefaultHesabGroup
    {
        private static List<HesabGroupBussines> list = new List<HesabGroupBussines>();
        private static HesabGroupBussines SetDef(string name, string code, Guid guid)
        {
            try
            {
                var state = new HesabGroupBussines()
                {
                    Guid = guid,
                    Name = name,
                    Code = code
                };
                return state;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
        public static List<HesabGroupBussines> SetDef()
        {
            try
            {
                list.Add(SetDef("دارایی های جاری", "1", ParentDefaults.HesabGroupGuids.CurrentAssets));
                list.Add(SetDef("دارایی های غیر جاری", "2", ParentDefaults.HesabGroupGuids.NonCurrentAssets));
                list.Add(SetDef("بدهی های جاری", "3", ParentDefaults.HesabGroupGuids.CurrentDebits));
                list.Add(SetDef("بدهی های غیرجاری", "4", ParentDefaults.HesabGroupGuids.NonCurrentDebits));
                list.Add(SetDef("حقوق صاحبان سهام", "5", ParentDefaults.HesabGroupGuids.HoghooghSahebaneSaham));
                list.Add(SetDef("درآمدها", "6", ParentDefaults.HesabGroupGuids.Income));
                list.Add(SetDef("بهای تمام شده کالا", "7", ParentDefaults.HesabGroupGuids.BahayeTamamShode));
                list.Add(SetDef("هزینه ها", "8", ParentDefaults.HesabGroupGuids.Hazine));
                list.Add(SetDef("سایر حساب ها", "9", ParentDefaults.HesabGroupGuids.OtherHesabs));

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
