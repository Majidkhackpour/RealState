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

        private static string _imgPath = "";
        public static string ImagePath
        {
            get
            {
                if (!string.IsNullOrEmpty(_imgPath)) return _imgPath;
                var mem = SettingsBussines.Get("ImagePath");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _imgPath = value;
                SettingsBussines.Save("ImagePath", _imgPath);
            }
        }

        private static string _mediaPath = "";
        public static string MediaPath
        {
            get
            {
                if (!string.IsNullOrEmpty(_mediaPath)) return _mediaPath;
                var mem = SettingsBussines.Get("MediaPath");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _mediaPath = value;
                SettingsBussines.Save("MediaPath", _mediaPath);
            }
        }
    }
}
