namespace Payamak
{
    public class Replacor
    {
        public class Owner
        {
            public static string OwnerName => "[نام مالک]".Trim();
            public static string DateSabt => "[تاریخ ثبت]".Trim();
            public static string Code => "[کدملک]".Trim();
            public static string Region => "[محدوده]".Trim();
            public static string UserName => "[مشاور]".Trim();
        }
        public class Request
        {
            public static string Name => "[نام متقاضی]".Trim();
            public static string DateSabt => "[تاریخ ثبت]".Trim();
            public static string UserName => "[مشاور]".Trim();
        }
        public class Rahn
        {
            public static string Name => "[نام متقاضی]".Trim();
            public static string DateSh => "[تاریخ ارسال]".Trim();
            public static string Region => "[محدوده ملک]".Trim();
            public static string RahnPrice => "[رهن]".Trim();
            public static string EjarePrice => "[اجاره]".Trim();
        }
        public class Forush
        {
            public static string Name => "[نام متقاضی]".Trim();
            public static string DateSh => "[تاریخ ارسال]".Trim();
            public static string Region => "[محدوده ملک]".Trim();
            public static string SellPrice => "[قیمت]".Trim();
        }
    }
}
