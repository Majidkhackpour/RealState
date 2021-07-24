using System;
using System.Collections.Generic;
using System.Reflection;
using Services;

namespace User.AccessLevel
{
    public class AccessLevelClass
    {
        private object _cls;
        private PropertyInfoClass _info = null;
        public AccessLevelClass(object cls) => _cls = cls;
        public AccessLevelClass(string name, string persianname, object cls)
        {
            Name = name;
            _cls = cls;
            PersianName = persianname;
        }

        public string Name { get; set; }

        public string PersianName { get; set; }

        public PropertyInfoClass info => _info ?? (_info = new PropertyInfoClass(_cls));
        public bool? Checked
        {
            get => info.CkeckAll;
            set => info.CkeckAll = value;
        }
        private PropertyInfo _propInfo;
        public static List<AccessLevelClass> ListInfo(Services.Access.AccessLevel access)
        {
            try
            {
                if (access == null) return null;
                var ret = new List<AccessLevelClass>();
                foreach (var prop in access.GetType().GetProperties())
                {
                    var attrs = prop.GetCustomAttributes(true);
                    foreach (var attr in attrs)
                    {
                        var pname = attr as PersianNameAttribute.PersianName;
                        if (pname == null) continue;
                        ret.Add(new AccessLevelClass(prop.Name, pname.Text, prop.GetValue(access)));
                        break;
                    }

                }
                return ret;
            }
            catch (Exception e)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(e);
                return null;
            }
        }
    }
}
