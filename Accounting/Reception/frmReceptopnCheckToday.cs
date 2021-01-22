using System;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;

namespace Accounting.Reception
{
    public partial class frmReceptopnCheckToday : MetroForm
    {
        public frmReceptopnCheckToday() => InitializeComponent();

        private async void frmReceptopnCheckToday_Load(object sender, System.EventArgs e)
        {
            try
            {
                var list = await ReceptionBussines.CheckReportAsync();
                ReceptionBindingSource.DataSource = list?.ToSortableBindingList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void frmReceptopnCheckToday_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
    }
}
