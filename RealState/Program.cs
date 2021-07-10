using EntityCache.Assistence;
using Ertegha;
using Nito.AsyncEx;
using Notification;
using Persistence;
using Services;
using Settings;
using Settings.Classes;
using Settings.WorkingYear;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;
using RealState.LoginPanel;
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

            Utilities.NEVER_EAT_POISON_Disable_CertificateValidation();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var res = frmLoginMain.Instance.Load_();
            if (res != DialogResult.OK)
            {
                Application.Exit();
                return;
            }


            Cache.Path = Application.StartupPath;

            SetVersionAccess();

            if (!VersionAccess.Building)
            {
                MessageBox.Show(
                    "سریال نرم افزار شما، مجوز استفاده از نرم افزار را ندارد. لطفا جهت ارتقای نسخه نرم افزار خود اقدام نمایید");
                return;
            }

            clsTemp.Init();

            var frmMain = new frmNewMain();
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
                        case EnAppSerial.WebService:
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
    }
}
