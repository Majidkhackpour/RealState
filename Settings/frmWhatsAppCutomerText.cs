using DevComponents.DotNetBar;
using EntityCache.Assistence;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Services;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Settings
{
    public partial class frmWhatsAppCutomerText : MetroForm
    {
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
        private void LoadWhatsApp()
        {
            try
            {
                var sett = SettingsBussines.Setting;

                txtText.Text = !string.IsNullOrEmpty(sett.Whatsapp.CustomerMessage)
                    ? sett.Whatsapp.CustomerMessage
                    : sett.Telegram.Text;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task SaveWhatsAppAsync()
        {
            try
            {
                SettingsBussines.Setting.Whatsapp.CustomerMessage = txtText.Text;
                await SettingsBussines.Setting.SaveAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmWhatsAppCutomerText() => InitializeComponent();

        private void btnType_Click(object sender, System.EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnCode_Click(object sender, System.EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnDocType_Click(object sender, System.EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnSide_Click(object sender, System.EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnConType_Click(object sender, System.EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnTarakom_Click(object sender, System.EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnAccType_Click(object sender, System.EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnTabaqeNo_Click(object sender, System.EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnRegion_Click(object sender, System.EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnTabaqeCount_Click(object sender, System.EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnSell_Click(object sender, System.EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnRoomCount_Click(object sender, System.EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnRahn_Click(object sender, System.EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnSaleSakht_Click(object sender, System.EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnAddress_Click(object sender, System.EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnFloorCover_Click(object sender, System.EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnMobile_Click(object sender, System.EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnView_Click(object sender, System.EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnEjare_Click(object sender, System.EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnTejari_Click(object sender, System.EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnKitchenService_Click(object sender, System.EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnMasahat_Click(object sender, System.EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnZirBana_Click(object sender, System.EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnDong_Click(object sender, System.EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnPricePerMeter_Click(object sender, System.EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnVahedPerTabaqe_Click(object sender, System.EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnHitting_Click(object sender, System.EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnParking_Click(object sender, System.EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnColling_Click(object sender, System.EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnEvelator_Click(object sender, System.EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnStore_Click(object sender, System.EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnBalcony_Click(object sender, System.EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void btnOtherOptions_Click(object sender, System.EventArgs e) => SetDataInTxt((ButtonX)sender, txtText);
        private void frmWhatsAppCutomerText_Load(object sender, EventArgs e) => LoadWhatsApp();
        private async void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                await SaveWhatsAppAsync();
                frmNotification.PublicInfo.ShowMessage("تنظیمات با موفقیت ثبت شد");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void frmWhatsAppCutomerText_KeyDown(object sender, KeyEventArgs e)
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
