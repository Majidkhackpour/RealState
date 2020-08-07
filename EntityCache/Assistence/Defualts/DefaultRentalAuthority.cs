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
