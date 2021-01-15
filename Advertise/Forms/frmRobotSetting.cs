using System;
using System.Windows.Forms;
using MetroFramework.Forms;
using Services;
using Settings.Classes;

namespace Advertise.Forms
{
    public partial class frmRobotSetting : MetroForm
    {
        private void SettData()
        {
            try
            {
                chbSilent.Checked = clsAdvertise.IsSilent;
                chbChat.Checked = clsAdvertise.IsGiveChat;

                txtD_DayCount.Value = clsAdvertise.Divar_AdvCountInDay;
                txtD_MountCount.Value = clsAdvertise.Divar_AdvCountInMounth;
                txtD_PicCount.Value = clsAdvertise.Divar_PicCountInPerAdv;
                txtD_Update.Value = clsAdvertise.Divar_DayCountForUpdateState;

                txtSh_DayCount.Value = clsAdvertise.Sheypoor_AdvCountInDay;
                txtSh_MounthCount.Value = clsAdvertise.Sheypoor_AdvCountInMounth;
                txtSh_PicCount.Value = clsAdvertise.Sheypoor_PicCountInPerAdv;
                txtSh_Update.Value = clsAdvertise.Sheypoor_DayCountForUpdateState;

                if (string.IsNullOrEmpty(clsAdvertise.Sender)) rbtnRealState.Checked = true;
                else
                {
                    if (clsAdvertise.Sender == "املاک") rbtnRealState.Checked = true;
                    else rbtnShakhsi.Checked = true;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmRobotSetting()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void frmRobotSetting_Load(object sender, EventArgs e)
        {
            SettData();
        }
        private void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                clsAdvertise.IsSilent = chbSilent.Checked;
                clsAdvertise.IsGiveChat = chbChat.Checked;

                clsAdvertise.Divar_AdvCountInDay = (int)txtD_DayCount.Value;
                clsAdvertise.Divar_AdvCountInMounth = (int)txtD_MountCount.Value;
                clsAdvertise.Divar_PicCountInPerAdv = (int)txtD_PicCount.Value;
                clsAdvertise.Divar_DayCountForUpdateState = (int)txtD_Update.Value;

                clsAdvertise.Sheypoor_AdvCountInDay = (int)txtSh_DayCount.Value;
                clsAdvertise.Sheypoor_AdvCountInMounth = (int)txtSh_MounthCount.Value;
                clsAdvertise.Sheypoor_PicCountInPerAdv = (int)txtSh_PicCount.Value;
                clsAdvertise.Sheypoor_DayCountForUpdateState = (int)txtSh_Update.Value;

                clsAdvertise.Sender = rbtnRealState.Checked ? "املاک" : "شخصی";

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void frmRobotSetting_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        if (!btnFinish.Focused && !btnCancel.Focused)
                            SendKeys.Send("{Tab}");
                        break;
                    case Keys.F5:
                        btnFinish.PerformClick();
                        break;
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
    }
}
