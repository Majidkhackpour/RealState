using DevComponents.DotNetBar;
using EntityCache.Assistence;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Payamak.Panel;
using Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Settings.Forms
{
    public partial class frmSms : MetroForm
    {
        private async Task LoadSmsAsync()
        {
            try
            {
                await FillCmbSmsAsync();
                var sett = SettingsBussines.Setting;
                if (sett.Sms.DefaultPanelGuid != Guid.Empty)
                {
                    var panel = await SmsPanelsBussines.GetAsync(sett.Sms.DefaultPanelGuid);
                    if (panel != null)
                        cmbPanel.Text = panel.Sender;
                }

                chbSendOwner.Checked = sett.Sms.IsSendToOwner;
                txtOwnerText.Text = sett.Sms.OwnerText;
                chbSendSayer.Checked = sett.Sms.IsSendToSayer;
                txtSayerText.Text = sett.Sms.SayerText;
                chbSendAfterMatch.Checked = sett.Sms.IsSendAfterMatch;
                txtMatchTextRahn.Text = sett.Sms.SendMatchText;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task FillCmbSmsAsync()
        {
            try
            {
                var list = await SmsPanelsBussines.GetAllAsync();
                defBindingSource.DataSource = list.Where(q => q.Status).ToSortableBindingList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task SaveSmsAsync()
        {
            try
            {
                if (cmbPanel.SelectedValue != null)
                    SettingsBussines.Setting.Sms.DefaultPanelGuid = (Guid)cmbPanel.SelectedValue;
                SettingsBussines.Setting.Sms.IsSendToOwner = chbSendOwner.Checked;
                SettingsBussines.Setting.Sms.OwnerText = txtOwnerText.Text;
                SettingsBussines.Setting.Sms.IsSendToSayer = chbSendSayer.Checked;
                SettingsBussines.Setting.Sms.SayerText = txtSayerText.Text;
                SettingsBussines.Setting.Sms.IsSendAfterMatch = chbSendAfterMatch.Checked;
                SettingsBussines.Setting.Sms.SendMatchText = txtMatchTextRahn.Text;

                await SettingsBussines.Setting.SaveAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void SetDataInTxt(ButtonX btn, TextBox txt)
        {
            try
            {
                var insertText = btn.Text;
                var selectionIndex = txt.SelectionStart;
                txt.Text = txt.Text.Insert(selectionIndex, insertText);
                txt.SelectionStart = selectionIndex + insertText.Length;
                txt.Focus();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmSms() => InitializeComponent();
        private async void btnFinish_Click(object sender, System.EventArgs e)
        {
            btnFinish.Enabled = false;
            try
            {
                await SaveSmsAsync();
                frmNotification.PublicInfo.ShowMessage("تنظیمات با موفقیت ثبت شد");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            finally
            {
                btnFinish.Enabled = true;
            }
        }
        private async void frmSms_Load(object sender, System.EventArgs e) => await LoadSmsAsync();
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private async void btnAddPanel_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmPanelMain(new SmsPanelsBussines(), false);
                if (frm.ShowDialog(this) == DialogResult.OK)
                    await LoadSmsAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnOwner_OwnerName_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtOwnerText);
        private void btnOwner_DateSh_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtOwnerText);
        private void btnOwner_BuildingCode_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtOwnerText);
        private void btnOwner_Region_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtOwnerText);
        private void btnOwner_UserName_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtOwnerText);
        private void btnRahn_SayerName_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtMatchTextRahn);
        private void btnRahn_DateSh_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtMatchTextRahn);
        private void btnRahn_Rahn_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtMatchTextRahn);
        private void btnRahn_Ejare_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtMatchTextRahn);
        private void btnSayer_SayerName_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtSayerText);
        private void btnSayer_DateSh_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtSayerText);
        private void btnSayer_UserName_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtSayerText);
        private void frmSms_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape) btnCancel.PerformClick();
                else if (e.KeyCode == Keys.F5) btnFinish.PerformClick();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnAddress_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtMatchTextRahn);
    }
}
