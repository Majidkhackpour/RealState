using System;
using System.Windows.Forms;
using Advertise.Forms.Simcard;
using MetroFramework.Forms;
using Services;

namespace Advertise.Forms.AdvertiseLog
{
    public partial class frmLogFilter : MetroForm
    {
        public frmLogFilter() => InitializeComponent();
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void btnFinish_Click(object sender, System.EventArgs e)
        {
            try
            {
                DateTime? d1 = null, d2 = null;
                if (!string.IsNullOrEmpty(txtDate1.Text))
                    d1 = new DateTime(txtDate1.Miladi.Year, txtDate1.Miladi.Month, txtDate1.Miladi.Day, 0, 0, 0);
                if (!string.IsNullOrEmpty(txtDate2.Text))
                    d2 = new DateTime(txtDate2.Miladi.Year, txtDate2.Miladi.Month, txtDate2.Miladi.Day, 23, 59, 59);
                var frm = new frmAdvertiseLog(d1, d2, txtNumber.Text);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void frmLogFilter_Load(object sender, EventArgs e)
        {
            try
            {
                txtDate1.Text = txtDate2.Text = txtNumber.Text = "";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnSearchNumber_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmShowSimcard(true);
                if (frm.ShowDialog(this) == DialogResult.OK)
                    txtNumber.Text = frm.Number;
                frm.Dispose();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void frmLogFilter_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F5) btnFinish.PerformClick();
                else if (e.KeyCode == Keys.Escape) btnCancel.PerformClick();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
