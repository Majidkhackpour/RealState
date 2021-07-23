using System;
using MetroFramework.Forms;
using System.Windows.Forms;
using Services;

namespace Print
{
    public partial class frmSetPrintSize : MetroForm
    {
        public EnPrintType _PrintType { get; set; }
        public frmSetPrintSize(bool isHasExcel = true)
        {
            InitializeComponent();
            if (!isHasExcel) radioButton1.Enabled = false;
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
        private void SetAccess()
        {
            try
            {
                pictureBox2.Visible = VersionAccess.Excel;
                radioButton1.Visible = VersionAccess.Excel;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (rbtnA4.Checked) _PrintType = EnPrintType.Pdf_A4;
            else if (rbtnA5.Checked) _PrintType = EnPrintType.Pdf_A5;
            else _PrintType = EnPrintType.Excel;


            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
