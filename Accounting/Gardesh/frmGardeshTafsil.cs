using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;

namespace Accounting.Gardesh
{
    public partial class frmGardeshTafsil : MetroForm
    {
        private Guid _tafsilGuid;

        private async Task LoadDataAsync()
        {
            try
            {
                var list = await GardeshBussines.GetAllGardeshAsync(_tafsilGuid);
                GardeshBindingSource.DataSource = list?.OrderBy(q => q.DateM)?.ToSortableBindingList();
                _ = Task.Run(HilightGridAsync);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task HilightGridAsync()
        {
            try
            {
                Invoke(new MethodInvoker(() =>
                {
                    for (var i = 0; i < DGrid.RowCount; i++)
                    {
                        var debit = (decimal)DGrid[dgDebit.Index, i].Value;
                        var credit = (decimal)DGrid[dgCredit.Index, i].Value;

                        if (debit > credit)
                            DGrid.Rows[i].DefaultCellStyle.BackColor = Color.OrangeRed;
                        else if (credit > debit)
                            DGrid.Rows[i].DefaultCellStyle.BackColor = Color.PaleTurquoise;
                    }
                }));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmGardeshTafsil(Guid tafsilGuid)
        {
            InitializeComponent();
            _tafsilGuid = tafsilGuid;
        }

        private void DGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        => DGrid.Rows[e.RowIndex].Cells["dgRadif"].Value = e.RowIndex + 1;
        private async void frmGardeshTafsil_Load(object sender, EventArgs e) => await LoadDataAsync();
        private void frmGardeshTafsil_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
    }
}
