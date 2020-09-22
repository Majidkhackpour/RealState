using System;
using System.Windows.Forms;
using Services;
using Settings.Classes;

namespace Settings.SettingForms
{
    public partial class frmBackUpSetting : Form
    {
        private void SettData()
        {
            try
            {
                txtPath.Text = clsBackUp.BackUpPath;
                chbAuto.Checked = clsBackUp.IsAutoBackUp.ParseToBoolean();
                txtTime.Text = clsBackUp.BackUpDuration;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmBackUpSetting()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void frmBackUpSetting_Load(object sender, EventArgs e)
        {
            SettData();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                clsBackUp.BackUpPath = txtPath.Text;
                clsBackUp.BackUpDuration = txtTime.Text;
                clsBackUp.IsAutoBackUp = chbAuto.Checked.ToString();


                DialogResult = DialogResult.OK;
                Close();
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
                if (ff.ShowDialog() == DialogResult.OK)
                    txtPath.Text = ff.SelectedPath;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void chbAuto_CheckedChanged(object sender, EventArgs e)
        {
            txtTime.Enabled = chbAuto.Checked;
        }
    }
}
