using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Assistence;
using Ertegha;
using Notification;
using Persistence;
using Services;
using Settings;
using Settings.Classes;
using Settings.WorkingYear;
using User;

namespace RealState
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            if (!IsAdmin())
            {
                new frmRunAsAdmin().ShowDialog();
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ClsCache.InitMapper();
            InitConfigs();

            var frmYear = new frmShowWorkingYears();
            if (frmYear.ShowDialog() != DialogResult.OK) return;

            SetDefults();

            var color = Color.FromArgb(255, 192, 128);
            clsNotification.Init(color);

            if (!CheckHardSerial()) return;

            

            //_ = Task.Run(CheckHardSerialWithServerAsync);


            if (!CheckVersion()) return;

            var splash = new frmSplashCircle();
            splash.ShowDialog();


            var logForm = new frmLogin();
            if (logForm.ShowDialog() != DialogResult.OK) return;

            SetVersionAccess();

            if (!VersionAccess.Building)
            {
                MessageBox.Show(
                    "سریال نرم افزار شما، مجوز استفاده از نرم افزار را ندارد. لطفا جهت ارتقای نسخه نرم افزار خود اقدام نمایید");
                return;
            }

            clsTemp.Init();

            var frmMain = new frmMain();
            frmMain.ShowDialog();
        }
        private static void SetVersionAccess()
        {
            try
            {
                var serial = clsRegistery.GetRegistery("U1001ML");

                if (string.IsNullOrEmpty(serial)) return;
                var serialList = new List<string>();
                var code = "";
                foreach (var item in serial.ToList())
                {
                    if (code.Length < 2)
                    {
                        code += item;
                        if (code.Length == 2)
                        {
                            serialList.Add(code);
                            code = "";
                        }
                    }
                    else
                    {
                        serialList.Add(code);
                        code = "";
                    }
                }


                foreach (var item in serialList)
                {
                    switch ((EnAppSerial)item.ParseToInt())
                    {
                        case EnAppSerial.Building:
                            VersionAccess.Building = true;
                            break;
                        case EnAppSerial.Sms:
                            VersionAccess.Sms = true;
                            break;
                        case EnAppSerial.Advertise:
                            VersionAccess.Advertise = true;
                            break;
                        case EnAppSerial.Telegram:
                            VersionAccess.Telegram = true;
                            Cache.IsSendToServer = true;
                            break;
                        case EnAppSerial.WhatsApp:
                            VersionAccess.WhatsApp = true;
                            break;
                        case EnAppSerial.Excel:
                            VersionAccess.Excel = true;
                            break;
                        case EnAppSerial.AutoBackUp:
                            VersionAccess.AutoBackUp = true;
                            break;
                        case EnAppSerial.Accounting:
                            VersionAccess.Accounting = true;
                            break;
                        case EnAppSerial.WebSite:
                            Cache.IsSendToServer = true;
                            break;
                        case EnAppSerial.MobileApp:
                            Cache.IsSendToServer = true;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private static bool CheckHardSerial()
        {
            try
            {
                var free = clsRegistery.GetRegistery("U1008FD");
                if (string.IsNullOrEmpty(free))
                {
                    //Register
                    var serialNumber = clsRegistery.GetRegistery("U1001ML");
                    var codeHdd = SoftwareLock.GenerateActivationCodeClient.ActivationCode();
                    var codeDb = clsGlobalSetting.HardDriveSerial;
                    if (string.IsNullOrEmpty(codeDb))
                    {
                        clsGlobalSetting.HardDriveSerial = codeHdd;
                        codeDb = clsGlobalSetting.HardDriveSerial;
                    }
                    if (codeDb != codeHdd)
                    {
                        var frm = new SoftwareLock.frmClient(serialNumber, true);
                        if (frm.ShowDialog() != DialogResult.OK) return false;
                        serialNumber = clsRegistery.GetRegistery("U1001ML");
                    }
                    if (string.IsNullOrEmpty(serialNumber))
                    {
                        var frm = new SoftwareLock.frmClient(serialNumber, true);
                        if (frm.ShowDialog() != DialogResult.OK) return false;
                    }

                    return true;
                }
                else
                {
                    //10 Days Free
                    var fDate = free.ParseToDate();
                    if (fDate < DateTime.Now)
                    {
                        //Expire Free Time
                        MessageBox.Show("مهلت استفاده 10 روزه رایگان شما از نرم افزار به اتمام رسیده است");
                        var frm = new SoftwareLock.frmClient("", false);
                        if (frm.ShowDialog() != DialogResult.OK) return false;
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return false;
            }
        }
        private static bool CheckVersion()
        {
            try
            {
                var currentVersion = AccGlobalSettings.AppVersion.ParseToInt();
                var dbVersion = clsGlobalSetting.ApplicationVersion.ParseToInt();

                if (dbVersion <= 0)
                {
                    dbVersion = currentVersion;
                    clsGlobalSetting.ApplicationVersion = dbVersion.ToString();
                }

                if (currentVersion < dbVersion)
                {
                    MessageBox.Show($"نسخه فایل اجرایی {currentVersion} و نسخه بانک اطلاعاتی {dbVersion} می باشد. \r\n" +
                                           $"لطفا جهت بروزرسانی نسخه اجرایی خود، با تیم پشتیبانی تماس حاصل فرمایید");
                    return false;
                }

                if (currentVersion > dbVersion)
                    clsGlobalSetting.ApplicationVersion = currentVersion.ToString();



                if (string.IsNullOrEmpty(clsEconomyUnit.EconomyName))
                {
                    var frm = new frmEconomyUnit();
                    if (frm.ShowDialog() == DialogResult.Cancel) Application.Exit();
                }

                return true;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return false;
            }
        }
        private static void InitConfigs()
        {
            try
            {
                ErrorHandler.AddHandler(Assembly.GetExecutingAssembly().GetName().Version.ToString(), ENSource.Building,
                    Application.StartupPath, clsRegistery.GetRegistery("U1001ML"));
                ClsCache.Init(AppSettings.DefaultConnectionString, clsGlobalSetting.HardDriveSerial);
                ErrorManager.Init(ENSource.Building, null);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private static void SetDefults()
        {
            try
            {
                clsErtegha.StartErtegha(AppSettings.DefaultConnectionString, null);
                ClsCache.InserDefults();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private static bool IsAdmin()
        {
            try
            {
                var identity = WindowsIdentity.GetCurrent();
                var principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return false;
            }
        }
        private static async Task CheckHardSerialWithServerAsync()
        {
            try
            {
                while (!AccGlobalSettings.IsAuthorize)
                {
                    var res = await Utilities.PingHostAsync();
                    if (res.HasError)
                    {
                        await Task.Delay(12000000);
                        continue;
                    }

                    AccGlobalSettings.IsAuthorize = SendRequest(clsGlobalSetting.HardDriveSerial);
                    if (AccGlobalSettings.IsAuthorize) continue;
                    Application.Exit();
                    return;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private static bool SendRequest(string hSerial)
        {
            try
            {
                return WebHesabBussines.WebCheckLuck.CheckHardSerial(hSerial);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return false;
            }
        }
    }
}
