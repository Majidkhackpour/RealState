using System;
using MetroFramework.Forms;
using System.Windows.Forms;
using Services;

namespace Print
{
    public partial class frmSetPrintSize : MetroForm
    {
        public EnPrintType PrintType { get; set; }
        public frmSetPrintSize()
        {
            InitializeComponent();
        }
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void frmSetPrintSize_KeyDown(object sender, KeyEventArgs e)
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
            PrintType = rbtnA4.Checked ? EnPrintType.A4 : EnPrintType.A5;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
