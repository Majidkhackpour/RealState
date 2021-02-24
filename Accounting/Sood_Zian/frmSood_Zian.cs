using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MetroFramework.Forms;
using Print;
using Services;

namespace Accounting.Sood_Zian
{
    public partial class frmSood_Zian : MetroForm
    {
        private DateTime _date1, _date2;
        public frmSood_Zian(DateTime d1, DateTime d2)
        {
            InitializeComponent();
            _date1 = d1;
            _date2 = d2;
        }

        private void frmSood_Zian_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                var list = new List<clsSood_Zian>()
                {
                    new clsSood_Zian(_date1,_date2)
                };
                var cls = new ReportGenerator(StiType.Sood_Zian, EnPrintType.Pdf_A4)
                { Lst = new List<object>(list) };
                cls.PrintNew();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void frmSood_Zian_Load(object sender, System.EventArgs e)
        {
            try
            {
                var cls = new clsSood_Zian(_date1, _date2);

                lblCompanyName.Text = cls.CompanyName;
                lblDate1.Text = Calendar.MiladiToShamsi(_date1);
                lblDate2.Text = Calendar.MiladiToShamsi(_date2);

                txtBazarYab.Text = cls.TotalBazarYab.ToString("N0");
                txtBeforeTax.Text = cls.Sood_BeforeTax.ToString("N0");
                txtCommition.Text = cls.TotalCommition.ToString("N0");
                txtNakhales.Text = cls.Sood_Nakhales.ToString("N0");
                txtSood.Text = cls.Sood_Total.ToString("N0");
                txtTax.Text = cls.TotalTax.ToString("N0");

                lblBallance.Text = cls.Ballance;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
