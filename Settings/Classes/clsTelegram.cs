using EntityCache.Bussines;

namespace Settings.Classes
{
    public static class clsTelegram
    {
        private static string _token = "";
        public static string Token
        {
            get
            {
                if (!string.IsNullOrEmpty(_token)) return _token;
                var mem = SettingsBussines.Get("Token");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _token = value;
                SettingsBussines.Save("Token", _token);
            }
        }

        private static string _channel = "";
        public static string Channel
        {
            get
            {
                if (!string.IsNullOrEmpty(_channel)) return _channel;
                var mem = SettingsBussines.Get("Channel");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _channel = value;
                SettingsBussines.Save("Channel", _channel);
            }
        }

        private static string _text = "";
        public static string Text
        {
            get
            {
                if (!string.IsNullOrEmpty(_text)) return _text;
                var mem = SettingsBussines.Get("Text");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _text = value;
                SettingsBussines.Save("Text", _text);
            }
        }

        private static string _mngChannel = "";
        public static string ManagerChannel
        {
            get
            {
                if (!string.IsNullOrEmpty(_mngChannel)) return _mngChannel;
                var mem = SettingsBussines.Get("ManagerChannel");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _mngChannel = value;
                SettingsBussines.Save("ManagerChannel", _mngChannel);
            }
        }

        private static string _mngText = "";
        public static string ManagetText
        {
            get
            {
                if (!string.IsNullOrEmpty(_mngText)) return _mngText;
                var mem = SettingsBussines.Get("ManagetText");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _mngText = value;
                SettingsBussines.Save("ManagetText", _mngText);
            }
        }
    }
}
