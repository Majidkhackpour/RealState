using EntityCache.Bussines;
using Services;

namespace Settings.Classes
{
    public class clsPrint
    {
        public static EnPrintType PrintType = EnPrintType.None;

        private static string _showPreview = "";
        public static bool ShowPreview
        {
            get
            {
                if (!string.IsNullOrEmpty(_showPreview)) return _showPreview.ParseToBoolean();
                var mem = SettingsBussines.Get("PRNT010U");
                return mem?.Value.ParseToBoolean() ?? false;
            }
            set
            {
                _showPreview = value.ToString();
                SettingsBussines.Save("PRNT010U", _showPreview);
            }
        }

        private static string _showDesign = "";
        public static bool ShowDesign
        {
            get
            {
                if (!string.IsNullOrEmpty(_showDesign)) return _showDesign.ParseToBoolean();
                var mem = SettingsBussines.Get("PRNT020U");
                return mem?.Value.ParseToBoolean() ?? false;
            }
            set
            {
                _showDesign = value.ToString();
                SettingsBussines.Save("PRNT020U", _showDesign);
            }
        }
    }
}
