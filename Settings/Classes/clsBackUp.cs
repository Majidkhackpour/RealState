﻿using EntityCache.Bussines;

namespace Settings.Classes
{
    public static class clsBackUp
    {
        private static string _backUpPath = "";
        public static string BackUpPath
        {
            get
            {
                if (!string.IsNullOrEmpty(_backUpPath)) return _backUpPath;
                var mem = SettingsBussines.Get("BackUpPath");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _backUpPath = value;
                SettingsBussines.Save("BackUpPath", _backUpPath);
            }
        }

        private static string _backUpDuration = "";
        public static string BackUpDuration
        {
            get
            {
                if (!string.IsNullOrEmpty(_backUpDuration)) return _backUpDuration;
                var mem = SettingsBussines.Get("BackUpDuration");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _backUpDuration = value;
                SettingsBussines.Save("BackUpDuration", _backUpDuration);
            }
        }

        private static string _isAutoBackUp = "";
        public static string IsAutoBackUp
        {
            get
            {
                if (!string.IsNullOrEmpty(_isAutoBackUp)) return _isAutoBackUp;
                var mem = SettingsBussines.Get("IsAutoBackUp");
                return mem == null ? "" : mem.Value;
            }
            set
            {
                _isAutoBackUp = value;
                SettingsBussines.Save("IsAutoBackUp", _isAutoBackUp);
            }
        }
    }
}
