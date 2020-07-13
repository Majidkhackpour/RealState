using System;
using System.Collections.Generic;
using EntityCache.Bussines;
using PacketParser.Services;

namespace EntityCache.Assistence.Defualts
{
    public static class DefaultKitchenService
    {
        private static List<KitchenServiceBussines> list = new List<KitchenServiceBussines>();
        private static KitchenServiceBussines SetDef(string name)
        {
            try
            {
                var reg = new KitchenServiceBussines()
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

        public static List<KitchenServiceBussines> SetDef()
        {
            try
            {
                list.Add(SetDef("MDF"));
                list.Add(SetDef("HPL"));
                list.Add(SetDef("فایبرگلاس"));
                list.Add(SetDef("فلزی"));
                list.Add(SetDef("چوبی"));
                

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
