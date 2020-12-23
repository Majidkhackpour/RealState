using EntityCache.Bussines;

namespace Settings.Classes
{
    public class clsGlobal
    {
        private static string _isShowReminder = "";
        public static string IsShowReminder
        {
            get
            {
                if (!string.IsNullOrEmpty(_isShowReminder)) return _isShowReminder;
                var mem = SettingsBussines.Get("IsShowReminder");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _isShowReminder = value;
                SettingsBussines.Save("IsShowReminder", _isShowReminder);
            }
        }


        private static string _isShowBirthday = "";
        public static string IsShowBirthDay
        {
            get
            {
                if (!string.IsNullOrEmpty(_isShowBirthday)) return _isShowBirthday;
                var mem = SettingsBussines.Get("IsShowBirthDay");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _isShowBirthday = value;
                SettingsBussines.Save("IsShowBirthDay", _isShowBirthday);
            }
        }

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
