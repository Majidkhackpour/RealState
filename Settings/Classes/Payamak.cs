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

        private static string _isSendToOwner = "";
        public static string IsSendToOwner
        {
            get
            {
                if (!string.IsNullOrEmpty(_isSendToOwner)) return _isSendToOwner;
                var mem = SettingsBussines.Get("IsSendToOwner");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _isSendToOwner = value;
                SettingsBussines.Save("IsSendToOwner", _isSendToOwner);
            }
        }

        private static string _ownerText = "";
        public static string OwnerText
        {
            get
            {
                if (!string.IsNullOrEmpty(_ownerText)) return _ownerText;
                var mem = SettingsBussines.Get("OwnerText");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _ownerText = value;
                SettingsBussines.Save("OwnerText", _ownerText);
            }
        }

        private static string _isSendToSayer = "";
        public static string IsSendToSayer
        {
            get
            {
                if (!string.IsNullOrEmpty(_isSendToSayer)) return _isSendToSayer;
                var mem = SettingsBussines.Get("IsSendToSayer");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _isSendToSayer = value;
                SettingsBussines.Save("IsSendToSayer", _isSendToSayer);
            }
        }

        private static string _sayerText = "";
        public static string SayerText
        {
            get
            {
                if (!string.IsNullOrEmpty(_sayerText)) return _sayerText;
                var mem = SettingsBussines.Get("SayerText");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _sayerText = value;
                SettingsBussines.Save("SayerText", _sayerText);
            }
        }

        private static string _isSendAfterMatch = "";
        public static string IsSendAfterMatch
        {
            get
            {
                if (!string.IsNullOrEmpty(_isSendAfterMatch)) return _isSendAfterMatch;
                var mem = SettingsBussines.Get("IsSendAfterMatch");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _isSendAfterMatch = value;
                SettingsBussines.Save("IsSendAfterMatch", _isSendAfterMatch);
            }
        }

        private static string _sendMatchTextRahn = "";
        public static string SendMatchTextRahn
        {
            get
            {
                if (!string.IsNullOrEmpty(_sendMatchTextRahn)) return _sendMatchTextRahn;
                var mem = SettingsBussines.Get("SendMatchTextRahn");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _sendMatchTextRahn = value;
                SettingsBussines.Save("SendMatchTextRahn", _sendMatchTextRahn);
            }
        }

        private static string _sendMatchTextKharid = "";
        public static string SendMatchTextKharid
        {
            get
            {
                if (!string.IsNullOrEmpty(_sendMatchTextKharid)) return _sendMatchTextKharid;
                var mem = SettingsBussines.Get("SendMatchTextKharid");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _sendMatchTextKharid = value;
                SettingsBussines.Save("SendMatchTextKharid", _sendMatchTextKharid);
            }
        }
    }
}
