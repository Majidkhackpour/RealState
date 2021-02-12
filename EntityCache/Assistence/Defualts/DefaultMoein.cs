using System;
using System.Collections.Generic;
using EntityCache.Bussines;
using Services;
using Services.DefaultCoding;

namespace EntityCache.Assistence.Defualts
{
    public class DefaultMoein
    {
        private static List<MoeinBussines> list = new List<MoeinBussines>();
        private static MoeinBussines SetDef(string name, string code, Guid guid, Guid kolGuid)
        {
            try
            {
                var state = new MoeinBussines()
                {
                    Name = name,
                    Account = 0,
                    Guid = guid,
                    Code = code,
                    KolGuid = kolGuid
                };
                return state;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
        public static List<MoeinBussines> SetDef()
        {
            try
            {
                list.Add(SetDef("موجودی نزد بانک ها", "10101", ParentDefaults.MoeinCoding.CLSMoein10101, ParentDefaults.KolCoding.ClsKol101));
                list.Add(SetDef("موجودی نزد صندوق ها", "10102", ParentDefaults.MoeinCoding.CLSMoein10102, ParentDefaults.KolCoding.ClsKol101));
                list.Add(SetDef("موجودی نزد تنخواه گردان", "10103", ParentDefaults.MoeinCoding.CLSMoein10103, ParentDefaults.KolCoding.ClsKol101));
                list.Add(SetDef("اسناد و اوراق بهادار نزد صندوق", "10104", ParentDefaults.MoeinCoding.CLSMoein10104, ParentDefaults.KolCoding.ClsKol101));
                list.Add(SetDef("وجوه در راه", "10105", ParentDefaults.MoeinCoding.CLSMoein10105, ParentDefaults.KolCoding.ClsKol101));
                list.Add(SetDef("موجودی واریزی نامه های ارزی", "10106", ParentDefaults.MoeinCoding.CLSMoein10106, ParentDefaults.KolCoding.ClsKol101));
                list.Add(SetDef("مسکوکات", "10107", ParentDefaults.MoeinCoding.CLSMoein10107, ParentDefaults.KolCoding.ClsKol101));
                list.Add(SetDef("سپرده سرمایه گذاری", "10201", ParentDefaults.MoeinCoding.CLSMoein10201, ParentDefaults.KolCoding.ClsKol102));
                list.Add(SetDef("سرمایه گذاری در سهام", "10202", ParentDefaults.MoeinCoding.CLSMoein10202, ParentDefaults.KolCoding.ClsKol102));
                list.Add(SetDef("سرمایه گذاری در اوراق مشارکت", "10203", ParentDefaults.MoeinCoding.CLSMoein10203, ParentDefaults.KolCoding.ClsKol102));
                list.Add(SetDef("اسناد دریافتنی تجاری درجریان وصول", "10301", ParentDefaults.MoeinCoding.CLSMoein10301, ParentDefaults.KolCoding.ClsKol103));
                list.Add(SetDef("اسناد دریافتنی تجاری نزد صندوق", "10302", ParentDefaults.MoeinCoding.CLSMoein10302, ParentDefaults.KolCoding.ClsKol103));
                list.Add(SetDef("اسناد دریافتنی تجاری واخواستی", "10303", ParentDefaults.MoeinCoding.CLSMoein10303, ParentDefaults.KolCoding.ClsKol103));
                list.Add(SetDef("حساب های دریافتنی تجاری", "10304", ParentDefaults.MoeinCoding.CLSMoein10304, ParentDefaults.KolCoding.ClsKol103));
                list.Add(SetDef("اسناد دریافتنی غیرتجاری در جریان وصول", "10401", ParentDefaults.MoeinCoding.CLSMoein10401, ParentDefaults.KolCoding.ClsKol104));
                list.Add(SetDef("اسناد دریافتنی غیرتجاری نزد صندوق", "10402", ParentDefaults.MoeinCoding.CLSMoein10402, ParentDefaults.KolCoding.ClsKol104));
                list.Add(SetDef("اسناد دریافتنی غیر تجاری واخواستی", "10403", ParentDefaults.MoeinCoding.CLSMoein10403, ParentDefaults.KolCoding.ClsKol104));
                list.Add(SetDef("حساب های دریافتنی غیر تجاری", "10404", ParentDefaults.MoeinCoding.CLSMoein10404, ParentDefaults.KolCoding.ClsKol104));
                list.Add(SetDef("مساعده کارکنان", "10405", ParentDefaults.MoeinCoding.CLSMoein10405, ParentDefaults.KolCoding.ClsKol104));
                list.Add(SetDef("وام ضروری کارکنان", "10406", ParentDefaults.MoeinCoding.CLSMoein10406, ParentDefaults.KolCoding.ClsKol104));
                list.Add(SetDef("حق العمل کاران", "10407", ParentDefaults.MoeinCoding.CLSMoein10407, ParentDefaults.KolCoding.ClsKol104));
                list.Add(SetDef("ترخیص کاران گمرکی", "10408", ParentDefaults.MoeinCoding.CLSMoein10408, ParentDefaults.KolCoding.ClsKol104));
                list.Add(SetDef("سپرده های موقت", "10409", ParentDefaults.MoeinCoding.CLSMoein10409, ParentDefaults.KolCoding.ClsKol104));
                list.Add(SetDef("سود سهام دریافتنی", "10410", ParentDefaults.MoeinCoding.CLSMoein10410, ParentDefaults.KolCoding.ClsKol104));
                list.Add(SetDef("طلب از شرکت های گروه", "10411", ParentDefaults.MoeinCoding.CLSMoein10411, ParentDefaults.KolCoding.ClsKol104));
                list.Add(SetDef("طلب از سایر اشخاص وابسته", "10412", ParentDefaults.MoeinCoding.CLSMoein10412, ParentDefaults.KolCoding.ClsKol104));
                list.Add(SetDef("خسارت قابل دریافت از بیمه", "10413", ParentDefaults.MoeinCoding.CLSMoein10413, ParentDefaults.KolCoding.ClsKol104));
                list.Add(SetDef("موجودی مواد اولیه", "10501", ParentDefaults.MoeinCoding.CLSMoein10501, ParentDefaults.KolCoding.ClsKol105));
                list.Add(SetDef("موجودی قطعات و لوازم یدکی", "10502", ParentDefaults.MoeinCoding.CLSMoein10502, ParentDefaults.KolCoding.ClsKol105));
                list.Add(SetDef("مواد کمکی و بسته بندی", "10503", ParentDefaults.MoeinCoding.CLSMoein10503, ParentDefaults.KolCoding.ClsKol105));
                list.Add(SetDef("کالای درجریان ساخت", "10504", ParentDefaults.MoeinCoding.CLSMoein10504, ParentDefaults.KolCoding.ClsKol105));
                list.Add(SetDef("کالای ساخته شده", "10505", ParentDefaults.MoeinCoding.CLSMoein10505, ParentDefaults.KolCoding.ClsKol105));
                list.Add(SetDef("موجودی در راه", "10506", ParentDefaults.MoeinCoding.CLSMoein10506, ParentDefaults.KolCoding.ClsKol105));
                list.Add(SetDef("کالای امانی ما نزد دیگران", "10507", ParentDefaults.MoeinCoding.CLSMoein10507, ParentDefaults.KolCoding.ClsKol105));
                list.Add(SetDef("موجودی اقلام راکد و ناباب", "10508", ParentDefaults.MoeinCoding.CLSMoein10508, ParentDefaults.KolCoding.ClsKol105));
                list.Add(SetDef("موجودی ضایعات مواد اولیه", "10509", ParentDefaults.MoeinCoding.CLSMoein10509, ParentDefaults.KolCoding.ClsKol105));
                list.Add(SetDef("موجودی ضایعات قطعاتو لوازم یدکی", "10510", ParentDefaults.MoeinCoding.CLSMoein10510, ParentDefaults.KolCoding.ClsKol105));
                list.Add(SetDef("انحراف نرخ مواد اولیه هنگام خرید", "10511", ParentDefaults.MoeinCoding.CLSMoein10511, ParentDefaults.KolCoding.ClsKol105));
                list.Add(SetDef("انحرافات کالای درجریان ساخت", "10512", ParentDefaults.MoeinCoding.CLSMoein10512, ParentDefaults.KolCoding.ClsKol105));
                list.Add(SetDef("سایر موجودی ها", "10513", ParentDefaults.MoeinCoding.CLSMoein10513, ParentDefaults.KolCoding.ClsKol105));
                list.Add(SetDef("پیش پرداخت خرید", "10601", ParentDefaults.MoeinCoding.CLSMoein10601, ParentDefaults.KolCoding.ClsKol106));
                list.Add(SetDef("پیش پرداخت خدمات", "10602", ParentDefaults.MoeinCoding.CLSMoein10602, ParentDefaults.KolCoding.ClsKol106));
                list.Add(SetDef("پیش پرداخت بیمه", "10603", ParentDefaults.MoeinCoding.CLSMoein10603, ParentDefaults.KolCoding.ClsKol106));
                list.Add(SetDef("پیش پرداخت مالیات", "10604", ParentDefaults.MoeinCoding.CLSMoein10604, ParentDefaults.KolCoding.ClsKol106));
                list.Add(SetDef("پیش پرداخت به پیمانکاران", "10605", ParentDefaults.MoeinCoding.CLSMoein10605, ParentDefaults.KolCoding.ClsKol106));
                list.Add(SetDef("سایر پیش پرداخت ها", "10606", ParentDefaults.MoeinCoding.CLSMoein10606, ParentDefaults.KolCoding.ClsKol106));
                list.Add(SetDef("سفارشات مواد اولیه", "10607", ParentDefaults.MoeinCoding.CLSMoein10607, ParentDefaults.KolCoding.ClsKol106));
                list.Add(SetDef("سفارشات کالا", "10608", ParentDefaults.MoeinCoding.CLSMoein10608, ParentDefaults.KolCoding.ClsKol106));
                list.Add(SetDef("سفارشات قطعات و لوازم یدکی", "10609", ParentDefaults.MoeinCoding.CLSMoein10609, ParentDefaults.KolCoding.ClsKol106));
                list.Add(SetDef("سفارشات ماشین آلات", "10610", ParentDefaults.MoeinCoding.CLSMoein10610, ParentDefaults.KolCoding.ClsKol106));
                list.Add(SetDef("موجودی تمبر و سفته", "10611", ParentDefaults.MoeinCoding.CLSMoein10611, ParentDefaults.KolCoding.ClsKol106));
                list.Add(SetDef("هزینه های قبل از گشایش اعتبار سفارش", "10612", ParentDefaults.MoeinCoding.CLSMoein10612, ParentDefaults.KolCoding.ClsKol106));
                list.Add(SetDef("سپرده بیمه", "10701", ParentDefaults.MoeinCoding.CLSMoein10701, ParentDefaults.KolCoding.ClsKol107));
                list.Add(SetDef("سپرده حسن انجام کار", "10702", ParentDefaults.MoeinCoding.CLSMoein10702, ParentDefaults.KolCoding.ClsKol107));
                list.Add(SetDef("سپرده حسن اجرای تعهدات", "10703", ParentDefaults.MoeinCoding.CLSMoein10703, ParentDefaults.KolCoding.ClsKol107));
                list.Add(SetDef("سپرده شرکت در مناقصات", "10704", ParentDefaults.MoeinCoding.CLSMoein10704, ParentDefaults.KolCoding.ClsKol107));
                list.Add(SetDef("سپرده شرکت در مزایده", "10705", ParentDefaults.MoeinCoding.CLSMoein10705, ParentDefaults.KolCoding.ClsKol107));
                list.Add(SetDef("سپرده نزد بانک ها", "10706", ParentDefaults.MoeinCoding.CLSMoein10706, ParentDefaults.KolCoding.ClsKol107));
                list.Add(SetDef("سپرده های گمرکی", "10707", ParentDefaults.MoeinCoding.CLSMoein10707, ParentDefaults.KolCoding.ClsKol107));
                list.Add(SetDef("زمین", "20101", ParentDefaults.MoeinCoding.CLSMoein20101, ParentDefaults.KolCoding.ClsKol201));
                list.Add(SetDef("ساختمان", "20102", ParentDefaults.MoeinCoding.CLSMoein20102, ParentDefaults.KolCoding.ClsKol201));
                list.Add(SetDef("تاسیسات", "20103", ParentDefaults.MoeinCoding.CLSMoein20103, ParentDefaults.KolCoding.ClsKol201));
                list.Add(SetDef("ماشین آلات و تجهیزات", "20104", ParentDefaults.MoeinCoding.CLSMoein20104, ParentDefaults.KolCoding.ClsKol201));
                list.Add(SetDef("ابزارآلات", "20105", ParentDefaults.MoeinCoding.CLSMoein20105, ParentDefaults.KolCoding.ClsKol201));
                list.Add(SetDef("وسائط نقلیه", "20106", ParentDefaults.MoeinCoding.CLSMoein20106, ParentDefaults.KolCoding.ClsKol201));
                list.Add(SetDef("اثاثیه و منصوبات", "20107", ParentDefaults.MoeinCoding.CLSMoein20107, ParentDefaults.KolCoding.ClsKol201));
                list.Add(SetDef("قالب ها", "20108", ParentDefaults.MoeinCoding.CLSMoein20108, ParentDefaults.KolCoding.ClsKol201));
                list.Add(SetDef("لوازم آزمایشگاهی", "20109", ParentDefaults.MoeinCoding.CLSMoein20109, ParentDefaults.KolCoding.ClsKol201));
                list.Add(SetDef("دارایی های سرمایه ای موجود در انبار", "20110", ParentDefaults.MoeinCoding.CLSMoein20110, ParentDefaults.KolCoding.ClsKol201));
                list.Add(SetDef("ساختمان", "20202", ParentDefaults.MoeinCoding.CLSMoein20202, ParentDefaults.KolCoding.ClsKol202));
                list.Add(SetDef("تاسیسات", "20203", ParentDefaults.MoeinCoding.CLSMoein20203, ParentDefaults.KolCoding.ClsKol202));
                list.Add(SetDef("ماشین آلات و تجهیزات", "20204", ParentDefaults.MoeinCoding.CLSMoein20204, ParentDefaults.KolCoding.ClsKol202));
                list.Add(SetDef("ابزارآلات", "20205", ParentDefaults.MoeinCoding.CLSMoein20205, ParentDefaults.KolCoding.ClsKol202));
                list.Add(SetDef("وسائط نقلیه", "20206", ParentDefaults.MoeinCoding.CLSMoein20206, ParentDefaults.KolCoding.ClsKol202));
                list.Add(SetDef("اثاثیه و منصوبات", "20207", ParentDefaults.MoeinCoding.CLSMoein20207, ParentDefaults.KolCoding.ClsKol202));
                list.Add(SetDef("قالب ها", "20208", ParentDefaults.MoeinCoding.CLSMoein20208, ParentDefaults.KolCoding.ClsKol202));
                list.Add(SetDef("لوازم آزمایشگاهی", "20209", ParentDefaults.MoeinCoding.CLSMoein20209, ParentDefaults.KolCoding.ClsKol202));
                list.Add(SetDef("ساختمان در جریان تکمیل", "20301", ParentDefaults.MoeinCoding.CLSMoein20301, ParentDefaults.KolCoding.ClsKol203));
                list.Add(SetDef("تاسیسات در جریان تکمیل", "20302", ParentDefaults.MoeinCoding.CLSMoein20302, ParentDefaults.KolCoding.ClsKol203));
                list.Add(SetDef("ماشین آلات در جریان تکمیل", "20303", ParentDefaults.MoeinCoding.CLSMoein20303, ParentDefaults.KolCoding.ClsKol203));
                list.Add(SetDef("ابزارآلات در جریان تکمیل", "20304", ParentDefaults.MoeinCoding.CLSMoein20304, ParentDefaults.KolCoding.ClsKol203));
                list.Add(SetDef("قالب های در جریان تکمیل", "20305", ParentDefaults.MoeinCoding.CLSMoein20305, ParentDefaults.KolCoding.ClsKol203));
                list.Add(SetDef("حق الامتیاز ها", "20401", ParentDefaults.MoeinCoding.CLSMoein20401, ParentDefaults.KolCoding.ClsKol204));
                list.Add(SetDef("حق استفاده از خدمات عمومی", "20402", ParentDefaults.MoeinCoding.CLSMoein20402, ParentDefaults.KolCoding.ClsKol204));
                list.Add(SetDef("سرقفلی محل کسب", "20403", ParentDefaults.MoeinCoding.CLSMoein20403, ParentDefaults.KolCoding.ClsKol204));
                list.Add(SetDef("نرم افزارها", "20404", ParentDefaults.MoeinCoding.CLSMoein20404, ParentDefaults.KolCoding.ClsKol204));
                list.Add(SetDef("سیستم ها و روش ها", "20405", ParentDefaults.MoeinCoding.CLSMoein20405, ParentDefaults.KolCoding.ClsKol204));
                list.Add(SetDef("سایر دارایی های نامشهود", "20406", ParentDefaults.MoeinCoding.CLSMoein20406, ParentDefaults.KolCoding.ClsKol204));
                list.Add(SetDef("سرمایه گذاری در سهام شرکت ها", "20501", ParentDefaults.MoeinCoding.CLSMoein20501, ParentDefaults.KolCoding.ClsKol205));
                list.Add(SetDef("سرمایه گذاری در اوراق مشارکت", "20502", ParentDefaults.MoeinCoding.CLSMoein20502, ParentDefaults.KolCoding.ClsKol205));
                list.Add(SetDef("سپرده های بانکی", "20503", ParentDefaults.MoeinCoding.CLSMoein20503, ParentDefaults.KolCoding.ClsKol205));
                list.Add(SetDef("وام های اعطایی", "20504", ParentDefaults.MoeinCoding.CLSMoein20504, ParentDefaults.KolCoding.ClsKol205));
                list.Add(SetDef("مخارج انتقالی به دوره های آتی", "20601", ParentDefaults.MoeinCoding.CLSMoein20601, ParentDefaults.KolCoding.ClsKol299));
                list.Add(SetDef("وجه نقد مسدود شده نزد بانک", "20602", ParentDefaults.MoeinCoding.CLSMoein20602, ParentDefaults.KolCoding.ClsKol299));
                list.Add(SetDef("وجه نقد کنار گذاشته شده برای هدف مشخص", "20603", ParentDefaults.MoeinCoding.CLSMoein20603, ParentDefaults.KolCoding.ClsKol299));
                list.Add(SetDef("اسناد دریافتنی بلندمدت", "20604", ParentDefaults.MoeinCoding.CLSMoein20604, ParentDefaults.KolCoding.ClsKol299));
                list.Add(SetDef("حصه بلندمدت وام کارکنان", "20605", ParentDefaults.MoeinCoding.CLSMoein20605, ParentDefaults.KolCoding.ClsKol299));
                list.Add(SetDef("اسناد پرداختنی تجاری", "30101", ParentDefaults.MoeinCoding.CLSMoein30101, ParentDefaults.KolCoding.ClsKol301));
                list.Add(SetDef("معلق خرید", "30102", ParentDefaults.MoeinCoding.CLSMoein30102, ParentDefaults.KolCoding.ClsKol301));
                list.Add(SetDef("حساب های پرداختنی تجاری", "30103", ParentDefaults.MoeinCoding.CLSMoein30103, ParentDefaults.KolCoding.ClsKol301));
                list.Add(SetDef("اسناد پرداختنی غیرتجاری", "30201", ParentDefaults.MoeinCoding.CLSMoein30201, ParentDefaults.KolCoding.ClsKol302));
                list.Add(SetDef("حساب های پرداختنی غیر تجاری", "30202", ParentDefaults.MoeinCoding.CLSMoein30202, ParentDefaults.KolCoding.ClsKol302));
                list.Add(SetDef("مالیات های تکمیلی پرداختنی", "30203", ParentDefaults.MoeinCoding.CLSMoein30203, ParentDefaults.KolCoding.ClsKol302));
                list.Add(SetDef("مالیات بر درآمد شرکت پرداختنی", "30204", ParentDefaults.MoeinCoding.CLSMoein30204, ParentDefaults.KolCoding.ClsKol302));
                list.Add(SetDef("حق بیمه پرداختنی", "30205", ParentDefaults.MoeinCoding.CLSMoein30205, ParentDefaults.KolCoding.ClsKol302));
                list.Add(SetDef("حقوق و دستمزد پرداختنی", "30206", ParentDefaults.MoeinCoding.CLSMoein30206, ParentDefaults.KolCoding.ClsKol302));
                list.Add(SetDef("عوارض شهرداری", "30207", ParentDefaults.MoeinCoding.CLSMoein30207, ParentDefaults.KolCoding.ClsKol302));
                list.Add(SetDef("دو در هزار فروش صنایع", "30208", ParentDefaults.MoeinCoding.CLSMoein30208, ParentDefaults.KolCoding.ClsKol302));
                list.Add(SetDef("یک در هزار تربیت بدنی", "30209", ParentDefaults.MoeinCoding.CLSMoein30209, ParentDefaults.KolCoding.ClsKol302));
                list.Add(SetDef("عوارض آموزش و پرورش", "30210", ParentDefaults.MoeinCoding.CLSMoein30210, ParentDefaults.KolCoding.ClsKol302));
                list.Add(SetDef("ذخیره هزینه های معوق پرداخت نشده", "30211", ParentDefaults.MoeinCoding.CLSMoein30211, ParentDefaults.KolCoding.ClsKol302));
                list.Add(SetDef("حساب های پرداختنی", "30212", ParentDefaults.MoeinCoding.CLSMoein30212, ParentDefaults.KolCoding.ClsKol302));
                list.Add(SetDef("جاری شرکا", "30213", ParentDefaults.MoeinCoding.CLSMoein30213, ParentDefaults.KolCoding.ClsKol302));
                list.Add(SetDef("پیش دریافت فروش", "30301", ParentDefaults.MoeinCoding.CLSMoein30301, ParentDefaults.KolCoding.ClsKol303));
                list.Add(SetDef("پیش دریافت ارائه خدمات", "30302", ParentDefaults.MoeinCoding.CLSMoein30302, ParentDefaults.KolCoding.ClsKol303));
                list.Add(SetDef("سایر پیش دریافت ها", "30303", ParentDefaults.MoeinCoding.CLSMoein30303, ParentDefaults.KolCoding.ClsKol303));
                list.Add(SetDef("ذخیره مالیات بر درآمد شرکت ها", "30401", ParentDefaults.MoeinCoding.CLSMoein30401, ParentDefaults.KolCoding.ClsKol304));
                list.Add(SetDef("سود سهام پرداختنی", "30501", ParentDefaults.MoeinCoding.CLSMoein30501, ParentDefaults.KolCoding.ClsKol305));
                list.Add(SetDef("سپرده حسن انجام کار", "30601", ParentDefaults.MoeinCoding.CLSMoein30601, ParentDefaults.KolCoding.ClsKol306));
                list.Add(SetDef("سپرده حسن اجرای تعهدات", "30602", ParentDefaults.MoeinCoding.CLSMoein30602, ParentDefaults.KolCoding.ClsKol306));
                list.Add(SetDef("سپرده دریافتی مزایده", "30603", ParentDefaults.MoeinCoding.CLSMoein30603, ParentDefaults.KolCoding.ClsKol306));
                list.Add(SetDef("سپرده دریافتی مناقصه", "30604", ParentDefaults.MoeinCoding.CLSMoein30604, ParentDefaults.KolCoding.ClsKol306));
                list.Add(SetDef("سایر سپرده های دریافتی", "30605", ParentDefaults.MoeinCoding.CLSMoein30605, ParentDefaults.KolCoding.ClsKol306));
                list.Add(SetDef("فروش اقساطی", "30701", ParentDefaults.MoeinCoding.CLSMoein30701, ParentDefaults.KolCoding.ClsKol307));
                list.Add(SetDef("سلف", "30702", ParentDefaults.MoeinCoding.CLSMoein30702, ParentDefaults.KolCoding.ClsKol307));
                list.Add(SetDef("مشارکت مدنی", "30703", ParentDefaults.MoeinCoding.CLSMoein30703, ParentDefaults.KolCoding.ClsKol307));
                list.Add(SetDef("مضاربه", "30704", ParentDefaults.MoeinCoding.CLSMoein30704, ParentDefaults.KolCoding.ClsKol307));
                list.Add(SetDef("ذخیره مطالبات مشکوک الوصول", "30801", ParentDefaults.MoeinCoding.CLSMoein30801, ParentDefaults.KolCoding.ClsKol308));
                list.Add(SetDef("ذخیره کاهش ارزش موجودی مواد", "30802", ParentDefaults.MoeinCoding.CLSMoein30802, ParentDefaults.KolCoding.ClsKol308));
                list.Add(SetDef("ذخیره کاهش ارزش قطعات و ملزومات مصرفی", "30803", ParentDefaults.MoeinCoding.CLSMoein30803, ParentDefaults.KolCoding.ClsKol308));
                list.Add(SetDef("ذخیره کاهش ارزش موجودی کالا", "30804", ParentDefaults.MoeinCoding.CLSMoein30804, ParentDefaults.KolCoding.ClsKol308));
                list.Add(SetDef("ذخیره بن کارگری", "30805", ParentDefaults.MoeinCoding.CLSMoein30805, ParentDefaults.KolCoding.ClsKol308));
                list.Add(SetDef("ذخیره تضمین محصولات", "30806", ParentDefaults.MoeinCoding.CLSMoein30806, ParentDefaults.KolCoding.ClsKol308));
                list.Add(SetDef("ذخیره مرخصی استفاده نشده", "30807", ParentDefaults.MoeinCoding.CLSMoein30807, ParentDefaults.KolCoding.ClsKol308));
                list.Add(SetDef("اسناد پرداختنی بلند مدت تجاری", "40101", ParentDefaults.MoeinCoding.CLSMoein40101, ParentDefaults.KolCoding.ClsKol401));
                list.Add(SetDef("حساب های پرداختنی بلندمدت تجاری", "40102", ParentDefaults.MoeinCoding.CLSMoein40102, ParentDefaults.KolCoding.ClsKol401));
                list.Add(SetDef("اسناد پرداختنی بلندمدت غیر تجاری", "40201", ParentDefaults.MoeinCoding.CLSMoein40201, ParentDefaults.KolCoding.ClsKol402));
                list.Add(SetDef("حساب های پرداختنی بلند مدت غیر تجاری", "40202", ParentDefaults.MoeinCoding.CLSMoein40202, ParentDefaults.KolCoding.ClsKol402));
                list.Add(SetDef("فروش اقساطی", "40301", ParentDefaults.MoeinCoding.CLSMoein40301, ParentDefaults.KolCoding.ClsKol403));
                list.Add(SetDef("سلف", "40302", ParentDefaults.MoeinCoding.CLSMoein40302, ParentDefaults.KolCoding.ClsKol403));
                list.Add(SetDef("مشارکت مدنی", "40303", ParentDefaults.MoeinCoding.CLSMoein40303, ParentDefaults.KolCoding.ClsKol403));
                list.Add(SetDef("مضاربه", "40304", ParentDefaults.MoeinCoding.CLSMoein40304, ParentDefaults.KolCoding.ClsKol403));
                list.Add(SetDef("سود ناشی از تسعیر بدهی های بلند مدت ارزی", "40501", ParentDefaults.MoeinCoding.CLSMoein40501, ParentDefaults.KolCoding.ClsKol405));
                list.Add(SetDef("دارایی های اهدایی از طرف اشخاص", "40502", ParentDefaults.MoeinCoding.CLSMoein40502, ParentDefaults.KolCoding.ClsKol405));
                list.Add(SetDef("سرمایه سهام", "50101", ParentDefaults.MoeinCoding.CLSMoein50101, ParentDefaults.KolCoding.ClsKol501));
                list.Add(SetDef("صرف", "50102", ParentDefaults.MoeinCoding.CLSMoein50102, ParentDefaults.KolCoding.ClsKol501));
                list.Add(SetDef("سرمایه سهام عادی شده تعهد شده", "50103", ParentDefaults.MoeinCoding.CLSMoein50103, ParentDefaults.KolCoding.ClsKol501));
                list.Add(SetDef("سرمایه اهدایی", "50104", ParentDefaults.MoeinCoding.CLSMoein50104, ParentDefaults.KolCoding.ClsKol501));
                list.Add(SetDef("امتیاز پاره سهام", "50105", ParentDefaults.MoeinCoding.CLSMoein50105, ParentDefaults.KolCoding.ClsKol501));
                list.Add(SetDef("سهام خزانه", "50106", ParentDefaults.MoeinCoding.CLSMoein50106, ParentDefaults.KolCoding.ClsKol501));
                list.Add(SetDef("سود سهمی قابل توزیع", "50107", ParentDefaults.MoeinCoding.CLSMoein50107, ParentDefaults.KolCoding.ClsKol501));
                list.Add(SetDef("مازاد حاصل از تجزیه سهام", "50108", ParentDefaults.MoeinCoding.CLSMoein50108, ParentDefaults.KolCoding.ClsKol501));
                list.Add(SetDef("صرف حاصل از بازخرید سهام متاز", "50109", ParentDefaults.MoeinCoding.CLSMoein50109, ParentDefaults.KolCoding.ClsKol501));
                list.Add(SetDef("سرمایه پرداخت شده ناشی از تعهد پرداخت نشده", "50110", ParentDefaults.MoeinCoding.CLSMoein50110, ParentDefaults.KolCoding.ClsKol501));
                list.Add(SetDef("حق تقدم خرید سهام", "50111", ParentDefaults.MoeinCoding.CLSMoein50111, ParentDefaults.KolCoding.ClsKol501));
                list.Add(SetDef("حق خرید سهام", "50112", ParentDefaults.MoeinCoding.CLSMoein50112, ParentDefaults.KolCoding.ClsKol501));
                list.Add(SetDef("اندوخته احتیاطی", "50301", ParentDefaults.MoeinCoding.CLSMoein50301, ParentDefaults.KolCoding.ClsKol503));
                list.Add(SetDef("اندوخته توسعه و تکمیل", "50302", ParentDefaults.MoeinCoding.CLSMoein50302, ParentDefaults.KolCoding.ClsKol503));
                list.Add(SetDef("اندوخته عمومی", "50303", ParentDefaults.MoeinCoding.CLSMoein50303, ParentDefaults.KolCoding.ClsKol503));
                list.Add(SetDef("اندوخته جایگزین دارایی ها", "50304", ParentDefaults.MoeinCoding.CLSMoein50304, ParentDefaults.KolCoding.ClsKol503));
                list.Add(SetDef("سایر اندوخته ها", "50305", ParentDefaults.MoeinCoding.CLSMoein50305, ParentDefaults.KolCoding.ClsKol503));
                list.Add(SetDef("زمین", "50401", ParentDefaults.MoeinCoding.CLSMoein50401, ParentDefaults.KolCoding.ClsKol504));
                list.Add(SetDef("ساختمان", "50402", ParentDefaults.MoeinCoding.CLSMoein50402, ParentDefaults.KolCoding.ClsKol504));
                list.Add(SetDef("تاسیسات", "50403", ParentDefaults.MoeinCoding.CLSMoein50403, ParentDefaults.KolCoding.ClsKol504));
                list.Add(SetDef("ماشین آلات و تجهیزات", "50404", ParentDefaults.MoeinCoding.CLSMoein50404, ParentDefaults.KolCoding.ClsKol504));
                list.Add(SetDef("ابزارآلات", "50405", ParentDefaults.MoeinCoding.CLSMoein50405, ParentDefaults.KolCoding.ClsKol504));
                list.Add(SetDef("وسائط نقلیه", "50406", ParentDefaults.MoeinCoding.CLSMoein50406, ParentDefaults.KolCoding.ClsKol504));
                list.Add(SetDef("اثاثیه و منصوبات", "50407", ParentDefaults.MoeinCoding.CLSMoein50407, ParentDefaults.KolCoding.ClsKol504));
                list.Add(SetDef("قالب ها", "50408", ParentDefaults.MoeinCoding.CLSMoein50408, ParentDefaults.KolCoding.ClsKol504));
                list.Add(SetDef("لوازم آزمایشگاهی", "50409", ParentDefaults.MoeinCoding.CLSMoein50409, ParentDefaults.KolCoding.ClsKol504));
                list.Add(SetDef("دارایی های سرمایه ای موجود در انبار", "50410", ParentDefaults.MoeinCoding.CLSMoein50410, ParentDefaults.KolCoding.ClsKol504));
                list.Add(SetDef("سرمایه گذاری در سهام شرکت های تابعه", "50411", ParentDefaults.MoeinCoding.CLSMoein50411, ParentDefaults.KolCoding.ClsKol504));
                list.Add(SetDef("سرمایه گذاری در سهام شرکت های وابسته", "50412", ParentDefaults.MoeinCoding.CLSMoein50412, ParentDefaults.KolCoding.ClsKol504));
                list.Add(SetDef("سرمایه گذاری در سهام سایر شرکت ها", "50413", ParentDefaults.MoeinCoding.CLSMoein50413, ParentDefaults.KolCoding.ClsKol504));
                list.Add(SetDef("سرمایه گذاری در اوراق مشارکت شرکت های تابعه", "50414", ParentDefaults.MoeinCoding.CLSMoein50414, ParentDefaults.KolCoding.ClsKol504));
                list.Add(SetDef("سرمایه گذاری در اوراق مشارکت شرکت های وابسته", "50415", ParentDefaults.MoeinCoding.CLSMoein50415, ParentDefaults.KolCoding.ClsKol504));
                list.Add(SetDef("سرمایه گذاری در اوراق مشارکت سایر شرکت ها", "50416", ParentDefaults.MoeinCoding.CLSMoein50416, ParentDefaults.KolCoding.ClsKol504));
                list.Add(SetDef("سود (زیان) انباشته", "50601", ParentDefaults.MoeinCoding.CLSMoein50601, ParentDefaults.KolCoding.ClsKol505));
                list.Add(SetDef("سود (زیان) سال جاری", "50602", ParentDefaults.MoeinCoding.CLSMoein50602, ParentDefaults.KolCoding.ClsKol505));
                list.Add(SetDef("تعدیلات سنواتی", "50603", ParentDefaults.MoeinCoding.CLSMoein50603, ParentDefaults.KolCoding.ClsKol505));
                list.Add(SetDef("فروش کالای داخلی", "60101", ParentDefaults.MoeinCoding.CLSMoein60101, ParentDefaults.KolCoding.ClsKol601));
                list.Add(SetDef("برگشت از فزوش و تخفیفات داخلی", "60102", ParentDefaults.MoeinCoding.CLSMoein60102, ParentDefaults.KolCoding.ClsKol601));
                list.Add(SetDef("تخفیفات نقدی فروش داخلی", "60103", ParentDefaults.MoeinCoding.CLSMoein60103, ParentDefaults.KolCoding.ClsKol601));
                list.Add(SetDef("فروش کالای صادراتی", "60104", ParentDefaults.MoeinCoding.CLSMoein60104, ParentDefaults.KolCoding.ClsKol601));
                list.Add(SetDef("برگشت از فروش و تخفیفات فروش صادراتی", "60105", ParentDefaults.MoeinCoding.CLSMoein60105, ParentDefaults.KolCoding.ClsKol601));
                list.Add(SetDef("تخفیفات نقدی فروش صادراتی", "60106", ParentDefaults.MoeinCoding.CLSMoein60106, ParentDefaults.KolCoding.ClsKol601));
                list.Add(SetDef("درآمد حاصل از ارائه خدمات داخلی", "60201", ParentDefaults.MoeinCoding.CLSMoein60201, ParentDefaults.KolCoding.ClsKol602));
                list.Add(SetDef("درآمد حاصل از ارائه خدمات خارجی", "60202", ParentDefaults.MoeinCoding.CLSMoein60202, ParentDefaults.KolCoding.ClsKol602));
                list.Add(SetDef("فروش ضایعات عادی", "60301", ParentDefaults.MoeinCoding.CLSMoein60301, ParentDefaults.KolCoding.ClsKol603));
                list.Add(SetDef("سود حاصل از فروش مواد اولیه", "60302", ParentDefaults.MoeinCoding.CLSMoein60302, ParentDefaults.KolCoding.ClsKol603));
                list.Add(SetDef("سود ناشی از تسعیر دارایی ها و بدهی های عملیاتی", "60303", ParentDefaults.MoeinCoding.CLSMoein60303, ParentDefaults.KolCoding.ClsKol603));
                list.Add(SetDef("سایر درآمدهای عملیاتی", "60304", ParentDefaults.MoeinCoding.CLSMoein60304, ParentDefaults.KolCoding.ClsKol603));
                list.Add(SetDef("سود حاصل از فروش دارایی ها", "60401", ParentDefaults.MoeinCoding.CLSMoein60401, ParentDefaults.KolCoding.ClsKol604));
                list.Add(SetDef("سود حاصل از سرمایه گذاری", "60402", ParentDefaults.MoeinCoding.CLSMoein60402, ParentDefaults.KolCoding.ClsKol604));
                list.Add(SetDef("سود ناشی از فروش سرمایه گذاری", "60403", ParentDefaults.MoeinCoding.CLSMoein60403, ParentDefaults.KolCoding.ClsKol604));
                list.Add(SetDef("سود ناشی از تسعیر دارایی ها و بدهی های غیرعملیاتی", "60404", ParentDefaults.MoeinCoding.CLSMoein60404, ParentDefaults.KolCoding.ClsKol604));
                list.Add(SetDef("سایر درآمدهای غیرعملیاتی", "60405", ParentDefaults.MoeinCoding.CLSMoein60405, ParentDefaults.KolCoding.ClsKol604));
                list.Add(SetDef("بهای تمام شده کالای فروش رفته داخلی درون گروهی", "70101", ParentDefaults.MoeinCoding.CLSMoein70101, ParentDefaults.KolCoding.ClsKol701));
                list.Add(SetDef("بهای تمام شده کالای فروش رفته خارج از گروه", "70102", ParentDefaults.MoeinCoding.CLSMoein70102, ParentDefaults.KolCoding.ClsKol701));
                list.Add(SetDef("مواد مستقیم", "70201", ParentDefaults.MoeinCoding.CLSMoein70201, ParentDefaults.KolCoding.ClsKol702));
                list.Add(SetDef("دستمزد مستقیم", "70202", ParentDefaults.MoeinCoding.CLSMoein70202, ParentDefaults.KolCoding.ClsKol702));
                list.Add(SetDef("سربار", "70203", ParentDefaults.MoeinCoding.CLSMoein70203, ParentDefaults.KolCoding.ClsKol702));
                list.Add(SetDef("دستمزد مستقیم", "70301", ParentDefaults.MoeinCoding.CLSMoein70301, ParentDefaults.KolCoding.ClsKol703));
                list.Add(SetDef("سربار", "70302", ParentDefaults.MoeinCoding.CLSMoein70302, ParentDefaults.KolCoding.ClsKol703));
                list.Add(SetDef("حقوق و دستمزد مستمر", "80101", ParentDefaults.MoeinCoding.CLSMoein80101, ParentDefaults.KolCoding.ClsKol801));
                list.Add(SetDef("حقوق و دستمزد غیرمستمر", "80102", ParentDefaults.MoeinCoding.CLSMoein80102, ParentDefaults.KolCoding.ClsKol801));
                list.Add(SetDef("حق بیمه سهم کارفرما", "80103", ParentDefaults.MoeinCoding.CLSMoein80103, ParentDefaults.KolCoding.ClsKol801));
                list.Add(SetDef("دستمزد کارکنان روزمزد", "80104", ParentDefaults.MoeinCoding.CLSMoein80104, ParentDefaults.KolCoding.ClsKol801));
                list.Add(SetDef("هزینه تعمیر و نگهداری دارایی های غیرتولیدی", "80201", ParentDefaults.MoeinCoding.CLSMoein80201, ParentDefaults.KolCoding.ClsKol802));
                list.Add(SetDef("هزینه سوخت وسائط نقلیه", "80202", ParentDefaults.MoeinCoding.CLSMoein80202, ParentDefaults.KolCoding.ClsKol802));
                list.Add(SetDef("هزینه تسهیلات عمومی بخش های غیرتولیدی", "80203", ParentDefaults.MoeinCoding.CLSMoein80203, ParentDefaults.KolCoding.ClsKol802));
                list.Add(SetDef("هزینه بیمه دارایی های ثابت غیرتولیدی", "80204", ParentDefaults.MoeinCoding.CLSMoein80204, ParentDefaults.KolCoding.ClsKol802));
                list.Add(SetDef("هزینه بیمه موجودی ها", "80205", ParentDefaults.MoeinCoding.CLSMoein80205, ParentDefaults.KolCoding.ClsKol802));
                list.Add(SetDef("هزینه ملزومات", "80206", ParentDefaults.MoeinCoding.CLSMoein80206, ParentDefaults.KolCoding.ClsKol802));
                list.Add(SetDef("هزینه پست", "80207", ParentDefaults.MoeinCoding.CLSMoein80207, ParentDefaults.KolCoding.ClsKol802));
                list.Add(SetDef("هزینه اجاره", "80208", ParentDefaults.MoeinCoding.CLSMoein80208, ParentDefaults.KolCoding.ClsKol802));
                list.Add(SetDef("هزینه استهلاک دارایی های غیرتولیدی", "80209", ParentDefaults.MoeinCoding.CLSMoein80209, ParentDefaults.KolCoding.ClsKol802));
                list.Add(SetDef("هزینه مواد مصرفی آزمایشگاهی", "80210", ParentDefaults.MoeinCoding.CLSMoein80210, ParentDefaults.KolCoding.ClsKol802));
                list.Add(SetDef("هزینه های دارایی و تشکیلاتی", "80211", ParentDefaults.MoeinCoding.CLSMoein80211, ParentDefaults.KolCoding.ClsKol802));
                list.Add(SetDef("هزینه های توزیع و فروش", "80212", ParentDefaults.MoeinCoding.CLSMoein80212, ParentDefaults.KolCoding.ClsKol802));
                list.Add(SetDef("زیان ضایعات غیرعادی تولید", "80301", ParentDefaults.MoeinCoding.CLSMoein80301, ParentDefaults.KolCoding.ClsKol803));
                list.Add(SetDef("زیان ناشی از کاهش ارزش", "80302", ParentDefaults.MoeinCoding.CLSMoein80302, ParentDefaults.KolCoding.ClsKol803));
                list.Add(SetDef("زیان ناشی از موجودی اقلام راکد و ناباب", "80303", ParentDefaults.MoeinCoding.CLSMoein80303, ParentDefaults.KolCoding.ClsKol803));
                list.Add(SetDef("خالص کسری و اضافی انبار", "80304", ParentDefaults.MoeinCoding.CLSMoein80304, ParentDefaults.KolCoding.ClsKol803));
                list.Add(SetDef("هزینه های جذب نشده در تولید", "80305", ParentDefaults.MoeinCoding.CLSMoein80305, ParentDefaults.KolCoding.ClsKol803));
                list.Add(SetDef("زیان ناشی از تسعیر دارایی ها و بدهی های ارزی عملیاتی", "80306", ParentDefaults.MoeinCoding.CLSMoein80306, ParentDefaults.KolCoding.ClsKol803));
                list.Add(SetDef("هزینه سود وام های دریافتنی", "80401", ParentDefaults.MoeinCoding.CLSMoein80401, ParentDefaults.KolCoding.ClsKol804));
                list.Add(SetDef("هزینه کارمزد وام ها", "80402", ParentDefaults.MoeinCoding.CLSMoein80402, ParentDefaults.KolCoding.ClsKol804));
                list.Add(SetDef("هزینه تمبر و سفته", "80403", ParentDefaults.MoeinCoding.CLSMoein80403, ParentDefaults.KolCoding.ClsKol804));
                list.Add(SetDef("هزینه جزیمه دیرکرد وام ها", "80404", ParentDefaults.MoeinCoding.CLSMoein80404, ParentDefaults.KolCoding.ClsKol804));
                list.Add(SetDef("هزینه های متفرقه مالی", "80405", ParentDefaults.MoeinCoding.CLSMoein80405, ParentDefaults.KolCoding.ClsKol804));
                list.Add(SetDef("زیان حاصل از فروش دارایی های ثابت مشهود", "80501", ParentDefaults.MoeinCoding.CLSMoein80501, ParentDefaults.KolCoding.ClsKol805));
                list.Add(SetDef("زیان حاصل از سرمایه گذاری", "80502", ParentDefaults.MoeinCoding.CLSMoein80502, ParentDefaults.KolCoding.ClsKol805));
                list.Add(SetDef("زیان حاصل از فروش سرمایه گذاری ها", "80503", ParentDefaults.MoeinCoding.CLSMoein80503, ParentDefaults.KolCoding.ClsKol805));
                list.Add(SetDef("زیان ناشی از تسعیر دارایی ها و بدهی های غیرعملیاتی", "80504", ParentDefaults.MoeinCoding.CLSMoein80504, ParentDefaults.KolCoding.ClsKol805));
                list.Add(SetDef("سایر هزینه های غیرعملیاتی", "80505", ParentDefaults.MoeinCoding.CLSMoein80505, ParentDefaults.KolCoding.ClsKol805));
                list.Add(SetDef("زیان ناشی از اقلام غیرمترقبه", "80506", ParentDefaults.MoeinCoding.CLSMoein80506, ParentDefaults.KolCoding.ClsKol805));
                list.Add(SetDef("حساب های انتظامی به نفع شرکت", "90101", ParentDefaults.MoeinCoding.CLSMoein90101, ParentDefaults.KolCoding.ClsKol901));
                list.Add(SetDef("حساب های انتظامی بر عهده شرکت", "90102", ParentDefaults.MoeinCoding.CLSMoein90102, ParentDefaults.KolCoding.ClsKol901));
                list.Add(SetDef("طرف حساب های انتظامی به نفع شرکت", "90201", ParentDefaults.MoeinCoding.CLSMoein90201, ParentDefaults.KolCoding.ClsKol902));
                list.Add(SetDef("طرف حساب های انتظامی بر عهده شرکت", "90202", ParentDefaults.MoeinCoding.CLSMoein90202, ParentDefaults.KolCoding.ClsKol902));


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
