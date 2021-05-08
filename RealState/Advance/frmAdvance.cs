using System;
using MetroFramework.Forms;
using System.Windows.Forms;
using Services;

namespace RealState.Advance
{
    public partial class frmAdvance : MetroForm
    {
        public frmAdvance() => InitializeComponent();

        private void frmAdvance_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
        private void mnuResentToHost_Click(object sender, System.EventArgs e)
        {
            try
            {
                var frm = new frmResentToHost();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuSQL_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmRunScript();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
