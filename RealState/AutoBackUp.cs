using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBaseUtilities;
using EntityCache.Bussines;
using Notification;
using Persistence;
using Services;
using Settings;
using Settings.Classes;
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
                if (string.IsNullOrEmpty(clsBackUp.IsAutoBackUp) || !clsBackUp.IsAutoBackUp.ParseToBoolean() ||
                    clsBackUp.BackUpDuration.ParseToInt() <= 0) return;
                var duration = clsBackUp.BackUpDuration.ParseToInt();
                while (true)
                {
                    var list = await BackUpLogBussines.GetAllAsync();
                    var lastAutoBackUp = list.Where(q => q.Type == EnBackUpType.Auto).OrderBy(q => q.InsertedDate)
                        ?.FirstOrDefault();
                    var path = clsBackUp.BackUpPath;
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
            try
            {
                if (!isAuto)
                {
                    if (string.IsNullOrEmpty(clsBackUp.BackUpOpen) || !clsBackUp.BackUpOpen.ParseToBoolean()) return;
                    path = Path.Combine(path, "AradBackUp");
                }

                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                var file = Path.GetFileName(Assembly.GetEntryAssembly()?.Location)
                    ?.Replace(".exe", "__");
                var d = Calendar.MiladiToShamsi(DateTime.Now).Replace("/", "_");
                d += "__" + DateTime.Now.Hour + " - " + DateTime.Now.Minute;
                file += d;
                file = file.Replace(" ", "");
                var newPath = Path.Combine(path, file + ".NPZ2");
                await DataBase.BackUpStartAsync(_owner, AppSettings.DefaultConnectionString, ENSource.Building, type, newPath);
                if (VersionAccess.AutoBackUp)
                    await UploadBackUpAsync(newPath, file);
                if (isAuto) await SendBackUpSmsAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private static async Task SendBackUpSmsAsync()
        {
            try
            {
                if (!string.IsNullOrEmpty(clsBackUp.BackUpSms) && clsBackUp.BackUpSms.ParseToBoolean() &&
                    VersionAccess.Sms)
                {
                    if (string.IsNullOrEmpty(Settings.Classes.Payamak.DefaultPanelGuid))
                        return;
                    var text = $"مدیریت محترم مجموعه {clsEconomyUnit.EconomyName ?? ""} \r\n" +
                               $"{clsEconomyUnit.ManagerName ?? ""} عزیز \r\n" +
                               $"در تاریخ {Calendar.MiladiToShamsi(DateTime.Now)} \r\n" +
                               $"و در ساعت {DateTime.Now.ToShortTimeString()} \r\n" +
                               $"پشتیبان گیری خودکار از داده ها انجام شد \r\n" +
                               $"باتشکر \r\n" +
                               $"گروه مهندسی آراد";

                    var panel = SmsPanelsBussines.Get(Guid.Parse(Settings.Classes.Payamak.DefaultPanelGuid));
                    if (panel == null)
                        return;

                    var sApi = new Sms.Api(panel.API.Trim());


                    var result = sApi.Send(panel.Sender, clsEconomyUnit.ManagerMobile ?? "", text);

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
