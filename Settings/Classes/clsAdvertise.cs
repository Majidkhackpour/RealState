using System;
using EntityCache.Bussines;
using Services;

namespace Settings.Classes
{
    public static class clsAdvertise
    {
        private static string _sender = "";
        public static string Sender
        {
            get
            {
                if (!string.IsNullOrEmpty(_sender)) return _sender;
                var mem = SettingsBussines.Get("AdvSender");
                return mem?.Value ?? "";
            }
            set
            {
                _sender = value;
                SettingsBussines.Save("AdvSender", _sender);
            }
        }

        private static bool? _isGiveChat;
        public static bool IsGiveChat
        {
            get
            {
                if (_isGiveChat != null) return (bool)_isGiveChat;
                var mem = SettingsBussines.Get("IsGiveChat");
                return mem?.Value.ParseToBoolean() ?? false;
            }
            set
            {
                _isGiveChat = value;
                SettingsBussines.Save("IsGiveChat", _isGiveChat.ToString());
            }
        }

        private static int _divarUpdate = 0;
        public static int Divar_DayCountForUpdateState
        {
            get
            {
                if (_divarUpdate != 0) return _divarUpdate;
                var mem = SettingsBussines.Get("Divar_DayCountForUpdateState");
                return mem?.Value.ParseToInt() ?? 0;
            }
            set
            {
                _divarUpdate = value;
                SettingsBussines.Save("Divar_DayCountForUpdateState", _divarUpdate.ToString());
            }
        }

        private static int _divarPicCount = 0;
        public static int Divar_PicCountInPerAdv
        {
            get
            {
                if (_divarPicCount != 0) return _divarPicCount;
                var mem = SettingsBussines.Get("Divar_PicCountInPerAdv");
                return mem?.Value.ParseToInt() ?? 0;
            }
            set
            {
                _divarPicCount = value;
                SettingsBussines.Save("Divar_PicCountInPerAdv", _divarPicCount.ToString());
            }
        }

        private static int _divarDayCount = 0;
        public static int Divar_AdvCountInDay
        {
            get
            {
                if (_divarDayCount != 0) return _divarDayCount;
                var mem = SettingsBussines.Get("Divar_AdvCountInDay");
                return mem?.Value.ParseToInt() ?? 0;
            }
            set
            {
                _divarDayCount = value;
                SettingsBussines.Save("Divar_AdvCountInDay", _divarDayCount.ToString());
            }
        }

        private static int _divarMounthCount = 0;
        public static int Divar_AdvCountInMounth
        {
            get
            {
                if (_divarMounthCount != 0) return _divarMounthCount;
                var mem = SettingsBussines.Get("Divar_AdvCountInMounth");
                return mem?.Value.ParseToInt() ?? 0;
            }
            set
            {
                _divarMounthCount = value;
                SettingsBussines.Save("Divar_AdvCountInMounth", _divarMounthCount.ToString());
            }
        }

        private static int _sheypoorUpdate = 0;
        public static int Sheypoor_DayCountForUpdateState
        {
            get
            {
                if (_sheypoorUpdate != 0) return _sheypoorUpdate;
                var mem = SettingsBussines.Get("Sheypoor_DayCountForUpdateState");
                return mem?.Value.ParseToInt() ?? 0;
            }
            set
            {
                _sheypoorUpdate = value;
                SettingsBussines.Save("Sheypoor_DayCountForUpdateState", _sheypoorUpdate.ToString());
            }
        }

        private static int _sheypoorPicCount = 0;
        public static int Sheypoor_PicCountInPerAdv
        {
            get
            {
                if (_sheypoorPicCount != 0) return _sheypoorPicCount;
                var mem = SettingsBussines.Get("Sheypoor_PicCountInPerAdv");
                return mem?.Value.ParseToInt() ?? 0;
            }
            set
            {
                _sheypoorPicCount = value;
                SettingsBussines.Save("Sheypoor_PicCountInPerAdv", _sheypoorPicCount.ToString());
            }
        }

        private static int _sheypoorDayCount = 0;
        public static int Sheypoor_AdvCountInDay
        {
            get
            {
                if (_sheypoorDayCount != 0) return _sheypoorDayCount;
                var mem = SettingsBussines.Get("Sheypoor_AdvCountInDay");
                return mem?.Value.ParseToInt() ?? 0;
            }
            set
            {
                _sheypoorDayCount = value;
                SettingsBussines.Save("Sheypoor_AdvCountInDay", _sheypoorDayCount.ToString());
            }
        }

        private static int _sheypoorMounthCount = 0;
        public static int Sheypoor_AdvCountInMounth
        {
            get
            {
                if (_sheypoorMounthCount != 0) return _sheypoorMounthCount;
                var mem = SettingsBussines.Get("Sheypoor_AdvCountInMounth");
                return mem?.Value.ParseToInt() ?? 0;
            }
            set
            {
                _sheypoorMounthCount = value;
                SettingsBussines.Save("Sheypoor_AdvCountInMounth", _sheypoorMounthCount.ToString());
            }
        }

        private static bool? _isSilent;
        public static bool IsSilent
        {
            get
            {
                if (_isSilent != null) return (bool)_isSilent;
                var mem = SettingsBussines.Get("IsSilent");
                return mem?.Value.ParseToBoolean() ?? false;
            }
            set
            {
                _isSilent = value;
                SettingsBussines.Save("IsSilent", _isSilent.ToString());
            }
        }

        private static int _maxFileCount = 0;
        public static int MaxFileCount
        {
            get
            {
                if (_maxFileCount != 0) return _maxFileCount;
                var mem = SettingsBussines.Get("MaxFileCount");
                return mem?.Value.ParseToInt() ?? 0;
            }
            set
            {
                _maxFileCount = value;
                SettingsBussines.Save("MaxFileCount", _maxFileCount.ToString());
            }
        }

        private static bool? _isGiveFile;
        public static bool IsGiveFile
        {
            get
            {
                if (_isGiveFile != null) return (bool)_isGiveFile;
                var mem = SettingsBussines.Get("IsGiveFile");
                return mem?.Value.ParseToBoolean() ?? false;
            }
            set
            {
                _isGiveFile = value;
                SettingsBussines.Save("IsGiveFile", _isGiveFile.ToString());
            }
        }

        private static DateTime? _getFileDate;
        public static DateTime? GetFileDate
        {
            get
            {
                if (_getFileDate != null) return (DateTime)_getFileDate;
                var mem = SettingsBussines.Get("GetFileDate");
                if (mem == null || string.IsNullOrEmpty(mem.Value)) return null;
                return mem.Value.ParseToDate();
            }
            set
            {
                _getFileDate = value;
                SettingsBussines.Save("GetFileDate", _getFileDate.ToString());
            }
        }
    }
}
