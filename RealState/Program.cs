using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using DataBaseUtilities;
using EntityCache.Assistence;
using Ertegha;
using Notification;
using Services;
using Settings;
using Settings.Classes;
using Settings.WorkingYear;
using User;

namespace RealState
{
    static class Program
    {
        private static bool isAdmin()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        [STAThread]
        static void Main()
        {

            //if (!isAdmin())
            //{
            //    MessageBox.Show("اجرا نمایید Run As Adminstrator لطفا برنامه را در حالت");
            //    return;
            //}
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var owner = new frmMain();

            var frmYear = new frmShowWorkingYears();
            if (frmYear.ShowDialog(owner) != DialogResult.OK) return;

            //Config Cache
            ClsCache.Init(AppSettings.DefaultConnectionString);

            clsErtegha.StartErtegha(AppSettings.DefaultConnectionString, owner);

            ClsCache.InserDefults();

            var color = Color.FromArgb(255, 192, 128);
            clsNotification.Init(color);

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
                    if (frm.ShowDialog(owner) != DialogResult.OK) return;
                    serialNumber = clsRegistery.GetRegistery("U1001ML");
                }

                if (string.IsNullOrEmpty(serialNumber))
                {
                    var frm = new SoftwareLock.frmClient(serialNumber, true);
                    if (frm.ShowDialog(owner) != DialogResult.OK) return;
                }

            }
            else
            {
                //10 Days Free
                var fDate = free.ParseToDate();
                if (fDate < DateTime.Now)
                {
                    //Expire Free Time
                    MessageBox.Show(owner, "مهلت استفاده 10 روزه رایگان شما از نرم افزار به اتمام رسیده است");
                    var frm = new SoftwareLock.frmClient("", false);
                    if (frm.ShowDialog(owner) != DialogResult.OK) return;
                }
            }


            var currentVersion = AccGlobalSettings.AppVersion.ParseToInt();
            var dbVersion = clsGlobalSetting.ApplicationVersion.ParseToInt();

            if (dbVersion <= 0)
            {
                dbVersion = currentVersion;
                clsGlobalSetting.ApplicationVersion = dbVersion.ToString();
            }

            if (currentVersion < dbVersion)
            {
                MessageBox.Show(owner, $"نسخه فایل اجرایی {currentVersion} و نسخه بانک اطلاعاتی {dbVersion} می باشد. \r\n" +
                                $"لطفا جهت بروزرسانی نسخه اجرایی خود، با تیم پشتیبانی تماس حاصل فرمایید");
                return;
            }

            if (currentVersion > dbVersion)
                clsGlobalSetting.ApplicationVersion = currentVersion.ToString();



            if (string.IsNullOrEmpty(clsEconomyUnit.EconomyName))
            {
                var frm = new frmEconomyUnit();
                if (frm.ShowDialog(owner) == DialogResult.Cancel) Application.Exit();
            }


            var splash = new frmSplashCircle();
            splash.ShowDialog(owner);


            var logForm = new frmLogin();
            if (logForm.ShowDialog(owner) != DialogResult.OK) return;

            SetVersionAccess();

            if (!VersionAccess.Building)
            {
                MessageBox.Show(owner,
                    "سریال نرم افزار شما، مجوز استفاده از نرم افزار را ندارد. لطفا جهت ارتقای نسخه نرم افزار خود اقدام نمایید");
                return;
            }

            var frmMain = new frmMain();
            frmMain.ShowDialog(owner);

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
                        case EnAppSerial.Building: VersionAccess.Building = true;
                            break;
                        case EnAppSerial.Sms: VersionAccess.Sms = true;
                            break;
                        case EnAppSerial.Advertise: VersionAccess.Advertise = true;
                            break;
                        case EnAppSerial.Telegram: VersionAccess.Telegram = true;
                            break;
                        case EnAppSerial.WhatsApp: VersionAccess.WhatsApp = true;
                            break;
                        case EnAppSerial.Excel: VersionAccess.Excel = true;
                            break;
                        case EnAppSerial.AutoBackUp: VersionAccess.AutoBackUp = true;
                            break;
                        case EnAppSerial.Accounting: VersionAccess.Accounting = true;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
