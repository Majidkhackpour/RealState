using EntityCache.Bussines;
using Services;

namespace Settings.Classes
{
    public class clsGlobal
    {
        private static string _birthdayText = "";
        public static string BirthDayText
        {
            get
            {
                if (!string.IsNullOrEmpty(_birthdayText)) return _birthdayText;
                var mem = SettingsBussines.Get("BirthDayText");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _birthdayText = value;
                SettingsBussines.Save("BirthDayText", _birthdayText);
            }
        }

        private static int _setArchive = 0;
        public static int SetArchive
        {
            get
            {
                if (_setArchive>0) return _setArchive;
                var mem = SettingsBussines.Get("DayCountForArchive");
                return mem?.Value.ParseToInt() ?? 0;
            }
            set
            {
                _setArchive = value;
                SettingsBussines.Save("DayCountForArchive", _setArchive.ToString());
            }
        }
    }
}
