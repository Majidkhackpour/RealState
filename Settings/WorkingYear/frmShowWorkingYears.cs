using System;
using System.Windows.Forms;
using MetroFramework.Forms;
using Services;

namespace Settings.WorkingYear
{
    public partial class frmShowWorkingYears : MetroForm
    {
        public frmShowWorkingYears()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, System.EventArgs e)
        {
            try
            {
                var frm = new frmWorkingYearMain();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
