using System;
using System.Collections.Generic;
using EntityCache.Bussines;
using Services;
using Services.DefaultCoding;

namespace EntityCache.Assistence.Defualts
{
    public class DefaultTafsil
    {
        private static List<TafsilBussines> list = new List<TafsilBussines>();
        private static TafsilBussines SetDef(string name, string code, Guid guid, HesabType hType)
        {
            try
            {
                var state = new TafsilBussines()
                {
                    Guid = guid,
                    Name = name,
                    Code = code,
                    Account = 0,
                    Description = "",
                    isSystem = true,
                    HesabType = hType,
                    AccountFirst = 0
                };
                return state;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
        public static List<TafsilBussines> SetDef()
        {
            try
            {
                list.Add(SetDef("حساب بانکی مرکزی", "1010101", ParentDefaults.TafsilCoding.CLSTafsil1010101, HesabType.Bank));
                list.Add(SetDef("مشتری عمومی", "1030401", ParentDefaults.TafsilCoding.CLSTafsil1030401, HesabType.Customer));
                list.Add(SetDef("صندوق مرکزی", "1010202", ParentDefaults.TafsilCoding.CLSTafsil1010202, HesabType.Sandouq));
                list.Add(SetDef("وجوه در راه حواله شده از شعب", "1010501", ParentDefaults.TafsilCoding.CLSTafsil1010501, HesabType.Tafsil));
                list.Add(SetDef("وجوه در راه حواله شده از اشخاص", "1010502", ParentDefaults.TafsilCoding.CLSTafsil1010502, HesabType.Tafsil));
                list.Add(SetDef("سپرده سرمایه گذاری کوتاه مدت", "1020101", ParentDefaults.TafsilCoding.CLSTafsil1020101, HesabType.Tafsil));
                list.Add(SetDef("سرمایه گذاری در سهام شرکت های پذیرفته شده در بورس", "1020201", ParentDefaults.TafsilCoding.CLSTafsil1020201, HesabType.Tafsil));
                list.Add(SetDef("سرمایه گذاری در سهام سایر شرکت ها", "1020202", ParentDefaults.TafsilCoding.CLSTafsil1020202, HesabType.Tafsil));
                list.Add(SetDef("سرمایه گذاری در اوراق مشارکت پذیرفته شده در بورس", "1020301", ParentDefaults.TafsilCoding.CLSTafsil1020301, HesabType.Tafsil));
                list.Add(SetDef("سرمایه گذاری در اوراق مشارکت سایر شرکت ها", "1020302", ParentDefaults.TafsilCoding.CLSTafsil1020302, HesabType.Tafsil));
                list.Add(SetDef("موجودی مواد اولیه در راه", "1050601", ParentDefaults.TafsilCoding.CLSTafsil1050601, HesabType.Tafsil));
                list.Add(SetDef("موجودی کالای در راه", "1050602", ParentDefaults.TafsilCoding.CLSTafsil1050602, HesabType.Tafsil));
                list.Add(SetDef("پیش پرداخت خرید مواد اولیه", "1060101", ParentDefaults.TafsilCoding.CLSTafsil1060101, HesabType.Tafsil));
                list.Add(SetDef("پیش پرداخت خرید کالا", "1060102", ParentDefaults.TafsilCoding.CLSTafsil1060102, HesabType.Tafsil));
                list.Add(SetDef("پیش پرداخت هزینه های جاری", "1060201", ParentDefaults.TafsilCoding.CLSTafsil1060201, HesabType.Tafsil));
                list.Add(SetDef("پیش پرداخت حسابرسی", "1060202", ParentDefaults.TafsilCoding.CLSTafsil1060202, HesabType.Tafsil));
                list.Add(SetDef("پیش پرداخت اجاره", "1060203", ParentDefaults.TafsilCoding.CLSTafsil1060203, HesabType.Tafsil));
                list.Add(SetDef("پیش پرداخت دارایی ها", "1060301", ParentDefaults.TafsilCoding.CLSTafsil1060301, HesabType.Tafsil));
                list.Add(SetDef("پیش پرداخت بیمه تامین اجتماعی", "1060302", ParentDefaults.TafsilCoding.CLSTafsil1060302, HesabType.Tafsil));
                list.Add(SetDef("پیش پرداخت مالیات", "1060401", ParentDefaults.TafsilCoding.CLSTafsil1060401, HesabType.Tafsil));
                list.Add(SetDef("پیش پرداخت به پیمانکاران", "1060501", ParentDefaults.TafsilCoding.CLSTafsil1060501, HesabType.Tafsil));
                list.Add(SetDef("پیش پرداخت هزینه های توسعه و تحقیق", "1060601", ParentDefaults.TafsilCoding.CLSTafsil1060601, HesabType.Tafsil));
                list.Add(SetDef("پیش پرداخت هزینه های سود و کارمزد وام", "1060602", ParentDefaults.TafsilCoding.CLSTafsil1060602, HesabType.Tafsil));
                list.Add(SetDef("بهای اصلی سفارش خارجی", "1060701", ParentDefaults.TafsilCoding.CLSTafsil1060701, HesabType.Tafsil));
                list.Add(SetDef("هزینه های ثبت سفارش", "1060702", ParentDefaults.TafsilCoding.CLSTafsil1060702, HesabType.Tafsil));
                list.Add(SetDef("هزینه های بانکی سفارش", "1060704", ParentDefaults.TafsilCoding.CLSTafsil1060704, HesabType.Tafsil));
                list.Add(SetDef("هزینه های گمرکی سفارش", "1060705", ParentDefaults.TafsilCoding.CLSTafsil1060705, HesabType.Tafsil));
                list.Add(SetDef("حقوق و عوارض بندری سفارش", "1060706", ParentDefaults.TafsilCoding.CLSTafsil1060706, HesabType.Tafsil));
                list.Add(SetDef("هزینه های بازرسی سفارش", "1060707", ParentDefaults.TafsilCoding.CLSTafsil1060707, HesabType.Hazine));
                list.Add(SetDef("هزینه حمل سفارش", "1060708", ParentDefaults.TafsilCoding.CLSTafsil1060708, HesabType.Hazine));
                list.Add(SetDef("هزینه حق العمل ترخیص سفارش", "1060709", ParentDefaults.TafsilCoding.CLSTafsil1060709, HesabType.Hazine));
                list.Add(SetDef("حق تالیف", "2040101", ParentDefaults.TafsilCoding.CLSTafsil2040101, HesabType.Hazine));
                list.Add(SetDef("حق اختراع", "2040102", ParentDefaults.TafsilCoding.CLSTafsil2040102, HesabType.Hazine));
                list.Add(SetDef("حق انحصاری تولید", "2040103", ParentDefaults.TafsilCoding.CLSTafsil2040103, HesabType.Hazine));
                list.Add(SetDef("حق انحصاری توزیع", "2040104", ParentDefaults.TafsilCoding.CLSTafsil2040104, HesabType.Hazine));
                list.Add(SetDef("سرقفلی محل کسب", "2040301", ParentDefaults.TafsilCoding.CLSTafsil2040301, HesabType.Hazine));
                list.Add(SetDef("نرم افزارهای حسابداری و مالی", "2040401", ParentDefaults.TafsilCoding.CLSTafsil2040401, HesabType.Hazine));
                list.Add(SetDef("نرم افزارهای فنی", "2040402", ParentDefaults.TafsilCoding.CLSTafsil2040402, HesabType.Hazine));
                list.Add(SetDef("نرم افزارهای اداری", "2040403", ParentDefaults.TafsilCoding.CLSTafsil2040403, HesabType.Hazine));
                list.Add(SetDef("سپرده های بانکی بلندمدت", "2050301", ParentDefaults.TafsilCoding.CLSTafsil2050301, HesabType.Hazine));
                list.Add(SetDef("وام های اعطایی بلندمدت", "2050401", ParentDefaults.TafsilCoding.CLSTafsil2050401, HesabType.Hazine));
                list.Add(SetDef("مالیات بر سود سهام", "3020301", ParentDefaults.TafsilCoding.CLSTafsil3020301, HesabType.Hazine));
                list.Add(SetDef("مالیات بر حقوق کارکنان", "3020302", ParentDefaults.TafsilCoding.CLSTafsil3020302, HesabType.Hazine));
                list.Add(SetDef("مالیات بر درآمد شرکت", "3020401", ParentDefaults.TafsilCoding.CLSTafsil3020401, HesabType.Hazine));
                list.Add(SetDef("مالیات بر ارزش افزوده", "3020305", ParentDefaults.TafsilCoding.CLSTafsil3020305, HesabType.Hazine));
                list.Add(SetDef("عوارض شهرداری", "3020306", ParentDefaults.TafsilCoding.CLSTafsil3020306, HesabType.Hazine));
                list.Add(SetDef("حق بیمه سهم کارفرما", "3020501", ParentDefaults.TafsilCoding.CLSTafsil3020501, HesabType.Hazine));
                list.Add(SetDef("حق بیمه سهم کارکنان", "3020502", ParentDefaults.TafsilCoding.CLSTafsil3020502, HesabType.Hazine));
                list.Add(SetDef("بیمه عمر و حوادث", "3020503", ParentDefaults.TafsilCoding.CLSTafsil3020503, HesabType.Hazine));
                list.Add(SetDef("حقوق و دستمزد پرداختنی", "3020601", ParentDefaults.TafsilCoding.CLSTafsil3020601, HesabType.Hazine));
                list.Add(SetDef("روند حقوق", "3020602", ParentDefaults.TafsilCoding.CLSTafsil3020602, HesabType.Hazine));
                list.Add(SetDef("عیدی و پاداش پرداختنی", "3020603", ParentDefaults.TafsilCoding.CLSTafsil3020603, HesabType.Hazine));
                list.Add(SetDef("حساب های پرداختنی به شرکت های گروه", "3021201", ParentDefaults.TafsilCoding.CLSTafsil3021201, HesabType.Tafsil));
                list.Add(SetDef("حساب های پرداختنی به اشخاص", "3021202", ParentDefaults.TafsilCoding.CLSTafsil3021202, HesabType.Tafsil));
                list.Add(SetDef("حساب های پرداختنی به پیمانکاران", "3021203", ParentDefaults.TafsilCoding.CLSTafsil3021203, HesabType.Tafsil));
                list.Add(SetDef("سرمایه سهام ممتاز", "5010101", ParentDefaults.TafsilCoding.CLSTafsil5010101, HesabType.Tafsil));
                list.Add(SetDef("سرمایه سهام عادی", "5010102", ParentDefaults.TafsilCoding.CLSTafsil5010102, HesabType.Tafsil));
                list.Add(SetDef("سرمایه صرف ممتاز", "5010201", ParentDefaults.TafsilCoding.CLSTafsil5010201, HesabType.Tafsil));
                list.Add(SetDef("سرمایه صرف عادی", "5010202", ParentDefaults.TafsilCoding.CLSTafsil5010202, HesabType.Tafsil));
                list.Add(SetDef("تعهد صاحبان سهام", "5010302", ParentDefaults.TafsilCoding.CLSTafsil5010302, HesabType.Tafsil));
                list.Add(SetDef("سرمایه اهدایی از دولت", "5010401", ParentDefaults.TafsilCoding.CLSTafsil5010401, HesabType.Tafsil));
                list.Add(SetDef("سهام خزانه", "5010601", ParentDefaults.TafsilCoding.CLSTafsil5010601, HesabType.Tafsil));
                list.Add(SetDef("سرمایه پرداخت شده", "5011001", ParentDefaults.TafsilCoding.CLSTafsil5011001, HesabType.Tafsil));
                list.Add(SetDef("تخفیفات نقدی فروش", "6010301", ParentDefaults.TafsilCoding.CLSTafsil6010301, HesabType.Tafsil));
                list.Add(SetDef("درآمدناخالص", "6020101", ParentDefaults.TafsilCoding.CLSTafsil6020101, HesabType.Tafsil));
                list.Add(SetDef("بهای تمام شده مواد مستقیم", "7010101", ParentDefaults.TafsilCoding.CLSTafsil7010101, HesabType.Tafsil));
                list.Add(SetDef("بهای تمام شده دستمزد مستقیم", "7010102", ParentDefaults.TafsilCoding.CLSTafsil7010102, HesabType.Tafsil));
                list.Add(SetDef("بهای تمام شده سربار", "7010103", ParentDefaults.TafsilCoding.CLSTafsil7010103, HesabType.Tafsil));
                list.Add(SetDef("حقوق پایه", "8010101", ParentDefaults.TafsilCoding.CLSTafsil8010101, HesabType.Hazine));
                list.Add(SetDef("اضافه کار", "8010102", ParentDefaults.TafsilCoding.CLSTafsil8010102, HesabType.Hazine));
                list.Add(SetDef("حق جذب", "8010103", ParentDefaults.TafsilCoding.CLSTafsil8010103, HesabType.Hazine));
                list.Add(SetDef("فوق العاده مسکن و خواروبار", "8010104", ParentDefaults.TafsilCoding.CLSTafsil8010104, HesabType.Hazine));
                list.Add(SetDef("حق اولاد", "8010105", ParentDefaults.TafsilCoding.CLSTafsil8010105, HesabType.Hazine));
                list.Add(SetDef("بن کارگری", "8010106", ParentDefaults.TafsilCoding.CLSTafsil8010106, HesabType.Hazine));
                list.Add(SetDef("سهم صندوق کارآموزی", "8010107", ParentDefaults.TafsilCoding.CLSTafsil8010107, HesabType.Hazine));
                list.Add(SetDef("بازخرید سنوات خدمت کارکنان", "8010108", ParentDefaults.TafsilCoding.CLSTafsil8010108, HesabType.Hazine));
                list.Add(SetDef("حق سرپرستی", "8010109", ParentDefaults.TafsilCoding.CLSTafsil8010109, HesabType.Hazine));
                list.Add(SetDef("حق سختی کار", "8010110", ParentDefaults.TafsilCoding.CLSTafsil8010110, HesabType.Hazine));
                list.Add(SetDef("ایاب و ذهاب", "8010111", ParentDefaults.TafsilCoding.CLSTafsil8010111, HesabType.Hazine));
                list.Add(SetDef("رستوران", "8010112", ParentDefaults.TafsilCoding.CLSTafsil8010112, HesabType.Hazine));
                list.Add(SetDef("حق بدی آب و هوا", "8010113", ParentDefaults.TafsilCoding.CLSTafsil8010113, HesabType.Hazine));
                list.Add(SetDef("حق تضمین", "8010114", ParentDefaults.TafsilCoding.CLSTafsil8010114, HesabType.Hazine));
                list.Add(SetDef("حق شیفت و شب کاری", "8010115", ParentDefaults.TafsilCoding.CLSTafsil8010115, HesabType.Hazine));
                list.Add(SetDef("حق نوبت کاری", "8010116", ParentDefaults.TafsilCoding.CLSTafsil8010116, HesabType.Hazine));
                list.Add(SetDef("مرخصی استفاده نشده", "8010205", ParentDefaults.TafsilCoding.CLSTafsil8010205, HesabType.Hazine));
                list.Add(SetDef("حق سفر مربوط به شغل", "8010206", ParentDefaults.TafsilCoding.CLSTafsil8010206, HesabType.Hazine));
                list.Add(SetDef("کمک های غیرنقدی", "8010207", ParentDefaults.TafsilCoding.CLSTafsil8010207, HesabType.Hazine));
                list.Add(SetDef("آموزش", "8010209", ParentDefaults.TafsilCoding.CLSTafsil8010209, HesabType.Hazine));
                list.Add(SetDef("بهداشت و درمان", "8010210", ParentDefaults.TafsilCoding.CLSTafsil8010210, HesabType.Hazine));
                list.Add(SetDef("خسارت اخراج", "8010211", ParentDefaults.TafsilCoding.CLSTafsil8010211, HesabType.Hazine));
                list.Add(SetDef("دستمزد کارکنان روزمزد", "8010401", ParentDefaults.TafsilCoding.CLSTafsil8010401, HesabType.Hazine));
                list.Add(SetDef("هزینه تعمیر و نگهداری ساختمان", "8020101", ParentDefaults.TafsilCoding.CLSTafsil8020101, HesabType.Hazine));
                list.Add(SetDef("هزینه تعمیر و نگهداری تاسیسات", "8020102", ParentDefaults.TafsilCoding.CLSTafsil8020102, HesabType.Hazine));
                list.Add(SetDef("هزینه تعمیر و نگهداری ماشین آلات و تجهیزات", "8020103", ParentDefaults.TafsilCoding.CLSTafsil8020103, HesabType.Hazine));
                list.Add(SetDef("هزینه تعمیر و نگهداری ابزارآلات", "8020104", ParentDefaults.TafsilCoding.CLSTafsil8020104, HesabType.Hazine));
                list.Add(SetDef("هزینه گاز", "8020301", ParentDefaults.TafsilCoding.CLSTafsil8020301, HesabType.Hazine));
                list.Add(SetDef("هزینه تلفن", "8020302", ParentDefaults.TafsilCoding.CLSTafsil8020302, HesabType.Hazine));
                list.Add(SetDef("هزینه برق", "8020303", ParentDefaults.TafsilCoding.CLSTafsil8020303, HesabType.Hazine));
                list.Add(SetDef("هزینه آب", "8020304", ParentDefaults.TafsilCoding.CLSTafsil8020304, HesabType.Hazine));
                list.Add(SetDef("هزینه حق الزحمه مشاوره", "8021101", ParentDefaults.TafsilCoding.CLSTafsil8021101, HesabType.Hazine));
                list.Add(SetDef("هزینه حق الزحمه حسابرسی", "8021102", ParentDefaults.TafsilCoding.CLSTafsil8021102, HesabType.Hazine));
                list.Add(SetDef("هزینه حق الزحمه وکالت", "8021103", ParentDefaults.TafsilCoding.CLSTafsil8021103, HesabType.Hazine));
                list.Add(SetDef("حق عضویت", "8021105", ParentDefaults.TafsilCoding.CLSTafsil8021105, HesabType.Hazine));
                list.Add(SetDef("هزینه کتب و نشریات", "8021106", ParentDefaults.TafsilCoding.CLSTafsil8021106, HesabType.Hazine));
                list.Add(SetDef("هزینه کمک و اعانات", "8020108", ParentDefaults.TafsilCoding.CLSTafsil8020108, HesabType.Hazine));
                list.Add(SetDef("هزینه پذیرایی و تشریفات", "8021109", ParentDefaults.TafsilCoding.CLSTafsil8021109, HesabType.Hazine));
                list.Add(SetDef("حق حضور اعضای هیئت مدیره", "8021110", ParentDefaults.TafsilCoding.CLSTafsil8021110, HesabType.Hazine));
                list.Add(SetDef("هزینه کارمزد خدمات بانکی", "8021111", ParentDefaults.TafsilCoding.CLSTafsil8021111, HesabType.Hazine));
                list.Add(SetDef("هزینه آگهی و تبلیغات", "8021201", ParentDefaults.TafsilCoding.CLSTafsil8021201, HesabType.Hazine));
                list.Add(SetDef("هزینه شرکت در مناقصه", "8021202", ParentDefaults.TafsilCoding.CLSTafsil8021202, HesabType.Hazine));
                list.Add(SetDef("هزینه شرکت در مزایده", "8021203", ParentDefaults.TafsilCoding.CLSTafsil8021203, HesabType.Hazine));
                list.Add(SetDef("هزینه ارسال نمونه", "8021204", ParentDefaults.TafsilCoding.CLSTafsil8021204, HesabType.Hazine));
                list.Add(SetDef("هزینه های نمایشگاه", "8021206", ParentDefaults.TafsilCoding.CLSTafsil8021206, HesabType.Hazine));
                list.Add(SetDef("هزینه بازاریابی و پورسانت", "8021207", ParentDefaults.TafsilCoding.CLSTafsil8021207, HesabType.Hazine));
                list.Add(SetDef("هزینه حمل کالای فروش رفته", "8021208", ParentDefaults.TafsilCoding.CLSTafsil8021208, HesabType.Hazine));
                list.Add(SetDef("هزینه انبارداری", "8021209", ParentDefaults.TafsilCoding.CLSTafsil8021209, HesabType.Hazine));
                list.Add(SetDef("هزینه های اداری و عمومی", "8021210", ParentDefaults.TafsilCoding.CLSTafsil8021210, HesabType.Hazine));
                list.Add(SetDef("ضمانت نامه بانکی", "9010106", ParentDefaults.TafsilCoding.CLSTafsil9010106, HesabType.Tafsil));
                list.Add(SetDef("کالای امانی ما نزد دیگران", "9010108", ParentDefaults.TafsilCoding.CLSTafsil9010108, HesabType.Tafsil));
                list.Add(SetDef("اسناد تضمینی تنخواه", "9010110", ParentDefaults.TafsilCoding.CLSTafsil9010110, HesabType.Tafsil));
                list.Add(SetDef("کالای امانی دیگران نزد ما", "9010207", ParentDefaults.TafsilCoding.CLSTafsil9010207, HesabType.Tafsil));
                list.Add(SetDef("ضمانت نامه گمرکی", "9010209", ParentDefaults.TafsilCoding.CLSTafsil9010209, HesabType.Tafsil));

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
