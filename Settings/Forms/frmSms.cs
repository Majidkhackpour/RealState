using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Payamak.Panel;
using Services;

namespace Settings.Forms
{
    public partial class frmSms : MetroForm
    {
        private async Task LoadSmsAsync()
        {
            try
            {
                await FillCmbSmsAsync();

                if (!string.IsNullOrEmpty(Classes.Payamak.DefaultPanelGuid))
                {
                    var panel = SmsPanelsBussines.Get(Guid.Parse(Classes.Payamak.DefaultPanelGuid));
                    if (panel != null)
                        cmbPanel.Text = panel.Sender;
                }

                chbSendOwner.Checked = Classes.Payamak.IsSendToOwner.ParseToBoolean();
                txtOwnerText.Text = Classes.Payamak.OwnerText;
                chbSendSayer.Checked = Classes.Payamak.IsSendToSayer.ParseToBoolean();
                txtSayerText.Text = Classes.Payamak.SayerText;
                chbSendAfterMatch.Checked = Classes.Payamak.IsSendAfterMatch.ParseToBoolean();
                txtMatchTextRahn.Text = Classes.Payamak.SendMatchTextRahn;
                txtMatchTextKharid.Text = Classes.Payamak.SendMatchTextKharid;
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
        private void SaveSms()
        {
            try
            {
                Classes.Payamak.DefaultPanelGuid = cmbPanel.SelectedValue?.ToString();
                Classes.Payamak.IsSendToOwner = chbSendOwner.Checked.ToString();
                Classes.Payamak.OwnerText = txtOwnerText.Text;
                Classes.Payamak.IsSendToSayer = chbSendSayer.Checked.ToString();
                Classes.Payamak.SayerText = txtSayerText.Text;
                Classes.Payamak.IsSendAfterMatch = chbSendAfterMatch.Checked.ToString();
                Classes.Payamak.SendMatchTextRahn = txtMatchTextRahn.Text;
                Classes.Payamak.SendMatchTextKharid = txtMatchTextKharid.Text;
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
        private void btnFinish_Click(object sender, System.EventArgs e)
        {
            btnFinish.Enabled = false;
            try
            {
                SaveSms();
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
                var frm = new frmPanelMain();
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
        private void btnRahn_Region_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtMatchTextRahn);
        private void btnRahn_Rahn_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtMatchTextRahn);
        private void btnRahn_Ejare_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtMatchTextRahn);
        private void btnSayer_SayerName_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtSayerText);
        private void btnSayer_DateSh_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtSayerText);
        private void btnSayer_UserName_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtSayerText);
        private void btnKharid_SayerName_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtMatchTextKharid);
        private void btnKharid_DateSh_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtMatchTextKharid);
        private void btnKharid_Region_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtMatchTextKharid);
        private void btnKharid_Price_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender, txtMatchTextKharid);
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
    }
}
