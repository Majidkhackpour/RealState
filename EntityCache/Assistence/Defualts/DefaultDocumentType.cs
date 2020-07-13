using System;
using System.Collections.Generic;
using EntityCache.Bussines;
using PacketParser.Services;

namespace EntityCache.Assistence.Defualts
{
    public static class DefaultDocumentType
    {
        private static List<DocumentTypeBussines> list = new List<DocumentTypeBussines>();
        private static DocumentTypeBussines SetDef(string name)
        {
            try
            {
                var reg = new DocumentTypeBussines()
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

        public static List<DocumentTypeBussines> SetDef()
        {
            try
            {
                list.Add(SetDef("آستانه"));
                list.Add(SetDef("اوقاف"));
                list.Add(SetDef("سایر"));
                list.Add(SetDef("شرطی"));
                list.Add(SetDef("شش دانگ"));
                list.Add(SetDef("قولنامه"));
                list.Add(SetDef("مشاعی آپارتمانی"));
                list.Add(SetDef("مشاعی شریک"));
                list.Add(SetDef("مشاعی وراث"));
                list.Add(SetDef("ملکی"));
                list.Add(SetDef("وکالتی"));
                list.Add(SetDef("کمتر از شش دانگ"));
                

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
