using System.Collections.Generic;
using EntityCache.Bussines;
using Services;

namespace Settings.Classes
{
    public class clsBuildingRequest
    {
        private static string _strColumns = "";
        private static string StrColumns
        {
            get
            {
                if (!string.IsNullOrEmpty(_strColumns)) return _strColumns;
                var mem = SettingsBussines.Get("BuildingRequestColumns");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _strColumns = value;
                SettingsBussines.Save("BuildingRequestColumns", _strColumns);
            }
        }


        private static List<string> _columnList = new List<string>();
        public static List<string> ColumnsList
        {
            get
            {
                var res = StrColumns.FromJson<List<string>>();
                return res;
            }
            set => StrColumns = Json.ToStringJson(value);
        }
    }
}
