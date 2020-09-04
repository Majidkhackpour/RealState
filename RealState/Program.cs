using System;
using System.Drawing;
using System.Security.Principal;
using System.Windows.Forms;
using DataBaseUtilities;
using EntityCache.Assistence;
using Ertegha;
using Notification;
using Services;
using Settings;
using Settings.Classes;
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


            //ConfigConnectionString
            var reg = clsRegistery.GetConnectionRegistery("BuildingCn");
            if (string.IsNullOrEmpty(reg.value))
            {
                var frm = new frmSetConnectionString(ENSource.Building, AppSettings.DefaultConnectionString);
                if (frm.ShowDialog() != DialogResult.OK) return;
            }


            //Config Cache
            ClsCache.Init(AppSettings.DefaultConnectionString);
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
                    if (frm.ShowDialog() != DialogResult.OK) return;
                    serialNumber = clsRegistery.GetRegistery("U1001ML");
                }

                if (string.IsNullOrEmpty(serialNumber))
                {
                    var frm = new SoftwareLock.frmClient(serialNumber, true);
                    if (frm.ShowDialog() != DialogResult.OK) return;
                }

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
                    if (frm.ShowDialog() != DialogResult.OK) return;
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
                MessageBox.Show($"نسخه فایل اجرایی {currentVersion} و نسخه بانک اطلاعاتی {dbVersion} می باشد. \r\n" +
                                $"لطفا جهت بروزرسانی نسخه اجرایی خود، با تیم پشتیبانی تماس حاصل فرمایید");
                return;
            }

            if (currentVersion > dbVersion)
                clsGlobalSetting.ApplicationVersion = currentVersion.ToString();



            if (string.IsNullOrEmpty(clsEconomyUnit.EconomyName))
            {
                var res = clsErtegha.StartErtegha();
                if (res.HasError)
                {
                    MessageBox.Show("خطا در بازسازی اطلاعات", "پیغام سیستم", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("بازسازی اطلاعات با موفقیت انجام شد", "پیغام سیستم", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                var frm = new frmEconomyUnit();
                if (frm.ShowDialog() == DialogResult.Cancel) Application.Exit();
            }

            var logForm = new frmLogin();
            if (logForm.ShowDialog() != DialogResult.OK) return;

            var frmMain = new frmMain();
            frmMain.ShowDialog();

        }
    }
}
