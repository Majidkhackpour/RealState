using EntityCache.Bussines;

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
    }
}
