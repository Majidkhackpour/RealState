using System;
using System.Windows.Forms;
using MetroFramework.Forms;
using Notification;
using Services;

namespace Accounting.Sood_Zian
{
    public partial class frmFilterSood_Zian : MetroForm
    {
        public frmFilterSood_Zian() => InitializeComponent();

        private void btnCancel_Click(object sender, System.EventArgs e) => Close();
        private void frmFilterSood_Zian_KeyDown(object sender, KeyEventArgs e)
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
                var d1 = Calendar.ShamsiToMiladi(txtDate1.Text);
                var d2 = Calendar.ShamsiToMiladi(txtDate2.Text);

                var frm = new frmSood_Zian(d1, d2);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void frmFilterSood_Zian_Load(object sender, EventArgs e)
        {
            try
            {
                txtDate1.Text = Calendar.MiladiToShamsi(Calendar.StartDayOfPersianMonth());
                txtDate2.Text = Calendar.MiladiToShamsi(Calendar.EndDayOfPersianMonth());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
