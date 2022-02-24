using Persistence;
using RealState.LoginPanel;
using Services;
using Settings;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebHesabBussines;

namespace RealState
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            if (!Initializer.IsAdmin())
            {
                new frmRunAsAdmin().ShowDialog();
                return;
            }

            Utilities.NEVER_EAT_POISON_Disable_CertificateValidation();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            txtSetter.Switch_Language_To_Persian();
            var contextGuid = Guid.NewGuid().ToString();
            var client = clsRegistery.GetRegistery("X1001MR");
            Cache.IsClient = !string.IsNullOrEmpty(client) && client.ParseToBoolean();
            var res = frmLoginMain.GetInstance(contextGuid).Load_();
            if (res != DialogResult.OK)
            {
                Application.Exit();
                return;
            }

            if (WebCustomer.CheckCustomer() && WebCustomer.Customer.HardSerial != "265155255")
                _ = Task.Run(() => WebTelegramReporter.SendBuildingReport(WebCustomer.Customer.Guid, "ورود به نرم افزار"));

            var frmMain = new frmNewMain(contextGuid);
            frmMain.ShowDialog();
        }
    }
}
