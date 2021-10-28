using System;
using System.Windows.Forms;
using MetroFramework.Forms;
using Notification;
using Services;
using Settings.Classes;

namespace Settings.Forms
{
    public partial class frmPublicSetting : MetroForm
    {
        private void LoadGlobal()
        {
            try
            {
                txtBirthDayText.Text = clsGlobal.BirthDayText;
                txtSetArchive.Value = clsGlobal.SetArchive;
                chbPrintDesign.Checked = clsPrint.ShowDesign;
                chbPrintPreView.Checked = clsPrint.ShowPreview;
                txtImagePath.Text = clsGlobal.ImagePath;
                txtMediaPath.Text = clsGlobal.MediaPath;
                chbShowDialog.Checked = clsGlobal.ShowDialog;
                chbDeleteRequest.Checked = clsGlobal.DeleteRequest;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void SaveGlobal()
        {
            try
            {
                clsGlobal.BirthDayText = txtBirthDayText.Text;
                clsGlobal.SetArchive = (int)txtSetArchive.Value;
                clsPrint.ShowDesign = chbPrintDesign.Checked;
                clsPrint.ShowPreview = chbPrintPreView.Checked;
                clsGlobal.ImagePath = txtImagePath.Text;
                clsGlobal.MediaPath = txtMediaPath.Text;
                clsGlobal.ShowDialog = chbShowDialog.Checked;
                clsGlobal.DeleteRequest = chbDeleteRequest.Checked;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmPublicSetting() => InitializeComponent();
        private void frmPublicSetting_Load(object sender, EventArgs e) => LoadGlobal();
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void btnFinish_Click(object sender, EventArgs e)
        {
            btnFinish.Enabled = false;
            try
            {
                SaveGlobal();
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
        private void frmPublicSetting_KeyDown(object sender, KeyEventArgs e)
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
