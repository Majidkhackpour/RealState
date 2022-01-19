using System;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace Settings.Classes
{
    public class clsGlobalSetting
    {
        private static string _lastUser = "";
        private static string _hardDriveSerial = "";
        private static string _applicationVersion = "";

        public static async Task<string> GetLastUserAsync()
        {

            try
            {
                if (!string.IsNullOrEmpty(_lastUser)) return _lastUser;
                var mem = await SettingsBussines.GetAsync("LastUser");
                return mem == null ? "" : mem.Value;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return "";
        }
        public static async Task SetLastUserAsync(string value)
        {
            try
            {
                _lastUser = value;
                var sett = new SettingsBussines()
                {
                    Guid = Guid.NewGuid(),
                    Value = _lastUser,
                    Name = "LastUser"
                };
                await sett.SaveAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public static async Task<string> GetApplicationVersionAsync()
        {
            try
            {
                if (!string.IsNullOrEmpty(_applicationVersion)) return _applicationVersion;
                var mem = await SettingsBussines.GetAsync("AppVersion");
                return mem == null ? "" : mem.Value;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return "";
        }
        public static async Task SetApplicationVersionAsync(string value)
        {
            try
            {
                _applicationVersion = value;
                var sett = new SettingsBussines()
                {
                    Guid = Guid.NewGuid(),
                    Value = _applicationVersion,
                    Name = "AppVersion"
                };
                await sett.SaveAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public static async Task<string> GetHardDriveSerialAsync()
        {
            try
            {
                if (!string.IsNullOrEmpty(_hardDriveSerial)) return _hardDriveSerial;
                var mem = await SettingsBussines.GetAsync("U1001HS");
                return mem == null ? "" : mem.Value;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return "";
        }
        public static async Task SetHardDriveSerialAsync(string value)
        {
            try
            {
                _hardDriveSerial = value;
                var sett = new SettingsBussines()
                {
                    Guid = Guid.NewGuid(),
                    Value = _hardDriveSerial,
                    Name = "U1001HS"
                };
                await sett.SaveAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
