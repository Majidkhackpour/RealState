using DataBaseUtilities;
using EntityCache.Bussines;
using Persistence;
using Services;
using Settings;
using Settings.Classes;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebHesabBussines;

namespace RealState
{
    public class AutoBackUp
    {
        private static IWin32Window _owner;

        public static void Init(IWin32Window owner)
        {
            _owner = owner;
            _ = Task.Run(AutoBackUpAsync);
        }
        private static async Task AutoBackUpAsync()
        {
            try
            {
                await Task.Delay(2000);
                if (!SettingsBussines.Setting.BackUp.IsAutoBackUp || SettingsBussines.Setting.BackUp.BackUpDuration<= 0) return;
                var duration = SettingsBussines.Setting.BackUp.BackUpDuration;
                while (true)
                {
                    var list = await BackUpLogBussines.GetAllAsync();
                    var lastAutoBackUp = list.Where(q => q.Type == EnBackUpType.Auto).OrderBy(q => q.InsertedDate)
                        ?.FirstOrDefault();
                    var path = SettingsBussines.Setting.BackUp.BackUpPath;
                    if (lastAutoBackUp == null)
                    {
                        await BackUpAsync(path, true, EnBackUpType.Auto);
                        await Task.Delay(60000);
                        continue;
                    }
                    var du = (DateTime.Now - lastAutoBackUp.InsertedDate).Minutes;
                    if (du < duration)
                    {
                        await Task.Delay(60000);
                        continue;
                    }
                    await BackUpAsync(path, true, EnBackUpType.Auto);
                    await Task.Delay(1000);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public static async Task BackUpAsync(string path, bool isAuto, EnBackUpType type)
        {
            var line = 0;
            try
            {
                if (!isAuto)
                {
                    line = 1;
                    if (!SettingsBussines.Setting.BackUp.BackUpOpen) return;
                    line = 2;
                    path = Path.Combine(path, "AradBackUp");
                }

                line = 3;
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                line = 4;
                var file = Path.GetFileName(Assembly.GetEntryAssembly()?.Location)
                    ?.Replace(".exe", "__");
                line = 5;
                var d = Calendar.MiladiToShamsi(DateTime.Now).Replace("/", "_");
                line = 6;
                d += "__" + DateTime.Now.Hour + " - " + DateTime.Now.Minute;
                line = 7;
                file += d;
                line = 8;
                file = file.Replace(" ", "");
                line = 9;
                var newPath = Path.Combine(path, file + ".NPZ2");
                line = 10;
                await DataBase.BackUpStartAsync(_owner, AppSettings.DefaultConnectionString, ENSource.Building, type, newPath);
                line = 11;
                if (VersionAccess.AutoBackUp)
                {
                    line = 12;
                    await UploadBackUpAsync(newPath, file);
                }

                line = 13;
                if (isAuto) await SendBackUpSmsAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex, $"Error in Line:{line}");
            }
        }
        private static async Task SendBackUpSmsAsync()
        {
            try
            {
                if (SettingsBussines.Setting.BackUp.BackUpSms && VersionAccess.Sms)
                {
                    if (SettingsBussines.Setting.Sms.DefaultPanelGuid==Guid.Empty)
                        return;
                    var text = $"مدیریت محترم مجموعه {SettingsBussines.Setting.CompanyInfo.EconomyName ?? ""} \r\n" +
                               $"{SettingsBussines.Setting.CompanyInfo.ManagerName ?? ""} عزیز \r\n" +
                               $"در تاریخ {Calendar.MiladiToShamsi(DateTime.Now)} \r\n" +
                               $"و در ساعت {DateTime.Now.ToShortTimeString()} \r\n" +
                               $"پشتیبان گیری خودکار از داده ها انجام شد \r\n" +
                               $"باتشکر \r\n" +
                               $"گروه مهندسی آراد";

                    var panel = await SmsPanelsBussines.GetAsync(SettingsBussines.Setting.Sms.DefaultPanelGuid);
                    if (panel == null)
                        return;

                    var sApi = new Sms.Api(panel.API.Trim());


                    var result = sApi.Send(panel.Sender, SettingsBussines.Setting.CompanyInfo.ManagerMobile ?? "", text);

                    var smsLog = new SmsLogBussines()
                    {
                        Guid = Guid.NewGuid(),
                        UserGuid = UserBussines.CurrentUser?.Guid ?? Guid.Empty,
                        Cost = result.Cost,
                        Message = result.Message,
                        MessageId = result.Messageid,
                        Reciver = result.Receptor,
                        Sender = result.Sender,
                        StatusText = result.StatusText
                    };

                    await smsLog.SaveAsync();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private static async Task UploadBackUpAsync(string newPath, string fileName)
        {
            try
            {
                if (!File.Exists(newPath)) return;
                var path = Path.Combine(Application.StartupPath, $"{fileName}_{Cache.HardSerial}");
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                var inf = new FileInfo(newPath);
                var x = Path.Combine(path, $"{fileName}_{Cache.HardSerial}.{inf.Extension}");
                File.Copy(newPath, x);
                var res = await CompressFile.CompressFileInstance.CompressFileZipAsync(path, newPath);
                if (res.HasError || string.IsNullOrEmpty(res.value)) return;
                await WebBackUp.UploadFileAsync(res.value, fileName, Cache.HardSerial);
                File.Delete(res.value);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
