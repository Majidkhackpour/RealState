using DevComponents.DotNetBar;
using EntityCache.Assistence;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Services;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;

namespace Settings.Forms
{
    public partial class frmTelegram : MetroForm
    {
        private Control _focusedControl;
        private void LoadTelegram()
        {
            try
            {
                var sett = SettingsBussines.Setting;

                txtToken.Text = sett.Telegram.Token;
                txtChannel.Text = sett.Telegram.Channel;
                txtText1.Text = sett.Telegram.Text;
                txtText2.Text = sett.Telegram.Text2;
                txtText3.Text = sett.Telegram.Text3;
                txtText4.Text = sett.Telegram.Text4;
                txtText5.Text = sett.Telegram.Text5;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task SaveTelegramAsync()
        {
            try
            {
                SettingsBussines.Setting.Telegram.Token = txtToken.Text;
                SettingsBussines.Setting.Telegram.Channel = txtChannel.Text;
                SettingsBussines.Setting.Telegram.Text = txtText1.Text;
                SettingsBussines.Setting.Telegram.Text2 = txtText2.Text;
                SettingsBussines.Setting.Telegram.Text3 = txtText3.Text;
                SettingsBussines.Setting.Telegram.Text4 = txtText4.Text;
                SettingsBussines.Setting.Telegram.Text5 = txtText5.Text;

                await SettingsBussines.Setting.SaveAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void SetDataInTxt(ButtonX btn)
        {
            try
            {
                var insertText = btn.Text;
                if (!(_focusedControl is TextBox txt)) return;
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
        public frmTelegram() => InitializeComponent();
        private void frmTelegram_Load(object sender, System.EventArgs e) => LoadTelegram();
        private async void btnFinish_Click(object sender, System.EventArgs e)
        {
            btnFinish.Enabled = false;
            try
            {
                await SaveTelegramAsync();
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
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void frmTelegram_KeyDown(object sender, KeyEventArgs e)
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
        private void btnType_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender);
        private void btnCode_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender);
        private void btnDocType_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender);
        private void btnSide_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender);
        private void btnConType_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender);
        private void btnTarakom_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender);
        private void btnAccType_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender);
        private void btnTabaqeNo_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender);
        private void btnRegion_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender);
        private void btnTabaqeCount_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender);
        private void btnSell_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender);
        private void btnRoomCount_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender);
        private void btnRahn_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender);
        private void btnSaleSakht_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender);
        private void btnAddress_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender);
        private void btnFloorCover_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender);
        private void btnMobile_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender);
        private void btnView_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender);
        private void btnEjare_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender);
        private void btnTejari_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender);
        private void btnTell_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender);
        private void btnKitchenService_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender);
        private void btnMasahat_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender);
        private void btnChannel_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender);
        private void btnZirBana_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender);
        private void btnDong_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender);
        private void btnPricePerMeter_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender);
        private void btnVahedPerTabaqe_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender);
        private void btnHitting_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender);
        private void btnParking_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender);
        private void btnColling_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender);
        private void btnEvelator_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender);
        private void btnStore_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender);
        private void btnBalcony_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender);
        private void btnOtherOptions_Click(object sender, EventArgs e) => SetDataInTxt((ButtonX)sender);
        private void btnTelegramManager_Click(object sender, EventArgs e) => new frmTelegramManager().ShowDialog(this);
        private void txtText1_Enter(object sender, EventArgs e) => _focusedControl = txtText1;
        private void txtText2_Enter(object sender, EventArgs e) => _focusedControl = txtText2;
        private void txtText3_Enter(object sender, EventArgs e) => _focusedControl = txtText3;
        private void txtText4_Enter(object sender, EventArgs e) => _focusedControl = txtText4;
        private void txtText5_Enter(object sender, EventArgs e) => _focusedControl = txtText5;
    }
}
