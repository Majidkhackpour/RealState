using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces.Waiter;
using EntityCache.Bussines;
using EntityCache.Bussines.ReportBussines;
using MetroFramework.Forms;
using Services;

namespace Building
{
    public partial class frmMultiText : MetroForm
    {
        private BuildingReportBussines bu;
        public string TelegramText
        {
            get
            {
                if (rbtn1.Checked) return txtText1.Text;
                if (rbtn2.Checked) return txtText2.Text;
                if (rbtn3.Checked) return txtText3.Text;
                if (rbtn4.Checked) return txtText4.Text;
                if (rbtn5.Checked) return txtText5.Text;
                return "";
            }
        }

        private async Task SetTextAsync()
        {
            try
            {
                var t1 = SettingsBussines.Setting.Telegram.Text;
                var t2 = SettingsBussines.Setting.Telegram.Text2;
                var t3 = SettingsBussines.Setting.Telegram.Text3;
                var t4 = SettingsBussines.Setting.Telegram.Text4;
                var t5 = SettingsBussines.Setting.Telegram.Text5;

                if (!string.IsNullOrEmpty(t1))
                    t1 = await clsTelegramManager.GetTelegramTextAsync(bu, t1);
                if (!string.IsNullOrEmpty(t2))
                    t2 = await clsTelegramManager.GetTelegramTextAsync(bu, t2);
                if (!string.IsNullOrEmpty(t3))
                    t3 = await clsTelegramManager.GetTelegramTextAsync(bu, t3);
                if (!string.IsNullOrEmpty(t4))
                    t4 = await clsTelegramManager.GetTelegramTextAsync(bu, t4);
                if (!string.IsNullOrEmpty(t5))
                    t5 = await clsTelegramManager.GetTelegramTextAsync(bu, t5);

                BeginInvoke(new MethodInvoker(() =>
                {
                    txtText1.Text = t1;
                    txtText2.Text = t2;
                    txtText3.Text = t3;
                    txtText4.Text = t4;
                    txtText5.Text = t5;
                }));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmMultiText(BuildingReportBussines _bu)
        {
            InitializeComponent();
            rbtn1.Checked = true;
            ucHeader.Text = "انتخاب الگوی متن ارسال در تلگرام";
            bu = _bu;
        }

        private void btnFinish_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void frmMultiText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5) btnFinish.PerformClick();
            if (e.KeyCode == Keys.Escape) btnCancel.PerformClick();
        }
        private void frmMultiText_Load(object sender, EventArgs e) => _ = new Waiter("درحال پردازش ...", this, Task.Run(SetTextAsync));
    }
}
