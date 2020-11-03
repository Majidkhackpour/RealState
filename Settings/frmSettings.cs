using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Payamak.Panel;
using Services;
using Settings.Classes;

namespace Settings
{
    public partial class frmSettings : MetroForm
    {
        private void SetAccess()
        {
            try
            {
                pnlSandouq.Enabled = VersionAccess.Accounting;
                pnlSms.Enabled = VersionAccess.Sms;
                pnlTelegram.Enabled = VersionAccess.Telegram;
                chbAuto.Enabled = VersionAccess.AutoBackUp;
                txtTime.Enabled = VersionAccess.AutoBackUp;
                chbBackUpSms.Enabled = VersionAccess.Sms;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmSettings()
        {
            InitializeComponent();
            superTabControl1.SelectedTab = superTabItem5;
        }
        private void frmSettings_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Escape:
                        btnCancel.PerformClick();
                        break;
                }
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }
        }
        private async Task SetDataAsync()
        {
            try
            {
                SetAccess();
                await LoadEconomyAsync();
                LoadSandouqAsync();
                await LoadSmsAsync();
                LoadTelegram();
                LoadBackUp();
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

        #region Economy
        private async Task FillCmbEconomyAsync()
        {
            try
            {
                cmbEcType.Items.Add(EnEconomyType.Amlak.GetDisplay());
                cmbEcType.Items.Add(EnEconomyType.AnbouhSaz.GetDisplay());
                cmbEcType.Items.Add(EnEconomyType.Sayer.GetDisplay());

                var list = await StatesBussines.GetAllAsync();
                StateBindingSource.DataSource = list.Where(q => q.Status).OrderBy(q => q.Name);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task LoadEconomyAsync()
        {
            try
            {
                await FillCmbEconomyAsync();

                txtEcName.Text = clsEconomyUnit.EconomyName;
                txtEcMobile.Text = clsEconomyUnit.ManagerMobile;
                txtEcTell.Text = clsEconomyUnit.ManagerTell;
                txtEcFax.Text = clsEconomyUnit.ManagerFax;
                txtEcManagerName.Text = clsEconomyUnit.ManagerName;
                txtEcEmail.Text = clsEconomyUnit.ManagerEmail;
                txtEcAddress.Text = clsEconomyUnit.ManagerAddress;
                if (string.IsNullOrEmpty(clsEconomyUnit.EconomyType)) cmbEcType.SelectedIndex = 0;
                else
                    cmbEcType.Text = clsEconomyUnit.EconomyType;
                if (string.IsNullOrEmpty(clsEconomyUnit.EconomyState))
                    cmbEcState.SelectedIndex = 0;
                else
                    cmbEcState.SelectedValue = Guid.Parse(clsEconomyUnit.EconomyState);
                cmbEcCity.SelectedValue = Guid.Parse(clsEconomyUnit.EconomyCity);
                if (!string.IsNullOrEmpty(clsEconomyUnit.ManagerRegion))
                    cmbEcRegion.SelectedValue = Guid.Parse(clsEconomyUnit.ManagerRegion);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbEcCity.SelectedValue == null) return;
                var list = await RegionsBussines.GetAllAsync((Guid)cmbEcCity.SelectedValue);
                RegionBindingSource.DataSource = list.OrderBy(q => q.Name).ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void cmbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbEcState.SelectedValue == null) return;
                var list = await CitiesBussines.GetAllAsync((Guid)cmbEcState.SelectedValue);
                CityBindingSource.DataSource = list.OrderBy(q => q.Name).ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void SaveEconomy()
        {
            try
            {
                clsEconomyUnit.EconomyName = txtEcName.Text;
                clsEconomyUnit.ManagerMobile = txtEcMobile.Text;
                clsEconomyUnit.ManagerTell = txtEcTell.Text;
                clsEconomyUnit.ManagerFax = txtEcFax.Text;
                clsEconomyUnit.ManagerName = txtEcManagerName.Text;
                clsEconomyUnit.ManagerEmail = txtEcEmail.Text;
                clsEconomyUnit.ManagerRegion = cmbEcRegion.SelectedValue?.ToString() ?? Guid.NewGuid().ToString();
                clsEconomyUnit.ManagerAddress = txtEcAddress.Text;
                clsEconomyUnit.EconomyType = cmbEcType.Text;
                clsEconomyUnit.EconomyState = cmbEcState.SelectedValue.ToString();
                clsEconomyUnit.EconomyCity = cmbEcCity.SelectedValue.ToString();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        #endregion

        #region Sandouq
        private void LoadSandouqAsync()
        {
            try
            {
                FillCmbSandouq();

                txtSCode.Text = clsSandouq.NationalCode;
                txtSNatCode.Text = clsSandouq.NationalCode;
                txtSIdCode.Text = clsSandouq.IdCode;
                txtSArzesh.Text = clsSandouq.ArzeshAfzoude;
                txtSTabdil.Text = clsSandouq.Tabdil;
                cmbSType.Text = clsSandouq.EconomyCodeStatus;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void FillCmbSandouq()
        {
            try
            {
                cmbSType.Items.Add(EnEconomyCodeStatus.HasUserName.GetDisplay());
                cmbSType.Items.Add(EnEconomyCodeStatus.HasCode.GetDisplay());
                cmbSType.Items.Add(EnEconomyCodeStatus.DontHave.GetDisplay());

                cmbSType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void SaveSandouq()
        {
            try
            {
                clsSandouq.NationalCode = txtSCode.Text;
                clsSandouq.NationalCode = txtSNatCode.Text;
                clsSandouq.IdCode = txtSIdCode.Text;
                clsSandouq.ArzeshAfzoude = txtSArzesh.Text;
                clsSandouq.Tabdil = txtSTabdil.Text;
                clsSandouq.EconomyCodeStatus = cmbSType.Text;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        #endregion

        #region Sms
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
                Classes.Payamak.DefaultPanelGuid = cmbPanel.SelectedValue.ToString();
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
        private void btnOwner_OwnerName_Click(object sender, EventArgs e)
        => SetDataInTxt((ButtonX)sender, txtOwnerText);
        private void btnOwner_DateSh_Click(object sender, EventArgs e)
         => SetDataInTxt((ButtonX)sender, txtOwnerText);
        private void btnOwner_BuildingCode_Click(object sender, EventArgs e)
        => SetDataInTxt((ButtonX)sender, txtOwnerText);
        private void btnOwner_Region_Click(object sender, EventArgs e)
        => SetDataInTxt((ButtonX)sender, txtOwnerText);
        private void btnOwner_UserName_Click(object sender, EventArgs e)
        => SetDataInTxt((ButtonX)sender, txtOwnerText);
        private void btnSayer_SayerName_Click(object sender, EventArgs e)
            => SetDataInTxt((ButtonX)sender, txtSayerText);
        private void btnSayer_DateSh_Click(object sender, EventArgs e)
         => SetDataInTxt((ButtonX)sender, txtSayerText);
        private void btnSayer_UserName_Click(object sender, EventArgs e)
        => SetDataInTxt((ButtonX)sender, txtSayerText);
        private void btnRahn_SayerName_Click(object sender, EventArgs e)
        => SetDataInTxt((ButtonX)sender, txtMatchTextRahn);
        private void btnRahn_DateSh_Click(object sender, EventArgs e)
        => SetDataInTxt((ButtonX)sender, txtMatchTextRahn);
        private void btnRahn_Region_Click(object sender, EventArgs e)
        => SetDataInTxt((ButtonX)sender, txtMatchTextRahn);
        private void btnRahn_Rahn_Click(object sender, EventArgs e)
        => SetDataInTxt((ButtonX)sender, txtMatchTextRahn);
        private void btnRahn_Ejare_Click(object sender, EventArgs e)
        => SetDataInTxt((ButtonX)sender, txtMatchTextRahn);
        private void btnKharid_SayerName_Click(object sender, EventArgs e)
        => SetDataInTxt((ButtonX)sender, txtMatchTextKharid);
        private void btnKharid_DateSh_Click(object sender, EventArgs e)
        => SetDataInTxt((ButtonX)sender, txtMatchTextKharid);
        private void btnKharid_Region_Click(object sender, EventArgs e)
        => SetDataInTxt((ButtonX)sender, txtMatchTextKharid);
        private void btnKharid_Price_Click(object sender, EventArgs e)
        => SetDataInTxt((ButtonX)sender, txtMatchTextKharid);
        #endregion

        #region Telegram
        private void LoadTelegram()
        {
            try
            {
                txtToken.Text = clsTelegram.Token;
                txtChannel.Text = clsTelegram.Channel;
                txtText.Text = clsTelegram.Text;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void SaveTelegram()
        {
            try
            {
                clsTelegram.Token = txtToken.Text;
                clsTelegram.Channel = txtChannel.Text;
                clsTelegram.Text = txtText.Text;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnCode_Click(object sender, EventArgs e)
        => SetDataInTxt((ButtonX)sender, txtText);
        private void btnType_Click(object sender, EventArgs e)
        => SetDataInTxt((ButtonX)sender, txtText);
        private void btnConType_Click(object sender, EventArgs e)
        => SetDataInTxt((ButtonX)sender, txtText);
        private void btnAccType_Click(object sender, EventArgs e)
        => SetDataInTxt((ButtonX)sender, txtText);
        private void btnRegion_Click(object sender, EventArgs e)
        => SetDataInTxt((ButtonX)sender, txtText);
        private void btnSell_Click(object sender, EventArgs e)
        => SetDataInTxt((ButtonX)sender, txtText);
        private void btnRahn_Click(object sender, EventArgs e)
        => SetDataInTxt((ButtonX)sender, txtText);
        private void btnEjare_Click(object sender, EventArgs e)
        => SetDataInTxt((ButtonX)sender, txtText);
        private void btnMasahat_Click(object sender, EventArgs e)
        => SetDataInTxt((ButtonX)sender, txtText);
        private void btnZirBana_Click(object sender, EventArgs e)
        => SetDataInTxt((ButtonX)sender, txtText);
        private void btnDocType_Click(object sender, EventArgs e)
        => SetDataInTxt((ButtonX)sender, txtText);
        private void btnSide_Click(object sender, EventArgs e)
        => SetDataInTxt((ButtonX)sender, txtText);
        private void btnTarakom_Click(object sender, EventArgs e)
        => SetDataInTxt((ButtonX)sender, txtText);
        private void btnTabaqeNo_Click(object sender, EventArgs e)
        => SetDataInTxt((ButtonX)sender, txtText);
        private void btnTabaqeCount_Click(object sender, EventArgs e)
        => SetDataInTxt((ButtonX)sender, txtText);
        private void btnRoomCount_Click(object sender, EventArgs e)
        => SetDataInTxt((ButtonX)sender, txtText);
        private void btnSaleSakht_Click(object sender, EventArgs e)
        => SetDataInTxt((ButtonX)sender, txtText);
        private void btnTejari_Click(object sender, EventArgs e)
        => SetDataInTxt((ButtonX)sender, txtText);
        private void btnChannel_Click(object sender, EventArgs e)
         => SetDataInTxt((ButtonX)sender, txtText);
        #endregion

        #region BackUp
        private void LoadBackUp()
        {
            try
            {
                txtPath.Text = clsBackUp.BackUpPath;
                chbAuto.Checked = clsBackUp.IsAutoBackUp.ParseToBoolean();
                txtTime.Text = clsBackUp.BackUpDuration;
                chbBackUpSms.Checked = clsBackUp.BackUpSms.ParseToBoolean();
                chbOpen.Checked = clsBackUp.BackUpOpen.ParseToBoolean();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void SaveBackUp()
        {
            try
            {
                clsBackUp.BackUpPath = txtPath.Text;
                clsBackUp.BackUpDuration = txtTime.Text;
                clsBackUp.IsAutoBackUp = chbAuto.Checked.ToString();
                clsBackUp.BackUpSms = chbBackUpSms.Checked.ToString();
                clsBackUp.BackUpOpen = chbOpen.Checked.ToString();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnPath_Click(object sender, EventArgs e)
        {
            try
            {
                var ff = new FolderBrowserDialog();
                if (ff.ShowDialog(this) == DialogResult.OK)
                    txtPath.Text = ff.SelectedPath;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void chbAuto_CheckedChanged(object sender, EventArgs e) => txtTime.Enabled = chbAuto.Checked;
        #endregion


        private async void frmSettings_Load(object sender, EventArgs e) => await SetDataAsync();
        private async void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                SaveEconomy();
                SaveSandouq();
                SaveSms();
                SaveTelegram();
                SaveBackUp();

                frmNotification.PublicInfo.ShowMessage("تنظیمات با موفقیت ثبت شد");

                await SetDataAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
