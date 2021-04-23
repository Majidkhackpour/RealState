using System;
using System.Collections.Generic;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Assistence.Defualts
{
    public static class DefaultBankSegest
    {
        private static List<BankSegestBussines> list = new List<BankSegestBussines>();
        private static BankSegestBussines SetDef(string name)
        {
            try
            {
                var reg = new BankSegestBussines()
                {
                    Guid = Guid.NewGuid(),
                    BankName = name
                };
                return reg;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
        public static List<BankSegestBussines> SetDef()
        {
            try
            {
                list.Add(SetDef("تجارت"));
                list.Add(SetDef("رفاه کارگران"));
                list.Add(SetDef("سپه"));
                list.Add(SetDef("سپه طلایی"));
                list.Add(SetDef("پست بانک"));
                list.Add(SetDef("ثادرات"));
                list.Add(SetDef("ملت"));
                list.Add(SetDef("ملی"));
                list.Add(SetDef("مهر ایران"));
                list.Add(SetDef("صندوق پس انداز قراض الحسنه مهر بسیجیان"));
                list.Add(SetDef("توسعه تعاون"));
                list.Add(SetDef("اقتصاد نوین"));
                list.Add(SetDef("پارسیان"));
                list.Add(SetDef("کارآفرین"));
                list.Add(SetDef("پاسارگاد"));
                list.Add(SetDef("سرمایه"));
                list.Add(SetDef("سینا"));
                list.Add(SetDef("تات"));
                list.Add(SetDef("شهر"));
                list.Add(SetDef("دی"));
                list.Add(SetDef("انصار"));
                list.Add(SetDef("توسعه صادرات"));
                list.Add(SetDef("کشاورزی"));
                list.Add(SetDef("مسکن"));
                list.Add(SetDef("فرشتگان"));
                list.Add(SetDef("میزان"));
                list.Add(SetDef("عسگریه"));
                list.Add(SetDef("الزهرا"));
                list.Add(SetDef("امید"));
                list.Add(SetDef("قوامین"));
                list.Add(SetDef("کارسازان آینده"));
                list.Add(SetDef("ثامن"));
                list.Add(SetDef("قائم"));
                list.Add(SetDef("صالحین"));
                list.Add(SetDef("ثامن الائمه"));
                list.Add(SetDef("ثامن الحجج"));
                list.Add(SetDef("ایرانیان"));
                list.Add(SetDef("اعتماد ایرانیان"));
                list.Add(SetDef("قدس"));
                list.Add(SetDef("وحدت"));
                list.Add(SetDef("بدر توس"));
                list.Add(SetDef("مولی الموحدین"));
                list.Add(SetDef("دانش"));
                list.Add(SetDef("امین طلاب"));
                list.Add(SetDef("بهمن ایثار"));
                list.Add(SetDef("افضل توس"));
                list.Add(SetDef("معین الرضا"));
                list.Add(SetDef("فردوسی"));
                list.Add(SetDef("باران"));
                list.Add(SetDef("ایران زمین"));
                list.Add(SetDef("پیشگامان"));

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
