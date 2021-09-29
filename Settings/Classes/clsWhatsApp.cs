using EntityCache.Bussines;

namespace Settings.Classes
{
    public class clsWhatsApp
    {
        private static string _apiCode = "";
        public static string ApiCode
        {
            get
            {
                if (!string.IsNullOrEmpty(_apiCode)) return _apiCode;
                var mem = SettingsBussines.Get("WhatsAppApiCode");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _apiCode = value;
                SettingsBussines.Save("WhatsAppApiCode", _apiCode);
            }
        }

        private static string _number = "";
        public static string Number
        {
            get
            {
                if (!string.IsNullOrEmpty(_number)) return _number;
                var mem = SettingsBussines.Get("WhatsAppNumber");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _number = value;
                SettingsBussines.Save("WhatsAppNumber", _number);
            }
        }

        private static string _cusMessage = "";
        public static string CustomerMessage
        {
            get
            {
                if (!string.IsNullOrEmpty(_cusMessage)) return _cusMessage;
                var mem = SettingsBussines.Get("WhatsApp_MessageForCustomer");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _cusMessage = value;
                SettingsBussines.Save("WhatsApp_MessageForCustomer", _cusMessage);
            }
        }

        private static string _mngMessage = "";
        public static string ManagerMessage
        {
            get
            {
                if (!string.IsNullOrEmpty(_mngMessage)) return _mngMessage;
                var mem = SettingsBussines.Get("WhatsApp_MessageForManager");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _mngMessage = value;
                SettingsBussines.Save("WhatsApp_MessageForManager", _mngMessage);
            }
        }
    }
}
