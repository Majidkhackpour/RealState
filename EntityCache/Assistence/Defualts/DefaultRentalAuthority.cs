using System;
using System.Collections.Generic;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Assistence.Defualts
{
    public static class DefaultRentalAuthority
    {
        private static List<RentalAuthorityBussines> list = new List<RentalAuthorityBussines>();
        private static RentalAuthorityBussines SetDef(string name)
        {
            try
            {
                var reg = new RentalAuthorityBussines()
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
        public static List<RentalAuthorityBussines> SetDef()
        {
            try
            {
                list.Add(SetDef("خانواده"));
                list.Add(SetDef("دانشجو"));
                list.Add(SetDef("زوج جوان"));
                list.Add(SetDef("سرباز"));
                list.Add(SetDef("مجرد"));
                list.Add(SetDef("مذهبی"));
                list.Add(SetDef("خانواده کم جمعیت"));
                list.Add(SetDef("دانشجو دختر"));
                list.Add(SetDef("دانشجو پسر"));
                list.Add(SetDef("خانواده 3 نفره"));
                list.Add(SetDef("خانواده 4 نفره"));
                list.Add(SetDef("زوج سالمند"));
                list.Add(SetDef("مطب پزشک"));
                list.Add(SetDef("شرکت"));
                list.Add(SetDef("موسسه اعتباری"));
                list.Add(SetDef("مدرسه"));
                list.Add(SetDef("مهدکودک"));
                list.Add(SetDef("آموزشگاه"));
                list.Add(SetDef("آرایشگاه زنانه"));
                list.Add(SetDef("آرایشگاه مردانه"));

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
