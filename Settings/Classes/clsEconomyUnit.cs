using EntityCache.Bussines;

namespace Settings.Classes
{
    public class clsEconomyUnit
    {
        private static string _economyName = "";
        public static string EconomyName
        {
            get
            {
                if (!string.IsNullOrEmpty(_economyName)) return _economyName;
                var mem = SettingsBussines.Get("EconomyName");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _economyName = value;
                SettingsBussines.Save("EconomyName", _economyName);
            }
        }

        private static string _economyType = "";
        public static string EconomyType
        {
            get
            {
                if (!string.IsNullOrEmpty(_economyType)) return _economyType;
                var mem = SettingsBussines.Get("EconomyType");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _economyType = value;
                SettingsBussines.Save("EconomyType", _economyType);
            }
        }

        private static string _managerMobile = "";
        public static string ManagerMobile
        {
            get
            {
                if (!string.IsNullOrEmpty(_managerMobile)) return _managerMobile;
                var mem = SettingsBussines.Get("ManagerMobile");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _managerMobile = value;
                SettingsBussines.Save("ManagerMobile", _managerMobile);
            }
        }

        private static string _managerName = "";
        public static string ManagerName
        {
            get
            {
                if (!string.IsNullOrEmpty(_managerName)) return _managerName;
                var mem = SettingsBussines.Get("ManagerName");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _managerName = value;
                SettingsBussines.Save("ManagerName", _managerName);
            }
        }

        private static string _managerTell = "";
        public static string ManagerTell
        {
            get
            {
                if (!string.IsNullOrEmpty(_managerTell)) return _managerTell;
                var mem = SettingsBussines.Get("ManagerTell");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _managerTell = value;
                SettingsBussines.Save("ManagerTell", _managerTell);
            }
        }

        private static string _managerFax = "";
        public static string ManagerFax
        {
            get
            {
                if (!string.IsNullOrEmpty(_managerFax)) return _managerFax;
                var mem = SettingsBussines.Get("ManagerFax");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _managerFax = value;
                SettingsBussines.Save("ManagerFax", _managerFax);
            }
        }

        private static string _managerEmail = "";
        public static string ManagerEmail
        {
            get
            {
                if (!string.IsNullOrEmpty(_managerEmail)) return _managerEmail;
                var mem = SettingsBussines.Get("ManagerEmail");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _managerEmail = value;
                SettingsBussines.Save("ManagerEmail", _managerEmail);
            }
        }

        private static string _managerRegion = "";
        public static string ManagerRegion
        {
            get
            {
                if (!string.IsNullOrEmpty(_managerRegion)) return _managerRegion;
                var mem = SettingsBussines.Get("ManagerRegion");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _managerRegion = value;
                SettingsBussines.Save("ManagerRegion", _managerRegion);
            }
        }

        private static string _managerAddress = "";
        public static string ManagerAddress
        {
            get
            {
                if (!string.IsNullOrEmpty(_managerAddress)) return _managerAddress;
                var mem = SettingsBussines.Get("ManagerAddress");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _managerAddress = value;
                SettingsBussines.Save("ManagerAddress", _managerAddress);
            }
        }

        private static string _economyState = "";
        public static string EconomyState
        {
            get
            {
                if (!string.IsNullOrEmpty(_economyState)) return _economyState;
                var mem = SettingsBussines.Get("EconomyState");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _economyState = value;
                SettingsBussines.Save("EconomyState", _economyState);
            }
        }

        private static string _economyCity = "";
        public static string EconomyCity
        {
            get
            {
                if (!string.IsNullOrEmpty(_economyCity)) return _economyCity;
                var mem = SettingsBussines.Get("EconomyCity");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _economyCity = value;
                SettingsBussines.Save("EconomyCity", _economyCity);
            }
        }
    }
}
