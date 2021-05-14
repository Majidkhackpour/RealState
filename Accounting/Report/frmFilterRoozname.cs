using System;
using System.Windows.Forms;
using MetroFramework.Forms;
using Services;

namespace Accounting.Report
{
    public partial class frmFilterRoozname : MetroForm
    {
        private DateTime _d1, _d2;

        private void DrawUi()
        {
            try
            {
                if (rbtnToday.Checked || rbtnAll.Checked) txtDate1.Enabled = txtDate2.Enabled = false;
                else txtDate1.Enabled = txtDate2.Enabled = true;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmFilterRoozname()
        {
            InitializeComponent();
            ucHeader.Text = "فیلتر دفتر روزنامه";
            rbtnToday.Checked = true;
            DrawUi();
        }

        private void rbtnToday_CheckedChanged(object sender, EventArgs e) => DrawUi();
        private void rbtnBetween_CheckedChanged(object sender, EventArgs e) => DrawUi();
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void frmFilterRoozname_KeyDown(object sender, KeyEventArgs e)
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
        private void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbtnToday.Checked)
                {
                    _d1 = DateTime.Now;
                    _d2 = DateTime.Now;
                }
                else if (rbtnAll.Checked)
                {
                    _d1 = new DateTime(1990, 01, 01, 0, 0, 0);
                    _d2 = new DateTime(2030, 01, 01, 0, 0, 0);
                }
                else
                {
                    _d1 = Calendar.ShamsiToMiladi(txtDate1.Text);
                    _d2 = Calendar.ShamsiToMiladi(txtDate2.Text);
                }

                var frm = new frmRoozname(_d1, _d2);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void rbtnAll_CheckedChanged(object sender, EventArgs e) => DrawUi();
    }
}
