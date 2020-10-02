using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;

namespace Accounting
{
    public partial class frmShowAccounts : MetroForm
    {
        private async Task LoadPeoplesAsync(bool status, string search = "")
        {
            try
            {
                var list = await PeoplesBussines.GetAllAsync(search, Guid.Empty);
                peopleBindingSource.DataSource = list.Where(q => q.Status == status).ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmShowAccounts()
        {
            InitializeComponent();
        }

        private async void frmShowAccounts_Load(object sender, EventArgs e) => await LoadPeoplesAsync(true);

        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                await LoadPeoplesAsync(true, txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void DGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DGrid.Rows[e.RowIndex].Cells["dgRadif"].Value = e.RowIndex + 1;
        }

        private void frmShowAccounts_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Escape:
                        Close();
                        break;
                    case Keys.F:
                        if (e.Control) txtSearch.Focus();
                        break;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void btnGardeshHesab_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var frm = new frmGardeshHesab(guid, EnAccountingType.Peoples);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void DGrid_DoubleClick(object sender, EventArgs e)
        {
            btnGardeshHesab.PerformClick();
        }
    }
}
