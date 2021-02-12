using System;
using System.Collections.Generic;
using EntityCache.Bussines;
using Services;
using Services.DefaultCoding;

namespace EntityCache.Assistence.Defualts
{
    public class DefaultKol
    {
        private static List<KolBussines> list = new List<KolBussines>();
        private static KolBussines SetDef(string name, string code, Guid guid, EnHesabGroup groupGuid)
        {
            try
            {
                var state = new KolBussines()
                {
                    Guid = guid,
                    Name = name,
                    Code = code,
                    Account = 0,
                    HesabGroup = groupGuid
                };
                return state;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
        public static List<KolBussines> SetDef()
        {
            try
            {
                list.Add(SetDef("موجودی نقد و بانک", "101", ParentDefaults.KolCoding.ClsKol101, EnHesabGroup.CurrentAssets));
                list.Add(SetDef("سرمایه گذاری کوتاه مدت", "102", ParentDefaults.KolCoding.ClsKol102, EnHesabGroup.CurrentAssets));
                list.Add(SetDef("حساب ها و استاد دریافتنی تجاری", "103", ParentDefaults.KolCoding.ClsKol103, EnHesabGroup.CurrentAssets));
                list.Add(SetDef("سایر حساب ها و اسناد دریافتنی", "104", ParentDefaults.KolCoding.ClsKol104, EnHesabGroup.CurrentAssets));
                list.Add(SetDef("موجودی کالا و مواد", "105", ParentDefaults.KolCoding.ClsKol105, EnHesabGroup.CurrentAssets));
                list.Add(SetDef("سفارش و پیش پرداخت ها", "106", ParentDefaults.KolCoding.ClsKol106, EnHesabGroup.CurrentAssets));
                list.Add(SetDef("سپرده های ما نزد دیگران", "107", ParentDefaults.KolCoding.ClsKol107, EnHesabGroup.CurrentAssets));
                list.Add(SetDef("دارایی های ثابت مشهود", "201", ParentDefaults.KolCoding.ClsKol201, EnHesabGroup.NonCurrentAssets));
                list.Add(SetDef("استهلاک انباشته دارایی های ثابت مشهود", "202", ParentDefaults.KolCoding.ClsKol202, EnHesabGroup.NonCurrentAssets));
                list.Add(SetDef("دارایی های درجریان تکمیل", "203", ParentDefaults.KolCoding.ClsKol203, EnHesabGroup.NonCurrentAssets));
                list.Add(SetDef("دارایی های نامشهود", "204", ParentDefaults.KolCoding.ClsKol204, EnHesabGroup.NonCurrentAssets));
                list.Add(SetDef("سرمایه گذاری بلند مدت", "205", ParentDefaults.KolCoding.ClsKol205, EnHesabGroup.NonCurrentAssets));
                list.Add(SetDef("سایر دارایی های غیرجاری", "299", ParentDefaults.KolCoding.ClsKol299, EnHesabGroup.NonCurrentAssets));
                list.Add(SetDef("حساب ها و اسناد پرداختنی تجاری", "301", ParentDefaults.KolCoding.ClsKol301, EnHesabGroup.CurrentDebits));
                list.Add(SetDef("سایر حساب ها و اسناد پرداختنی", "302", ParentDefaults.KolCoding.ClsKol302, EnHesabGroup.CurrentDebits));
                list.Add(SetDef("سفارشات و پیش دریافت ها", "303", ParentDefaults.KolCoding.ClsKol303, EnHesabGroup.CurrentDebits));
                list.Add(SetDef("ذخیره مالیات", "304", ParentDefaults.KolCoding.ClsKol304, EnHesabGroup.CurrentDebits));
                list.Add(SetDef("سود سهام پرداختنی", "305", ParentDefaults.KolCoding.ClsKol305, EnHesabGroup.CurrentDebits));
                list.Add(SetDef("سپرده های پرداختنی", "306", ParentDefaults.KolCoding.ClsKol306, EnHesabGroup.CurrentDebits));
                list.Add(SetDef("تسهیلات و اعتبارات مالی دریافتنی کوتاه مدت", "307", ParentDefaults.KolCoding.ClsKol307, EnHesabGroup.CurrentDebits));
                list.Add(SetDef("ذخایر", "308", ParentDefaults.KolCoding.ClsKol308, EnHesabGroup.CurrentDebits));
                list.Add(SetDef("حساب ها و اسناد پرداختنی بلنذ مدت تجاری", "401", ParentDefaults.KolCoding.ClsKol401, EnHesabGroup.NonCurrentDebits));
                list.Add(SetDef("سایر حساب ها و اسناد پرداختنی بلند مدت", "402", ParentDefaults.KolCoding.ClsKol402, EnHesabGroup.NonCurrentDebits));
                list.Add(SetDef("تسهیلات و اعتبارات مالی دریافتنی بلند مدت", "403", ParentDefaults.KolCoding.ClsKol403, EnHesabGroup.NonCurrentDebits));
                list.Add(SetDef("ذخیره مزایای پایان خدمت کارکنان", "404", ParentDefaults.KolCoding.ClsKol404, EnHesabGroup.NonCurrentDebits));
                list.Add(SetDef("درآمدهای انتقالی به دوره های آتی", "405", ParentDefaults.KolCoding.ClsKol405, EnHesabGroup.NonCurrentDebits));
                list.Add(SetDef("سرمایه پرداخت شده", "501", ParentDefaults.KolCoding.ClsKol501, EnHesabGroup.HoghooghSahebaneSaham));
                list.Add(SetDef("اندوخته قانونی", "502", ParentDefaults.KolCoding.ClsKol502, EnHesabGroup.HoghooghSahebaneSaham));
                list.Add(SetDef("سایر اندوخته ها", "503", ParentDefaults.KolCoding.ClsKol503, EnHesabGroup.HoghooghSahebaneSaham));
                list.Add(SetDef("مازاد تجدید ارزیابی دارایی های ثابت مشهود", "504", ParentDefaults.KolCoding.ClsKol504, EnHesabGroup.HoghooghSahebaneSaham));
                list.Add(SetDef("سود(زیان) انباشته", "505", ParentDefaults.KolCoding.ClsKol505, EnHesabGroup.HoghooghSahebaneSaham));
                list.Add(SetDef("فروش", "601", ParentDefaults.KolCoding.ClsKol601, EnHesabGroup.Income));
                list.Add(SetDef("درآمد حاصل از ارائه خدمات", "602", ParentDefaults.KolCoding.ClsKol602, EnHesabGroup.Income));
                list.Add(SetDef("سایر درآمدهای عملیاتی", "603", ParentDefaults.KolCoding.ClsKol603, EnHesabGroup.Income));
                list.Add(SetDef("سایر درآمدهای غیرعملیاتی", "604", ParentDefaults.KolCoding.ClsKol604, EnHesabGroup.Income));
                list.Add(SetDef("بهای تمام شده کالای فروش رفته داخلی", "701", ParentDefaults.KolCoding.ClsKol701, EnHesabGroup.BahayeTamamShode));
                list.Add(SetDef("بهای تمام شده کالای فروش رفته خارجی", "702", ParentDefaults.KolCoding.ClsKol702, EnHesabGroup.BahayeTamamShode));
                list.Add(SetDef("بهای تمام شده خدمات ارائه شده", "703", ParentDefaults.KolCoding.ClsKol703, EnHesabGroup.BahayeTamamShode));
                list.Add(SetDef("هزینه حقوق و دستمزد کارکانن غیردولتی", "801", ParentDefaults.KolCoding.ClsKol801, EnHesabGroup.Hazine));
                list.Add(SetDef("هزینه های عملیاتی", "802", ParentDefaults.KolCoding.ClsKol802, EnHesabGroup.Hazine));
                list.Add(SetDef("سایر هزینه های عملیاتی", "803", ParentDefaults.KolCoding.ClsKol803, EnHesabGroup.Hazine));
                list.Add(SetDef("هزینه های مالی", "804", ParentDefaults.KolCoding.ClsKol804, EnHesabGroup.Hazine));
                list.Add(SetDef("هزینه های غیرعملیاتی", "805", ParentDefaults.KolCoding.ClsKol805, EnHesabGroup.Hazine));
                list.Add(SetDef("حساب های انتظامی", "901", ParentDefaults.KolCoding.ClsKol901, EnHesabGroup.OtherHesabs));
                list.Add(SetDef("طرف حساب های انتظامی", "902", ParentDefaults.KolCoding.ClsKol902, EnHesabGroup.OtherHesabs));
                list.Add(SetDef("تراز افتتاحیه", "903", ParentDefaults.KolCoding.ClsKol903, EnHesabGroup.OtherHesabs));
                list.Add(SetDef("تراز اختتامیه", "904", ParentDefaults.KolCoding.ClsKol904, EnHesabGroup.OtherHesabs));


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
