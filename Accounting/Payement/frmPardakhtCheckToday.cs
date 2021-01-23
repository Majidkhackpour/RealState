using System;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;

namespace Accounting.Payement
{
    public partial class frmPardakhtCheckToday : MetroForm
    {
        public frmPardakhtCheckToday() => InitializeComponent();

        private async void frmPardakhtCheckToday_Load(object sender, System.EventArgs e)
        {
            try
            {
                var list = await PardakhtBussines.CheckReportAsync();
                pardakhtBindingSource.DataSource = list?.ToSortableBindingList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void frmPardakhtCheckToday_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape) Close();
        }
    }
}
