using System;
using System.Windows.Forms;
using MetroFramework.Forms;
using Services;

namespace Settings.WorkingYear
{
    public partial class frmWorkingYearMain : MetroForm
    {
        public frmWorkingYearMain()
        {
            InitializeComponent();
        }

        private void btnFinish_Click(object sender, System.EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
