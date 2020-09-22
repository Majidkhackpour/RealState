using EntityCache.Bussines;

namespace Settings.Classes
{
    public class clsSandouq
    {
        private static string _economyCode = "";
        public static string EconomyCode
        {
            get
            {
                if (!string.IsNullOrEmpty(_economyCode)) return _economyCode;
                var mem = SettingsBussines.Get("EconomyCode");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _economyCode = value;
                SettingsBussines.Save("EconomyCode", _economyCode);
            }
        }

        private static string _economyCodeStatus = "";
        public static string EconomyCodeStatus
        {
            get
            {
                if (!string.IsNullOrEmpty(_economyCodeStatus)) return _economyCodeStatus;
                var mem = SettingsBussines.Get("EconomyCodeStatus");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _economyCodeStatus = value;
                SettingsBussines.Save("EconomyCodeStatus", _economyCodeStatus);
            }
        }

        private static string _natCode = "";
        public static string NationalCode
        {
            get
            {
                if (!string.IsNullOrEmpty(_natCode)) return _natCode;
                var mem = SettingsBussines.Get("NationalCode");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _natCode = value;
                SettingsBussines.Save("NationalCode", _natCode);
            }
        }

        private static string _idCode = "";
        public static string IdCode
        {
            get
            {
                if (!string.IsNullOrEmpty(_idCode)) return _idCode;
                var mem = SettingsBussines.Get("IdCode");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _idCode = value;
                SettingsBussines.Save("IdCode", _idCode);
            }
        }

        private static string _arzeshAfzoude = "";
        public static string ArzeshAfzoude
        {
            get
            {
                if (!string.IsNullOrEmpty(_arzeshAfzoude)) return _arzeshAfzoude;
                var mem = SettingsBussines.Get("ArzeshAfzoude");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _arzeshAfzoude = value;
                SettingsBussines.Save("ArzeshAfzoude", _arzeshAfzoude);
            }
        }

        private static string _tabdil = "";
        public static string Tabdil
        {
            get
            {
                if (!string.IsNullOrEmpty(_tabdil)) return _tabdil;
                var mem = SettingsBussines.Get("Tabdil");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _tabdil = value;
                SettingsBussines.Save("Tabdil", _tabdil);
            }
        }
    }
}
