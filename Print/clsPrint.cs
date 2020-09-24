using EntityCache.Bussines;
using Services;

namespace Print
{
    public class clsPrint
    {
        public static EnPrintType PrintType = EnPrintType.None;

        private static string _showPreview = "";
        public static string ShowPreview
        {
            get
            {
                if (!string.IsNullOrEmpty(_showPreview)) return _showPreview;
                var mem = SettingsBussines.Get("PRNT010U");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _showPreview = value;
                SettingsBussines.Save("PRNT010U", _showPreview);
            }
        }

        private static bool _showDesign = false;
        public static bool ShowDesign { get => _showDesign; set => _showDesign = value; }
    }
}
