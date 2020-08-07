using EntityCache.Bussines;

namespace Settings.Classes
{
    public class clsGlobalSetting
    {
        private static string _lastUser = "";
        public static string LastUser
        {
            get
            {
                if (!string.IsNullOrEmpty(_lastUser)) return _lastUser;
                var mem = SettingsBussines.Get("LastUser");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _lastUser = value;
                SettingsBussines.Save("LastUser", _lastUser);
            }
        }


        private static string _applicationVersion = "";
        public static string ApplicationVersion
        {
            get
            {
                if (!string.IsNullOrEmpty(_applicationVersion)) return _applicationVersion;
                var mem = SettingsBussines.Get("AppVersion");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _applicationVersion = value;
                SettingsBussines.Save("AppVersion", _applicationVersion);
            }
        }
        
    }
}
