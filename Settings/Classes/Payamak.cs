using EntityCache.Bussines;

namespace Settings.Classes
{
    public class Payamak
    {
        private static string _defPanelGuid = "";
        public static string DefaultPanelGuid
        {
            get
            {
                if (!string.IsNullOrEmpty(_defPanelGuid)) return _defPanelGuid;
                var mem = SettingsBussines.Get("defPanel");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _defPanelGuid = value;
                SettingsBussines.Save("defPanel", _defPanelGuid);
            }
        }
    }
}
